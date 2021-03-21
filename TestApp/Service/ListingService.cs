using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Entity;
using TestApp.Repository;

namespace TestApp.Service
{
    public class ListingService
    {
        private readonly DataContext _dataContext;

        public ListingService(
            DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Listing>> GetAll(string propertyType)
        {
            var weatherForecastSet = _dataContext.Set<Listing>();
            var queryable = weatherForecastSet.AsQueryable();
            if (!string.IsNullOrEmpty(propertyType))
            {
                queryable = queryable.Where(x => x.PropertyType == propertyType);
            }
            return queryable.ToList();
        }

        public async Task<Listing> GetById(int id)
        {
            var listingSet = _dataContext.Set<Listing>();
            var listing = await listingSet.FindAsync(id);
            if (listing != null)
            {
                return listing;
            }
            //Make it a 400 in a real application
            throw new ArgumentException();
        }

        public async Task<Listing> Create(Listing request)
        {
            await _dataContext.AddAsync(request);
            await _dataContext.SaveChangesAsync();

            return request;
        }

        public async Task<Listing> Update(Listing request)
        {
            _dataContext.Update(request);
            await _dataContext.SaveChangesAsync();

            return request;
        }
    }
}
