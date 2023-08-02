using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_API_LTSEDU.Model.Entity;
using Test_API_LTSEDU.Repository;
using Test_API_LTSEDU.Service.Pagination;

namespace Test_API_LTSEDU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementController : ControllerBase
    {
        private readonly IStoreManagement management;
        public ManagementController()
        {
            management = new StoreManagement();
        }
        // Gui lenh tra ve cac doi tuong dang qan ly trong csdl
        [HttpGet("getProducts")]
        public async Task<IActionResult> GetListProduct([FromQuery]Pagination pagination)
        {
            PageResult<ProductDetails> res = await management.HienThiKhoHang(pagination);
            return Ok(res);
        }
    }
}
