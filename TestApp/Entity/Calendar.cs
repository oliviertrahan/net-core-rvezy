using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Entity
{
    [Table("calendar")]
    public class Calendar
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("listing")]
        public int ListingId { get; set; }

        public DateTime Date { get; set; }

        public bool Available { get; set; }

        public int Price { get; set; }
    }
}
