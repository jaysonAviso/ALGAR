using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        
        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }
        
        [MaxLength(100)]
        public string Phone { get; set; }
        
        [MaxLength(100)]
        public string Email { get; set; }
    }
}