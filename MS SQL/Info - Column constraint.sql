/*** Information about Column Constraint ***/
/*******************************************/

SELECT
    KCU1.Constraint_Name    as FK_ConstraintName
    , KCU1.Table_Name       as FK_TableName
    , KCU1.Column_Name      as FK_ColumnName
    , KCU1.Ordinal_Position as FK_OrdinalPosition
    , KCU2.Constraint_Name  as REFERENCED_ConstraintName
    , KCU2.Table_Name       as REFERENCED_TableName
    , KCU2.Column_Name      as REFERENCED_ColumnName
    , KCU2.Ordinal_Position as REFERENCED_OrdinalPosition
FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS as RC
INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE as KCU1
    on KCU1.CONSTRAINT_CATALOG  = RC.CONSTRAINT_CATALOG
    and KCU1.CONSTRAINT_Schema  = RC.CONSTRAINT_Schema
    and KCU1.CONSTRAINT_NAME    = RC.CONSTRAINT_NAME
INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE as KCU2
    on  KCU2.CONSTRAINT_CATALOG = RC.UNIQUE_CONSTRAINT_CATALOG
    and KCU2.CONSTRAINT_Schema  = RC.UNIQUE_CONSTRAINT_Schema
    and KCU2.CONSTRAINT_NAME    = RC.UNIQUE_CONSTRAINT_NAME
    and KCU2.ORDINAL_POSITION    = RC.ORDINAL_POSITION
ORDER BY FK_TableName
    , FK_ColumnName

