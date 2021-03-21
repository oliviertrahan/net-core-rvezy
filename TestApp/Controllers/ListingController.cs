using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Controllers.Dto;
using TestApp.Entity;
using TestApp.Repository;
using TestApp.Service;

namespace TestApp.Controllers
{
    [ApiController]
    [Route("listing")]
    public class ListingController : ControllerBase
    {
        private readonly ILogger<ListingController> _logger;
        private readonly ListingService _listingService;

        public ListingController(
            ILogger<ListingController> logger,
            ListingService listingService)
        {
            _logger = logger;
            _listingService = listingService;
        }

        [HttpGet]
        public async Task<IEnumerable<Listing>> GetAll([FromQuery] string property_type)
        {
            return await _listingService.GetAll(property_type);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Listing> GetById([FromRoute] int id)
        {
            var listing = await _listingService.GetById(id);
            if (listing != null)
            {
                return listing;
            }
            //Make it a 404 in a real application
            throw new ArgumentException();
        }

        //Would normally put request in a DTO, using entity in the interest of time
        [HttpPost]
        public async Task<Listing> Post([FromBody] Listing request)
        {
            var listing = await _listingService.Create(request);
            return listing;
        }
    }
}
