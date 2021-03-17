using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class Farmer
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { set; get; }
        [StringLength(20)]
        public string Code { set; get; }
        [StringLength(100)]
        public string FullName { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        [StringLength(20)]
        public string IdentificationNo { get; set; }
        public DateTime IssuedOn { get; set; }
        public string IssuedBy { get; set; }
        [StringLength(20)]
        public string AccountNumber { get; set; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
