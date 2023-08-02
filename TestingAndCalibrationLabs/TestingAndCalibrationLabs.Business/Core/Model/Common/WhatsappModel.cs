using Microsoft.AspNetCore.Http;
using System;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Business.Core.Model
{

    public class WhatsappModel : Entity
    {
        public long from { get; set; }
        public string phoneNumberId { get; set; }
        public string entry { get; set; }
        public string messagingproduct { get; set; }
        public string to { get; set; }
        public IFormFile Image { get; set; }
        
        public string text { get; set; }
       // public string Image { get; set; }
       // public byte[] body { get; set; }

        //   public DateTime? CreatedOn { get; set; }

        // Image Name 
      //  public string Name { get; set; }
       // [MaxLength(100)]
        //Image Type
      //  public string FileType { get; set; }
     //   [MaxLength]
        //Image Byte
     //   public byte[] DataFiles { get; set; }
        //Image Create Date
     //   public DateTime? CreatedOn { get; set; }
    }
}
