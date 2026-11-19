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
        public List<StudyUnit> GetStudyUnits()
        {
            return studyUnitRepository.GetStudyUnits();
        }

        // GET api/StudyUnit/5
        [HttpGet("{id}")]
        public ActionResult<StudyUnit> GetStudyUnit(int id)
        {
            StudyUnit studyUnit = studyUnitRepository.GetStudyUnit(id);
            if (studyUnit == null)
                return NotFound();
            return studyUnit;
        }

        // GET api/StudyUnit/subject/5 - היחידות של מקצוע, לפי סדר הפרקים
        [HttpGet("subject/{subjectId}")]
        public List<StudyUnit> GetStudyUnitsBySubject(int subjectId)
        {
            return studyUnitRepository.GetStudyUnitsBySubject(subjectId);
        }

        // POST api/StudyUnit
        [HttpPost]
        public StudyUnit AddStudyUnit(StudyUnit studyUnit)
        {
            return studyUnitRepository.AddStudyUnit(studyUnit);
        }

        // PUT api/StudyUnit
        [HttpPut]
        public StudyUnit UpdateStudyUnit(StudyUnit studyUnit)
        {
            return studyUnitRepository.UpdateStudyUnit(studyUnit);
        }

        // DELETE api/StudyUnit/5
        [HttpDelete("{id}")]
        public ActionResult DeleteStudyUnit(int id)
        {
            if (!studyUnitRepository.DeleteStudyUnit(id))
                return NotFound();
            return Ok();
        }
    }
}
