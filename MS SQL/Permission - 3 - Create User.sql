DECLARE @GroupName NVARCHAR(200) = 'NewUserNameFromActiveDirectory'
    , @RoleName NVARCHAR(50) = 'NewRoleName'

IF EXISTS ( SELECT * FROM sysusers WHERE name = @GroupName )
BEGIN
    EXEC ('DROP USER [' + @GroupName + ']')
END

EXEC ('CREATE USER [' + @GroupName + '] FOR LOGIN [' + @GroupName + ']')
EXEC ('ALTER ROLE [' + @RoleName + '] ADD MEMBER [' + @GroupName + ']')
GO