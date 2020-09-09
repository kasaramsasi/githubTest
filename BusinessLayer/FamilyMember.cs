using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class FamilyMember
    {
        public int id { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Gender is Required")]
        public String Gender { get; set; }
        [Required(ErrorMessage = "City is Required")]
        public String City { get; set; }
        public String Mobileno { get; set; }
       
        
        public DateTime DateoOfBirth { get; set; }


    }
}
