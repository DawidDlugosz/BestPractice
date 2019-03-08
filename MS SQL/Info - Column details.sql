DECLARE @ColumnName nvarchar(200) = 'ColumnName'

SELECT
    OBJECT_SCHEMA_NAME(object_id) + '.' + OBJECT_NAME(object_id) as FullTableName
    , name as ColumnName
    , TYPE_NAME(system_type_id) as TypeName
    , max_length
    , IsNullable = CASE WHEN is_nullable = 1 THEN 'NULL' ELSE 'NOT NULL' END
FROM sys.columns
WHERE name = @ColumnName
ORDER BY TableName, ColumnName