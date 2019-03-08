DECLARE @SchemaName VARCHAR(10) = 'INFO'

SELECT
    SCHEMA_NAME(t.schema_id) as [Schema]
    , t.name as TableName
    , i.name as IndexName
    , sum(p.rows) as RowCounts
    , sum(a.total_pages) as TotalPages
    , sum(a.used_pages) as UsedPages
    , sum(a.data_pages) as DataPages
    , (sum(a.total_pages) * 8) as TotalSpaceKB
    , (sum(a.used_pages) * 8) as UsedSpaceKB
    , (sum(a.data_pages) * 8) as DataSpaceKB
    , (sum(a.total_pages) * 8) / 1024  as TotalSpaceMB
    , (sum(a.used_pages) * 8) / 1024 as UsedSpaceMB
    , (sum(a.data_pages) * 8) / 1024 as DataSpaceMB
FROM sys.tables as t
INNER JOIN sys.indexes as i on t.object_id = i.object_id
INNER JOIN sys.partitions as p on i.object_id = p.object_id and i.index_id = p.index_id
INNER JOIN sys.allocation_units as a on p.partition_id = a.container_id
WHERE 
    (SCHEMA_NAME(t.schema_id) = @SchemaName) AND
    t.name NOT LIKE 'dt%' AND
    i.object_id > 255 AND
    i.index_id <= 1
GROUP BY
    t.name
    , SCHEMA_NAME(t.schema_id)
    , i.object_id
    , i.index_id
    , i.name
ORDER BY
    RowCounts DESC,
    TotalPages DESC,
    TableName ASC