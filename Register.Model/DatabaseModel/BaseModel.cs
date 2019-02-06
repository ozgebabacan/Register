using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Model.DatabaseModel
{
    public class BaseModel
    {
        [Key]
        public long Id { get; set; }
    }
}
