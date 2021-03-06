/****** Object:  ForeignKey [FK_tblCategory_tblCategory]    Script Date: 08/29/2009 00:33:56 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblCategory_tblCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblCategory]'))
ALTER TABLE [dbo].[tblCategory] DROP CONSTRAINT [FK_tblCategory_tblCategory]
GO
/****** Object:  ForeignKey [FK_tblProduct_tblCategory]    Script Date: 08/29/2009 00:33:56 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblProduct_tblCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblProduct]'))
ALTER TABLE [dbo].[tblProduct] DROP CONSTRAINT [FK_tblProduct_tblCategory]
GO
/****** Object:  Table [dbo].[tblProduct]    Script Date: 08/29/2009 00:33:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblProduct]') AND type in (N'U'))
DROP TABLE [dbo].[tblProduct]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 08/29/2009 00:33:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblUser]') AND type in (N'U'))
DROP TABLE [dbo].[tblUser]
GO
/****** Object:  Table [dbo].[tblNews]    Script Date: 08/29/2009 00:33:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblNews]') AND type in (N'U'))
DROP TABLE [dbo].[tblNews]
GO
/****** Object:  Table [dbo].[tblCategory]    Script Date: 08/29/2009 00:33:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblCategory]') AND type in (N'U'))
DROP TABLE [dbo].[tblCategory]
GO
/****** Object:  Table [dbo].[tblEmail]    Script Date: 08/29/2009 00:33:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblEmail]') AND type in (N'U'))
DROP TABLE [dbo].[tblEmail]
GO
/****** Object:  Table [dbo].[tblInformation]    Script Date: 08/29/2009 00:33:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblInformation]') AND type in (N'U'))
DROP TABLE [dbo].[tblInformation]
GO
/****** Object:  Table [dbo].[tblInformation]    Script Date: 08/29/2009 00:33:56 ******/
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
/****** Object:  Table [dbo].[tblEmail]    Script Date: 08/29/2009 00:33:56 ******/
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
/****** Object:  Table [dbo].[tblCategory]    Script Date: 08/29/2009 00:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblCategory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblCategory](
	[ID] [uniqueidentifier] NOT NULL,
	[ParentID] [uniqueidentifier] NULL,
	[CategoryNo] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CategoryName] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Deleted] [bit] NULL,
	[Language] [tinyint] NULL,
	[Level] [tinyint] NOT NULL,
 CONSTRAINT [PK_tblCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[tblCategory] ([ID], [ParentID], [CategoryNo], [CategoryName], [Description], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Deleted], [Language], [Level]) VALUES (N'f695e78a-60c7-4e0b-98b4-51dd11ef8eb4', NULL, N'1', N'Category 1', N'Description 1', CAST(0x00009C7300046C74 AS DateTime), NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[tblCategory] ([ID], [ParentID], [CategoryNo], [CategoryName], [Description], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Deleted], [Language], [Level]) VALUES (N'5d8d6a3e-a009-487a-8fb4-9d8b9bffa369', NULL, N'1', N'Category 2', N'Description 2', CAST(0x00009C730004A10A AS DateTime), NULL, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[tblCategory] ([ID], [ParentID], [CategoryNo], [CategoryName], [Description], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [Deleted], [Language], [Level]) VALUES (N'a465af08-63b4-4981-adc5-bfae8304e6c6', N'f695e78a-60c7-4e0b-98b4-51dd11ef8eb4', N'1', N'Sub Category ', N'Description Sub', CAST(0x00009C73001D195F AS DateTime), NULL, NULL, NULL, NULL, 1, 2)
/****** Object:  Table [dbo].[tblNews]    Script Date: 08/29/2009 00:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblNews]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblNews](
	[ID] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Subject] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Content] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Language] [tinyint] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PostedDate] [datetime] NULL,
	[PostedBy] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EndedDate] [datetime] NULL,
	[EndedBy] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Status] [tinyint] NULL,
	[Image] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_tblNews_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 08/29/2009 00:33:56 ******/
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
/****** Object:  Table [dbo].[tblProduct]    Script Date: 08/29/2009 00:33:56 ******/
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
	[ProductName] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Price] [float] NULL,
	[Image] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedBy] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UpdatedDate] [datetime] NULL,
	[Deleted] [bit] NULL,
	[Property] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Language] [tinyint] NULL,
 CONSTRAINT [PK_tblProduct] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  ForeignKey [FK_tblCategory_tblCategory]    Script Date: 08/29/2009 00:33:56 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblCategory_tblCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblCategory]'))
ALTER TABLE [dbo].[tblCategory]  WITH CHECK ADD  CONSTRAINT [FK_tblCategory_tblCategory] FOREIGN KEY([ParentID])
REFERENCES [dbo].[tblCategory] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblCategory_tblCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblCategory]'))
ALTER TABLE [dbo].[tblCategory] CHECK CONSTRAINT [FK_tblCategory_tblCategory]
GO
/****** Object:  ForeignKey [FK_tblProduct_tblCategory]    Script Date: 08/29/2009 00:33:56 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblProduct_tblCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblProduct]'))
ALTER TABLE [dbo].[tblProduct]  WITH CHECK ADD  CONSTRAINT [FK_tblProduct_tblCategory] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[tblCategory] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblProduct_tblCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblProduct]'))
ALTER TABLE [dbo].[tblProduct] CHECK CONSTRAINT [FK_tblProduct_tblCategory]
GO
