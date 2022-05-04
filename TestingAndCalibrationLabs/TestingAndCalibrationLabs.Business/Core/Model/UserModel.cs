using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class UserModel : Entity
    {
        public UserModel(string emailId)
        {
            Email = emailId;
        }

        //public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
    }
}