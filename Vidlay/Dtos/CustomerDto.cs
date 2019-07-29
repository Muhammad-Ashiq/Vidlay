using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidlay.Models;

namespace Vidlay.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }


        [StringLength(255)]
        public string Name { get; set; }

        //[Min18YearIfMember]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        
        public MembershipTypeDto MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}