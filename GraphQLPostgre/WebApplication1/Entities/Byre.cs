using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class Byre
    {
        [Key]
        public int Id { get; set; }
        [StringLength(10)]
        public string Code { set; get; }
        [StringLength(100)]
        public string Name { set; get; }
        public int? QuantityCattle { set; get; }
        public int FarmerId { set; get; }
        public Farmer Farmer { get; set; }
    }
}
