USE [InternetcafeManagmentHK]
GO

/****** Object:  StoredProcedure [dbo].[GetLatestLoginTime]    Script Date: 6/29/2017 2:03:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetLatestLoginTime]
@computerid int,@sessionid uniqueidentifier

as
begin

select top 1 [time] from SessionLog where computerid=@computerid and sessionid=@sessionid and action='START' order by time desc

end 
GO

