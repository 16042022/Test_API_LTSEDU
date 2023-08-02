using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using Test_API_LTSEDU.Model.Entity;
using Test_API_LTSEDU.Service.Pagination;

namespace Test_API_LTSEDU.Repository
{
    public class StoreManagement : IStoreManagement
    {
        private readonly AppDbConext dbConext;
        public StoreManagement()
        {
            dbConext = new AppDbConext();
        }
        //Tra ve list distinct cac Id la doi thuoc tinh cuoi cung
        public async Task<List<int>> TheLastProp()
        {
            List<int> lastProp = await dbConext.ProductDetailPropertyDetails
                .Select(x => x.ProductDetailsId).Distinct().ToListAsync();
            return lastProp;
        }
        public async Task<PageResult<ProductDetails>> HienThiKhoHang(Pagination pgn)
        {
            List<int> lastProp = await TheLastProp();
            // Tra ve list cac ProductDetail hien tai
            var curr_item = await dbConext.ProductDetails
                .Where(pd => lastProp.Contains(pd.Id)).ToListAsync();

            // Get the paginated data
            var res = PageResult<ProductDetails>.ToPageResult(pgn, curr_item);
            pgn.TotalCount = curr_item.Count;
            return new PageResult<ProductDetails>(pgn, res);
        }
    }
}
