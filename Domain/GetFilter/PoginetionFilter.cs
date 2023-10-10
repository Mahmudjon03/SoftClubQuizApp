
namespace Domain.GetFilter
{
    public class PaginationFilder
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PaginationFilder()
        {

        }
        public PaginationFilder(int pageNumber, int pageSize)
        {
            if (PageNumber <= 0) PageNumber = 1;
            PageSize = pageSize;
            if (PageSize <= 0) PageSize = 5;
            PageNumber=pageNumber;
        }
    }
}
