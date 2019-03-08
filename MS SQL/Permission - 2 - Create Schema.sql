DECLARE @SchemaName VARCHAR(50) = 'NewSchemaName'
    , @Query VARCHAR(500) 

SET @Query = 'CREATE SCHEMA [' + @SchemaName + ']'

IF NOT EXISTS (SELECT name FROM sys.schemas WHERE name = @SchemaName)
BEGIN
    EXEC(@Query)
    PRINT('Schema ' + @SchemaName + ' was created')
END
ELSE
BEGIN
    PRINT('Schema ' + @SchemaName + ' already exist')
END
GO

ALTER AUTHORIZATION ON SCHEMA::[NewSchemaName] TO [NewRoleName] -- Allow all CRUD operation on objects from schema
GRANT CREATE TABLE TO [NewRoleName] -- Allow Create Table operation
GRANT CREATE VIEW TO [NewRoleName]  -- Allow Create View operation
GO