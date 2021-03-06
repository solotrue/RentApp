using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rent.Shared.Models;
using Rent.Shared.Request;
using Rent.Server.Data;
using Rent.Server.Repositories.Extensions;
using System.Linq.Dynamic.Core;


namespace Rent.Server.Repositories 
	{
		public class CityRepository : AppRepository<City>, ICityRepository
		{
			private readonly AppDbContext _dbContext;
			public CityRepository(AppDbContext dbContext) : base(dbContext)
			{
				_dbContext = dbContext;
			}

			public async Task<PagedList<City>> GetAllCities(CityPagingParameters cityPagingParameters)
			{
				var result = await _dbContext.Cities
											.Search(cityPagingParameters.SearchTerm)
											.OrderBy(cityPagingParameters.OrderBy)
											.ToListAsync();
				return PagedList<City>.ToPagedList(result, cityPagingParameters.PageNumber, cityPagingParameters.PageSize);
			}
			public async Task<City> GetCityByTitle(string title) 
			{
				return await _dbContext.Cities.FirstOrDefaultAsync(c => c.Title == title);
			}
    
		}
	}

