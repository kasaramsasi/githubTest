using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
   public  class Register
    {
        public int Userid { get; set; }

        [Required(ErrorMessage ="UserName Required")]
        public String Username { get; set; }

        [Required(ErrorMessage ="Password Required")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}
