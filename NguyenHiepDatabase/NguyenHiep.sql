/****** Object:  ForeignKey [FK_tblProduct_tblCategory]    Script Date: 07/30/2009 01:16:36 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblProduct_tblCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblProduct]'))
ALTER TABLE [dbo].[tblProduct] DROP CONSTRAINT [FK_tblProduct_tblCategory]
GO
/****** Object:  Table [dbo].[tblProduct]    Script Date: 07/30/2009 01:16:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblProduct]') AND type in (N'U'))
DROP TABLE [dbo].[tblProduct]
GO
/****** Object:  Table [dbo].[tblInformation]    Script Date: 07/30/2009 01:16:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblInformation]') AND type in (N'U'))
DROP TABLE [dbo].[tblInformation]
GO
/****** Object:  Table [dbo].[tblCategory]    Script Date: 07/30/2009 01:16:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblCategory]') AND type in (N'U'))
DROP TABLE [dbo].[tblCategory]
GO
/****** Object:  Table [dbo].[tblNews]    Script Date: 07/30/2009 01:16:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblNews]') AND type in (N'U'))
DROP TABLE [dbo].[tblNews]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 07/30/2009 01:16:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblUser]') AND type in (N'U'))
DROP TABLE [dbo].[tblUser]
GO
/****** Object:  Table [dbo].[tblEmail]    Script Date: 07/30/2009 01:16:36 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblEmail]') AND type in (N'U'))
DROP TABLE [dbo].[tblEmail]
GO
/****** Object:  Table [dbo].[tblEmail]    Script Date: 07/30/2009 01:16:36 ******/
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
/****** Object:  Table [dbo].[tblUser]    Script Date: 07/30/2009 01:16:36 ******/
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
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[tblNews]    Script Date: 07/30/2009 01:16:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblNews]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblNews](
	[ID] [uniqueidentifier] NOT NULL,
	[TitleVN] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TitleEN] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SubjectVN] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SubjectEN] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContentVN] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContentEN] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Type] [tinyint] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PostedDate] [datetime] NULL,
	[PostedBy] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EndedBy] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EndedDate] [datetime] NULL,
	[Deleted] [bit] NULL,
	[Image] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_tblNews] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'72593ae0-cb17-49d6-82e5-0de78c2470c4', N'Image 8', NULL, NULL, NULL, N'<p>C&ugrave;ng với Ngọc Hải v&agrave; Ngọc H&agrave;, ba anh em Ngọc sơn đ&atilde; từng thực hiện nhiều chương tr&igrave;nh ca nhạc. Với giọng nam cao, ấm, khỏe c&oacute; &acirc;m vựng kh&aacute; rộng; với một phong c&aacute;ch chuy&ecirc;n nghiệp Ngọc Sơn kh&ocirc;ng chỉ để lại cho kh&aacute;n giả trong nước v&agrave; quốc tế ấn tượng với những ca kh&uacute;c d&acirc;n tộc đằm thắm, trữ t&igrave;nh m&agrave; anh c&ograve;n c&oacute; sức cuốn h&uacute;t bởi nhiều thể loại &acirc;m nhạc kh&aacute;c nhau như Pop, Rap,C&ugrave;ng với Ngọc Hải v&agrave; Ngọc H&agrave;, ba anh em Ngọc sơn đ&atilde; từng thực hiện nhiều chương tr&igrave;nh ca nhạc. Với giọng nam cao, ấm, khỏe c&oacute; &acirc;m vựng kh&aacute; rộng; với một phong c&aacute;ch chuy&ecirc;n nghiệp Ngọc Sơn kh&ocirc;ng chỉ để lại cho kh&aacute;n đ&atilde; từng thực hiện nhiều chương tr&igrave;nh ca nhạc. Với giọng nam cao, ấm, khỏe c&oacute; &acirc;m vựng kh&aacute; rộng; với một phong c&aacute;ch chuy&ecirc;n nghiệp Ngọc Sơn kh&ocirc;ng chỉ để lại cho kh&aacute;n</p>
