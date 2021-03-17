using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class TypeOfCattle
    {
        [Key]
        public int Id { get; set; }
        [StringLength(10)]
        public string Code { get; set; }
        [StringLength(100)]
        public string Name { get; set; }

    }
}
