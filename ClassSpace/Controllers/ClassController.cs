using DAL.Data;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClassSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private IClassRepository classRepository;

        public ClassController(IClassRepository classRepository)
        {
            this.classRepository = classRepository;
        }

        // GET api/Class
        [HttpGet]
        public List<Class> GetClasses()
        {
            return classRepository.GetClasses();
        }

        // GET api/Class/5
        [HttpGet("{id}")]
        public ActionResult<Class> GetClass(int id)
        {
            Class classRoom = classRepository.GetClass(id);
            if (classRoom == null)
                return NotFound();
            return classRoom;
        }

        // POST api/Class
        [HttpPost]
        public Class AddClass(Class classRoom)
        {
            return classRepository.AddClass(classRoom);
        }

        // PUT api/Class
        [HttpPut]
        public Class UpdateClass(Class classRoom)
        {
            return classRepository.UpdateClass(classRoom);
        }

        // DELETE api/Class/5
        [HttpDelete("{id}")]
        public ActionResult DeleteClass(int id)
        {
            if (!classRepository.DeleteClass(id))
                return NotFound();
            return Ok();
        }
    }
}
