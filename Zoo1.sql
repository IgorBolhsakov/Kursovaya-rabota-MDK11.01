USE [master]
GO
/****** Object:  Database [Zoo1]    Script Date: 10.10.2022 7:33:57 ******/
CREATE DATABASE [Zoo1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Zoo1', FILENAME = N'F:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Zoo1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Zoo1_log', FILENAME = N'F:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Zoo1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Zoo1] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Zoo1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Zoo1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Zoo1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Zoo1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Zoo1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Zoo1] SET ARITHABORT OFF 
GO
ALTER DATABASE [Zoo1] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Zoo1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Zoo1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Zoo1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Zoo1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Zoo1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Zoo1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Zoo1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Zoo1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Zoo1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Zoo1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Zoo1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Zoo1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Zoo1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Zoo1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Zoo1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Zoo1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Zoo1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Zoo1] SET  MULTI_USER 
GO
ALTER DATABASE [Zoo1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Zoo1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Zoo1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Zoo1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Zoo1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Zoo1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Zoo1] SET QUERY_STORE = OFF
GO
USE [Zoo1]
GO
/****** Object:  Table [dbo].[Вальер]    Script Date: 10.10.2022 7:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Вальер](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Размер] [varchar](50) NULL,
	[Описание] [varchar](255) NULL,
	[Количество_животных_внутри] [int] NULL,
 CONSTRAINT [PK_Вальер] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Вид_животного]    Script Date: 10.10.2022 7:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Вид_животного](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Наименование] [varchar](50) NULL,
	[id_корма] [int] NULL,
 CONSTRAINT [PK_Вид_животного] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Должность]    Script Date: 10.10.2022 7:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Должность](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Наименование] [varchar](50) NULL,
 CONSTRAINT [PK_Должность] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Животное]    Script Date: 10.10.2022 7:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Животное](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Кличка] [varchar](50) NULL,
	[id_вольера] [int] NULL,
	[id_вида_животного] [int] NULL,
 CONSTRAINT [PK_Животное] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Заказ_корма]    Script Date: 10.10.2022 7:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Заказ_корма](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Логин_пользователя] [varchar](50) NULL,
	[id_корма] [int] NULL,
	[Дата] [date] NULL,
	[Сумма] [decimal](18, 2) NULL,
	[Количество] [int] NULL,
 CONSTRAINT [PK_Заказ_корма] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[История_расхода_корма]    Script Date: 10.10.2022 7:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[История_расхода_корма](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Логин_пользователя] [varchar](50) NULL,
	[Дата_и_время] [datetime] NULL,
	[id_корма] [int] NULL,
	[Количество] [int] NULL,
	[Сумма] [decimal](18, 2) NULL,
 CONSTRAINT [PK_История_расхода_корма] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Корм]    Script Date: 10.10.2022 7:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Корм](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Наименование] [varchar](50) NULL,
	[Цена] [decimal](18, 2) NULL,
	[Количество] [int] NULL,
 CONSTRAINT [PK_Корм] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Пользователь]    Script Date: 10.10.2022 7:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Пользователь](
	[Логин] [varchar](50) NOT NULL,
	[Пароль] [varchar](50) NULL,
	[id_должности] [int] NULL,
	[id_статуса] [int] NULL,
	[ФИО] [varchar](255) NULL,
	[Паспорт] [varchar](10) NULL,
 CONSTRAINT [PK_Пользователь] PRIMARY KEY CLUSTERED 
(
	[Логин] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Статус]    Script Date: 10.10.2022 7:33:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Статус](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Наименование] [varchar](50) NULL,
 CONSTRAINT [PK_Статус] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Вальер] ON 

INSERT [dbo].[Вальер] ([id], [Размер], [Описание], [Количество_животных_внутри]) VALUES (1, N'70x120', N'aksjdlasjdlkasdjlasjk
kasjdkasjdlas
icvosjdivjsoijdvosdjivo', 1)
INSERT [dbo].[Вальер] ([id], [Размер], [Описание], [Количество_животных_внутри]) VALUES (2, N'100x100', N'Вольер для куриц', 1)
INSERT [dbo].[Вальер] ([id], [Размер], [Описание], [Количество_животных_внутри]) VALUES (3, N'17x17 m', N'Вольер предназначенный для парнокопытных животных', 0)
SET IDENTITY_INSERT [dbo].[Вальер] OFF
GO
SET IDENTITY_INSERT [dbo].[Вид_животного] ON 

INSERT [dbo].[Вид_животного] ([id], [Наименование], [id_корма]) VALUES (1, N'Пингвин', 2)
INSERT [dbo].[Вид_животного] ([id], [Наименование], [id_корма]) VALUES (2, N'Курица', 1)
SET IDENTITY_INSERT [dbo].[Вид_животного] OFF
GO
SET IDENTITY_INSERT [dbo].[Должность] ON 

INSERT [dbo].[Должность] ([id], [Наименование]) VALUES (1, N'Сотрудник')
INSERT [dbo].[Должность] ([id], [Наименование]) VALUES (2, N'Мл.Менеджер')
INSERT [dbo].[Должность] ([id], [Наименование]) VALUES (3, N'Ст.Менеджер')
INSERT [dbo].[Должность] ([id], [Наименование]) VALUES (4, N'Директор')
SET IDENTITY_INSERT [dbo].[Должность] OFF
GO
SET IDENTITY_INSERT [dbo].[Животное] ON 

INSERT [dbo].[Животное] ([id], [Кличка], [id_вольера], [id_вида_животного]) VALUES (1, N'Пин', 1, 1)
INSERT [dbo].[Животное] ([id], [Кличка], [id_вольера], [id_вида_животного]) VALUES (4, N'Коко', 2, 2)
SET IDENTITY_INSERT [dbo].[Животное] OFF
GO
SET IDENTITY_INSERT [dbo].[Заказ_корма] ON 

INSERT [dbo].[Заказ_корма] ([id], [Логин_пользователя], [id_корма], [Дата], [Сумма], [Количество]) VALUES (9, N'm1', 2, CAST(N'2022-10-10' AS Date), CAST(613.17 AS Decimal(18, 2)), 3)
SET IDENTITY_INSERT [dbo].[Заказ_корма] OFF
GO
SET IDENTITY_INSERT [dbo].[История_расхода_корма] ON 

INSERT [dbo].[История_расхода_корма] ([id], [Логин_пользователя], [Дата_и_время], [id_корма], [Количество], [Сумма]) VALUES (1, N's', CAST(N'2022-10-10T00:00:00.000' AS DateTime), 1, 2, CAST(802.74 AS Decimal(18, 2)))
INSERT [dbo].[История_расхода_корма] ([id], [Логин_пользователя], [Дата_и_время], [id_корма], [Количество], [Сумма]) VALUES (2, N's', CAST(N'2022-10-10T00:00:00.000' AS DateTime), 2, 2, CAST(408.78 AS Decimal(18, 2)))
INSERT [dbo].[История_расхода_корма] ([id], [Логин_пользователя], [Дата_и_время], [id_корма], [Количество], [Сумма]) VALUES (3, N's', CAST(N'2022-10-10T00:00:00.000' AS DateTime), 1, 1, CAST(47.22 AS Decimal(18, 2)))
INSERT [dbo].[История_расхода_корма] ([id], [Логин_пользователя], [Дата_и_время], [id_корма], [Количество], [Сумма]) VALUES (4, N's', CAST(N'2022-10-10T03:39:10.000' AS DateTime), 1, 1, CAST(47.22 AS Decimal(18, 2)))
INSERT [dbo].[История_расхода_корма] ([id], [Логин_пользователя], [Дата_и_время], [id_корма], [Количество], [Сумма]) VALUES (5, N's', CAST(N'2022-10-10T07:12:37.000' AS DateTime), 2, 2, CAST(408.78 AS Decimal(18, 2)))
INSERT [dbo].[История_расхода_корма] ([id], [Логин_пользователя], [Дата_и_время], [id_корма], [Количество], [Сумма]) VALUES (6, N's', CAST(N'2022-10-10T07:20:04.000' AS DateTime), 1, 3, CAST(591.90 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[История_расхода_корма] OFF
GO
SET IDENTITY_INSERT [dbo].[Корм] ON 

INSERT [dbo].[Корм] ([id], [Наименование], [Цена], [Количество]) VALUES (1, N'Пшеница', CAST(197.30 AS Decimal(18, 2)), 10)
INSERT [dbo].[Корм] ([id], [Наименование], [Цена], [Количество]) VALUES (2, N'Рыба', CAST(204.39 AS Decimal(18, 2)), 15)
SET IDENTITY_INSERT [dbo].[Корм] OFF
GO
INSERT [dbo].[Пользователь] ([Логин], [Пароль], [id_должности], [id_статуса], [ФИО], [Паспорт]) VALUES (N'd', N'd', 4, 2, N'Дир', N'5716478963')
INSERT [dbo].[Пользователь] ([Логин], [Пароль], [id_должности], [id_статуса], [ФИО], [Паспорт]) VALUES (N'm1', N'm1', 2, 1, N'Ботько Виктор Сергеевич', N'9435902937')
INSERT [dbo].[Пользователь] ([Логин], [Пароль], [id_должности], [id_статуса], [ФИО], [Паспорт]) VALUES (N'ml', N'ml', 2, 1, N'Иванов Иван Иванович', N'8926498236')
INSERT [dbo].[Пользователь] ([Логин], [Пароль], [id_должности], [id_статуса], [ФИО], [Паспорт]) VALUES (N'pd', N'pd', 1, 1, N'Прокофьев Денис', N'1234567890')
INSERT [dbo].[Пользователь] ([Логин], [Пароль], [id_должности], [id_статуса], [ФИО], [Паспорт]) VALUES (N's', N's', 1, 1, N'Федоренко Фёдор Фёдорович', N'1165489238')
INSERT [dbo].[Пользователь] ([Логин], [Пароль], [id_должности], [id_статуса], [ФИО], [Паспорт]) VALUES (N'sm', N'sm', 3, 1, N'Петров Петр Петрович', N'2727468172')
GO
SET IDENTITY_INSERT [dbo].[Статус] ON 

INSERT [dbo].[Статус] ([id], [Наименование]) VALUES (1, N'В штате')
INSERT [dbo].[Статус] ([id], [Наименование]) VALUES (2, N'На больничном')
INSERT [dbo].[Статус] ([id], [Наименование]) VALUES (3, N'Уволен')
SET IDENTITY_INSERT [dbo].[Статус] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Животное__4D6C7FF872652DE2]    Script Date: 10.10.2022 7:33:57 ******/
ALTER TABLE [dbo].[Животное] ADD UNIQUE NONCLUSTERED 
(
	[Кличка] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Вид_животного]  WITH CHECK ADD  CONSTRAINT [FK_Вид_животного_Корм] FOREIGN KEY([id_корма])
