using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class AssignmentUnitRepository : IAssignmentUnitRepository
    {
        private ClassSpaceDB db;

        public AssignmentUnitRepository(ClassSpaceDB db)
        {
            this.db = db;
        }

        public async Task<List<AssignmentUnit>> GetAssignmentUnitsAsync()
        {
            return await db.AssignmentUnits
                .Include(au => au.Assignment)
                .Include(au => au.Unit)
                .ToListAsync();
        }

        public async Task<AssignmentUnit> GetAssignmentUnitAsync(int assignmentId, int unitId)
        {
            return await db.AssignmentUnits
                .Include(au => au.Assignment)
                .Include(au => au.Unit)
                .FirstOrDefaultAsync(au => au.AssignmentID == assignmentId && au.UnitID == unitId);
        }

        public async Task<List<AssignmentUnit>> GetUnitsByAssignmentAsync(int assignmentId)
        {
            return await db.AssignmentUnits
                .Include(au => au.Unit)
                .Where(au => au.AssignmentID == assignmentId)
                .ToListAsync();
        }

        public async Task<AssignmentUnit> AddAssignmentUnitAsync(AssignmentUnit assignmentUnit)
        {
            db.AssignmentUnits.Add(assignmentUnit);
            await db.SaveChangesAsync();
            return assignmentUnit;
        }

        public async Task<bool> DeleteAssignmentUnitAsync(int assignmentId, int unitId)
        {
            AssignmentUnit assignmentUnit = await db.AssignmentUnits.FirstOrDefaultAsync(au => au.AssignmentID == assignmentId && au.UnitID == unitId);
            if (assignmentUnit == null)
                return false;
            db.AssignmentUnits.Remove(assignmentUnit);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
