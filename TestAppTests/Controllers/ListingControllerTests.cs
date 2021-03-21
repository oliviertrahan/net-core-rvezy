using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestApp.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Entity;
using TestApp.Service;
using System.Linq;

namespace TestApp.Controllers.Tests
{
    [TestClass()]
    public class ListingControllerTests
    {

        private readonly ListingService _listingService;

        private int GetRandomId()
        {
            var random = new Random();
            return random.Next(0, int.MaxValue);
        }

        [TestMethod()]
        public void GetAllTest()
        {
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