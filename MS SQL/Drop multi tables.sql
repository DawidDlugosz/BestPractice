SET NOCOUNT ON

IF OBJECT_ID('tempdb..#TableToDrop') IS NOT NULL
    DROP TABLE #TableToDrop
GO

CREATE TABLE #TableToDrop(Id int identity(1,1) NOT NULL, SchemaName nvarchar(10), TableName nvarchar(200))

INSERT INTO #TableToDrop (SchemaName, TableName)
VALUES  ('USER', 'Customer'),
        ('USER', 'CustomerDetails'),
        ('INFO', 'PerformanceDetails');

DECLARE @CurrentRow int = 0
    , @QuantityOfRow int
    , @SchemaName NVARCHAR(10)
    , @TableName NVARCHAR(200)
    , @Query NVARCHAR(max);

SELECT @QuantityOfRow = Count(*) FROM #TableToDrop

WHILE(@CurrentRow < @QuantityOfRow)
BEGIN
    SET @CurrentRow = @CurrentRow + 1
    SELECT @SchemaName = SchemaName
        , @TableName = TableName
    FROM #TableToDrop
    WHERE ID = @CurrentRow

    IF EXISTS (
        SELECT object_id, type
        FROM sys.objects
        WHERE name = @TableName
        AND SCHEMA_NAME(schema_id) = @SchemaName
        AND type = 'U'  -- Table
    )
    BEGIN
        SET @Query = 'DROP TABLE [' + @SchemaName + '].[' + @TableName + ']'
        EXEC (@Query)
        PRINT ('Executed query: ' + Query)
    END
    ELSE
        PRINT ('TABLE [' + @SchemaName + '].[' + @TableName + '] NOT EXIST')
END

SET NOCOUNT OFF