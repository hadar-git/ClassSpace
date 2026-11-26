using DAL.Data;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClassSpace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyUnitController : ControllerBase
    {
        private IStudyUnitRepository studyUnitRepository;

        public StudyUnitController(IStudyUnitRepository studyUnitRepository)
        {
            this.studyUnitRepository = studyUnitRepository;
        }

        // GET api/StudyUnit
        [HttpGet]
        public async Task<List<StudyUnit>> GetStudyUnits()
        {
            return await studyUnitRepository.GetStudyUnitsAsync();
        }

        // GET api/StudyUnit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudyUnit>> GetStudyUnit(int id)
        {
            StudyUnit studyUnit = await studyUnitRepository.GetStudyUnitAsync(id);
            if (studyUnit == null)
                return NotFound();
            return studyUnit;
        }

        // GET api/StudyUnit/subject/5 - היחידות של מקצוע, לפי סדר הפרקים
        [HttpGet("subject/{subjectId}")]
        public async Task<List<StudyUnit>> GetStudyUnitsBySubject(int subjectId)
        {
            return await studyUnitRepository.GetStudyUnitsBySubjectAsync(subjectId);
        }

        // POST api/StudyUnit
        [HttpPost]
        public async Task<StudyUnit> AddStudyUnit(StudyUnit studyUnit)
        {
            return await studyUnitRepository.AddStudyUnitAsync(studyUnit);
        }

        // PUT api/StudyUnit
        [HttpPut]
        public async Task<StudyUnit> UpdateStudyUnit(StudyUnit studyUnit)
        {
            return await studyUnitRepository.UpdateStudyUnitAsync(studyUnit);
        }

        // DELETE api/StudyUnit/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudyUnit(int id)
        {
            if (!await studyUnitRepository.DeleteStudyUnitAsync(id))
                return NotFound();
            return Ok();
        }
    }
}