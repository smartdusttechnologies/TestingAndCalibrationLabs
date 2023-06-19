

namespace TestingAndCalibrationLabs.Business.Core.Model
{
    public class ForgotPasswordModel : Entity
    {


        
        public string Email { get; set; }

        public bool EmailSent { get; set; }

        public string OTP { get; set; }

        public int UserId { get; set; }

     



    }

}

