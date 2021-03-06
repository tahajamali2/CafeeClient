USE [master]
GO
/****** Object:  Database [InternetcafeManagment]    Script Date: 6/16/2017 3:12:46 AM ******/
CREATE DATABASE [InternetcafeManagment]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InternetcafeManagment', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\InternetcafeManagment.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'InternetcafeManagment_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\InternetcafeManagment_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [InternetcafeManagment] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InternetcafeManagment].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InternetcafeManagment] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InternetcafeManagment] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InternetcafeManagment] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InternetcafeManagment] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InternetcafeManagment] SET ARITHABORT OFF 
GO
ALTER DATABASE [InternetcafeManagment] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [InternetcafeManagment] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InternetcafeManagment] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InternetcafeManagment] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InternetcafeManagment] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InternetcafeManagment] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InternetcafeManagment] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InternetcafeManagment] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InternetcafeManagment] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InternetcafeManagment] SET  ENABLE_BROKER 
GO
ALTER DATABASE [InternetcafeManagment] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InternetcafeManagment] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InternetcafeManagment] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InternetcafeManagment] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InternetcafeManagment] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InternetcafeManagment] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [InternetcafeManagment] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InternetcafeManagment] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [InternetcafeManagment] SET  MULTI_USER 
GO
ALTER DATABASE [InternetcafeManagment] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InternetcafeManagment] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InternetcafeManagment] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InternetcafeManagment] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [InternetcafeManagment] SET DELAYED_DURABILITY = DISABLED 
GO
USE [InternetcafeManagment]
GO
/****** Object:  Table [dbo].[Computers]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Computers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pcname] [varchar](max) NOT NULL,
	[ipaddress] [varchar](max) NOT NULL,
	[floorid] [int] NOT NULL CONSTRAINT [DF_Computers_floorid]  DEFAULT ((0)),
	[isactive] [bit] NOT NULL CONSTRAINT [DF__Computers__isact__286302EC]  DEFAULT ((1)),
	[status] [int] NOT NULL,
	[port] [int] NULL,
 CONSTRAINT [PK__Computer__3213E83F6A74C0AC] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](max) NOT NULL,
	[contact] [varchar](max) NOT NULL,
	[username] [varchar](max) NOT NULL,
	[password] [varchar](max) NOT NULL,
	[type] [varchar](max) NOT NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Floor]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Floor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_Floor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Papers]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Papers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](50) NOT NULL,
	[singlePrice] [decimal](18, 2) NOT NULL,
	[doublePrice] [decimal](18, 2) NOT NULL,
	[isColorPaper] [int] NOT NULL,
	[isMisc] [bit] NOT NULL,
	[isActive] [bit] NOT NULL,
 CONSTRAINT [PK__Papers__3213E83FFD8841C8] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](50) NOT NULL,
	[price] [decimal](18, 2) NOT NULL,
	[timeRestricted] [varchar](3) NOT NULL,
	[startTime] [datetime] NOT NULL,
	[endTime] [datetime] NOT NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rates]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rates](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](max) NOT NULL,
	[price] [decimal](18, 2) NOT NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_Rates] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Session]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Session](
	[id] [uniqueidentifier] NOT NULL,
	[sessionCode] [varchar](8) NOT NULL,
	[computerId] [int] NOT NULL,
	[startTime] [datetime] NOT NULL,
	[endTime] [datetime] NULL,
	[loginTime] [datetime] NULL,
	[logOffTime] [datetime] NULL,
	[sessionClosed] [bit] NOT NULL,
	[isActive] [bit] NOT NULL,
	[status] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[InvoicedBy] [int] NULL,
 CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SessionLog]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SessionLog](
	[sessionlog_id] [int] IDENTITY(1,1) NOT NULL,
	[computerid] [int] NULL,
	[time] [datetime] NULL,
	[action] [varchar](50) NULL,
	[comments] [varchar](max) NULL,
	[sessionid] [uniqueidentifier] NULL,
	[byemployee] [int] NULL,
 CONSTRAINT [PK_SessionLog] PRIMARY KEY CLUSTERED 
(
	[sessionlog_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SessionPrint]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SessionPrint](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[sessionId] [uniqueidentifier] NOT NULL,
	[paperid] [int] NOT NULL,
	[description] [varchar](max) NOT NULL,
	[isDouble] [bit] NOT NULL,
	[processData] [datetime] NOT NULL,
	[JobStatus] [varchar](50) NOT NULL,
	[submittedTime] [nvarchar](max) NOT NULL,
	[caption] [nvarchar](max) NOT NULL,
	[dataType] [nvarchar](max) NOT NULL,
	[elapsedTime] [nvarchar](max) NOT NULL,
	[jobId] [nvarchar](max) NOT NULL,
	[PagesPrinted] [int] NOT NULL,
	[StartTime] [nvarchar](max) NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[TimeSubmitted] [nvarchar](max) NOT NULL,
	[TotalPages] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Shift]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Shift](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](50) NOT NULL,
	[startTime] [datetime] NOT NULL,
	[endTime] [datetime] NOT NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_Shift] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[DeleteComputer]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DeleteComputer]
@id as int
as
begin
delete from Computers where id = @id

end

GO
/****** Object:  StoredProcedure [dbo].[DeletePaper]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeletePaper]
@id as int 
as
begin
 delete from Papers where id = @id
end

GO
/****** Object:  StoredProcedure [dbo].[DeleteProduct]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteProduct]
@id int 
as
begin
delete from product
where id = @id;
end

GO
/****** Object:  StoredProcedure [dbo].[DeleteRate]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DeleteRate]
@id as int
as
begin
delete  from Rates where id =@id
end

GO
/****** Object:  StoredProcedure [dbo].[DeleteShift]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DeleteShift]
@id as int
as
begin
 delete from Shift where id = @id
end

GO
/****** Object:  StoredProcedure [dbo].[GetNonClosedSession]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetNonClosedSession]
@computerid int,@sessioncode varchar(max)

as
begin

Declare @isvalidated bit = 1;

IF (select count(*) from [Session] where sessionCode=@sessioncode) = 0
BEGIN

SET @isvalidated = 0
select 'Error' as Data
select 'Session code does not exist!' as [Message]

END

IF (select count(*) from [Session] where sessionCode=@sessioncode and computerId=@computerid) = 0 and @isvalidated=1
BEGIN

SET @isvalidated = 0
select 'Error' as Data
select 'Session is not associate to this computer!' as [Message]

END


IF (select count(*) from [Session] where sessionCode=@sessioncode and computerId=@computerid and sessionClosed=0) = 0 and @isvalidated=1
BEGIN

SET @isvalidated = 0
select 'Error' as Data
select 'Session is already expired!' as [Message]

END

IF (select count(*) from [Session] where sessionCode=@sessioncode and computerId=@computerid and sessionClosed=0 and isActive=0) = 0 and @isvalidated=1
BEGIN

SET @isvalidated = 0
select 'Error' as Data
select 'Session is currently active!' as [Message]

END


IF @isvalidated=1

BEGIN
Declare @sessionid uniqueidentifier;
select @sessionid=id from [Session] where sessionClosed=0 and isActive=0 and computerId=@computerid and sessionCode=@sessioncode

select 'Value' as Data

select * from [Session] where sessionClosed=0 and isActive=0 and computerId=@computerid and sessionCode=@sessioncode


select ROW_NUMBER() over(partition by sessionid,[action] order by [time],sessionid) id,* into #tempdata from SessionLog where sessionid=@sessionid
IF (select count(*) from #tempdata) > 0
BEGIN
--Declare @hour int =0;
--Declare @min int = 0;
--Declare @sec int=0;

--select @hour=(SUM(DATEDIFF(SECOND,start.[time],[stop].[time]))/60)/60 ,
--@min = SUM(DATEDIFF(MINUTE,start.[time],[stop].[time]))-(((SUM(DATEDIFF(MINUTE,start.[time],[stop].[time]))/60))*60),
-- @sec = SUM(DATEDIFF(SECOND,start.[time],[stop].[time])) 
-- from #tempdata start
--inner join #tempdata [stop] on start.id=[stop].id
--where [stop].[action]='STOP'

--select @hour [Hour],@min [Min],@sec-(((@hour*60)*60)+(@min *60)) [Sec]

select CONVERT(int,convert(char(2),dateadd(s,sum(datediff(s,start.[time],[stop].[time])),'1900-1-1'),8)) [Hour],
CONVERT(int,RIGHT(convert(char(5),dateadd(s,sum(datediff(s,start.[time],[stop].[time])),'1900-1-1'),8),2)) [Min],
CONVERT(int,RIGHT(convert(char(8),dateadd(s,sum(datediff(s,start.[time],[stop].[time])),'1900-1-1'),8),2)) [Sec]
 from #tempdata start
inner join #tempdata [stop] on start.id=[stop].id
where [stop].[action]='STOP'


END
ELSE 
BEGIN
select 0 as [Hour],0 as [Min],0 as Sec
END

drop table #tempdata
END

end 


GO
/****** Object:  StoredProcedure [dbo].[InserProduct]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[InserProduct]
@title  nvarchar(max) ='',
@price  decimal(18,2) = 0,
@timeRestricted varchar(3),
@starttime datetime,
@endTime datetime,
@active bit = 1
as
begin
insert into Product(title , price , timeRestricted , startTime , endTime , active) values(@title , @price ,
@timeRestricted , @starttime, @endTime , @active)

return SCOPE_IDENTITY();
end

GO
/****** Object:  StoredProcedure [dbo].[InsertComputer]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[InsertComputer]
@pcname as varchar(max),
@ipaddress as varchar(max),
@floorid as int,
@isactive as bit,
@isBusy as bit
as
begin
insert into Computers(pcname,ipaddress,floorid,isactive,isBusy,status) values (@pcname,@ipaddress,@floorid,@isactive,@isBusy,'Idle')
return SCOPE_IDENTITY()
end

GO
/****** Object:  StoredProcedure [dbo].[InsertPaper]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertPaper]
@title as varchar(max),
@singlePrice as decimal(18,2),
@doublePrice as decimal(18,2),
@isColorPaper int,
@isMisc bit,
@isActive bit
as
begin
 insert into Papers(title,singlePrice,doublePrice,isColorPaper,isMisc,isActive)
 values(@title,@singlePrice,@doublePrice,@isColorPaper,@isMisc,@isActive)
 return SCOPE_IDENTITY()
end

GO
/****** Object:  StoredProcedure [dbo].[InsertRate]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertRate]
@title as varchar(max),
@price as decimal ,
@active as bit
as
begin
insert into Rates(title,price,active) values(@title,@price,@active)
return SCOPE_IDENTITY();
end

GO
/****** Object:  StoredProcedure [dbo].[InsertShift]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertShift]
@title as varchar(50) ,
@startTime as datetime,
@endTime as datetime,
@active as bit
as
begin
 insert into Shift(title,startTime,endTime,active )
 values(@title,@startTime,@endTime,@active)
 return SCOPE_IDENTITY()
end

GO
/****** Object:  StoredProcedure [dbo].[PauseSession]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PauseSession]
@sessionid uniqueidentifier,@comment varchar(max),@byemployeeid int

as
BEGIN
Declare @computerId int;


select @computerId=computerId from [Session] where id=@sessionid


update [Session] set isActive=0,[status]=0 where id=@sessionid
update Computers set [status]=0 where id=@computerId;
INSERT INTO SessionLog VALUES(@computerId,GETDATE(),'STOP',@comment,@sessionid,@byemployeeid)


END;


GO
/****** Object:  StoredProcedure [dbo].[SelectComputerById]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SelectComputerById]
@id as int
as
begin
select * from Computers where id = @id

end

GO
/****** Object:  StoredProcedure [dbo].[SelectComputerByIP]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SelectComputerByIP]
@ip as varchar(max)
as
begin
select * from Computers where ipaddress = @ip

end

GO
/****** Object:  StoredProcedure [dbo].[SelectComputers]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SelectComputers]
as

begin
select * from Computers

end

GO
/****** Object:  StoredProcedure [dbo].[SelectFloors]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SelectFloors]
as

begin
select * from Floor

end

GO
/****** Object:  StoredProcedure [dbo].[SelectPaperById]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SelectPaperById]
@id as int 
as
begin
 select * from Papers where id = @id
end

GO
/****** Object:  StoredProcedure [dbo].[SelectPapers]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SelectPapers]
as
begin
 select * from Papers
end

GO
/****** Object:  StoredProcedure [dbo].[SelectProductById]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SelectProductById]
@id int 
as
begin
select *  from product
where id = @id;
end

GO
/****** Object:  StoredProcedure [dbo].[SelectProducts]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SelectProducts]
as
begin
select *  from product

end

GO
/****** Object:  StoredProcedure [dbo].[SelectRateById]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SelectRateById]
@id as int
as
begin
select * from Rates where id = @id
end

GO
/****** Object:  StoredProcedure [dbo].[SelectRates]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SelectRates]
as
begin
select * from Rates
end

GO
/****** Object:  StoredProcedure [dbo].[SelectShiftById]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SelectShiftById]
@id as int
as
begin
 Select * from Shift where id = @id
end

GO
/****** Object:  StoredProcedure [dbo].[SelectShifts]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SelectShifts]
as
begin
 Select * from Shift 
end

GO
/****** Object:  StoredProcedure [dbo].[StartSession]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StartSession]
@sessionid uniqueidentifier,@comment varchar(max),@byemployeeid int

as
BEGIN
Declare @IsLoggedIn datetime;
Declare @computerId int;
Declare @time datetime;

select @IsLoggedIn=loginTime,@computerId=computerId from [Session] where id=@sessionid

IF @IsLoggedIn IS NULL
BEGIN
SET @time=GETDATE();

update [Session] set loginTime=@time,isActive=1,[status]=1 where id=@sessionid
update Computers set [status]=1 where id=@computerId;
INSERT INTO SessionLog VALUES(@computerId,@time,'START',@comment,@sessionid,@byemployeeid)

END

ELSE 
BEGIN

SET @time=GETDATE();

update [Session] set isActive=1,[status]=1 where id=@sessionid
update Computers set [status]=1 where id=@computerId;
INSERT INTO SessionLog VALUES(@computerId,@time,'START',@comment,@sessionid,@byemployeeid)

END

END;
GO
/****** Object:  StoredProcedure [dbo].[StopSession]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StopSession]
@sessionid uniqueidentifier,@comment varchar(max),@byemployeeid int

as
BEGIN
Declare @computerId int;
Declare @time datetime;

select @computerId=computerId from [Session] where id=@sessionid

SET @time=GETDATE();

update [Session] set logoffTime=@time,isActive=0,[status]=0,sessionClosed=1 where id=@sessionid
update Computers set [status]=0 where id=@computerId;
INSERT INTO SessionLog VALUES(@computerId,@time,'STOP',@comment,@sessionid,@byemployeeid)


END;

GO
/****** Object:  StoredProcedure [dbo].[UpdateComputer]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateComputer]
@id as int,
@pcname as varchar(max),
@ipaddress as varchar(max),
@floorid as int,
@isactive as bit
as
begin
update  Computers set pcname = @pcname,ipaddress = @ipaddress,floorid = @floorid,isactive = @isactive
where id = @id
end

GO
/****** Object:  StoredProcedure [dbo].[UpdatePaper]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdatePaper]
@id as int,
@title as varchar(max),
@singlePrice as decimal(18,2),
@doublePrice as decimal(18,2),
@isColorPaper int,
@isMisc bit,
@isActive bit
as
begin
 update Papers  set title = @title,singlePrice = @singlePrice ,doublePrice=@doublePrice,isColorPaper = @isColorPaper,isMisc=@isMisc,isActive = @isActive
 where id = @id
end

GO
/****** Object:  StoredProcedure [dbo].[UpdateProduct]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateProduct]
@id int,
@title  nvarchar(max) ='',
@price  decimal(18,2) = 0,
@timeRestricted varchar(3),
@starttime datetime,
@endTime datetime,
@active bit = 1
as
begin
update  Product set title = @title, price =  @price, timeRestricted = @timeRestricted, startTime = @starttime , endTime = @endTime , active = @active
where id = @id;
end

GO
/****** Object:  StoredProcedure [dbo].[UpdateRate]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateRate]
@id as int,
@title as varchar(max),
@price as decimal ,
@active as bit
as
begin
update Rates set title = @title,price = @price,active = @active where id = @id

end

GO
/****** Object:  StoredProcedure [dbo].[UpdateShift]    Script Date: 6/16/2017 3:12:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[UpdateShift]
@id as int,
@title as varchar(50) ,
@startTime as datetime,
@endTime as datetime,
@active as bit
as
begin
 update [Shift] set title = @title,startTime = @startTime,endTime = @endTime,active =@active
 where id = @Id
end

GO
USE [master]
GO
ALTER DATABASE [InternetcafeManagment] SET  READ_WRITE 
GO
