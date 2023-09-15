Create PROCEDURE [dbo].[usp_Logs_AddEntry] (
  @machineName nvarchar(200),
  @logged datetime,
  @level varchar(5),
  @message nvarchar(max),
  @logger nvarchar(300),
 
  @callsite nvarchar(300)
 
) AS
BEGIN
  INSERT INTO [dbo].[Logs] (
    [MachineName],
    [Logged],
    [Level],
    [Message],
    [Logger],
    
    [Callsite]
    
  ) VALUES (
    @machineName,
    @logged,
    @level,
    @message,
    @logger,
   
    @callsite
  
  );
END