USE [HasConversions]
GO
/****** Object:  Table [dbo].[Dictionary]    Script Date: 12/14/2023 2:56:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dictionary](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Data] [nvarchar](max) NULL,
 CONSTRAINT [PK_Dictionary] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Dictionary] ON 

INSERT [dbo].[Dictionary] ([Id], [Data]) VALUES (1, N'{"Key":"K1","Value":"V1"}')
INSERT [dbo].[Dictionary] ([Id], [Data]) VALUES (2, N'{"Key":"K2","Value":"V2"}')
INSERT [dbo].[Dictionary] ([Id], [Data]) VALUES (3, N'{"Key":"K3","Value":"V3"}')
SET IDENTITY_INSERT [dbo].[Dictionary] OFF
GO
