CREATE PROCEDURE [dbo].[store_proc_Record]
    @ModuleId int ,
	@WorkflowStageId int ,
	@UpdatedDate DateTime,
	@UiPageDataTVP  UiPageDataTVP READONLY,
	@ChildTvp childData READONLY,
	@RecordId INT OUTPUT
	
	
AS
BEGIN
    --SET NOCOUNT ON;
    DECLARE @Id INT
	DECLARE @UId int
	DECLARE @Tvpcount int = (select count(*) from @UiPageDataTVP);
	declare @ind int = 1
	declare @tempTable table (Id int NOT NULL identity(1,1), UiPageMetadataId int,UiPageTypeId int,Value  varchar(200))
	insert into @tempTable (UiPageMetadataId,UiPageTypeId,Value)
	select * from @UiPageDataTVP
    -- Insert data into Table1
    
	INSERT INTO  Record(ModuleId,WorkflowStageId,UpdatedDate)
	values (@ModuleId,@WorkflowStageId,@UpdatedDate)
	SET @Id = SCOPE_IDENTITY()
	
	while @Tvpcount >= @ind begin

	INSERT INTO UiPageData(UiPageMetadataId,RecordId,UiPageTypeId)
	SELECT UiPageMetadataId, @Id,UiPageTypeId  FROM @tempTable where Id = @ind
	set @UId  = SCOPE_IDENTITY()
	
	INSERT INTO UiPageStringType ( UiPageMetadataId,Value,UiPageDataId,RecordId)
	select   temp.UiPageMetadataId,ctvp.Value, @UId, @Id from @ChildTvp ctvp join @tempTable temp on ctvp.UiPageMetadataId = temp.UiPageMetadataId
	join UiPageMetadata upmd on temp.UiPageMetadataId = upmd.Id 
where upmd.DataTypeId=2 and 
	temp.Id=@ind
	


 INSERT INTO UiPageFileAttachType (UiPageMetadataId, Value,UiPageDataId,RecordId)
	select  temp.UiPageMetadataId,ctvp.Value, @UId, @Id from @ChildTvp ctvp join @tempTable temp on ctvp.UiPageMetadataId = temp.UiPageMetadataId join UiPageMetadata upmd on temp.UiPageMetadataId = upmd.Id where upmd.DataTypeId=3 and
		temp.Id=@ind


 INSERT INTO UiPageIntType ( UiPageMetadataId,Value, UiPageDataId,RecordId)
  select temp.UiPageMetadataId,ctvp.Value,  @UId ,  @Id  from @ChildTvp ctvp join @tempTable temp on ctvp.UiPageMetadataId = temp.UiPageMetadataId join UiPageMetadata upmd on temp.UiPageMetadataId = upmd.Id where upmd.DataTypeId=1 and
  	temp.Id=@ind

	 INSERT INTO UiPageDateType (UiPageMetadataId, Value,UiPageDataId,RecordId)
	select  temp.UiPageMetadataId,ctvp.Value, @UId, @Id from @ChildTvp ctvp join @tempTable temp on ctvp.UiPageMetadataId = temp.UiPageMetadataId join UiPageMetadata upmd on temp.UiPageMetadataId = upmd.Id where upmd.DataTypeId=5 and
		temp.Id=@ind


 SET @ind += 1;  
	end 
	SET @RecordId = @Id;
END
