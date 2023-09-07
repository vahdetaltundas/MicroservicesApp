using FreeCourse.Services.Catagol.Dtos;
using FreeCourse.Services.Catagol.Services;
using FreeCourse.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.Catagol.Controllers
{
    
    public class CoursesController : CustomBaseController
    {
        private readonly ICourseService _corseService;

        public CoursesController(ICourseService corseService)
        {
            _corseService = corseService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            
            return CreateActionResult(await _corseService.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _corseService.GetAllAsync());
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAllByUserId(string id)
        {
            return CreateActionResult(await _corseService.GetAllByUserIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Add(CourseCreateDto courseCreateDto)
        {
            return CreateActionResult(await _corseService.CreateAsync(courseCreateDto));
        }
        [HttpPut]
        public async Task<IActionResult> Update(CourseUpdateDto courseUpdateDto)
        {
            return CreateActionResult(await _corseService.UpdateAsync(courseUpdateDto));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return CreateActionResult(await _corseService.DeleteAsync(id));
        }

    }
}
