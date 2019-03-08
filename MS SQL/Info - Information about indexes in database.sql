/*** Information about indexes in database ***/
/*********************************************/

SELECT OBJECT_SCHEMA_NAME(object_id) as SchemaName
    , OBJECT_NAME(object_id) as TableName
    , name as IndexName
    , type_desc as IndexType
FROM sys.indexes
WHERE type in 
(
    1   -- Clustered
    , 2 -- Non clustered
    , 3 -- XML
    , 0 -- Heap    
) 
ORDER BY SchemaName
    , TableName
    , IndexName