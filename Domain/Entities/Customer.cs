using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; } = NewId.Next().ToGuid();
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string StateOfResidence { get; set; }
        public string LGA { get; set; }
        public bool IsVerified { get; set; }
        public string OTP { get; set; }
        public DateTime? OTPExpiration { get; set; }
    }
}
