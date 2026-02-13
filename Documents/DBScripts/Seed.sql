GO
SET IDENTITY_INSERT [dbo].[Plans] ON 
GO
INSERT [dbo].[Plans] ([PlanId], [Name], [Description], [Price], [Currency], [JobsQuota], [IsActive], [CreatedDate], [UpdatedDate]) VALUES (1, N'Standard', N'<ul>
<li>Upto 250 character job description</li>
<li>1 job location</li>
<li>200 applies</li>
<li>Applies expiry 30 days</li>
</ul>', CAST(400.00 AS Decimal(18, 2)), N'INR', 4, 1, CAST(N'2015-02-12T00:00:00.000' AS DateTime), CAST(N'2015-02-12T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Plans] ([PlanId], [Name], [Description], [Price], [Currency], [JobsQuota], [IsActive], [CreatedDate], [UpdatedDate]) VALUES (2, N'Classified', N'<ul>
<li>Upto 250 character job description</li>
<li>1 job location</li>
<li>200 applies</li>
<li>Applies expiry 30 days</li>
<li>Jobseeker contact details are visible</li>
</ul>', CAST(850.00 AS Decimal(18, 2)), N'INR', 10, 1, CAST(N'2025-02-22T07:09:14.377' AS DateTime), CAST(N'2015-02-12T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Plans] ([PlanId], [Name], [Description], [Price], [Currency], [JobsQuota], [IsActive], [CreatedDate], [UpdatedDate]) VALUES (3, N'Premium', N'<ul>
<li>Upto 250 character job description</li>
<li>1 job location</li>
<li>200 applies</li>
<li>Applies expiry 30 days</li>
<li>Jobseeker contact details are visible</li>
<li>Boost on Job Search Page</li>
<li>Job Branding</li>
</ul>', CAST(1850.00 AS Decimal(18, 2)), N'INR', 25, 1, CAST(N'2025-02-22T00:00:00.000' AS DateTime), CAST(N'2025-02-22T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Plans] OFF
GO
SET IDENTITY_INSERT [dbo].[Subscriptions] ON 
GO
INSERT [dbo].[Subscriptions] ([SubscriptionId], [EmployerId], [PlanId], [JobsQuota], [ExpiryDate], [CreatedDate]) VALUES (1, 1, 1, 20, CAST(N'2025-05-08T12:00:02.523' AS DateTime), CAST(N'2025-04-08T12:00:02.760' AS DateTime))
GO
INSERT [dbo].[Subscriptions] ([SubscriptionId], [EmployerId], [PlanId], [JobsQuota], [ExpiryDate], [CreatedDate]) VALUES (2, 1, 2, 30, CAST(N'2025-05-08T12:00:43.383' AS DateTime), CAST(N'2025-04-08T12:00:43.383' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Subscriptions] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Email], [PhoneNumber], [Password], [CreatedDate], [IsActive]) VALUES (1, N'Admin', N'Kumar', N'admin@gmail.com', N'9876543210', N'$2a$11$f1jvhcWCRJOh58UktaKCFuFcNzVa9ZEzTQhjdRRMje9DwplWtGZpe', CAST(N'2024-08-29T11:43:19.500' AS DateTime), 1)
GO
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Email], [PhoneNumber], [Password], [CreatedDate], [IsActive]) VALUES (2, N'Jobseeker', N'Kumar', N'jobseeker@gmail.com', N'9876543211', N'$2a$11$f6Psc4ksmU5LfLPG53yZLOn7FbOBXBGdcvBiH9bU65Xo.BmLcSASm', CAST(N'2024-08-29T13:01:42.253' AS DateTime), 1)
GO
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [Email], [PhoneNumber], [Password], [CreatedDate], [IsActive]) VALUES (3, N'Employer', N'Kumar', N'employer@gmail.com', N'9876543210', N'$2a$11$gn78kIqTx4A2i3kiPTac9.QCn57qEDQtlg7rwyw.LKYRht/2ZLY0W', CAST(N'2024-12-25T18:22:35.353' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName], [Description]) VALUES (1, N'Admin', N'Admin')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName], [Description]) VALUES (2, N'Jobseeker', N'Jobseeker')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName], [Description]) VALUES (3, N'Employer', N'Employer')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (1, 1)
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (2, 2)
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (3, 3)
GO
SET IDENTITY_INSERT [dbo].[UserProfiles] ON 
GO
INSERT [dbo].[UserProfiles] ([ProfileId], [UserId], [ResumePath], [ProfileSummary], [ExperienceYears], [Skills], [Education], [CurrentLocation], [PreferredLocation]) VALUES (1, 2, NULL, N'Software Engineer', 5, N'C#, .NET', N'MCA', N'Noida', N'Noida')
GO
SET IDENTITY_INSERT [dbo].[UserProfiles] OFF
GO
SET IDENTITY_INSERT [dbo].[Employers] ON 
GO
INSERT [dbo].[Employers] ([EmployerId], [CompanyName], [ContactPerson], [ContactEmail], [ContactPhone], [CompanyWebsite], [CompanyLocation], [CompanySize], [Industry], [CompanyLogo]) VALUES (1, N'IBM', N'Mohan Kumar', N'mohan@ibm.com', N'9876543210', N'www.ibm.com', N'Pune', 100000, N'IT', N'/employer/ibm.png')
GO
INSERT [dbo].[Employers] ([EmployerId], [CompanyName], [ContactPerson], [ContactEmail], [ContactPhone], [CompanyWebsite], [CompanyLocation], [CompanySize], [Industry], [CompanyLogo]) VALUES (2, N'TCS', N'Ratan Kumar', N'ratan@tcs.com', N'9876543210', N'www.tcs.com', N'Pune', 100000, N'IT', N'/employer/ibm.png')
GO
SET IDENTITY_INSERT [dbo].[Employers] OFF
GO
SET IDENTITY_INSERT [dbo].[EmployerUsers] ON 
GO
INSERT [dbo].[EmployerUsers] ([EmployerUserId], [EmployerId], [UserId], [Permissions]) VALUES (1, 1, 3, N'write')
GO
SET IDENTITY_INSERT [dbo].[EmployerUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[Jobs] ON 
GO
INSERT [dbo].[Jobs] ([JobId], [EmployerId], [JobTitle], [JobDescription], [Location], [JobType], [MinExperience], [MaxExperience], [MinSalary], [MaxSalary], [Currency], [Skills], [PostedDate], [ExpiryDate], [Status], [IsActive], [Url]) VALUES (2, 1, N'Software Engineer', N'<ul><li><strong>5+ years of professional experience</strong> in .NET development using C# and ASP.NET (MVC, Web API). </li><li>Hands-on experience with <strong>OutSystems Low-Code platform</strong>, including knowledge of Service Studio and Integration Studio. </li><li>Strong understanding of <strong>Object-Oriented Programming (OOP)</strong> and <strong>SOLID principles</strong>. </li><li>Proficiency with <strong>front-end technologies</strong> such as HTML5, CSS3, JavaScript, and modern frameworks (React or Angular or Vue.js). </li><li>Experience with <strong>RESTful APIs</strong> and <strong>GraphQL </strong>integration. </li><li>Familiarity with <strong>Azure cloud services</strong> including Functions, App Services, and Storage. </li><li>Knowledge of <strong>Relational Databases</strong> like SQL Server and <strong>Entity Framework</strong> or other ORM tools. </li><li>Experience in <strong>Agile/Scrum</strong> development environments. </li><li>Exposure to <strong>Microservices architecture</strong> </li><li>Strong problem-solving skills and ability to work collaboratively in a team environment. </li><li>Excellent communication skills, both verbal and written. </li></ul>', N'Pune', N'FullTime', 1, 3, 300000, 500000, N'INR', N'C#, .NET, ASP.NET Core', CAST(N'2024-12-12T00:00:00.000' AS DateTime), CAST(N'2025-05-31T00:00:00.000' AS DateTime), N'Active', 1, N'software-engineer-1')
GO
INSERT [dbo].[Jobs] ([JobId], [EmployerId], [JobTitle], [JobDescription], [Location], [JobType], [MinExperience], [MaxExperience], [MinSalary], [MaxSalary], [Currency], [Skills], [PostedDate], [ExpiryDate], [Status], [IsActive], [Url]) VALUES (3, 1, N'Tech Lead', N'<ul><li><strong>5+ years of professional experience</strong> in .NET development using C# and ASP.NET (MVC, Web API). </li><li>Hands-on experience with <strong>OutSystems Low-Code platform</strong>, including knowledge of Service Studio and Integration Studio. </li><li>Strong understanding of <strong>Object-Oriented Programming (OOP)</strong> and <strong>SOLID principles</strong>. </li><li>Proficiency with <strong>front-end technologies</strong> such as HTML5, CSS3, JavaScript, and modern frameworks (React or Angular or Vue.js). </li><li>Experience with <strong>RESTful APIs</strong> and <strong>GraphQL </strong>integration. </li><li>Familiarity with <strong>Azure cloud services</strong> including Functions, App Services, and Storage. </li><li>Knowledge of <strong>Relational Databases</strong> like SQL Server and <strong>Entity Framework</strong> or other ORM tools. </li><li>Experience in <strong>Agile/Scrum</strong> development environments. </li><li>Exposure to <strong>Microservices architecture</strong> </li><li>Strong problem-solving skills and ability to work collaboratively in a team environment. </li><li>Excellent communication skills, both verbal and written. </li></ul>', N'Mumbai', N'FullTime', 2, 5, 500000, 1000000, N'INR', N'C#, .NET, ASP.NET Core', CAST(N'2024-12-12T00:00:00.000' AS DateTime), CAST(N'2025-06-19T00:00:00.000' AS DateTime), N'Active', 1, N'tech-lead-1')
GO
SET IDENTITY_INSERT [dbo].[Jobs] OFF
GO
SET IDENTITY_INSERT [dbo].[PublishJobHistories] ON 
GO
INSERT [dbo].[PublishJobHistories] ([HistoryId], [SubscriptionId], [EmployerId], [PublishDate], [Remarks]) VALUES (1, 1, 1, CAST(N'2025-04-08T11:58:41.267' AS DateTime), N'Payment successful, subscription updated.')
GO
INSERT [dbo].[PublishJobHistories] ([HistoryId], [SubscriptionId], [EmployerId], [PublishDate], [Remarks]) VALUES (2, 2, 1, CAST(N'2025-04-08T11:59:39.353' AS DateTime), N'Payment successful, subscription created.')
GO
INSERT [dbo].[PublishJobHistories] ([HistoryId], [SubscriptionId], [EmployerId], [PublishDate], [Remarks]) VALUES (3, 1, 1, CAST(N'2025-04-08T12:00:05.103' AS DateTime), N'Payment successful, subscription updated.')
GO
INSERT [dbo].[PublishJobHistories] ([HistoryId], [SubscriptionId], [EmployerId], [PublishDate], [Remarks]) VALUES (4, 2, 1, CAST(N'2025-04-08T12:00:12.147' AS DateTime), N'Payment successful, subscription updated.')
GO
INSERT [dbo].[PublishJobHistories] ([HistoryId], [SubscriptionId], [EmployerId], [PublishDate], [Remarks]) VALUES (5, 2, 1, CAST(N'2025-04-08T12:00:43.413' AS DateTime), N'Payment successful, subscription updated.')
GO
SET IDENTITY_INSERT [dbo].[PublishJobHistories] OFF
GO
