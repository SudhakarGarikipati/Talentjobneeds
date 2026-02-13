/****** Object:  Table [dbo].[Admins]    Script Date: 08-04-2025 17:33:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[AdminId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AdminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditLogs]    Script Date: 08-04-2025 17:33:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditLogs](
	[AuditLogId] [bigint] IDENTITY(1,1) NOT NULL,
	[TableName] [varchar](255) NOT NULL,
	[Operation] [varchar](50) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[OperationDate] [datetime] NULL,
	[OldValue] [text] NULL,
	[NewValue] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[AuditLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
-- /****** Object:  Table [dbo].[CartItems]    Script Date: 08-04-2025 17:33:07 ******/
-- SET ANSI_NULLS ON
-- GO
-- SET QUOTED_IDENTIFIER ON
-- GO
-- CREATE TABLE [dbo].[CartItems](
	-- [Id] [int] IDENTITY(1,1) NOT NULL,
	-- [PlanId] [int] NOT NULL,
	-- [UnitPrice] [decimal](18, 2) NOT NULL,
	-- [Quantity] [int] NOT NULL,
	-- [CartId] [bigint] NOT NULL,
-- PRIMARY KEY CLUSTERED 
-- (
	-- [Id] ASC
-- )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
-- ) ON [PRIMARY]
-- GO
-- /****** Object:  Table [dbo].[Carts]    Script Date: 08-04-2025 17:33:07 ******/
-- SET ANSI_NULLS ON
-- GO
-- SET QUOTED_IDENTIFIER ON
-- GO
-- CREATE TABLE [dbo].[Carts](
	-- [Id] [bigint] IDENTITY(1,1) NOT NULL,
	-- [EmployerId] [bigint] NOT NULL,
	-- [CreatedDate] [datetime] NOT NULL,
	-- [IsActive] [bit] NOT NULL,
-- PRIMARY KEY CLUSTERED 
-- (
	-- [Id] ASC
-- )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
-- ) ON [PRIMARY]
-- GO
/****** Object:  Table [dbo].[EmployerJobs]    Script Date: 08-04-2025 17:33:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployerJobs](
	[EmployerJobId] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployerId] [bigint] NOT NULL,
	[JobId] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployerJobId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employers]    Script Date: 08-04-2025 17:33:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employers](
	[EmployerId] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](255) NOT NULL,
	[ContactPerson] [varchar](255) NOT NULL,
	[ContactEmail] [varchar](255) NOT NULL,
	[ContactPhone] [varchar](50) NULL,
	[CompanyWebsite] [varchar](255) NULL,
	[CompanyLocation] [varchar](255) NULL,
	[CompanySize] [int] NULL,
	[Industry] [varchar](255) NULL,
	[CompanyLogo] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployerUsers]    Script Date: 08-04-2025 17:33:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployerUsers](
	[EmployerUserId] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployerId] [bigint] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[Permissions] [varchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployerUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ErrorLogs]    Script Date: 08-04-2025 17:33:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorLogs](
	[ErrorLogId] [bigint] IDENTITY(1,1) NOT NULL,
	[ErrorMessage] [text] NOT NULL,
	[StackTrace] [text] NULL,
	[LogDate] [datetime] NULL,
	[LoggedBy] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ErrorLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobApplications]    Script Date: 08-04-2025 17:33:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobApplications](
	[ApplicationId] [bigint] IDENTITY(1,1) NOT NULL,
	[JobId] [bigint] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[ApplicationDate] [datetime] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK__JobAppli__C93A4C991F44CE86] PRIMARY KEY CLUSTERED 
(
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jobs]    Script Date: 08-04-2025 17:33:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jobs](
	[JobId] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployerId] [bigint] NOT NULL,
	[JobTitle] [varchar](255) NOT NULL,
	[JobDescription] [text] NOT NULL,
	[Location] [varchar](255) NOT NULL,
	[JobType] [varchar](50) NOT NULL,
	[MinExperience] [int] NULL,
	[MaxExperience] [int] NULL,
	[MinSalary] [int] NULL,
	[MaxSalary] [int] NULL,
	[Currency] [varchar](5) NULL,
	[Skills] [varchar](500) NULL,
	[PostedDate] [datetime] NULL,
	[ExpiryDate] [datetime] NULL,
	[Status] [varchar](50) NULL,
	[IsActive] [bit] NOT NULL,
	[Url] [varchar](500) NULL,
 CONSTRAINT [PK__Jobs__056690C28650B276] PRIMARY KEY CLUSTERED 
(
	[JobId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notifications]    Script Date: 08-04-2025 17:33:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifications](
	[NotificationId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[Message] [text] NOT NULL,
	[IsRead] [bit] NULL,
	[SentDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[NotificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 08-04-2025 17:33:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentId] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployerId] [bigint] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Currency] [varchar](5) NULL,
	[PaymentDate] [datetime] NULL,
	[PaymentStatus] [varchar](50) NOT NULL,
 CONSTRAINT [PK__Payments__9B556A385D27BBBF] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Plans]    Script Date: 08-04-2025 17:33:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plans](
	[PlanId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Currency] [varchar](5) NULL,
	[JobsQuota] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK__Plans__755C22B7FAA092EF] PRIMARY KEY CLUSTERED 
(
	[PlanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PublishJobHistories]    Script Date: 08-04-2025 17:33:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PublishJobHistories](
	[HistoryId] [int] IDENTITY(1,1) NOT NULL,
	[SubscriptionId] [int] NOT NULL,
	[EmployerId] [bigint] NOT NULL,
	[PublishDate] [datetime] NOT NULL,
	[Remarks] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[HistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 08-04-2025 17:33:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
	[Description] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subscriptions]    Script Date: 08-04-2025 17:33:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscriptions](
	[SubscriptionId] [int] IDENTITY(1,1) NOT NULL,
	[EmployerId] [bigint] NOT NULL,
	[PlanId] [int] NOT NULL,
	[JobsQuota] [int] NOT NULL,
	[ExpiryDate] [datetime] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SubscriptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserProfiles]    Script Date: 08-04-2025 17:33:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfiles](
	[ProfileId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[ResumePath] [varchar](255) NULL,
	[ProfileSummary] [text] NULL,
	[ExperienceYears] [int] NULL,
	[Skills] [varchar](500) NULL,
	[Education] [text] NULL,
	[CurrentLocation] [varchar](255) NULL,
	[PreferredLocation] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 08-04-2025 17:33:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [bigint] NOT NULL,
	[RoleId] [bigint] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 08-04-2025 17:33:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[PhoneNumber] [varchar](20) NULL,
	[Password] [varchar](255) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AuditLogs] ADD  DEFAULT (getdate()) FOR [OperationDate]
GO
-- ALTER TABLE [dbo].[Carts] ADD  DEFAULT (getdate()) FOR [CreatedDate]
-- GO
ALTER TABLE [dbo].[ErrorLogs] ADD  DEFAULT (getdate()) FOR [LogDate]
GO
ALTER TABLE [dbo].[JobApplications] ADD  CONSTRAINT [DF__JobApplic__Appli__571DF1D5]  DEFAULT (getdate()) FOR [ApplicationDate]
GO
ALTER TABLE [dbo].[Jobs] ADD  CONSTRAINT [DF__Jobs__PostedDate__4F7CD00D]  DEFAULT (getdate()) FOR [PostedDate]
GO
ALTER TABLE [dbo].[Jobs] ADD  CONSTRAINT [DF__Jobs__IsActive__5070F446]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Notifications] ADD  DEFAULT ((0)) FOR [IsRead]
GO
ALTER TABLE [dbo].[Notifications] ADD  DEFAULT (getdate()) FOR [SentDate]
GO
ALTER TABLE [dbo].[Payments] ADD  CONSTRAINT [DF__Payments__Paymen__60A75C0F]  DEFAULT (getdate()) FOR [PaymentDate]
GO
ALTER TABLE [dbo].[Plans] ADD  CONSTRAINT [DF__Plans__IsActive__74AE54BC]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Plans] ADD  CONSTRAINT [DF__Plans__CreatedDa__75A278F5]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Subscriptions] ADD  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Admins]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[AuditLogs]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
-- ALTER TABLE [dbo].[CartItems]  WITH CHECK ADD  CONSTRAINT [FK_CartItem_Cart] FOREIGN KEY([CartId])
-- REFERENCES [dbo].[Carts] ([Id])
-- ON DELETE CASCADE
-- GO
-- ALTER TABLE [dbo].[CartItems] CHECK CONSTRAINT [FK_CartItem_Cart]
GO
ALTER TABLE [dbo].[EmployerJobs]  WITH CHECK ADD FOREIGN KEY([EmployerId])
REFERENCES [dbo].[Employers] ([EmployerId])
GO
ALTER TABLE [dbo].[EmployerJobs]  WITH CHECK ADD  CONSTRAINT [FK_EmployerJobs_JobId] FOREIGN KEY([JobId])
REFERENCES [dbo].[Jobs] ([JobId])
GO
ALTER TABLE [dbo].[EmployerJobs] CHECK CONSTRAINT [FK_EmployerJobs_JobId]
GO
ALTER TABLE [dbo].[EmployerUsers]  WITH CHECK ADD FOREIGN KEY([EmployerId])
REFERENCES [dbo].[Employers] ([EmployerId])
GO
ALTER TABLE [dbo].[EmployerUsers]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[JobApplications]  WITH CHECK ADD  CONSTRAINT [FK__JobApplic__JobId__5812160E] FOREIGN KEY([JobId])
REFERENCES [dbo].[Jobs] ([JobId])
GO
ALTER TABLE [dbo].[JobApplications] CHECK CONSTRAINT [FK__JobApplic__JobId__5812160E]
GO
ALTER TABLE [dbo].[JobApplications]  WITH CHECK ADD  CONSTRAINT [FK__JobApplic__UserI__59063A47] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[JobApplications] CHECK CONSTRAINT [FK__JobApplic__UserI__59063A47]
GO
ALTER TABLE [dbo].[Jobs]  WITH CHECK ADD  CONSTRAINT [FK__Jobs__EmployerId__5165187F] FOREIGN KEY([EmployerId])
REFERENCES [dbo].[Employers] ([EmployerId])
GO
ALTER TABLE [dbo].[Jobs] CHECK CONSTRAINT [FK__Jobs__EmployerId__5165187F]
GO
ALTER TABLE [dbo].[Notifications]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK__Payments__Employ__619B8048] FOREIGN KEY([EmployerId])
REFERENCES [dbo].[Employers] ([EmployerId])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK__Payments__Employ__619B8048]
GO
ALTER TABLE [dbo].[Subscriptions]  WITH CHECK ADD  CONSTRAINT [FK_Subscriptions_Plans] FOREIGN KEY([PlanId])
REFERENCES [dbo].[Plans] ([PlanId])
GO
ALTER TABLE [dbo].[Subscriptions] CHECK CONSTRAINT [FK_Subscriptions_Plans]
GO
ALTER TABLE [dbo].[UserProfiles]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Jobs]  WITH CHECK ADD  CONSTRAINT [CHK_MaxExperience] CHECK  (([MaxExperience]>=[MinExperience]))
GO
ALTER TABLE [dbo].[Jobs] CHECK CONSTRAINT [CHK_MaxExperience]
GO
ALTER TABLE [dbo].[Jobs]  WITH CHECK ADD  CONSTRAINT [CHK_MaxSalary] CHECK  (([MaxSalary]>=[MinSalary]))
GO
ALTER TABLE [dbo].[Jobs] CHECK CONSTRAINT [CHK_MaxSalary]
GO
ALTER TABLE [dbo].[Jobs]  WITH CHECK ADD  CONSTRAINT [CK__Jobs__MinExperie__4D94879B] CHECK  (([MinExperience]>=(0)))
GO
ALTER TABLE [dbo].[Jobs] CHECK CONSTRAINT [CK__Jobs__MinExperie__4D94879B]
GO
ALTER TABLE [dbo].[Jobs]  WITH CHECK ADD  CONSTRAINT [CK__Jobs__MinSalary__4E88ABD4] CHECK  (([MinSalary]>=(0)))
GO
ALTER TABLE [dbo].[Jobs] CHECK CONSTRAINT [CK__Jobs__MinSalary__4E88ABD4]
GO
