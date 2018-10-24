//////////////////////////////////
Создание таблицы департаментов
//////////////////////////////////
CREATE TABLE [dbo].[Department]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL
)
//////////////////////////////////
Создание таблицы работников
//////////////////////////////////
CREATE TABLE [dbo].[Employee]
(
	[Id] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Age] NVARCHAR(50) NOT NULL, 
    [Salary] NVARCHAR(50) NOT NULL, 
    [Department] NVARCHAR(50) NOT NULL
)
