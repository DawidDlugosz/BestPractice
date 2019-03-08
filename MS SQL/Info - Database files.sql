SELECT 
    name
    , size      -- in 8-KB pages
    , max_size  -- in 8-KB pages
    , growth
    , in_percent_growth
    , type_desc as fileType
FROM sys.database_files