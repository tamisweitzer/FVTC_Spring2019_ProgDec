CREATE TABLE [dbo].[tblUser]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserId] VARCHAR(25) NOT NULL, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [UserPass] VARCHAR(32) NOT NULL
)
