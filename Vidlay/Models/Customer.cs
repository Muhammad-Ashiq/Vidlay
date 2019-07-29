using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidlay.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required (ErrorMessage ="Please Enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }
        [Min18YearIfMember]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}