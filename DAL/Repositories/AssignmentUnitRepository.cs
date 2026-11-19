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

        public List<AssignmentUnit> GetAssignmentUnits()
        {
            return db.AssignmentUnits
                .Include(au => au.Assignment)
                .Include(au => au.Unit)
                .ToList();
        }

        public AssignmentUnit GetAssignmentUnit(int assignmentId, int unitId)
        {
            return db.AssignmentUnits
                .Include(au => au.Assignment)
                .Include(au => au.Unit)
                .FirstOrDefault(au => au.AssignmentID == assignmentId && au.UnitID == unitId);
        }

        public List<AssignmentUnit> GetUnitsByAssignment(int assignmentId)
        {
            return db.AssignmentUnits
                .Include(au => au.Unit)
                .Where(au => au.AssignmentID == assignmentId)
                .ToList();
        }

        public AssignmentUnit AddAssignmentUnit(AssignmentUnit assignmentUnit)
        {
            db.AssignmentUnits.Add(assignmentUnit);
            db.SaveChanges();
            return assignmentUnit;
        }

        public bool DeleteAssignmentUnit(int assignmentId, int unitId)
        {
            AssignmentUnit assignmentUnit = db.AssignmentUnits.FirstOrDefault(au => au.AssignmentID == assignmentId && au.UnitID == unitId);
            if (assignmentUnit == null)
                return false;
            db.AssignmentUnits.Remove(assignmentUnit);
            db.SaveChanges();
            return true;
        }
    }
}
