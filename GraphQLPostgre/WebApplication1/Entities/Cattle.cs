using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class Cattle
    {
        [Key]
        public int Id { get; set; }
        public int ByreId { set; get; }
        public Byre Byre { set; get; }
        public int? MotherId { set; get; }
        public int? FatherId { set; get; }
        [StringLength(50)]
        public string Name { set; get; }
        [StringLength(20)]
        public string Code { set; get; }
        public DateTime Birthday { set; get; }
        public DateTime DateBuy { get; set; }
        public DateTime ReproductionDateNearest { get; set; }
        [StringLength(10)]
        public string Gender { set; get; }
        public int TypeOfCattleId { get; set; }
        public TypeOfCattle TypeOfCattle { get; set; }

    }
}
