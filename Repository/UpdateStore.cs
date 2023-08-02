using Microsoft.EntityFrameworkCore;
using Test_API_LTSEDU.Model.Entity;
using Test_API_LTSEDU.Service;

namespace Test_API_LTSEDU.Repository
{
    public class UpdateStore : IUpdateStore
    {
        private readonly AppDbConext dbConext;
        public UpdateStore()
        {
            dbConext = new AppDbConext();
        }
        private async Task<bool> CheckValidProductId (int ProductDetailId)
        {
            bool ok = await dbConext.ProductDetails.AnyAsync(x => x.Id == ProductDetailId);
            if (ok) { return true; }
            else return false; 
        }
        public async Task<ErrorType> BotSoLuongSanPham(int ProductDetailsId, int SoLuongCapNhat)
        {
            using var trans = dbConext.Database.BeginTransaction();
            {
                try
                {
                    bool ok = await CheckValidProductId(ProductDetailsId);
                    if (!ok) { return ErrorType.SanPhamKhongTonTai; }
                    else
                    {
                        // Track doi tuong Product detail tuong ung
                        ProductDetails? pd = await dbConext.ProductDetails
                            .FirstOrDefaultAsync(x => x.Id == ProductDetailsId);
                        pd!.Quantity -= SoLuongCapNhat;
                        dbConext.ProductDetails.Update(pd); await dbConext.SaveChangesAsync();
                        // Tru cac doi trk/ sau cua no
                        while (pd!.ParentId != null)
                        {
                            pd = await dbConext.ProductDetails.FirstOrDefaultAsync(x => x.Id == pd.ParentId);
                            pd!.Quantity -= SoLuongCapNhat;
                            dbConext.ProductDetails.Update(pd); await dbConext.SaveChangesAsync();
                        }
                    }
                    await trans.CommitAsync();
                    return ErrorType.CapNhatThanhCong;
                }
                catch (Exception)
                {
                    await trans.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<ErrorType> ThemSoLuongSanPham(int ProductDetailsId, int SoLuongCapNhat)
        {
            using var trans = dbConext.Database.BeginTransaction();
            {
                try
                {
                    bool Valid = await CheckValidProductId(ProductDetailsId);
                    if (!Valid) { return ErrorType.SanPhamKhongTonTai; }
                    else
                    {
                        // Track doi tuong Product detail tuong ung
                        ProductDetails? pd = await dbConext.ProductDetails
                            .FirstOrDefaultAsync(x => x.Id == ProductDetailsId);
                        pd!.Quantity += SoLuongCapNhat;
                        dbConext.ProductDetails.Update(pd); await dbConext.SaveChangesAsync();
                        // Truy cap vao cac thuoc tinh doi trk/ doi sau
                        while(pd.ParentId != null)
                        {
                            pd = await dbConext.ProductDetails.FirstOrDefaultAsync(x => x.Id == pd.ParentId);
                            pd!.Quantity += SoLuongCapNhat;
                            dbConext.ProductDetails.Update(pd); await dbConext.SaveChangesAsync();
                        }
                    }
                    await trans.CommitAsync();
                    return ErrorType.CapNhatThanhCong;
                }
                catch (Exception)
                {
                    await trans.RollbackAsync();
                    throw;
                }
            }
        }
    }
}
