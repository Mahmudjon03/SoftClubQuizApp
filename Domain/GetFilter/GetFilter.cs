
namespace Domain.GetFilter
{
    public class GetFilter : PaginationFilder
    {
        public string ?Name { get; set; }
        public GetFilter()
        {
            
        }
        public GetFilter(int pageNumber, int pageSize) : base(pageNumber, pageSize)
        {
        }



       

    }
}
