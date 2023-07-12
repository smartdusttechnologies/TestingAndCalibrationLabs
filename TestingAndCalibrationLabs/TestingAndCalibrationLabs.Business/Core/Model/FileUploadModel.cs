using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public  class FileUploadModel :Entity
    {

        public string Name { get; set; }
        [MaxLength(100)]
        public string FileType { get; set; }
        [MaxLength]
        public byte[] DataFiles { get; set; }
        public DateTime? CreatedOn { get; set; }

    }
}
