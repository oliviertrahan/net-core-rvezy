using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Entity
{
    [Table("review")]
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("listing")]
        public int ListingId { get; set; }

        public DateTime Date { get; set; }

        public int ReviewerId { get; set; }

        public string ReviewerName { get; set; }

        public string Comments { get; set; }
    }
}
