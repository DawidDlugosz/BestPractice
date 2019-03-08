DECLARE @SearchedText VARCHAR(100) = 'ResponseID'

SELECT DISTINCT
    SCHEMA_NAME(schema_id) as SchemaName
    , o.name as ObjectName
    , o.type_desc
    , o.type
FROM sys.sql_models as M
INNER JOIN sys.objects as O on M.object_id = o.object_id
WHERE M.definition LIKE '%' + @SearchedText + '%'