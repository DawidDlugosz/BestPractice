
/*** Drop existing object ***/
/****************************/
If EXISTS (
    Select object_id, type
    from sys.objects
    where name = 'TableViewFunctionProcedureName'
    AND SCHEMA_NAME(schema_id) = 'SchemaName'
    AND type = 'FN' -- Scalar Function
--    AND type = 'IF' -- Table Function
--    AND type = 'P' -- Procedure
--    AND type = 'V' -- View
--    AND type = 'U' -- Table
)
BEGIN
    DROP TABLE SchemaName.TableViewFunctionProcedureName
    DROP VIEW SchemaName.TableViewFunctionProcedureName
    DROP PROCEDURE SchemaName.TableViewFunctionProcedureName
    DROP FUNCTION SchemaName.TableViewFunctionProcedureName
END
GO

/*** Drop temporary object ***/
/*****************************/
IF object_id('tempdb..#TempTableName') IS NOT NULL
    DROP Table #TempTableName
GO

/*** Drop Constraint ***/
/***********************/
Declare @ConstraintName nvarchar(200) = 'FK_tbl_constraintName'
    , @TableName nvarchar(200) = 'TableName'
    , @TableSchema nvarchar(10) = 'SchemaName'
    , @DropQuery nvarchar(max)
If EXISTS (
    Select
        OBJECT_NAME(OBJECT_ID) as NameOfConstraint
        , SCHEMA_NAME(schema_id) as SchemaName
        , OBJECT_NAME(parent_object_id) as TableName
        , type_desc as ConstraintType
    From sys.objects
    Where type_desc like '%CONSTRAINT'
        AND OBJECT_NAME(OBJECT_ID) = @ConstraintName
        AND OBJECT_NAME(parent_object_id) = @TableName
        AND OBJECT_NAME(schema_id) = @TableSchema
)
BEGIN
    SET @DropQuery = 'ALTER TABLE [' + @TableSchema + '].[' + @TableName + '] DROP CONSTRAINT [' + @ConstraintName + ']'
    PRINT @DropQuery
    EXEC(@DropQuery)
END
GO

/*** Drop Index ***/
/******************/
Declare @IndexName nvarchar(200) = 'IndexName'
    , @TableName nvarchar(200) = 'TableName'
    , @SchemaName nvarchar(10) = 'SchemaName'
IF EXISTS (
    Select I.name 
    From sys.indexes as I
    Left Join sys.objects as O on O.object_id = I.object_id
    Where I.name = @IndexName
    AND SCHEMA_NAME(O.schema_id) = @SchemaName
    AND OBJECT_NAME(O.object_id) = @TableName
)
    EXEC('DROP INDEX [' + @IndexName + '] ON [' + @SchemaName + '].[' + @TableName + ']')
GO