REFERENCES [dbo].[Корм] ([id])
GO
ALTER TABLE [dbo].[Вид_животного] CHECK CONSTRAINT [FK_Вид_животного_Корм]
GO
ALTER TABLE [dbo].[Животное]  WITH CHECK ADD  CONSTRAINT [FK_Животное_Вальер] FOREIGN KEY([id_вольера])
REFERENCES [dbo].[Вальер] ([id])
GO
ALTER TABLE [dbo].[Животное] CHECK CONSTRAINT [FK_Животное_Вальер]
GO
ALTER TABLE [dbo].[Животное]  WITH CHECK ADD  CONSTRAINT [FK_Животное_Вид_животного] FOREIGN KEY([id_вида_животного])
REFERENCES [dbo].[Вид_животного] ([id])
GO
ALTER TABLE [dbo].[Животное] CHECK CONSTRAINT [FK_Животное_Вид_животного]
GO
ALTER TABLE [dbo].[Заказ_корма]  WITH CHECK ADD  CONSTRAINT [FK_Заказ_корма_Корм] FOREIGN KEY([id_корма])
REFERENCES [dbo].[Корм] ([id])
GO
ALTER TABLE [dbo].[Заказ_корма] CHECK CONSTRAINT [FK_Заказ_корма_Корм]
GO
ALTER TABLE [dbo].[Заказ_корма]  WITH CHECK ADD  CONSTRAINT [FK_Заказ_корма_Пользователь] FOREIGN KEY([Логин_пользователя])
REFERENCES [dbo].[Пользователь] ([Логин])
GO
ALTER TABLE [dbo].[Заказ_корма] CHECK CONSTRAINT [FK_Заказ_корма_Пользователь]
GO
ALTER TABLE [dbo].[История_расхода_корма]  WITH CHECK ADD  CONSTRAINT [FK_История_расхода_корма_Корм] FOREIGN KEY([id_корма])
REFERENCES [dbo].[Корм] ([id])
GO
ALTER TABLE [dbo].[История_расхода_корма] CHECK CONSTRAINT [FK_История_расхода_корма_Корм]
GO
ALTER TABLE [dbo].[История_расхода_корма]  WITH CHECK ADD  CONSTRAINT [FK_История_расхода_корма_Пользователь] FOREIGN KEY([Логин_пользователя])
REFERENCES [dbo].[Пользователь] ([Логин])
GO
ALTER TABLE [dbo].[История_расхода_корма] CHECK CONSTRAINT [FK_История_расхода_корма_Пользователь]
GO
ALTER TABLE [dbo].[Пользователь]  WITH CHECK ADD  CONSTRAINT [FK_Пользователь_Должность] FOREIGN KEY([id_должности])
REFERENCES [dbo].[Должность] ([id])
GO
ALTER TABLE [dbo].[Пользователь] CHECK CONSTRAINT [FK_Пользователь_Должность]
GO
ALTER TABLE [dbo].[Пользователь]  WITH CHECK ADD  CONSTRAINT [FK_Пользователь_Статус] FOREIGN KEY([id_статуса])
REFERENCES [dbo].[Статус] ([id])
GO
ALTER TABLE [dbo].[Пользователь] CHECK CONSTRAINT [FK_Пользователь_Статус]
GO
USE [master]
GO
ALTER DATABASE [Zoo1] SET  READ_WRITE 
GO