<p>&nbsp;<img alt="" src="file:///C:/DOCUME~1/DUONGT~1/LOCALS~1/Temp/moz-screenshot-3.png" /><input src="/userfiles/image/image1.jpg" width="124" height="148" type="image" /><img alt="" src="file:///C:/DOCUME~1/DUONGT~1/LOCALS~1/Temp/moz-screenshot-2.png" /></p>
<p><img alt="" src="file:///C:/DOCUME~1/DUONGT~1/LOCALS~1/Temp/moz-screenshot-1.png" /></p>
<p>C&ugrave;ng với Ngọc Hải v&agrave; Ngọc H&agrave;, ba anh em Ngọc sơn đ&atilde; từng thực hiện nhiều chương tr&igrave;nh ca nhạc. Với giọng nam cao, ấm, khỏe c&oacute; &acirc;m vựng kh&aacute; rộng; với một phong c&aacute;ch chuy&ecirc;n nghiệp Ngọc Sơn kh&ocirc;ng chỉ để lại cho kh&aacute;n giả trong nước v&agrave; quốc tế ấn tượng với những ca kh&uacute;c d&acirc;n tộc đằm thắm, trữ t&igrave;nh m&agrave; anh c&ograve;n c&oacute; sức cuốn h&uacute;t bởi nhiều thể loại &acirc;m nhạc kh&aacute;c nhau như Pop, Rap,C&ugrave;ng với Ngọc Hải v&agrave; Ngọc H&agrave;, ba anh em Ngọc sơn đ&atilde; từng thực hiện nhiều chương tr&igrave;nh ca nhạc. Với giọng nam cao, ấm, khỏe c&oacute; &acirc;m vựng kh&aacute; rộng; với một phong c&aacute;ch chuy&ecirc;n nghiệp Ngọc Sơn kh&ocirc;ng chỉ để lại cho kh&aacute;n đ&atilde; từng thực hiện nhiều chương tr&igrave;nh ca nhạc. Với giọng nam cao, ấm, khỏe c&oacute; &acirc;sm vựng kh&aacute; rộng; với một phong c&aacute;ch chuy&ecirc;n nghiệp Ngọc Sơn kh&ocirc;ng chỉ để lại cho kh&aacute;n<input id="gwProxy" type="hidden" /><!--Session data--><input id="jsProxy" type="hidden" onclick="jsCall();" /></p>
<p>&nbsp;</p>
<p>Duong add more to test</p>
<div id="refHTML">&nbsp;</div>
<input id="gwProxy" type="hidden" /><!--Session data--><input id="jsProxy" type="hidden" onclick="jsCall();" />
<div id="refHTML">&nbsp;</div>
<input id="gwProxy" type="hidden" /><!--Session data--><input id="jsProxy" type="hidden" onclick="jsCall();" />
<div id="refHTML">&nbsp;</div>
<input id="gwProxy" type="hidden" /><!--Session data--><input id="jsProxy" type="hidden" onclick="jsCall();" />
<div id="refHTML">&nbsp;</div>
<input id="gwProxy" type="hidden" /><!--Session data--><input id="jsProxy" type="hidden" onclick="jsCall();" />
<div id="refHTML">&nbsp;</div>
<input id="gwProxy" type="hidden" /><!--Session data-->
<p>&nbsp;</p>
<input id="jsProxy" type="hidden" onclick="jsCall();" />
<div id="refHTML">&nbsp;</div>', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/Admin/ImagesInTileNews/72593ae0cb1749d682e50de78c2470c4.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'4145b835-4a6d-42e4-95c5-1233d315f7d0', N'', NULL, N'', NULL, N'<p>&nbsp;</p>
<input type="hidden" id="gwProxy"><!--Session data--></input><input type="hidden" id="jsProxy" onclick="jsCall();" />
<div id="refHTML">&nbsp;</div>', NULL, 2, CAST(0x00009C55016B4041 AS DateTime), NULL, CAST(0x00009C55016B4041 AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ImagesInTileNews/4145b8354a6d42e495c51233d315f7d0.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'bd674eb2-8562-4ca7-ad56-1b42264e9897', N'Image 7', NULL, NULL, NULL, N'<p>&nbsp;</p>
<input type="hidden" id="gwProxy" /><!--Session data--><input type="hidden" onclick="jsCall();" id="jsProxy" />
<p>&nbsp;dsadsafdsfdsfdsfasdfafdf</p>
<input type="hidden" id="gwProxy" /><!--Session data--><input type="hidden" id="jsProxy" onclick="jsCall();" />
<div id="refHTML">&nbsp;</div>
<input type="hidden" id="gwProxy" /><!--Session data--><input type="hidden" onclick="jsCall();" id="jsProxy" />
<div id="refHTML">&nbsp;</div>
<input type="hidden" id="gwProxy" /><!--Session data--><input type="hidden" id="jsProxy" onclick="jsCall();" />
<div id="refHTML">&nbsp;</div>
<input type="hidden" id="gwProxy" /><!--Session data--><input type="hidden" onclick="jsCall();" id="jsProxy" />
<div id="refHTML">&nbsp;</div>
<input type="hidden" id="gwProxy" /><!--Session data--><input type="hidden" id="jsProxy" onclick="jsCall();" />
<div id="refHTML">&nbsp;</div>
<input type="hidden" id="gwProxy" /><!--Session data--><input type="hidden" onclick="jsCall();" id="jsProxy" />
<div id="refHTML">&nbsp;</div>
<input type="hidden" id="gwProxy" /><!--Session data--><input type="hidden" id="jsProxy" onclick="jsCall();" />
<div id="refHTML">&nbsp;</div>
<input type="hidden" id="gwProxy" /><!--Session data--><input type="hidden" onclick="jsCall();" id="jsProxy" />
<div id="refHTML">&nbsp;</div>
<input type="hidden" id="gwProxy"><!--Session data--></input><input type="hidden" id="jsProxy" onclick="jsCall();" />
<div id="refHTML">&nbsp;</div>', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/Admin/ImagesInTileNews/bd674eb285624ca7ad561b42264e9897.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'2ca303b2-0d52-4ef7-8f07-1e9f9610f258', N'Image 5', NULL, NULL, NULL, N'<p>&nbsp;</p>
<input type="hidden" id="gwProxy" /><!--Session data--><input type="hidden" onclick="jsCall();" id="jsProxy" />
<div id="refHTML">&nbsp;</div>
<p>sfdsfdsf</p>
<input type="hidden" id="gwProxy"><!--Session data--></input><input type="hidden" id="jsProxy" onclick="jsCall();" />
<div id="refHTML">&nbsp;</div>', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'962e5535-4880-4ce0-8f96-2e68b07ffa39', N'Image 9', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/Images/image4.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'd51e1cb0-58b7-4de7-9843-3161a742ca8d', N'', NULL, N'', NULL, N'<p>&nbsp;</p>
<input type="hidden" id="gwProxy"><!--Session data--></input><input type="hidden" id="jsProxy" onclick="jsCall();" />
<div id="refHTML">&nbsp;</div>', NULL, 1, CAST(0x00009C55016B29FD AS DateTime), NULL, CAST(0x00009C55016B29FD AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ImagesInTileNews/d51e1cb058b74de798433161a742ca8d.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'7b5bdd04-8fd3-4ff6-9dc3-3dd209bde783', N'fdsf', NULL, N'sdfdsfds', NULL, N'<p>&nbsp;</p>
<input type="hidden" id="gwProxy"><!--Session data--></input><input type="hidden" id="jsProxy" onclick="jsCall();" />
<div id="refHTML">&nbsp;</div>
<p>fdsfsdfdsfsdf</p>', NULL, NULL, CAST(0x00009C55002F9704 AS DateTime), NULL, CAST(0x00009C55002F9704 AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ImagesInTileNews/7b5bdd048fd34ff69dc33dd209bde783.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'38a2529a-9a2b-4a99-97cb-4076cf48fba8', N'', NULL, N'', NULL, N'<p>&nbsp;</p>
<input type="hidden" id="gwProxy"><!--Session data--></input><input type="hidden" id="jsProxy" onclick="jsCall();" />
<div id="refHTML">&nbsp;</div>', NULL, 1, CAST(0x00009C550165775A AS DateTime), NULL, CAST(0x00009C550165775A AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ImagesInTileNews/38a2529a9a2b4a9997cb4076cf48fba8.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'b10da267-a4f8-4034-a777-41a3a192f396', N'', NULL, N'', NULL, N'<p>&nbsp;</p>
<input type="hidden" id="gwProxy"><!--Session data--></input><input type="hidden" id="jsProxy" onclick="jsCall();" />
<div id="refHTML">&nbsp;</div>', NULL, 2, CAST(0x00009C55016B5E23 AS DateTime), NULL, CAST(0x00009C55016B5E23 AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ImagesInTileNews/b10da267a4f84034a77741a3a192f396.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'58b781df-efa6-4da6-8529-590fcb4a731b', N'fdsf', NULL, N'sdfdsfds', NULL, N'<p>&nbsp;</p>
<input type="hidden" id="gwProxy"><!--Session data--></input><input type="hidden" id="jsProxy" onclick="jsCall();" />
<div id="refHTML">&nbsp;</div>', NULL, NULL, CAST(0x00009C5500304F0E AS DateTime), NULL, CAST(0x00009C5500304F0E AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ImagesInTileNews/58b781dfefa64da68529590fcb4a731b.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'895d8f2e-b336-432c-86e2-59acf43b1fc3', N'fdf', NULL, N'dsfdsfdsf', NULL, N'<p>&nbsp;</p>
<input type="hidden" id="gwProxy"><!--Session data--></input><input type="hidden" id="jsProxy" onclick="jsCall();" />
<div id="refHTML">&nbsp;</div>
<p>fdsfdsfdfdsf</p>', NULL, NULL, CAST(0x00009C5500308C98 AS DateTime), NULL, CAST(0x00009C5500308C98 AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ImagesInTileNews/895d8f2eb336432c86e259acf43b1fc3.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'0824819f-b4fe-46cc-9d92-5d27c903b118', N'', NULL, N'', NULL, N'<p>&nbsp;</p>
<input type="hidden" id="gwProxy"><!--Session data--></input><input type="hidden" id="jsProxy" onclick="jsCall();" />
<div id="refHTML">&nbsp;</div>', NULL, 1, CAST(0x00009C55016B4B26 AS DateTime), NULL, CAST(0x00009C55016B4B26 AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ImagesInTileNews/0824819fb4fe46cc9d925d27c903b118.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'589f967b-1f89-429a-8165-68b98ceeb8ed', N'Image 6', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/Images/image1.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'b3d955f9-a477-4893-9e2a-7ce9fedf49ed', N'fdf', NULL, N'dsfdsfsdf', NULL, N'<p>fdsfdsfs</p>', NULL, 1, CAST(0x00009C5501698281 AS DateTime), NULL, CAST(0x00009C5501698281 AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ImagesInTileNews/b3d955f9a47748939e2a7ce9fedf49ed.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'449aa763-03bb-4789-b217-8450625ade62', N'Image 1', NULL, NULL, NULL, N'Cùng v?i Ng?c H?i và Ng?c Hà, ba anh em Ng?c son dã t?ng th?c hi?n nhi?u chuong trình ca nh?c. V?i gi?ng nam cao, ?m, kh?e có âm v?ng khá r?ng; v?i m?t phong cách chuyên nghi?p Ng?c Son không ch? d? l?i cho khán gi? trong nu?c và qu?c t? ?n tu?ng v?i nh?ng ca khúc dân t?c d?m th?m, tr? tình mà anh còn có s?c cu?n hút b?i nhi?u th? lo?i âm nh?c khác nhau nhu Pop, Rap,', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/Images/image1.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'5dde27b8-491c-41a4-ad82-86139cbfac14', N'gfdg', NULL, N'dfgdfgdf', NULL, N'<p>&nbsp;</p>
<input type="hidden" id="gwProxy"><!--Session data--></input><input type="hidden" id="jsProxy" onclick="jsCall();" />
<div id="refHTML">&nbsp;</div>
<p>gfdgdfgdgdf</p>', NULL, NULL, CAST(0x00009C5500313D09 AS DateTime), NULL, CAST(0x00009C5500313D09 AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ImagesInTileNews/5dde27b8491c41a4ad8286139cbfac14.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'dcb512eb-00d5-4643-b111-87346cf6318a', N'fdsfdsfsd', NULL, N'', NULL, N'<p>&nbsp;</p>
<input type="hidden" id="gwProxy"><!--Session data--></input><input type="hidden" id="jsProxy" onclick="jsCall();" />
<div id="refHTML">&nbsp;</div>
<p>fdsfdsfs</p>', NULL, 2, CAST(0x00009C5501699E56 AS DateTime), NULL, CAST(0x00009C5501699E56 AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ImagesInTileNews/dcb512eb00d54643b11187346cf6318a.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'981314e5-1686-4419-a033-926156334334', N'', NULL, N'', NULL, N'<p>&nbsp;</p>
<input type="hidden" id="gwProxy"><!--Session data--></input><input type="hidden" id="jsProxy" onclick="jsCall();" />
<div id="refHTML">&nbsp;</div>', NULL, 1, CAST(0x00009C55016583D7 AS DateTime), NULL, CAST(0x00009C55016583D7 AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ImagesInTileNews/981314e516864419a033926156334334.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'de21d991-28d5-4f59-b20a-9343f5e18015', N'Image 3', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/Images/image4.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'd107f9cb-f1ea-453b-89a4-9d8026d8f7fa', N'Tieu de day', NULL, NULL, NULL, N'<p>Test choi thoi ah</p>
<div id="refHTML">&nbsp;</div>', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'961dff3b-8994-41dd-a437-a6c458ce31a7', N'Image 2', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/Images/image2.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'a79141a4-72f7-492e-a924-afb25859de6c', N'fdsf', NULL, N'sdfdsfds', NULL, N'<p>fdsfdsfdsfdsf</p>
<div id="refHTML">&nbsp;</div>', NULL, NULL, CAST(0x00009C55002F2AA2 AS DateTime), NULL, CAST(0x00009C55002F2AA2 AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ImagesInTileNews/a79141a472f7492ea924afb25859de6c.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'3e9c0a50-e213-4a6c-ad57-b47bb1d98b42', N'', NULL, N'', NULL, N'<p>&nbsp;</p>
<input type="hidden" id="gwProxy"><!--Session data--></input><input type="hidden" id="jsProxy" onclick="jsCall();" />
<div id="refHTML">&nbsp;</div>', NULL, 2, CAST(0x00009C5500322B09 AS DateTime), NULL, CAST(0x00009C5500322B09 AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ImagesInTileNews/3e9c0a50e2134a6cad57b47bb1d98b42.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'a880ede7-7cd0-4e05-8cab-cdd616a0c3cb', N'', NULL, N'', NULL, N'<p>&nbsp;</p>
<input type="hidden" id="gwProxy"><!--Session data--></input><input type="hidden" id="jsProxy" onclick="jsCall();" />
<div id="refHTML">&nbsp;</div>', NULL, 1, CAST(0x00009C55016591A6 AS DateTime), NULL, CAST(0x00009C55016591A6 AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ImagesInTileNews/a880ede77cd04e058cabcdd616a0c3cb.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'0171af96-c75f-4e4c-bb1e-ce84c91006c9', N' [Movie] Night at the Museum: Battle of the Smithsonian (2009) [R5]', NULL, N'Cùng với Ngọc Hải và Ngọc Hà, ba anh em Ngọc sơn', NULL, N'<p>C&ugrave;ng với Ngọc Hải v&agrave; Ngọc H&agrave;, ba anh em Ngọc sơn đ&atilde; từng thực hiện nhiều chương tr&igrave;nh ca nhạc. Với giọng nam cao, ấm, khỏe c&oacute; &acirc;m vựng kh&aacute; rộng; với một phong c&aacute;ch chuy&ecirc;n nghiệp Ngọc Sơn kh&ocirc;ng chỉ để lại cho kh&aacute;n giả trong nước v&agrave; quốc tế ấn tượng với những ca kh&uacute;c d&acirc;n tộc đằm thắm, trữ t&igrave;nh m&agrave; anh c&ograve;n c&oacute; sức cuốn h&uacute;t bởi nhiều thể loại &acirc;m nhạc kh&aacute;c nhau như Pop, Rap,<br />
C&ugrave;ng với Ngọc Hải v&agrave; Ngọc H&agrave;, ba anh em Ngọc sơn đ&atilde; từng thực hiện nhiều chương tr&igrave;nh ca nhạc. Với giọng nam cao, ấm, khỏe c&oacute; &acirc;m vựng kh&aacute; rộng; với một phong c&aacute;ch chuy&ecirc;n nghiệp Ngọc Sơn kh&ocirc;ng chỉ để lại cho kh&aacute;n đ&atilde; từng thực hiện nhiều chương tr&igrave;nh ca nhạc. Với giọng nam cao, ấm, khỏe c&oacute; &acirc;m vựng kh&aacute; rộng; với một phong c&aacute;ch chuy&ecirc;n nghiệp Ngọc Sơn kh&ocirc;ng chỉ để lại cho kh&aacute;n</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>C&ugrave;ng với Ngọc Hải v&agrave; Ngọc H&agrave;, ba anh em Ngọc sơn đ&atilde; từng thực hiện nhiều chương tr&igrave;nh ca nhạc. Với giọng nam cao, ấm, khỏe c&oacute; &acirc;m vựng kh&aacute; rộng; với một phong c&aacute;ch chuy&ecirc;n nghiệp Ngọc Sơn kh&ocirc;ng chỉ để lại cho kh&aacute;n giả trong nước v&agrave; quốc tế ấn tượng với những ca kh&uacute;c d&acirc;n tộc đằm thắm, trữ t&igrave;nh m&agrave; anh c&ograve;n c&oacute; sức cuốn h&uacute;t bởi nhiều thể loại &acirc;m nhạc kh&aacute;c nhau như Pop, Rap,<br />
<br />
C&ugrave;ng với Ngọc Hải v&agrave; Ngọc H&agrave;, ba anh em Ngọc sơn đ&atilde; từng thực hiện nhiều chương tr&igrave;nh ca nhạc. Với giọng nam cao, ấm, khỏe c&oacute; &acirc;m vựng kh&aacute; rộng; với một phong c&aacute;ch chuy&ecirc;n nghiệp Ngọc Sơn kh&ocirc;ng chỉ để lại cho kh&aacute;n đ&atilde; từng thực hiện nhiều chương tr&igrave;nh ca nhạc. Với giọng nam cao, ấm, khỏe c&oacute; &acirc;m vựng kh&aacute; rộng; với một phong c&aacute;ch chuy&ecirc;n nghiệp Ngọc Sơn kh&ocirc;ng chỉ để lại cho kh&aacute;n</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p style="text-align: center;"><input width="475" type="image" height="291" src="/NGUYENHIEP/uploads/image/imgSlide.jpg" /></p>
<p>C&ugrave;ng với Ngọc Hải v&agrave; Ngọc H&agrave;, ba anh em Ngọc sơn đ&atilde; từng thực hiện nhiều chương tr&igrave;nh ca nhạc. Với giọng nam cao, ấm, khỏe c&oacute; &acirc;m vựng kh&aacute; rộng; với một phong c&aacute;ch chuy&ecirc;n nghiệp Ngọc Sơn kh&ocirc;ng chỉ để lại cho kh&aacute;n giả trong nước v&agrave; quốc tế ấn tượng với những ca kh&uacute;c d&acirc;n tộc đằm thắm, trữ t&igrave;nh m&agrave; anh c&ograve;n c&oacute; sức cuốn h&uacute;t bởi nhiều thể loại &acirc;m nhạc kh&aacute;c nhau như Pop, Rap,<br />
C&ugrave;ng với Ngọc Hải v&agrave; Ngọc H&agrave;, ba anh em Ngọc sơn đ&atilde; từng thực hiện nhiều chương tr&igrave;nh ca nhạc. Với giọng nam cao, ấm, khỏe c&oacute; &acirc;m vựng kh&aacute; rộng; với một phong c&aacute;ch chuy&ecirc;n nghiệp Ngọc Sơn kh&ocirc;ng chỉ để lại cho kh&aacute;n đ&atilde; từng thực hiện nhiều chương tr&igrave;nh ca nhạc. Với giọng nam cao, ấm, khỏe c&oacute; &acirc;sm vựng kh&aacute; rộng; với một phong c&aacute;ch chuy&ecirc;n nghiệp Ngọc Sơn kh&ocirc;ng chỉ để lại cho kh&aacute;n</p>
<p>&nbsp;</p>
<p class="textRight bold" style="text-align: right;">NGuyen Han</p>
<input type="hidden" id="gwProxy" /><!--Session data--><input type="hidden" onclick="jsCall();" id="jsProxy" />
<div id="refHTML">&nbsp;</div>
<input type="hidden" id="gwProxy"><!--Session data--></input><input type="hidden" id="jsProxy" onclick="jsCall();" />
<div id="refHTML">&nbsp;</div>', NULL, 1, CAST(0x00009C5500319F9F AS DateTime), NULL, CAST(0x00009C5500319F9F AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ImagesInTileNews/0171af96c75f4e4cbb1ece84c91006c9.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'4f66b44d-d7d0-4929-88f0-d27e851201c6', N'Image 4', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/Images/image5.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'47d44058-bba6-4ad7-8d05-d5361d393504', N'fdsfdsf', NULL, N'dsfdsfsdfsdfdsfds', NULL, N'<p>&nbsp;</p>
<input type="hidden" id="gwProxy"><!--Session data--></input><input type="hidden" id="jsProxy" onclick="jsCall();" />
<p>fdsfdsfdsfsdfdsfsdf</p>
<div id="refHTML">&nbsp;</div>', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/Admin/ImagesInTileNews/47d44058bba64ad78d05d5361d393504.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'77af7d19-8c5b-453b-a8ef-d8a1cd012d77', N'fdsfds', NULL, N'', NULL, N'<p>&nbsp;</p>
<div id="refHTML">fdsfdsfdsfsdfdsf&nbsp;</div>', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'/Admin/ImagesInTileNews/77af7d198c5b453ba8efd8a1cd012d77.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'03f43955-d757-4507-a832-dc6d1e74941a', N'', NULL, N'', NULL, N'<p>&nbsp;</p>
<input type="hidden" id="gwProxy"><!--Session data--></input><input type="hidden" id="jsProxy" onclick="jsCall();" />
<div id="refHTML">&nbsp;</div>', NULL, 1, CAST(0x00009C550165693C AS DateTime), NULL, CAST(0x00009C550165693C AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ImagesInTileNews/03f43955d7574507a832dc6d1e74941a.jpg')
INSERT [dbo].[tblNews] ([ID], [TitleVN], [TitleEN], [SubjectVN], [SubjectEN], [ContentVN], [ContentEN], [Type], [CreatedDate], [CreatedBy], [PostedDate], [PostedBy], [EndedBy], [EndedDate], [Deleted], [Image]) VALUES (N'335d3fa0-dbb5-403c-b526-e03ffaecff0d', N' [Movie] Night at the Museum: Battle of the Smithsonian (2009) [R5]', NULL, N'', NULL, N'<p>C&ugrave;ng với Ngọc Hải v&agrave; Ngọc H&agrave;, ba anh em Ngọc sơn đ&atilde; từng thực hiện nhiều chương tr&igrave;nh ca nhạc. Với giọng nam cao, ấm, khỏe c&oacute; &acirc;m vựng kh&aacute; rộng; với một phong c&aacute;ch chuy&ecirc;n nghiệp Ngọc Sơn kh&ocirc;ng chỉ để lại cho kh&aacute;n giả trong nước v&agrave; quốc tế ấn tượng với những ca kh&uacute;c d&acirc;n tộc đằm thắm, trữ t&igrave;nh m&agrave; anh c&ograve;n c&oacute; sức cuốn h&uacute;t bởi nhiều thể loại &acirc;m nhạc kh&aacute;c nhau như Pop, Rap,&lt;BR /&gt;<br />
C&ugrave;ng với Ngọc Hải v&agrave; Ngọc H&agrave;, ba anh em Ngọc sơn đ&atilde; từng thực hiện nhiều chương tr&igrave;nh ca nhạc. Với giọng nam cao, ấm, khỏe c&oacute; &acirc;m vựng kh&aacute; rộng; với một phong c&aacute;ch chuy&ecirc;n nghiệp Ngọc Sơn kh&ocirc;ng chỉ để lại cho kh&aacute;n đ&atilde; từng thực hiện nhiều chương tr&igrave;nh ca nhạc. Với giọng nam cao, ấm, khỏe c&oacute; &acirc;m vựng kh&aacute; rộng; với một phong c&aacute;ch chuy&ecirc;n nghiệp Ngọc Sơn kh&ocirc;ng chỉ để lại cho kh&aacute;n &lt;/p&gt;</p>
<p style="text-align: center;"><input width="475" type="image" height="291" src="/NGUYENHIEP/uploads/image/imgSlide.jpg" /></p>
<p style="text-align: center;"><input width="475" type="image" height="291" src="/NGUYENHIEP/uploads/image/imgSlide.jpg" /></p>
<p style="text-align: center;"><input width="475" type="image" height="291" src="/NGUYENHIEP/uploads/image/imgSlide.jpg" /></p>
<p style="text-align: center;"><input width="475" type="image" height="291" src="/NGUYENHIEP/uploads/image/imgSlide.jpg" /></p>
<p style="text-align: center;">&nbsp;</p>
<p>C&ugrave;ng với Ngọc Hải v&agrave; Ngọc H&agrave;, ba anh em Ngọc sơn đ&atilde; từng thực hiện nhiều chương tr&igrave;nh ca nhạc. Với giọng nam cao, ấm, khỏe c&oacute; &acirc;m vựng kh&aacute; rộng; với một phong c&aacute;ch chuy&ecirc;n nghiệp Ngọc Sơn kh&ocirc;ng chỉ để lại cho kh&aacute;n giả trong nước v&agrave; quốc tế ấn tượng với những ca kh&uacute;c d&acirc;n tộc đằm thắm, trữ t&igrave;nh m&agrave; anh c&ograve;n c&oacute; sức cuốn h&uacute;t bởi nhiều thể loại &acirc;m nhạc kh&aacute;c nhau như Pop, Rap,<br />
C&ugrave;ng với Ngọc Hải v&agrave; Ngọc H&agrave;, ba anh em Ngọc sơn đ&atilde; từng thực hiện nhiều chương tr&igrave;nh ca nhạc. Với giọng nam cao, ấm, khỏe c&oacute; &acirc;m vựng kh&aacute; rộng; với một phong c&aacute;ch chuy&ecirc;n nghiệp Ngọc Sơn kh&ocirc;ng chỉ để lại cho kh&aacute;n đ&atilde; từng thực hiện nhiều chương tr&igrave;nh ca nhạc. Với giọng nam cao, ấm, khỏe c&oacute; &acirc;sm vựng kh&aacute; rộng; với một phong c&aacute;ch chuy&ecirc;n nghiệp Ngọc Sơn kh&ocirc;ng chỉ để lại cho kh&aacute;n</p>
<p>&nbsp;</p>
<p class="textRight bold" style="text-align: right;">NGuyen Han</p>', NULL, 2, CAST(0x00009C55016B6C00 AS DateTime), NULL, CAST(0x00009C55016B6C00 AS DateTime), NULL, NULL, NULL, NULL, N'/Admin/ImagesInTileNews/335d3fa0dbb5403cb526e03ffaecff0d.jpg')
/****** Object:  Table [dbo].[tblCategory]    Script Date: 07/30/2009 01:16:36 ******/
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
 CONSTRAINT [PK_tblCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[tblInformation]    Script Date: 07/30/2009 01:16:36 ******/
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
/****** Object:  Table [dbo].[tblProduct]    Script Date: 07/30/2009 01:16:36 ******/
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
	[Description] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PriceVN] [int] NULL,
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
INSERT [dbo].[tblProduct] ([ID], [ProductNo], [CategoryID], [ProductNameVN], [ProductNameEN], [Description], [PriceVN], [PriceEN], [Image], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Deleted], [Promoted], [StoreStatus], [WarrantyTime], [Property]) VALUES (N'bf8efff8-6cf7-456a-a3e5-755630ea2be7', NULL, NULL, N'trêtrt', NULL, N'<p>tr&ecirc;trtertertertẻt</p>', NULL, NULL, N'/Admin/ImagesInTileNews/bf8efff86cf7456aa3e5755630ea2be7.jpg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblProduct] ([ID], [ProductNo], [CategoryID], [ProductNameVN], [ProductNameEN], [Description], [PriceVN], [PriceEN], [Image], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Deleted], [Promoted], [StoreStatus], [WarrantyTime], [Property]) VALUES (N'da74b670-2d38-40ac-8d88-7c914b6e9af3', NULL, NULL, N'Ten san pham', NULL, N'<p>&nbsp;</p>
<input type="hidden" id="gwProxy"><!--Session data--></input><input type="hidden" id="jsProxy" onclick="jsCall();" />
<div id="refHTML">&nbsp;</div>', NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x00009C5400254FE1 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblProduct] ([ID], [ProductNo], [CategoryID], [ProductNameVN], [ProductNameEN], [Description], [PriceVN], [PriceEN], [Image], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Deleted], [Promoted], [StoreStatus], [WarrantyTime], [Property]) VALUES (N'd385079b-1251-4ee8-b675-aab45d353cdf', NULL, NULL, N'ddddddddddddddddddddddddd', NULL, N'', NULL, NULL, N'', NULL, NULL, NULL, CAST(0x00009C540029AECD AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblProduct] ([ID], [ProductNo], [CategoryID], [ProductNameVN], [ProductNameEN], [Description], [PriceVN], [PriceEN], [Image], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Deleted], [Promoted], [StoreStatus], [WarrantyTime], [Property]) VALUES (N'6ab137d4-2cf3-4fb4-86ad-ccf7067edd23', NULL, NULL, N'trêtrtert', NULL, N'<p>tểtrtertertertẻ</p>', NULL, NULL, N'/Admin/ImagesInTileNews/6ab137d42cf34fb486adccf7067edd23.jpg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tblProduct] ([ID], [ProductNo], [CategoryID], [ProductNameVN], [ProductNameEN], [Description], [PriceVN], [PriceEN], [Image], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate], [Deleted], [Promoted], [StoreStatus], [WarrantyTime], [Property]) VALUES (N'3afa7369-7172-40ba-8d65-f31ef08cc2d6', NULL, NULL, N'tét choi fdfsd', NULL, N'<p>fdsfdsfsdfsdfsdfsdfs</p>', NULL, NULL, N'/Admin/ImagesInTileNews/3afa7369717240ba8d65f31ef08cc2d6.jpg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
/****** Object:  ForeignKey [FK_tblProduct_tblCategory]    Script Date: 07/30/2009 01:16:36 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblProduct_tblCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblProduct]'))
ALTER TABLE [dbo].[tblProduct]  WITH CHECK ADD  CONSTRAINT [FK_tblProduct_tblCategory] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[tblCategory] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblProduct_tblCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblProduct]'))
ALTER TABLE [dbo].[tblProduct] CHECK CONSTRAINT [FK_tblProduct_tblCategory]
GO
