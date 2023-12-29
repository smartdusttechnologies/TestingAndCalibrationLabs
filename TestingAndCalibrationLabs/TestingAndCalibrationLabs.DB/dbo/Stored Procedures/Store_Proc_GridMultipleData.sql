CREATE PROCEDURE [dbo].[Store_Proc_GridMultipleData]
    @UiPageTypeId INT,
    @Id INT
AS
BEGIN
    SELECT
        um.Id AS UiPageMetadataId,
        COALESCE(CONVERT(VARCHAR, ups.UiPageDataId), CONVERT(VARCHAR, upi.UiPageDataId), CONVERT(VARCHAR, upf.UiPageDataId)) AS Id,
        COALESCE(CONVERT(VARCHAR, ups.Value), CONVERT(VARCHAR, upi.Value), CONVERT(VARCHAR, upf.Value)) AS Value,
        COALESCE(CONVERT(VARCHAR, ups.Id), CONVERT(VARCHAR, upi.Id), CONVERT(VARCHAR, upf.Id)) AS ChildId,
        COALESCE(CONVERT(VARCHAR, ups.RecordId), CONVERT(VARCHAR, upi.RecordId), CONVERT(VARCHAR, upf.RecordId)) AS RecordId,
	    COALESCE(CONVERT(VARCHAR, ups.SubRecordId), CONVERT(VARCHAR, upi.SubRecordId), CONVERT(VARCHAR, upf.SubRecordId)) AS SubRecordId,

        mmb.UiPageTypeId
    FROM
        UiPageMetadata um
		 JOIN
        [UiPageMetadataModuleBridge] mmb ON um.Id = mmb.UiPageMetadataId
	LEFT join [UiPageData] upd on upd.UiPageMetadataId= um.Id AND upd.UiPageMetadataId=mmb.UiPageMetadataId And upd.UiPageTypeId=@UiPageTypeId AND upd.RecordId = @Id AND upd.IsDeleted=0
    LEFT JOIN
        [UiPageStringType] ups ON um.Id = ups.UiPageMetadataId AND ups.UiPageMetadataId = mmb.UiPageMetadataId AND upd.Id=ups.UiPageDataId AND ups.RecordId = @Id and ups.IsDeleted = 0
    LEFT JOIN
        [UiPageIntType] upi ON um.Id = upi.UiPageMetadataId AND upi.UiPageMetadataId= mmb.UiPageMetadataId AND upd.Id = upi.UiPageDataId AND  upi.RecordId = @Id and upi.IsDeleted = 0
    LEFT JOIN
        [UiPageFileAttachType] upf ON um.Id = upf.UiPageMetadataId AND upf.UiPageMetadataId = mmb.UiPageMetadataId AND  upd.Id=upf.UiPageDataId and  upf.RecordId = @Id and upf.IsDeleted = 0
   
    WHERE
        mmb.MultiValueControl = 'true'
        AND mmb.UiPageTypeId = @UiPageTypeId
	    AND um.Id = mmb.UiPageMetadataId
		
        AND mmb.IsDeleted = 0;
		
END;
