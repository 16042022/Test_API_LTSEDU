namespace Test_API_LTSEDU.Service.Pagination
{
    public class Pagination
    {
        public int PageNum { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int TotalPage
        {
            get 
            {
                if (PageSize== 0) return 0;
                int a = TotalCount / PageSize;
                if (TotalCount % PageSize != 0) return ++a;
                else return a;
            }
        }

        public Pagination() 
        {
            PageSize = -1;
            PageNum = 1;
        }
    }
}
