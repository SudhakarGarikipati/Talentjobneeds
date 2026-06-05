using JobNeedsWebApp.HttpClients;
using JobNeedsWebApp.Middleware;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Http.Resilience; // Add this using directive
using Polly;
using Polly.Fallback;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        
        builder.Services.AddTransient<GlobalExceptionMiddleware>();

        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.Name = "JobNeedsAuthCookie";
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.LogoutPath = "/Account/Logout";
                options.SlidingExpiration = true;
            });

        builder.Services.AddHttpClient("AuthHttpClient", client =>
        {
            client.BaseAddress = new Uri(builder.Configuration["APIAddress"]);
            client.Timeout = TimeSpan.FromSeconds(30);
        });

        // Configure HttpClient with base address and timeout
        builder.Services.AddHttpClient("HttpClient", client =>
        {
            client.BaseAddress = new Uri(builder.Configuration["APIAddress"]);
            client.Timeout = TimeSpan.FromMinutes(3);
        })
        .AddHttpMessageHandler<ApiTokenHandler>() // Add the custom message handler for token management
        .AddResilienceHandler("my-pipeline", pipeline =>
        {
            // ⏳ TIMEOUT   
            pipeline.AddTimeout(new HttpTimeoutStrategyOptions
            {
                OnTimeout = args =>
                {
                    Console.WriteLine($"Request timed out. Waiting {args.Timeout}.");
                    return ValueTask.CompletedTask;
                },
                Timeout = TimeSpan.FromSeconds(40)
            });

            // 🔁 RETRY    
            pipeline.AddRetry(new HttpRetryStrategyOptions
            {
                MaxRetryAttempts = 3,
                Delay = TimeSpan.FromSeconds(2),
                BackoffType = DelayBackoffType.Exponential
            });

            // ⚡ CIRCUIT BREAKER
            pipeline.AddCircuitBreaker(new HttpCircuitBreakerStrategyOptions
            {
                FailureRatio = 0.5,
                MinimumThroughput = 10,
                BreakDuration = TimeSpan.FromSeconds(30)
            });
        });
       
        builder.Services.AddTransient<ApiTokenHandler>();
        builder.Services.AddHttpContextAccessor();

        // Register AuthHttpClient as a scoped service
        builder.Services.AddScoped(sp =>
        {
            var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
            var client = httpClientFactory.CreateClient("AuthHttpClient");
            return new AuthHttpClient(client);
        });

        builder.Services.AddScoped(sp =>
        {
            var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
            var client = httpClientFactory.CreateClient("HttpClient");
            return new JobsHttpClient(client);
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            //app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseMiddleware<GlobalExceptionMiddleware>();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapStaticAssets();

        app.UseStaticFiles();

        app.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                  );

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }

    
}