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

        public async Task<List<StudyUnit>> GetStudyUnitsAsync()
        {
            return await db.StudyUnits
                .Include(s => s.Subject)
                .OrderBy(s => s.OrderIndex)
                .ToListAsync();
        }

        public async Task<StudyUnit> GetStudyUnitAsync(int id)
        {
            return await db.StudyUnits
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(s => s.UnitId == id);
        }

        public async Task<StudyUnit> AddStudyUnitAsync(StudyUnit studyUnit)
        {
            await db.StudyUnits.AddAsync(studyUnit);
            await db.SaveChangesAsync();
            return studyUnit;
        }

        public async Task<StudyUnit> UpdateStudyUnitAsync(StudyUnit studyUnit)
        {
            db.StudyUnits.Update(studyUnit);
            await db.SaveChangesAsync();
            return studyUnit;
        }

        public async Task<bool> DeleteStudyUnitAsync(int id)
        {
            StudyUnit studyUnit = await db.StudyUnits.FirstOrDefaultAsync(s => s.UnitId == id);
            if (studyUnit == null)
                return false;
            db.StudyUnits.Remove(studyUnit);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<List<StudyUnit>> GetStudyUnitsBySubjectAsync(int subjectId)
        {
            return await db.StudyUnits
                .Include(s => s.Subject)
                .Where(s => s.SubjectID == subjectId)
                .OrderBy(s => s.OrderIndex)
                .ToListAsync();
        }
    }
}