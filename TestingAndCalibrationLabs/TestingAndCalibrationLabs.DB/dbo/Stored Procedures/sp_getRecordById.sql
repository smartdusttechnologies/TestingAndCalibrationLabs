CREATE PROCEDURE [dbo].[sp_getRecordById]
@recordId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE 
    @columns NVARCHAR(MAX) = '',
	@sql     NVARCHAR(MAX) = '';

SELECT 
    @columns += QUOTENAME(UiControlDisplayName) + ','
FROM 
    UiPageMetadata
ORDER BY 
    UiControlDisplayName;

SET @columns = LEFT(@columns, LEN(@columns) - 1);

SET @sql ='
SELECT * FROM
(
SELECT upm.UiPageId, upm.UiControlDisplayName, upd.RecordId,  upd.Value 
FROM [UiPageMetadata] upm
	INNER JOIN UiPageData upd ON upd.UiControlId = upm.Id AND upd.UiPageId = upm.UiPageId
WHERE upd.RecordId = '+ CAST(@recordId AS NVARCHAR(10)) +' AND upm.IsDeleted = 0 AND upd.IsDeleted = 0
) t
PIVOT(
max(Value)
FOR UiControlDisplayName IN ('+ @columns +')
) AS PivotTable'
EXECUTE sp_executesql @sql;

END