    using Microsoft.AspNetCore.Mvc;
    using POS.Application.Dtos.Request;
    using POS.Application.Interfaces;
    using POS.Infraestructure.Commons.Bases.Request;
    using POS.Infraestructure.Commons.Bases.Response;


namespace POS.Api.Controllers
    {
        [Route("api/[controller]")]
        public class CategoryController : ControllerBase

        {
            private readonly ICategoryApplication _categoryApplication;

            public CategoryController(ICategoryApplication categoryApplication)
            {
                _categoryApplication = categoryApplication;
            }

        
            [HttpPost]
            public async Task<IActionResult> ListCategories([FromBody] BaseFiltersRequest filters)
            {
                var response = await _categoryApplication.ListCategories(filters);
                return Ok(response);
            }

        
            [HttpGet("Select")]
            public async Task<IActionResult> ListSelectCategories()
            {
                var response = await _categoryApplication.ListSelectCategories();
                return Ok(response);
            }

        
            [HttpGet("{CategoryId:int}")]
            public async Task<IActionResult> CategoryId(int categoriId)
            {
                var response = await _categoryApplication.CategoryById(categoriId);

                return Ok(response);
            }

            [HttpPost("Register")]
            public async Task<IActionResult> RegisterCategory([FromBody] CategoryRequestDto requestDto)
            {
                var response = await _categoryApplication.RegisterCategory(requestDto);
                return Ok(response);
            }

            [HttpPut("Edit/{categoryId:int}")]
            public async Task<IActionResult> EditCategory(int categoryId, [FromBody] CategoryRequestDto requestDto)
            {
                var response = await _categoryApplication.EditCategory(categoryId, requestDto);
                return Ok(response);
            }

            [HttpPut("Remove/{categoryId:int}")]
            public async Task<IActionResult> RemoveCategory(int categoryId)
            {
                var response = await _categoryApplication.RemoveCategory(categoryId);
                return Ok(response);
            }

        }
    }

