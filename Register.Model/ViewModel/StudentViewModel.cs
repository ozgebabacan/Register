using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Register.Model.ViewModel
{
    public class StudentViewModel
    {
        public long Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Surname")]
        public string Surname { get; set; }

        [DisplayName("Mobile Phone")]
        public string MobilePhone { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("District")]
        public string District { get; set; }


        [DisplayName("Description")]
        public string Description { get; set; }
    }
}