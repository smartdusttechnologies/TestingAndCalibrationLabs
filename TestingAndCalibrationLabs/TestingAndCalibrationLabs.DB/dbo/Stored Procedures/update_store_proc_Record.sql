CREATE PROCEDURE [dbo].[update_store_proc_Record]
    @ModuleId INT,
	@WorkflowStageId INT,
	@RecordId INT, 
	@UpdatedDate datetime,
	@ChildTvp updatechildDatas READONLY
	
AS
BEGIN
    --SET NOCOUNT ON;
	DECLARE @Id INT
	declare @ind int = 1
	DECLARE @Tvpcount int = (select count(*) from @ChildTvp);
	declare @tempTable table (Id int NOT NULL identity(1,1),UipagedataId int ,UiPageMetadataId int,ChildId int,RecordId int,UiPageTypeId int,Value  varchar(200))
	insert into @tempTable ( UipagedataId,UiPageMetadataId,ChildId,RecordId,UiPageTypeId,Value)
	select Id,UiPageMetadataId,ChildId,RecordId,UiPageTypeId,Value from @ChildTvp

	
	-- Insert data into Record table
	UPDATE  Record 
	set  ModuleId = @ModuleId , WorkflowStageId = @WorkflowStageId ,UpdatedDate = @UpdatedDate
	WHERE Id = @RecordId;
		
		
	while @Tvpcount >= @ind begin
		MERGE INTO UiPageData AS target
    USING @tempTable AS source
    ON (target.Id = source.UipagedataId)
	 WHEN MATCHED and source.UipagedataId IN (SELECT Id FROM UiPageData WHERE RecordId = source.RecordId and source.Id = @ind)
	THEN
      UPDATE SET @Id = source.UipagedataId
	WHEN NOT MATCHED BY target and source.Id = @ind
	THEN 
	   INSERT (UiPageMetadataId ,RecordId,UiPageTypeId)
		VALUES (source.UiPageMetadataId,source.RecordId,source.UiPageTypeId);
		set @Id  = SCOPE_IDENTITY();
		


	 -- Update UiPageStringType table
    MERGE INTO UiPageStringType AS target
    USING @tempTable AS source
    ON (target.Id = source.ChildId)
    WHEN MATCHED AND source.UiPageMetadataId IN (SELECT Id FROM UiPageMetadata WHERE DataTypeId = 2 and source.Id = @ind)
	THEN
        UPDATE SET target.Value = source.Value
		-- WHEN NOT MATCHED SO INSERT INTO UiPageStringType
		WHEN NOT MATCHED BY target AND source.UiPageMetadataId IN (SELECT Id FROM UiPageMetadata WHERE DataTypeId = 2 and source.Id = @ind)
		THEN 
		INSERT (UiPageMetadataId ,Value,UiPageDataId,RecordId)
		VALUES (source.UiPageMetadataId,source.Value, @Id,source.RecordId)
       WHEN NOT MATCHED BY source AND target.UiPageDataId IN (SELECT Id FROM @ChildTvp ) THEN 
        DELETE;


      -- Update UiPageFileAttachType table
		 MERGE INTO UiPageFileAttachType AS target
    USING @tempTable AS source
    ON (target.Id = source.ChildId)
    WHEN MATCHED AND source.UiPageMetadataId IN (SELECT Id FROM UiPageMetadata WHERE DataTypeId = 3 and source.Id = @ind)
	THEN
        UPDATE SET target.Value = source.Value
		-- WHEN NOT MATCHED SO INSERT INTO UiPageStringType
		WHEN NOT MATCHED BY target AND source.UiPageMetadataId IN (SELECT Id FROM UiPageMetadata WHERE DataTypeId = 3 and source.Id = @ind) 
		THEN INSERT (UiPageMetadataId ,Value,UiPageDataId,RecordId)
		VALUES (source.UiPageMetadataId,source.Value, @Id,source.RecordId)
		WHEN NOT MATCHED BY source AND target.UiPageDataId IN (SELECT Id FROM @ChildTvp ) THEN 
        DELETE;


		-- Update UiPageIntType table
    MERGE INTO UiPageIntType AS target
    USING @tempTable AS source
    ON (target.Id = source.ChildId)
    WHEN MATCHED AND source.UiPageMetadataId IN (SELECT Id FROM UiPageMetadata WHERE DataTypeId = 1 and source.Id = @ind)
	THEN
        UPDATE SET target.Value = source.Value
		-- WHEN NOT MATCHED SO INSERT INTO UiPageStringType
		WHEN NOT MATCHED BY target AND source.UiPageMetadataId IN (SELECT Id FROM UiPageMetadata WHERE DataTypeId = 1 and source.Id = @ind ) 
		THEN INSERT (UiPageMetadataId ,Value,UiPageDataId,RecordId)
		VALUES (source.UiPageMetadataId,source.Value, @Id,source.RecordId)
		WHEN NOT MATCHED BY source AND target.UiPageDataId IN (SELECT Id FROM @ChildTvp ) THEN 
        DELETE;


	-- Update UiPageDateType table
    MERGE INTO UiPageDateType AS target
    USING @tempTable AS source
    ON (target.Id = source.ChildId)
    WHEN MATCHED AND source.UiPageMetadataId IN (SELECT Id FROM UiPageMetadata WHERE DataTypeId = 5 and source.Id = @ind)
	THEN
        UPDATE SET target.Value = source.Value
		-- WHEN NOT MATCHED SO INSERT INTO UiPageStringType
		WHEN NOT MATCHED BY target AND source.UiPageMetadataId IN (SELECT Id FROM UiPageMetadata WHERE DataTypeId = 5 and source.Id = @ind) 
		THEN INSERT (UiPageMetadataId ,Value,UiPageDataId,RecordId)
		VALUES (source.UiPageMetadataId,source.Value, @Id,source.RecordId)
		WHEN NOT MATCHED BY source AND target.UiPageDataId IN (SELECT Id FROM @ChildTvp ) THEN 
        DELETE;
		--WHEN NOT MATCHED BY source AND target.UiPageMetadataId IN (SELECT Id FROM UiPageMetadata WHERE DataTypeId = 1)
  --      THEN DELETE;
		 SET @ind += 1;  
	end 

END