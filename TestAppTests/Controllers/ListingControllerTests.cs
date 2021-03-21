using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestApp.Controllers;
using System;
using TestApp.Entity;
using TestApp.Service;
using System.Linq;
using TestApp.Repository;
using Microsoft.EntityFrameworkCore;

namespace TestApp.Controllers.Tests
{
    [TestClass()]
    public class ListingControllerTests
    {
        private ListingService _listingService;
        private ListingController _listingController;

        private DbContextOptions<DataContext> _dbContextOptions = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase("tempdb")
            .Options;

        public void Setup()
        {
            var dataContext = new DataContext(_dbContextOptions);
            _listingService = new ListingService(dataContext);
            _listingController = new ListingController(_listingService);
        }

        private int GetRandomId()
        {
            var random = new Random();
            return random.Next(0, int.MaxValue);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            Setup();
            var id = GetRandomId();
            var listing = new Listing
            {
                Id = id,
                ListingUrl = "https://url.com"
            };
            var newListing =_listingService.Create(listing).Result;
            var listings = _listingService.GetAll(null).Result.ToList();
            Assert.IsTrue(listings.Exists(x => x.Id == id));
        }

        [TestMethod()]
        public void GetAllPropertyTypeFiltersOutTest()
        {
            Setup();
            var id = GetRandomId();
            var listing = new Listing
            {
                Id = id,
                ListingUrl = "https://url.com",
                PropertyType = "Apartment"
            };
            var newListing = _listingService.Create(listing).Result;
            var listings = _listingService.GetAll("Condo").Result.ToList();
            Assert.IsFalse(listings.Exists(x => x.Id == id));
        }

        [TestMethod()]
        public void GetAllPropertyTypeFiltersInTest()
        {
            Setup();
            var id = GetRandomId();
            var listing = new Listing
            {
                Id = id,
                ListingUrl = "https://url.com",
                PropertyType = "Apartment"
            };
            var newListing = _listingService.Create(listing).Result;
            var listings = _listingService.GetAll("Apartment").Result.ToList();
            Assert.IsTrue(listings.Exists(x => x.Id == id));
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Setup();
            var id = GetRandomId();
            var listing = new Listing
            {
                Id = id,
                ListingUrl = "https://url.com"
            };
            var newListing = _listingService.Create(listing).Result;
            var retrivedListing = _listingService.GetById(id).Result;
            Assert.IsNotNull(retrivedListing);
        }

        [TestMethod()]
        public void CreateTest()
        {
            Setup();
            var id = GetRandomId();
            var listing = new Listing
            {
                Id = id,
                ListingUrl = "https://url.com"
            };
            var newListing = _listingService.Create(listing).Result;
            Assert.IsNotNull(newListing);
        }
    }
}