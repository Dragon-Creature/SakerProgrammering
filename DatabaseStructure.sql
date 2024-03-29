USE [SjukAnmala]
GO
/****** Object:  Table [dbo].[Illness]    Script Date: 2013-03-26 22:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Illness](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Start] [datetime] NOT NULL,
	[Expires] [datetime] NOT NULL,
	[MedicalCertificate] [bit] NOT NULL,
	[AnstalldId] [int] NULL,
	[ChildIllness] [bit] NOT NULL,
	[SocialSecurity] [nvarchar](50) NULL,
 CONSTRAINT [PK_Illness] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 2013-03-26 22:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nchar](25) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 2013-03-26 22:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](50) NOT NULL,
	[Password] [nchar](1000) NOT NULL,
	[Role] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Illness] ON 

INSERT [dbo].[Illness] ([Id], [Start], [Expires], [MedicalCertificate], [AnstalldId], [ChildIllness], [SocialSecurity]) VALUES (1, CAST(0x0000A18500000000 AS DateTime), CAST(0x0000A18500000000 AS DateTime), 0, 3, 0, N'')
INSERT [dbo].[Illness] ([Id], [Start], [Expires], [MedicalCertificate], [AnstalldId], [ChildIllness], [SocialSecurity]) VALUES (2, CAST(0x0000A18B00000000 AS DateTime), CAST(0x0000A19000000000 AS DateTime), 1, 3, 0, N'')
INSERT [dbo].[Illness] ([Id], [Start], [Expires], [MedicalCertificate], [AnstalldId], [ChildIllness], [SocialSecurity]) VALUES (3, CAST(0x0000A18500000000 AS DateTime), CAST(0x0000A18500000000 AS DateTime), 0, 3, 1, N'090704-3548')
INSERT [dbo].[Illness] ([Id], [Start], [Expires], [MedicalCertificate], [AnstalldId], [ChildIllness], [SocialSecurity]) VALUES (4, CAST(0x0000A18700000000 AS DateTime), CAST(0x0000A18700000000 AS DateTime), 0, 3, 0, N'')
INSERT [dbo].[Illness] ([Id], [Start], [Expires], [MedicalCertificate], [AnstalldId], [ChildIllness], [SocialSecurity]) VALUES (5, CAST(0x0000A1C200000000 AS DateTime), CAST(0x0000A1C900000000 AS DateTime), 1, 3, 0, N'')
INSERT [dbo].[Illness] ([Id], [Start], [Expires], [MedicalCertificate], [AnstalldId], [ChildIllness], [SocialSecurity]) VALUES (6, CAST(0x0000A18A00000000 AS DateTime), CAST(0x0000A18A00000000 AS DateTime), 0, 5, 1, N'110614-0000')
INSERT [dbo].[Illness] ([Id], [Start], [Expires], [MedicalCertificate], [AnstalldId], [ChildIllness], [SocialSecurity]) VALUES (7, CAST(0x0000A18A00000000 AS DateTime), CAST(0x0000A18A00000000 AS DateTime), 0, 5, 1, N'090704-3548')
INSERT [dbo].[Illness] ([Id], [Start], [Expires], [MedicalCertificate], [AnstalldId], [ChildIllness], [SocialSecurity]) VALUES (8, CAST(0x0000A18A00000000 AS DateTime), CAST(0x0000A18A00000000 AS DateTime), 0, 3, 1, N'060811-4585')
INSERT [dbo].[Illness] ([Id], [Start], [Expires], [MedicalCertificate], [AnstalldId], [ChildIllness], [SocialSecurity]) VALUES (9, CAST(0x0000A18A00000000 AS DateTime), CAST(0x0000A18A00000000 AS DateTime), 0, 3, 0, N'')
INSERT [dbo].[Illness] ([Id], [Start], [Expires], [MedicalCertificate], [AnstalldId], [ChildIllness], [SocialSecurity]) VALUES (10, CAST(0x0000A1B900000000 AS DateTime), CAST(0x0000A23F00000000 AS DateTime), 1, 3, 0, N'')
INSERT [dbo].[Illness] ([Id], [Start], [Expires], [MedicalCertificate], [AnstalldId], [ChildIllness], [SocialSecurity]) VALUES (11, CAST(0x0000A26D00000000 AS DateTime), CAST(0x0000A18A00000000 AS DateTime), 0, 5, 1, N'110404-3548')
INSERT [dbo].[Illness] ([Id], [Start], [Expires], [MedicalCertificate], [AnstalldId], [ChildIllness], [SocialSecurity]) VALUES (12, CAST(0x0000A18A00000000 AS DateTime), CAST(0x0000A18A00000000 AS DateTime), 0, 3, 0, N'')
INSERT [dbo].[Illness] ([Id], [Start], [Expires], [MedicalCertificate], [AnstalldId], [ChildIllness], [SocialSecurity]) VALUES (13, CAST(0x0000A17800000000 AS DateTime), CAST(0x0000A18A00000000 AS DateTime), 1, 3, 0, N'')
INSERT [dbo].[Illness] ([Id], [Start], [Expires], [MedicalCertificate], [AnstalldId], [ChildIllness], [SocialSecurity]) VALUES (14, CAST(0x0000A18A00000000 AS DateTime), CAST(0x0000A18A00000000 AS DateTime), 1, 3, 0, N'')
INSERT [dbo].[Illness] ([Id], [Start], [Expires], [MedicalCertificate], [AnstalldId], [ChildIllness], [SocialSecurity]) VALUES (15, CAST(0x0000A18A00000000 AS DateTime), CAST(0x0000A18A00000000 AS DateTime), 0, 3, 1, N'060811-4585')
INSERT [dbo].[Illness] ([Id], [Start], [Expires], [MedicalCertificate], [AnstalldId], [ChildIllness], [SocialSecurity]) VALUES (16, CAST(0x0000A18A00000000 AS DateTime), CAST(0x0000A18A00000000 AS DateTime), 0, 3, 0, N'')
INSERT [dbo].[Illness] ([Id], [Start], [Expires], [MedicalCertificate], [AnstalldId], [ChildIllness], [SocialSecurity]) VALUES (17, CAST(0x0000A18A00000000 AS DateTime), CAST(0x0000A18A00000000 AS DateTime), 0, 3, 0, N'')
INSERT [dbo].[Illness] ([Id], [Start], [Expires], [MedicalCertificate], [AnstalldId], [ChildIllness], [SocialSecurity]) VALUES (18, CAST(0x0000A18A00000000 AS DateTime), CAST(0x0000A18A00000000 AS DateTime), 0, 3, 0, N'')
INSERT [dbo].[Illness] ([Id], [Start], [Expires], [MedicalCertificate], [AnstalldId], [ChildIllness], [SocialSecurity]) VALUES (19, CAST(0x0000A18A00000000 AS DateTime), CAST(0x0000A18A00000000 AS DateTime), 0, 5, 0, N'')
INSERT [dbo].[Illness] ([Id], [Start], [Expires], [MedicalCertificate], [AnstalldId], [ChildIllness], [SocialSecurity]) VALUES (20, CAST(0x0000A18D00000000 AS DateTime), CAST(0x0000A1B900000000 AS DateTime), 1, 5, 0, N'')
INSERT [dbo].[Illness] ([Id], [Start], [Expires], [MedicalCertificate], [AnstalldId], [ChildIllness], [SocialSecurity]) VALUES (21, CAST(0x0000A18A00000000 AS DateTime), CAST(0x0000A18A00000000 AS DateTime), 0, 5, 1, N'100707-3942')
INSERT [dbo].[Illness] ([Id], [Start], [Expires], [MedicalCertificate], [AnstalldId], [ChildIllness], [SocialSecurity]) VALUES (22, CAST(0x0000A18C00000000 AS DateTime), CAST(0x0000A18C00000000 AS DateTime), 0, 5, 1, N'060811-4585')
SET IDENTITY_INSERT [dbo].[Illness] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (1, N'admin                    ')
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (2, N'user                     ')
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [Password], [Role]) VALUES (2, N'Admin2                                            ', N'83a394d5118729662082c2f310b3a8b249b5a5d6f7ecf333abedc197fbeaa8e9                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        ', 1)
INSERT [dbo].[Users] ([Id], [Name], [Password], [Role]) VALUES (3, N'User3                                             ', N'b87fadce6970e3055901e826b3b8ad6ac43b0c2aea1d5a60ffe89f537a9fc63c                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        ', 2)
INSERT [dbo].[Users] ([Id], [Name], [Password], [Role]) VALUES (5, N'User5                                             ', N'14b375b7075c7b5c425d9be61ba7546ed9743edcfcd801e8400d1b3bcf496fd6                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        ', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Illness] ADD  DEFAULT ('1900-01-01') FOR [Start]
GO
ALTER TABLE [dbo].[Illness] ADD  DEFAULT ('1900-01-01') FOR [Expires]
GO
ALTER TABLE [dbo].[Illness]  WITH CHECK ADD  CONSTRAINT [FK_Illness_Users] FOREIGN KEY([AnstalldId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Illness] CHECK CONSTRAINT [FK_Illness_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([Role])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
