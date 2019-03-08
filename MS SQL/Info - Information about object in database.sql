DECLARE @ObjectName NVARCHAR(200) = 'v_nameOfView'

SELECT OBJECT_SCHEMA_NAME(object_id) as SchemaName
    , name as ObjectName
    , type_desc as ObjectType
FROM sys.objects
WHERE name like '%' + @ObjectName + '%'