using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Entity
{
    [Table("listing")]
    public class Listing
    {
        [Key]
        public int Id { get; set; }

        public string ListingUrl { get; set; }

        public int ScrapeId { get; set; }

        //public DateTime LastScraped { get; set; }
        public string LastScraped { get; set; }

        public string Name { get; set; }

        public string Summary { get; set; }

        public string Space { get; set; }

        public string Description { get; set; }

        public string ExperiencesOffered { get; set; }

        public string NeighborhoodOverview { get; set; }

        public string Notes { get; set; }

        public string Transit { get; set; }

        public string ThumbnailUrl { get; set; }

        public string MediumUrl { get; set; }

        public string PictureUrl { get; set; }

        public string XlPictureUrl { get; set; }

        public string HostId { get; set; }

        public string HostUrl { get; set; }

        public string HostName { get; set; }

        //public DateTime HostSince { get; set; }
        public string HostSince { get; set; }

        public string HostAbout { get; set; }

        public string HostResponseTime { get; set; }

        public string HostResponseRate { get; set; }

        public string HostIsSuperHost { get; set; }

        public string PropertyType { get; set; }
    }
}
