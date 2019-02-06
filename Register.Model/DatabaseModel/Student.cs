using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Model.DatabaseModel
{
    public class Student:BaseModel
    {
        [Required(ErrorMessage = "*")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "*")]
        [MinLength(15,ErrorMessage = "Input Correct Mobile Number")]
        [DisplayName("Mobile Phone")]
        public string MobilePhone { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("City")]
        public virtual City City { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("District")]
        public virtual District District { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Description")]
        public string Description { get; set; }
    }
}
