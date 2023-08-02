using Microsoft.EntityFrameworkCore;
using Test_API_LTSEDU.Model.Entity;
using Test_API_LTSEDU.Service;

namespace Test_API_LTSEDU.Repository
{
    public class Transaction : ITransaction
    {
        private readonly AppDbConext dbConext;
        public Transaction()
        {
            dbConext = new AppDbConext();
        }
        // Tra ve 1 list cac danh sach ProductId co doi goc cua no la NULL
        private async Task<bool> CheckIdHopLe(int ProductDetailId)
        {
            // Tim trong danh sach don nhat cac ma, kiem tra ma nhap va co trung ma trong bang PDPD ko
            List<int> checkList = await dbConext.ProductDetailPropertyDetails
                .Select(x => x.ProductDetailsId).Distinct().ToListAsync();
            int ind = checkList.BinarySearch(ProductDetailId);
            if (ind < 0) { return false; }
            return true;
        }
        public async Task<ErrorType> MuaHang(int ProductDetailId, int SoLuongMua)
        {
            using var trans = dbConext.Database.BeginTransaction();
            {
                try
                {
                    // Kiem tra Id co nhap sai ko
                    bool valid = await dbConext.ProductDetails.AnyAsync(x => x.Id == ProductDetailId);
                    if (!valid) { return ErrorType.SanPhamKhongTonTai; }
                    else
                    {
                        bool hopLe = await CheckIdHopLe(ProductDetailId);
                        if (!hopLe) { return ErrorType.IdSanPhamKhongHopLe; }
                        else
                        {
                            // Tra ve doi tuong ProductDetail tuong ung voi ma vua nhap
                            ProductDetails? pd = await dbConext.ProductDetails
                                .FirstOrDefaultAsync(x => x.Id == ProductDetailId);
                            if (SoLuongMua > pd!.Quantity) return ErrorType.SanPhamKhongDuSoLuongBan;
                            else if (SoLuongMua < 1) return ErrorType.SoLuongMuaPhaiLonHon1;
                            else
                            {
                                pd!.Quantity -= SoLuongMua;
                                dbConext.ProductDetails.Update(pd); await dbConext.SaveChangesAsync();
                                // Tru cac doi cha cua doi tuong nay
                                while (pd!.ParentId != null)
                                {
                                    pd = await dbConext.ProductDetails.FirstOrDefaultAsync(x => x.Id == pd.ParentId);
                                    pd!.Quantity -= SoLuongMua;
                                    dbConext.ProductDetails.Update(pd); await dbConext.SaveChangesAsync();
                                }
                                // Qua trinh dat hang done, tra ve ket qua
                            }
                        }
                    }
                    await trans.CommitAsync();
                    return ErrorType.DatHangThanhCong;
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
