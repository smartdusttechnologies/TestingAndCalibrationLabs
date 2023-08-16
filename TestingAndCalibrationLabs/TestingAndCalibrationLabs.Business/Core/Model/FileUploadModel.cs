using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public  class FileUploadModel
    {
        // Image Name 
        public string Name { get; set; }
        [MaxLength(100)]
        //Image Type
        public string FileType { get; set; }
        [MaxLength]
        //Image Byte
        public byte[] DataFiles { get; set; }
        //Image Create Date
        public DateTime? CreatedOn { get; set; }
    }
}
