CREATE DATABASE MatrimonyDB;
GO
use MatrimonyDB;

go
select * from dbo.Users;

EXEC sp_help 'Countries';

USE MASTER;

DROP DATABASE MatrimonyDB;

GO
use MatrimonyDB;

go
select * from dbo.Users;

select * from dbo.Countries;

truncate table dbo.Users;

truncate table dbo.Countries;
