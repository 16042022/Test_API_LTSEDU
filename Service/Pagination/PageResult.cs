namespace Test_API_LTSEDU.Service.Pagination
{
    public class PageResult<T>
    {
        public Pagination pagination { get; set; }
        public List<T> items { get; set; }
        public PageResult(Pagination png, List<T> items)
        {
            pagination = png;
            this.items = items;
        }
        public static List<T> ToPageResult(Pagination pagination, List<T> data)
        {
            pagination.PageNum = (pagination.PageNum < 0)? 1: pagination.PageNum;
            data = data.Skip(pagination.PageSize*(pagination.PageNum-1)).Take(pagination.PageSize).ToList();
            return data;
        }
    }
}
