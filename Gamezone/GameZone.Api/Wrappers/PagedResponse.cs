public class PagedResponse<T> : Response<T>
{
    public int PageNumber { get; set; }
    public int TotalCount { get; set; }
    public int PageSize { get; set; }
    public PagedResponse(T data, int pageNumber, int totalCount, int pageSize)
    {
        this.PageNumber = pageNumber;
        this.TotalCount = totalCount;
        this.PageSize = pageSize;
        this.Data = data;
    }
}