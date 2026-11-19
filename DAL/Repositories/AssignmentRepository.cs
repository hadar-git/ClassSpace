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

        public List<Assignment> GetAssignments()
        {
            return db.Assignments
                .Include(a => a.TeacherSubject)
                .OrderBy(a => a.DueDate)
                .ToList();
        }

        public Assignment GetAssignment(int id)
        {
            return db.Assignments
                .Include(a => a.TeacherSubject)
                .FirstOrDefault(a => a.AssignmentId == id);
        }

        public Assignment AddAssignment(Assignment assignment)
        {
            db.Assignments.Add(assignment);
            db.SaveChanges();
            return assignment;
        }

        public Assignment UpdateAssignment(Assignment assignment)
        {
            db.Assignments.Update(assignment);
            db.SaveChanges();
            return assignment;
        }

        public bool DeleteAssignment(int id)
        {
            Assignment assignment = db.Assignments.FirstOrDefault(a => a.AssignmentId == id);
            if (assignment == null)
                return false;
            db.Assignments.Remove(assignment);
            db.SaveChanges();
            return true;
        }

        public List<Assignment> GetAssignmentsByTeacherSubject(int teacherSubjectId)
        {
            return db.Assignments
                .Include(a => a.TeacherSubject)
                .Where(a => a.TeacherSubjectID == teacherSubjectId)
                .OrderBy(a => a.DueDate)
                .ToList();
        }
    }
}
