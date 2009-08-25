/****** Object:  ForeignKey [FK_tblCategory_tblCategory1]    Script Date: 08/25/2009 23:32:20 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblCategory_tblCategory1]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblCategory]'))
ALTER TABLE [dbo].[tblCategory] DROP CONSTRAINT [FK_tblCategory_tblCategory1]
GO
/****** Object:  ForeignKey [FK_tblProduct_tblCategory]    Script Date: 08/25/2009 23:32:20 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblProduct_tblCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblProduct]'))
ALTER TABLE [dbo].[tblProduct] DROP CONSTRAINT [FK_tblProduct_tblCategory]
GO
/****** Object:  Table [dbo].[tblProduct]    Script Date: 08/25/2009 23:32:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblProduct]') AND type in (N'U'))
DROP TABLE [dbo].[tblProduct]
GO
/****** Object:  Table [dbo].[tblCategory]    Script Date: 08/25/2009 23:32:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblCategory]') AND type in (N'U'))
DROP TABLE [dbo].[tblCategory]
GO
/****** Object:  Table [dbo].[tblNews]    Script Date: 08/25/2009 23:32:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblNews]') AND type in (N'U'))
DROP TABLE [dbo].[tblNews]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 08/25/2009 23:32:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblUser]') AND type in (N'U'))
DROP TABLE [dbo].[tblUser]
GO
/****** Object:  Table [dbo].[tblEmail]    Script Date: 08/25/2009 23:32:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblEmail]') AND type in (N'U'))
DROP TABLE [dbo].[tblEmail]
GO
/****** Object:  Table [dbo].[tblInformation]    Script Date: 08/25/2009 23:32:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblInformation]') AND type in (N'U'))
DROP TABLE [dbo].[tblInformation]
GO
/****** Object:  Table [dbo].[tblInformation]    Script Date: 08/25/2009 23:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblInformation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblInformation](
	[ID] [uniqueidentifier] NOT NULL,
	[CompanyNameVN] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CompanyNameEN] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Logo] [image] NULL,
	[IntroduceVN] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IntroduceEN] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContactVN] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContactEN] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Deleted] [bit] NULL,
 CONSTRAINT [PK_tblInformation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[tblInformation] ([ID], [CompanyNameVN], [CompanyNameEN], [Logo], [IntroduceVN], [IntroduceEN], [ContactVN], [ContactEN], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Deleted]) VALUES (N'c75d5000-ab74-4a38-88c5-23e00a66ea36', NULL, NULL, NULL, NULL, NULL, N'<p>Cap nhat ne 2</p>', NULL, CAST(0x00009C5A017C12B6 AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[tblInformation] ([ID], [CompanyNameVN], [CompanyNameEN], [Logo], [IntroduceVN], [IntroduceEN], [ContactVN], [ContactEN], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Deleted]) VALUES (N'77e9ccf3-47ae-4f9f-a4eb-3d8a0bffa14a', NULL, NULL, NULL, NULL, NULL, NULL, N'<p>ccxzczczxc</p>', CAST(0x00009C5A003915CE AS DateTime), NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[tblEmail]    Script Date: 08/25/2009 23:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblEmail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblEmail](
	[ID] [uniqueidentifier] NOT NULL,
	[SendDate] [datetime] NULL,
	[Sender] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Email] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SendTo] [tinyint] NULL,
	[Title] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Content] [nvarchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_tblEmail] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'fab75de1-7a03-4cd3-b186-06bc8dd83f6e', CAST(0x00009C5B001367BE AS DateTime), N'fdsgj', N'duongbkit@gmail.com', 2, N'fdksf;l', N'fkds;fls')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'7c7f1069-6483-496f-84c5-171fb1f3927b', CAST(0x00009C590109E534 AS DateTime), N'fdsfsfs', N'duongbkit@gmail.com', 1, N'her her', N'noi dung')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'62f051d5-c9c8-4177-bf65-1f2c87ab4e18', CAST(0x00009C5B0004F354 AS DateTime), N'hejlkfjdsl', N'duongbkit@gmail.com', 2, N'fdsfsdfdfds', N'fdsfdsfsdf')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'788b7fdc-0eb0-400b-bb6b-1fe13c0782ab', CAST(0x00009C5B000946C0 AS DateTime), N'dsdadas', N'duongbkit@gmail.com', 2, N'dsfds', N'fdfdsf')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'25d34848-714f-43af-97ef-3418038b3ac5', CAST(0x00009C5C000FD3DE AS DateTime), N'test', N'duongbkit@gmail.com', 1, N'fdfdsf', N'dskfkdsl;fds')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'13b6c5d1-b959-437a-a955-385a53f5b3f2', CAST(0x00009C5901083D8D AS DateTime), N'fdsfsfs', N'duongbkit@gmail.com', 1, N'her her', N'noi dung')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'b8362041-1599-4bf8-9916-42b48bf283c5', CAST(0x00009C5B000B9C5A AS DateTime), N'fdsfsd', N'duongbkit@gmail.com', 2, N'fdfjksdl', N'fdsl;fka;')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'f760e405-50df-42ea-8b1b-45028d8542b5', CAST(0x00009C5B00117FFD AS DateTime), N'fdshfso', N'duongbkit@gmail.com', 1, N'fdjslf', N'fdlksfj')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'd6ad39ad-4b8e-4a23-a96d-46dea5eb079c', CAST(0x00009C5C000FACD0 AS DateTime), N'stephen', N'duongbkit@gmail.com', 1, N'fdsf', N'fdsjklffds')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'ad34d23f-1a83-410b-929b-48e7a6d7c736', CAST(0x00009C5B001217B5 AS DateTime), N'fgjl', N'duongbkit@gmail.com', 2, N'fdjsfl', N'fjdslfsd')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'04814bf6-fe4b-4249-82fc-5aa22f296bc1', CAST(0x00009C5B000CE4C5 AS DateTime), N'fdsfhdkl', N'duongbkit@gmail.com', 1, N'fdfjkl;', N'fdskl;fs')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'f6131283-1559-433b-a575-6731aaeb645e', CAST(0x00009C5B0014961B AS DateTime), N'fdsjfs', N'duongbkit@gmail.com', 2, N'fkjdsflk', N'fdjsfkls')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'c7e6e80b-4f70-4e37-b1ed-7124d6120613', CAST(0x00009C5B0004847F AS DateTime), N'Stephen', N'duongbkit@gmail.com', 1, N'Her her her test', N'tes tes te ts')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'b7bda866-0071-4874-a781-7224dddcfd0d', CAST(0x00009C590109D57E AS DateTime), N'fdsfsfs', N'duongbkit@gmail.com', 1, N'her her', N'noi dung')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'145aa4aa-32ad-463a-9fb2-72ab3322ad6d', CAST(0x00009C5B000F137B AS DateTime), N'fdshkfj', N'duongbkit@gmail.com', 1, N'dsadjl', N'fndsl')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'd51cfe9d-e3a5-4581-8ff5-7da01f2ce95a', CAST(0x00009C5A00134E7C AS DateTime), N'Stephen', N'duongbkit@gmail.com', 1, N'test choi', N'test choi')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'ff351113-f2c2-4ae6-8862-86a4989595f9', CAST(0x00009C5B000CAA40 AS DateTime), N'safsajl', N'duongbkit@gmail.com', 1, N'fdsfkl;', N'fdkjfl;ds')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'25aa4a42-df36-43b5-a6da-92cab1c6d264', CAST(0x00009C5B001BEF4B AS DateTime), N'hahahaah', N'duongbkit@gmail.com', 2, N'hhahah', N'jdjdjddjdj')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'a03ca124-2f8f-484d-b2a2-96ef89b29ab0', CAST(0x00009C5B001500BF AS DateTime), N'fjdfl', N'duongbkit@gmail.com', 2, N'fkjdskl', N'fjdhsfsl')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'bd6eabb1-e1e8-408a-be06-9749f6da29ce', CAST(0x00009C5B001AAAB4 AS DateTime), N'fdskjf', N'duongbkit@gmail.com', 2, N'dsjadkl', N'fdkjfkldsf')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'c1ad6c50-9ecc-4097-8995-9c994ef88e2f', CAST(0x00009C5B000E851D AS DateTime), N'HFDSFK', N'duongbkit@gmail.com', 1, N'fjdkfl', N'fdslkfsd')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'd4af4662-d327-4710-8399-9f6d9321c4a6', CAST(0x00009C5C000EA298 AS DateTime), N'stephen', N'duongbkit@gmail.com', 1, N'test thoi ah', N'hic hic')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'3e97a2fd-783b-44d6-b371-acd7935547d8', CAST(0x00009C5B00259225 AS DateTime), N'fdfjdsl', N'duongbkit@gmail.com', 2, N'fdjhfskj', N'djsfhkfj')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'a5633a35-1eb2-4ffc-908b-b1625be35088', CAST(0x00009C5B000B5817 AS DateTime), N'dsadas', N'duongbkit@gmail.com', 2, N'fdsfs', N'dfsd')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'17e66e5a-8a5f-4b3f-a0f3-b6200c60cc06', CAST(0x00009C5B000DD6FB AS DateTime), N'fdshfsdlk', N'duongbkit@gmail.com', 1, N'fjdsflk', N'fdsfjks;ld')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'06c5f114-753e-4977-aac0-b6bc64936b2e', CAST(0x00009C590109E0EF AS DateTime), N'fdsfsfs', N'duongbkit@gmail.com', 1, N'her her', N'noi dung')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'f16dce43-e674-44ab-bb09-bfc2e5165399', CAST(0x00009C590109DF03 AS DateTime), N'fdsfsfs', N'duongbkit@gmail.com', 1, N'her her', N'noi dung')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'751ab27e-e49b-406e-9af9-c7c00e827808', CAST(0x00009C5B001C803E AS DateTime), N'fdhfsl', N'duongbkit@gmail.com', 1, N'fjdsfl', N'fdlsjfsdl')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'5ffada43-eb64-460f-b480-c8a6146785f8', CAST(0x00009C5B0016BD1B AS DateTime), N'fdshfkl', N'duongbkit@gmail.com', 2, N'fdjsl', N'fdksjfls')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'5f484a54-f009-420f-8bb9-ce2bfcda85fa', CAST(0x00009C590109E314 AS DateTime), N'fdsfsfs', N'duongbkit@gmail.com', 1, N'her her', N'noi dung')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'a778653b-b770-40c4-91ec-d0762fe30df6', CAST(0x00009C59010A6ABE AS DateTime), N'fdsfsfs', N'duongbkit@gmail.com', 1, N'her her', N'noi dung')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'60518826-2f24-48d1-a2bb-d2cb864fd551', CAST(0x00009C590109AB6A AS DateTime), N'fdsfsfs', N'duongbkit@gmail.com', 1, N'her her', N'noi dung')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'6bdde6ed-9423-4f1f-b353-d812b2e32378', CAST(0x00009C5B001317ED AS DateTime), N'fdshfo', N'duongbkit@gmail.com', 2, N'fjdsfkl;', N'fjdsfkls')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'7e98eff7-f6f9-424e-a32f-e366d16a6b80', CAST(0x00009C5B0008686C AS DateTime), N'dsfdsfsd', N'duongbkit@gmail.com', 1, N'fdsfdsfsd', N'fdsfsdf')
INSERT [dbo].[tblEmail] ([ID], [SendDate], [Sender], [Email], [SendTo], [Title], [Content]) VALUES (N'aa60e6c6-8220-414c-a00b-e7285b11b517', CAST(0x00009C5B00103BC3 AS DateTime), N'fjdslkf', N'duong@gmail.com', 1, N'fjdlfk', N'fdsnfjl')
/****** Object:  Table [dbo].[tblUser]    Script Date: 08/25/2009 23:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblUser]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblUser](
	[ID] [uniqueidentifier] NOT NULL,
	[UserNo] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Status] [tinyint] NULL,
	[UserName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Password] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Deleted] [bit] NULL,
	[Email] [nchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Department] [tinyint] NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[tblUser] ([ID], [UserNo], [Status], [UserName], [Password], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Deleted], [Email], [Department]) VALUES (N'336faf4a-1e44-4f37-a8da-23563468e3be', NULL, NULL, N'accounts', N'9jmwyACJtiaqSgkScwg+PuM0zcfHMvHuftAN5WNGH/o=', CAST(0x00009C5B0004496C AS DateTime), NULL, NULL, NULL, NULL, N'hungpham12d2@gmail.com                            ', 5)
INSERT [dbo].[tblUser] ([ID], [UserNo], [Status], [UserName], [Password], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Deleted], [Email], [Department]) VALUES (N'474edbdd-53da-461c-b86d-2d12ccf4cc9c', NULL, NULL, N'marketing', N'9jmwyACJtiaqSgkScwg+PuM0zcfHMvHuftAN5WNGH/o=', CAST(0x00009C5B0004496C AS DateTime), NULL, NULL, NULL, NULL, N'vubao12a3@gmail.com                               ', 3)
INSERT [dbo].[tblUser] ([ID], [UserNo], [Status], [UserName], [Password], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Deleted], [Email], [Department]) VALUES (N'9aec3da5-519d-4b34-b553-412e2909a2b6', NULL, NULL, N'manager', N'9jmwyACJtiaqSgkScwg+PuM0zcfHMvHuftAN5WNGH/o=', CAST(0x00009C5B00044921 AS DateTime), NULL, NULL, NULL, NULL, N'hungpham12d2@yahoo.com                            ', 1)
INSERT [dbo].[tblUser] ([ID], [UserNo], [Status], [UserName], [Password], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Deleted], [Email], [Department]) VALUES (N'891ceea9-3448-45d1-93f9-5dc7791511ad', NULL, NULL, N'sales', N'9jmwyACJtiaqSgkScwg+PuM0zcfHMvHuftAN5WNGH/o=', CAST(0x00009C5B0004496C AS DateTime), NULL, NULL, NULL, NULL, N'tran.thien.an.113@gmail.com                       ', 4)
INSERT [dbo].[tblUser] ([ID], [UserNo], [Status], [UserName], [Password], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Deleted], [Email], [Department]) VALUES (N'13dc3bab-3322-4a4a-8b2d-c086f14d4077', NULL, NULL, N'admin', N'zqwJTwybcjmtOzp2y/lE7wSiyMGt8+RbzzPpPzLZkGQ=', CAST(0x00009C5900ECB1BB AS DateTime), NULL, NULL, NULL, NULL, N'stephentran84@gmail.com                           ', 1)
/****** Object:  Table [dbo].[tblNews]    Script Date: 08/25/2009 23:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblNews]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblNews](
	[ID] [uniqueidentifier] NOT NULL,
	[TitleVN] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TitleEN] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SubjectVN] [nvarchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SubjectEN] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContentVN] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContentEN] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Type] [tinyint] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PostedDate] [datetime] NULL,
	[PostedBy] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EndedBy] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EndedDate] [datetime] NULL,
	[Deleted] [bit] NULL,
	[Image] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_tblNews] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'46c9255a-eae8-4e2b-83a3-0a2721e43e75', NULL, N'troi oi oi oi oi oi oi oi oi ooi oi oi oi oi oi oio', NULL, N'dsdsadkl', NULL, N'<p>fdsfdsjk;l;</p>', 3, CAST(0x00009C5A016C4B2B AS DateTime), NULL, CAST(0x00009C5A016C4B2B AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ThumbImagesNewsSmallest/46c9255aeae84e2b83a30a2721e43e75.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'6a5d5c43-0621-413c-a0bd-15898923bf76', N'kfdfhskj', NULL, N'VJFHSLD', NULL, N'<p>GJFDGLKDS</p>', NULL, 2, CAST(0x00009C5C0013D157 AS DateTime), NULL, CAST(0x00009C5C0013D157 AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ThumbImagesNews/6a5d5c430621413ca0bd15898923bf76.JPG')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'36a7a2c0-6c52-404b-8331-1858209acff1', N'FLDSFL', NULL, N'FDLKFJL', NULL, N'<p>FDJSFL</p>', NULL, 3, CAST(0x00009C5C001691E0 AS DateTime), NULL, CAST(0x00009C5C001691E0 AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ThumbImagesNewsSmallest/36a7a2c06c52404b83311858209acff1.JPG')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'4cda6be0-9bc8-4905-acb6-192776b6d4aa', N'FDSJL', NULL, N'FHDSLKFJ', NULL, N'<p>FDSJFSDKL</p>', NULL, 3, CAST(0x00009C5C001673F9 AS DateTime), NULL, CAST(0x00009C5C001673F9 AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ThumbImagesNewsSmallest/4cda6be09bc84905acb6192776b6d4aa.JPG')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'a2c1d18e-397a-4ab4-ab84-1c746d5af79c', N'fdsfsd', NULL, N'fdsf', NULL, N'<p>fdsf</p>', NULL, 1, CAST(0x00009C620010C989 AS DateTime), NULL, CAST(0x00009C620010C989 AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ThumbImagesNews/a2c1d18e397a4ab4ab841c746d5af79c.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'97da4ce5-4a4f-4c1e-83a0-37154c331486', NULL, N'fdsfdsfs', NULL, N'fdsfdsfsdf', NULL, N'<p>fdsfsdfsdf</p>', 4, CAST(0x00009C5A017ACA3D AS DateTime), NULL, CAST(0x00009C5A017ACA3D AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ThumbImagesNews/97da4ce54a4f4c1e83a037154c331486.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'ef9c1b50-0514-4225-8281-414f55bae7b5', N'gfglk', NULL, N'gdflgjl', NULL, N'<p>gjdkflgjdskl;</p>', NULL, 2, CAST(0x00009C5C0005B9FB AS DateTime), NULL, CAST(0x00009C5C0005B9FB AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ThumbImagesNews/ef9c1b50051442258281414f55bae7b5.JPG')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'065bb0ce-88ce-4533-bdb7-547e9ae97b33', N'fdsfsd', NULL, N'kjljl', NULL, N'<p>k;lk;</p>', NULL, 3, CAST(0x00009C5C000A902D AS DateTime), NULL, CAST(0x00009C5C000A902D AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ThumbImagesNewsSmallest/065bb0ce88ce4533bdb7547e9ae97b33.JPG')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'049c80be-3798-470e-bcca-72135155c163', N'fdsfsd', NULL, N'kjljl', NULL, N'<p>k;lk;</p>', NULL, 3, CAST(0x00009C5C000BAFAB AS DateTime), NULL, CAST(0x00009C5C000BAFAB AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ThumbImagesNewsSmallest/049c80be3798470ebcca72135155c163.JPG')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'992fe680-babd-4b90-9370-93a3f43b38de', N'anh con trinh 2', NULL, N'chu de anh cong trinh', NULL, N'<p>noi dung anh cong trinh</p>', NULL, 2, CAST(0x00009C5C000545B0 AS DateTime), NULL, CAST(0x00009C5C000545B0 AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ThumbImagesNews/992fe680babd4b90937093a3f43b38de.JPG')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'570f8fb4-cc59-4a26-a5d2-96183af73ab3', N'kfdfhskj', NULL, N'VJFHSLD', NULL, N'<p>GJFDGLKDS</p>', NULL, 2, CAST(0x00009C5C0014A3A3 AS DateTime), NULL, CAST(0x00009C5C0014A3A3 AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ThumbImagesNews/570f8fb4cc594a26a5d296183af73ab3.JPG')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'b1d52a3f-8663-45d6-92e8-b15659a4148e', N'tui them tin tuc 2', NULL, N'chu de 2', NULL, N'<p>noi dung 2</p>', NULL, 1, CAST(0x00009C5C0004A0D7 AS DateTime), NULL, CAST(0x00009C5C0004A0D7 AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ThumbImagesNews/b1d52a3f866345d692e8b15659a4148e.JPG')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'57afd93d-6938-4b34-9b68-bb2903cc1410', NULL, NULL, NULL, NULL, N'<p>hahahahhahah</p>', NULL, 6, CAST(0x00009C5A017BDFE2 AS DateTime), NULL, CAST(0x00009C5A017BDFE2 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'73a872ad-44d6-4589-aed5-cde758706ef9', NULL, N'haha ahahah ahhaha ahhaah haha ha ahahah ahhaha hahaha ahahah ahahh haahh ha ah', NULL, N'kfjdkls', NULL, N'<p>fmdsl;fkmds;lflk</p>', 3, CAST(0x00009C5B00013641 AS DateTime), NULL, CAST(0x00009C5B00013641 AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ThumbImagesNewsSmallest/73a872ad44d64589aed5cde758706ef9.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'a1694de2-43c8-4b8c-8c70-d0b1263c9071', NULL, NULL, NULL, NULL, NULL, N'<p>fdsfdsfsdfsdfsd</p>', 5, CAST(0x00009C5A0177D0F6 AS DateTime), NULL, CAST(0x00009C5A0177D0F6 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'8d62a913-4234-4a56-b804-d33554734ade', N'fhdsfk', NULL, N'fjdslkfj', NULL, N'<p>fjdsfsldf</p>', NULL, 2, CAST(0x00009C5C0008A99C AS DateTime), NULL, CAST(0x00009C5C0008A99C AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ThumbImagesNews/8d62a91342344a56b804d33554734ade.JPG')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'c8ff3fe7-e5fe-464e-81a1-dd8ebba3500e', NULL, N'her eh e hrhrhrh', NULL, N'dsdasdasd', NULL, N'<p>hehehehehehhe</p>', 2, CAST(0x00009C5A017CF2CC AS DateTime), NULL, CAST(0x00009C5A017CF2CC AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ThumbImagesNews/c8ff3fe7e5fe464e81a1dd8ebba3500e.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'3cb4ca11-1e1f-48d5-bc36-e44c5ca09bad', N'jdljd djklk dlj dljld l jlkdkj djkld jl dhljdd djld djljld jdljd djlk dljld ldjldk dj dl', NULL, N'djld djl dkljd dlj', NULL, N'<p>djdk djlkd djkld djkld djkld</p>', NULL, 3, CAST(0x00009C5C00050091 AS DateTime), NULL, CAST(0x00009C5C00050091 AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ThumbImagesNewsSmallest/3cb4ca111e1f48d5bc36e44c5ca09bad.JPG')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'4df7a4b7-0104-4c2b-a774-e7c035eab57b', N'gf;gk', NULL, N'fjdsgkl', NULL, N'<p>gkjdfg;</p>', NULL, 1, CAST(0x00009C5C001519C7 AS DateTime), NULL, CAST(0x00009C5C001519C7 AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ThumbImagesNews/4df7a4b701044c2ba774e7c035eab57b.JPG')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'4914ab7c-db25-442a-8ce6-ea7897e237e1', N'glfdjglk', NULL, N'glkfjgl', NULL, N'<p>gjdflk;gj;l</p>', NULL, 2, CAST(0x00009C5C0014F938 AS DateTime), NULL, CAST(0x00009C5C0014F938 AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ThumbImagesNews/4914ab7cdb25442a8ce6ea7897e237e1.JPG')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'dc08ab71-aa07-46f6-be14-ea864dd17a04', N'fdkjsf', NULL, N'gkdjfgld', NULL, N'<p>gjdlfkg</p>', NULL, 2, CAST(0x00009C5C00137A00 AS DateTime), NULL, CAST(0x00009C5C00137A00 AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ThumbImagesNews/dc08ab71aa0746f6be14ea864dd17a04.JPG')
/****** Object:  Table [dbo].[tblCategory]    Script Date: 08/25/2009 23:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblCategory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblCategory](
	[ID] [uniqueidentifier] NOT NULL,
	[CategoryNo] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CategoryNameVN] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CategoryNameEN] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DescriptionVN] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DescriptionEN] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Deleted] [bit] NULL,
	[ParentID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_tblCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[tblCategory] ([ID], [CategoryNo], [CategoryNameVN], [CategoryNameEN], [DescriptionVN], [DescriptionEN], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Deleted], [ParentID]) VALUES (N'd6eebc9f-9dbd-46c2-a377-26edb734543e', N'1', N'Cửa sổ mở hất ra ngoài', NULL, N'Khong co gi', NULL, CAST(0x00009C5900F4E3AB AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblCategory] ([ID], [CategoryNo], [CategoryNameVN], [CategoryNameEN], [DescriptionVN], [DescriptionEN], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Deleted], [ParentID]) VALUES (N'1a3d8b6f-a4b1-416f-a096-67de2840fde9', N'1', N'Cửa sổ mở quay vào trong', NULL, N'Khong co gi', NULL, CAST(0x00009C5900F5025B AS DateTime), NULL, NULL, NULL, NULL, N'd6eebc9f-9dbd-46c2-a377-26edb734543e')
INSERT [dbo].[tblCategory] ([ID], [CategoryNo], [CategoryNameVN], [CategoryNameEN], [DescriptionVN], [DescriptionEN], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Deleted], [ParentID]) VALUES (N'7681869c-d716-4466-9cf5-6858d3b2ba08', N'1', N'Cửa đi xếp trượt', NULL, N'Khong co gi de mo ta', NULL, CAST(0x00009C5900F47BD0 AS DateTime), NULL, NULL, NULL, NULL, N'd6eebc9f-9dbd-46c2-a377-26edb734543e')
INSERT [dbo].[tblCategory] ([ID], [CategoryNo], [CategoryNameVN], [CategoryNameEN], [DescriptionVN], [DescriptionEN], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Deleted], [ParentID]) VALUES (N'c5691e2e-089b-4017-931d-75f20ef07f9d', N'1', N'Cửa sổ mở trượt', NULL, N'Khong', NULL, CAST(0x00009C5900F53B0C AS DateTime), NULL, NULL, NULL, NULL, N'd6eebc9f-9dbd-46c2-a377-26edb734543e')
INSERT [dbo].[tblCategory] ([ID], [CategoryNo], [CategoryNameVN], [CategoryNameEN], [DescriptionVN], [DescriptionEN], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Deleted], [ParentID]) VALUES (N'9e34f5aa-2de3-425d-9aa6-c066d3d1562e', N'1', N'Cửa đi mở trượt', NULL, N'Khong co gi', NULL, CAST(0x00009C5900F4A64B AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblCategory] ([ID], [CategoryNo], [CategoryNameVN], [CategoryNameEN], [DescriptionVN], [DescriptionEN], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Deleted], [ParentID]) VALUES (N'c44705ab-19b6-4795-8219-c092adac8f11', N'1', N'Kính an toàn', NULL, N'Khong', NULL, CAST(0x00009C5900F58EDA AS DateTime), NULL, NULL, NULL, NULL, N'9e34f5aa-2de3-425d-9aa6-c066d3d1562e')
INSERT [dbo].[tblCategory] ([ID], [CategoryNo], [CategoryNameVN], [CategoryNameEN], [DescriptionVN], [DescriptionEN], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Deleted], [ParentID]) VALUES (N'b052555a-47f0-4fc6-b962-d6a084b0c001', N'1', N'Cửa sổ mở quay ra ngoài', NULL, N'Khong', NULL, CAST(0x00009C5900F56EA0 AS DateTime), NULL, NULL, NULL, NULL, N'9e34f5aa-2de3-425d-9aa6-c066d3d1562e')
INSERT [dbo].[tblCategory] ([ID], [CategoryNo], [CategoryNameVN], [CategoryNameEN], [DescriptionVN], [DescriptionEN], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Deleted], [ParentID]) VALUES (N'02a71d1c-232c-48ca-b9dc-db23cc465836', N'1', N'Cửa đi hai cánh mở quay', NULL, N'Khong co gi', NULL, CAST(0x00009C5900F4C5A4 AS DateTime), NULL, NULL, NULL, NULL, N'9e34f5aa-2de3-425d-9aa6-c066d3d1562e')
INSERT [dbo].[tblCategory] ([ID], [CategoryNo], [CategoryNameVN], [CategoryNameEN], [DescriptionVN], [DescriptionEN], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Deleted], [ParentID]) VALUES (N'fa9b79d3-5a97-4a4b-99e8-e07db7fb0c61', N'1', N'fdfdfdfd', NULL, N'fdsfsdfsdfsdfsf', NULL, CAST(0x00009C590189C23F AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblCategory] ([ID], [CategoryNo], [CategoryNameVN], [CategoryNameEN], [DescriptionVN], [DescriptionEN], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Deleted], [ParentID]) VALUES (N'bb5681cf-0a58-41b4-897e-e1315131c836', N'1', N'Cửa sổ mở quay lật vào trong', NULL, N'Khong', NULL, CAST(0x00009C5900F51F94 AS DateTime), NULL, NULL, NULL, NULL, N'fa9b79d3-5a97-4a4b-99e8-e07db7fb0c61')
INSERT [dbo].[tblCategory] ([ID], [CategoryNo], [CategoryNameVN], [CategoryNameEN], [DescriptionVN], [DescriptionEN], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Deleted], [ParentID]) VALUES (N'cb21777f-41b8-47d1-947e-e50de27720f9', N'1', NULL, N'troi tori troi tr', NULL, N'ta ghet em lam', CAST(0x00009C5A00420A73 AS DateTime), NULL, CAST(0x00009C5A00464E79 AS DateTime), NULL, NULL, N'fa9b79d3-5a97-4a4b-99e8-e07db7fb0c61')
INSERT [dbo].[tblCategory] ([ID], [CategoryNo], [CategoryNameVN], [CategoryNameEN], [DescriptionVN], [DescriptionEN], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Deleted], [ParentID]) VALUES (N'927f0a89-256a-4ed5-b9d2-ea81d4cddac2', N'1', N'duong add', NULL, N'day ne hic', NULL, CAST(0x00009C59018B2C31 AS DateTime), NULL, NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[tblProduct]    Script Date: 08/25/2009 23:32:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblProduct]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblProduct](
	[ID] [uniqueidentifier] NOT NULL,
	[ProductNo] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CategoryID] [uniqueidentifier] NULL,
	[ProductNameVN] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ProductNameEN] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PriceVN] [float] NULL,
	[PriceEN] [float] NULL,
	[Image] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UpdatedDate] [datetime] NULL,
	[Deleted] [bit] NULL,
	[Promoted] [bit] NULL,
	[StoreStatus] [bit] NULL,
	[WarrantyTime] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Property] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_tblProduct] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[tblProduct] ([ID], [ProductNo], [CategoryID], [ProductNameVN], [ProductNameEN], [Description], [PriceVN], [PriceEN], [Image], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Deleted], [Promoted], [StoreStatus], [WarrantyTime], [Property]) VALUES (N'33e40e0f-715d-4791-bea9-0a4f3cde5e31', NULL, N'd6eebc9f-9dbd-46c2-a377-26edb734543e', N'kfjdsfh', NULL, N'<p>JGFDSLKGDSJL;</p>', 0, NULL, N'/Admin/ThumbImagesNews/33e40e0f715d4791bea90a4f3cde5e31.JPG', NULL, CAST(0x00009C5C00158B07 AS DateTime), NULL, NULL, NULL, 0, 1, N'fdlskjfl', N'kldsjfsdl')
INSERT [dbo].[tblProduct] ([ID], [ProductNo], [CategoryID], [ProductNameVN], [ProductNameEN], [Description], [PriceVN], [PriceEN], [Image], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Deleted], [Promoted], [StoreStatus], [WarrantyTime], [Property]) VALUES (N'5357b855-11d8-4445-af4e-2979ef9ba7d3', NULL, N'd6eebc9f-9dbd-46c2-a377-26edb734543e', N'fdslfj', NULL, N'<p>fdgkjsgp;</p>', 0, NULL, N'/Admin/ThumbImagesNews/5357b85511d84445af4e2979ef9ba7d3.JPG', NULL, CAST(0x00009C5C00154A56 AS DateTime), NULL, NULL, NULL, 0, 1, N'lkdsjg;', N'kdjsgs;')
INSERT [dbo].[tblProduct] ([ID], [ProductNo], [CategoryID], [ProductNameVN], [ProductNameEN], [Description], [PriceVN], [PriceEN], [Image], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Deleted], [Promoted], [StoreStatus], [WarrantyTime], [Property]) VALUES (N'2e154194-d502-4bdf-a5ef-45320bfd2ad5', NULL, N'1a3d8b6f-a4b1-416f-a096-67de2840fde9', N'ten san pham ne', NULL, N'<p>tesct choi thoi</p>', 0, NULL, N'/Admin/ThumbImagesNews/2e154194d5024bdfa5ef45320bfd2ad5.JPG', NULL, CAST(0x00009C5C000308E1 AS DateTime), NULL, CAST(0x00009C5D017C8289 AS DateTime), NULL, 1, 1, N'12 thang', N'test choi')
INSERT [dbo].[tblProduct] ([ID], [ProductNo], [CategoryID], [ProductNameVN], [ProductNameEN], [Description], [PriceVN], [PriceEN], [Image], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Deleted], [Promoted], [StoreStatus], [WarrantyTime], [Property]) VALUES (N'92ab030e-2454-4aaa-8be5-94d4305bbec3', NULL, N'd6eebc9f-9dbd-46c2-a377-26edb734543e', N'fdjsfh', NULL, N'<p>dlksfjdsfl</p>', 0, NULL, N'/Admin/ThumbImagesNews/92ab030e24544aaa8be594d4305bbec3.JPG', NULL, CAST(0x00009C5C00156B63 AS DateTime), NULL, NULL, NULL, 0, 1, N'fdjfl', N'fjdsfl')
INSERT [dbo].[tblProduct] ([ID], [ProductNo], [CategoryID], [ProductNameVN], [ProductNameEN], [Description], [PriceVN], [PriceEN], [Image], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Deleted], [Promoted], [StoreStatus], [WarrantyTime], [Property]) VALUES (N'b00e546a-9f01-4053-9d98-a801ce95555b', NULL, N'd6eebc9f-9dbd-46c2-a377-26edb734543e', N'KJFHDSF', NULL, N'<p>KJFDSG</p>', 0, NULL, N'/Admin/ThumbImagesNews/b00e546a9f0140539d98a801ce95555b.JPG', NULL, CAST(0x00009C5C0015AB7E AS DateTime), NULL, NULL, NULL, 0, 1, N'DJFFL', N'FDKLJFSDLKF')
INSERT [dbo].[tblProduct] ([ID], [ProductNo], [CategoryID], [ProductNameVN], [ProductNameEN], [Description], [PriceVN], [PriceEN], [Image], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Deleted], [Promoted], [StoreStatus], [WarrantyTime], [Property]) VALUES (N'f65ddd97-d243-4c30-90b5-f5ce304e44d8', NULL, N'cb21777f-41b8-47d1-947e-e50de27720f9', NULL, N'add new product', N'<p>test thu thoi</p>', NULL, 10000, N'/Admin/ThumbImagesNews/f65ddd97d2434c3090b5f5ce304e44d8.JPG', NULL, CAST(0x00009C5B018A992A AS DateTime), NULL, CAST(0x00009C5C0002BEA6 AS DateTime), NULL, 0, 1, N'12 thang', N'test thu')
/****** Object:  ForeignKey [FK_tblCategory_tblCategory1]    Script Date: 08/25/2009 23:32:20 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblCategory_tblCategory1]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblCategory]'))
ALTER TABLE [dbo].[tblCategory]  WITH CHECK ADD  CONSTRAINT [FK_tblCategory_tblCategory1] FOREIGN KEY([ParentID])
REFERENCES [dbo].[tblCategory] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblCategory_tblCategory1]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblCategory]'))
ALTER TABLE [dbo].[tblCategory] CHECK CONSTRAINT [FK_tblCategory_tblCategory1]
GO
/****** Object:  ForeignKey [FK_tblProduct_tblCategory]    Script Date: 08/25/2009 23:32:20 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblProduct_tblCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblProduct]'))
ALTER TABLE [dbo].[tblProduct]  WITH CHECK ADD  CONSTRAINT [FK_tblProduct_tblCategory] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[tblCategory] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblProduct_tblCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblProduct]'))
ALTER TABLE [dbo].[tblProduct] CHECK CONSTRAINT [FK_tblProduct_tblCategory]
GO
