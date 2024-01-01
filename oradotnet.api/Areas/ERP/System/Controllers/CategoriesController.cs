using Microsoft.AspNetCore.Mvc;
using oradotnet.api.Areas.ERP.System.Models;
using oradotnet.api.Areas.ERP.System.Repositroy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oradotnet.api.Areas.ERP.System.Controllers
{

    [Route("api/ERP/System/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {

        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Project> _projectRepository;

        public CategoriesController(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            return Ok("helo");
        }


    }
}
