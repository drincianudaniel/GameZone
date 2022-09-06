public class PagedResponse<T> : Response<T>
{
    public int PageNumber { get; set; }
    public int TotalCount { get; set; }
    public PagedResponse(T data, int pageNumber, int totalCount)
    {
        this.PageNumber = pageNumber;
        this.TotalCount = totalCount;
        this.Data = data;
    }
}