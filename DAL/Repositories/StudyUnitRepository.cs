using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class StudyUnitRepository : IStudyUnitRepository
    {
        private ClassSpaceDB db;

        public StudyUnitRepository(ClassSpaceDB db)
        {
            this.db = db;
        }

        public List<StudyUnit> GetStudyUnits()
        {
            return db.StudyUnits
                .Include(s => s.Subject)
                .OrderBy(s => s.OrderIndex)
                .ToList();
        }

        public StudyUnit GetStudyUnit(int id)
        {
            return db.StudyUnits
                .Include(s => s.Subject)
                .FirstOrDefault(s => s.UnitId == id);
        }

        public StudyUnit AddStudyUnit(StudyUnit studyUnit)
        {
            db.StudyUnits.Add(studyUnit);
            db.SaveChanges();
            return studyUnit;
        }

        public StudyUnit UpdateStudyUnit(StudyUnit studyUnit)
        {
            db.StudyUnits.Update(studyUnit);
            db.SaveChanges();
            return studyUnit;
        }

        public bool DeleteStudyUnit(int id)
        {
            StudyUnit studyUnit = db.StudyUnits.FirstOrDefault(s => s.UnitId == id);
            if (studyUnit == null)
                return false;
            db.StudyUnits.Remove(studyUnit);
            db.SaveChanges();
            return true;
        }

        public List<StudyUnit> GetStudyUnitsBySubject(int subjectId)
        {
            return db.StudyUnits
                .Include(s => s.Subject)
                .Where(s => s.SubjectID == subjectId)
                .OrderBy(s => s.OrderIndex)
                .ToList();
        }
    }
}
