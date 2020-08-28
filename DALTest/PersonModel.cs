using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALTest
{
    class PersonModel
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
      
        public DateTime DOB { get; set; }
        public int Salary { get; set; }
        public bool IsActive { get; set; }
    }
}
