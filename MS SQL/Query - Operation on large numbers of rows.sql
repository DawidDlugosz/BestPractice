/*** Operation on large numbers of rows (eliminate full Transaction log problem) ***/
/***********************************************************************************/

DECLARE @Count INT
    , @ControlCount INT

SET @ControlCount = 500000
SET @Count = @ControlCount
SET ROWCOUNT @ControlCount

WHILE @Count = @ControlCount
BEGIN
    BEGIN TRAN

        /* Select, Delete, Update */
        
        SET @Count = @@ROWCOUNT
    COMMIT
END