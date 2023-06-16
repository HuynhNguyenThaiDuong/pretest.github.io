using Microsoft.AspNetCore.Mvc;
using WereWolfGameBackEnd.Service.AdminService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WereWolfGameBackEnd.Controllers
{
    [Route("api/admin/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        // GET: api/<AdminController>
        [HttpGet]
        [ActionName("GetPlayerList")]
        public IActionResult GetPList()
        {
            return Ok(_adminService.GetPlayersList());
        }

        // DELETE api/<AdminController>/5
        [HttpDelete]
        [ActionName("DeletePlayer")]
        public IActionResult Delete(string id)
        {
            return Ok(_adminService.DeletePlayer(id));
        }

        [HttpGet]
        [ActionName("GetTransactionList")]
        public IActionResult GetTList()
        {
            return Ok(_adminService.GetTransactionsList());
        }
    }
}
