DECLARE @RoleName VARCHAR(50) = 'NewRoleName'
    , @Query VARCHAR(500) 

SET @Query = 'CREATE ROLE [' + @RoleName + ']'

IF NOT EXISTS (SELECT name FROM sys.database_principals WHERE name = @RoleName)
BEGIN
    EXEC(@Query)
    PRINT('Role ' + @RoleName + ' was created')
END
ELSE
BEGIN
    PRINT('Role ' + @RoleName + ' already exist')
END
GO