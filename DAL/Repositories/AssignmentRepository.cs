using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private ClassSpaceDB db;

        public AssignmentRepository(ClassSpaceDB db)
        {
            this.db = db;
        }

        public async Task<List<Assignment>> GetAssignmentsAsync()
        {
            return await db.Assignments
                .Include(a => a.TeacherSubject)
                .OrderBy(a => a.DueDate)
                .ToListAsync();
        }

        public async Task<Assignment> GetAssignmentAsync(int id)
        {
            return await db.Assignments
                .Include(a => a.TeacherSubject)
                .FirstOrDefaultAsync(a => a.AssignmentId == id);
        }

        public async Task<Assignment> AddAssignmentAsync(Assignment assignment)
        {
            db.Assignments.Add(assignment);
            await db.SaveChangesAsync();
            return assignment;
        }

        public async Task<Assignment> UpdateAssignmentAsync(Assignment assignment)
        {
            db.Assignments.Update(assignment);
            await db.SaveChangesAsync();
            return assignment;
        }

        public async Task<bool> DeleteAssignmentAsync(int id)
        {
            Assignment assignment = await db.Assignments.FirstOrDefaultAsync(a => a.AssignmentId == id);
            if (assignment == null)
                return false;
            db.Assignments.Remove(assignment);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<List<Assignment>> GetAssignmentsByTeacherSubjectAsync(int teacherSubjectId)
        {
            return await db.Assignments
                .Include(a => a.TeacherSubject)
                .Where(a => a.TeacherSubjectID == teacherSubjectId)
                .OrderBy(a => a.DueDate)
                .ToListAsync();
        }
    }
}
