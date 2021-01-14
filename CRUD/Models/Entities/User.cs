using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Models.Entities
{
    [Table("User")]
    public class User
    {
        [Display(Description = "Id")]
        public int Id { get; set; }

        [Display(Description = "Name")]
        public string Name { get; set; }

        [Display(Description = "Age")]
        public int Age { get; set; }

        [Display(Description = "User type")]
        public int Type { get; set; }

    }
}
