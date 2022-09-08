public class PagedResponse<T> : Response<T>
{
    public int PageNumber { get; set; }
    public int TotalRecords { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public PagedResponse(T data, int pageNumber, int totalRecords, int totalPages, int pageSize)
    {
        this.PageNumber = pageNumber;
        this.TotalRecords = totalRecords;
        this.TotalPages = totalPages;
        this.PageSize = pageSize;
        this.Data = data;
    }
}