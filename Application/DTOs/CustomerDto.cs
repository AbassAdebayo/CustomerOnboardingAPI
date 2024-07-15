using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string StateOfResidence { get; set; }
        public string LGA { get; set; }
        public bool IsVerified { get; set; }
        public string OTP { get; set; }
        public DateTime OTPExpiration { get; set; }
    }

    public class OnboardCustomerRequestModel
    {
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string StateOfResidence{get; set;}
        [Required]
        public string LGA { get; set; }
    }

    public class VerifyOtpRequestModel
    {
        public string PhoneNumber { get; set; }
        public string OTP { get; set; }
    }
}
