namespace Rent.Shared.Request
{
    public class PagingParameters
    {
		const int maxPageSize = 1000; 
		public int PageNumber { get; set; } = 1; 
		private int _pageSize = 3; 
		public int PageSize 
		{ 
			get 
			{ 
				return _pageSize; 
			} 
			set 
			{ 
				_pageSize = (value > maxPageSize) ? maxPageSize : value; 
			}
		}
		public string SearchTerm { get; set; }
		public string OrderBy { get; set; } = "Title";
	}

}
