USE [master]
GO
/****** Object:  Database [AdvWorks]    Script Date: 2/26/2017 7:09:03 PM ******/
CREATE DATABASE [AdvWorks]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AdvWorks', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\AdvWorks.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AdvWorks_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\AdvWorks_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [AdvWorks] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AdvWorks].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AdvWorks] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AdvWorks] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AdvWorks] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AdvWorks] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AdvWorks] SET ARITHABORT OFF 
GO
ALTER DATABASE [AdvWorks] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AdvWorks] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AdvWorks] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AdvWorks] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AdvWorks] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AdvWorks] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AdvWorks] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AdvWorks] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AdvWorks] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AdvWorks] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AdvWorks] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AdvWorks] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AdvWorks] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AdvWorks] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AdvWorks] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AdvWorks] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AdvWorks] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AdvWorks] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AdvWorks] SET  MULTI_USER 
GO
ALTER DATABASE [AdvWorks] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AdvWorks] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AdvWorks] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AdvWorks] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AdvWorks] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AdvWorks] SET QUERY_STORE = OFF
GO
USE [AdvWorks]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [AdvWorks]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2/26/2017 7:09:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ProductNumber] [nvarchar](25) NOT NULL,
	[MakeFlag] [bit] NULL,
	[FinishedGoodsFlag] [bit] NULL,
	[Color] [nvarchar](15) NULL,
	[SafetyStockLevel] [smallint] NULL,
	[ReorderPoint] [smallint] NULL,
	[StandardCost] [money] NULL,
	[ListPrice] [money] NULL,
	[Size] [nvarchar](5) NULL,
 CONSTRAINT [PK_Product_ProductID] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[sp_Delete_Product]    Script Date: 2/26/2017 7:09:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Delete_Product]
	@ProductID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DELETE FROM [dbo].[Product] WHERE [ProductID] = @ProductID

END

GO
/****** Object:  StoredProcedure [dbo].[sp_Get_All_Products]    Script Date: 2/26/2017 7:09:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_Get_All_Products]
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT [ProductID],[Name],[ProductNumber],[MakeFlag],[FinishedGoodsFlag],[Color],
                    [SafetyStockLevel],[ReorderPoint],[StandardCost],[ListPrice],[Size] FROM [dbo].[Product]
END

GO
/****** Object:  StoredProcedure [dbo].[sp_Get_Product_By_ID]    Script Date: 2/26/2017 7:09:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_Get_Product_By_ID]
@ProductID int
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT [ProductID],[Name],[ProductNumber],[MakeFlag],[FinishedGoodsFlag],[Color],
		[SafetyStockLevel],[ReorderPoint],[StandardCost],[ListPrice],[Size] 
	FROM [dbo].[Product] 
	WHERE [ProductID]=@ProductID
END

GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_Product]    Script Date: 2/26/2017 7:09:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_Insert_Product]
	@Name	nvarchar(100),
	@ProductNumber	nvarchar(50),
	@MakeFlag	bit NULL,
	@FinishedGoodsFlag	bit NULL,
	@Color	nvarchar(30) NULL,
	@SafetyStockLevel	smallint NULL,
	@ReorderPoint	smallint NULL,
	@StandardCost	money NULL,
	@ListPrice	money NULL,
	@Size	nvarchar(10) NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Product]([Name],[ProductNumber],[MakeFlag],[FinishedGoodsFlag],[Color],
		[SafetyStockLevel],[ReorderPoint],[StandardCost],[ListPrice],[Size])
    VALUES(@Name, @ProductNumber, @MakeFlag, @FinishedGoodsFlag,@Color,
		@SafetyStockLevel,@ReorderPoint,@StandardCost,@ListPrice,@Size)
END

GO
/****** Object:  StoredProcedure [dbo].[sp_Update_Product]    Script Date: 2/26/2017 7:09:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update_Product]
	@ProductID int,
	@Name	nvarchar(100),
	@ProductNumber	nvarchar(50),
	@MakeFlag	bit NULL,
	@FinishedGoodsFlag	bit NULL,
	@Color	nvarchar(30) NULL,
	@SafetyStockLevel	smallint NULL,
	@ReorderPoint	smallint NULL,
	@StandardCost	money NULL,
	@ListPrice	money NULL,
	@Size	nvarchar(10) NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE [dbo].[Product]
	   SET [Name] = @Name
		  ,[ProductNumber] = @ProductNumber
		  ,[MakeFlag] = @MakeFlag
		  ,[FinishedGoodsFlag] = @FinishedGoodsFlag
		  ,[Color] = @Color
		  ,[SafetyStockLevel] = @SafetyStockLevel
		  ,[ReorderPoint] = @ReorderPoint
		  ,[StandardCost] = @StandardCost
		  ,[ListPrice] = @ListPrice
		  ,[Size] = @Size
	 WHERE [ProductID] = @ProductID

END

GO
USE [master]
GO
ALTER DATABASE [AdvWorks] SET  READ_WRITE 
GO
