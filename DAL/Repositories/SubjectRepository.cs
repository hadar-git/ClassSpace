using DAL.Data;

namespace DAL.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private ClassSpaceDB db;

        public SubjectRepository(ClassSpaceDB db)
        {
            this.db = db;
        }

        public List<Subject> GetSubjects()
        {
            return db.Subjects.ToList();
        }

        public Subject GetSubject(int id)
        {
            return db.Subjects.FirstOrDefault(s => s.SubjectId == id);
        }

        public Subject AddSubject(Subject subject)
        {
            db.Subjects.Add(subject);
            db.SaveChanges();
            return subject;
        }

        public Subject UpdateSubject(Subject subject)
        {
            db.Subjects.Update(subject);
            db.SaveChanges();
            return subject;
        }

        public bool DeleteSubject(int id)
        {
            Subject subject = GetSubject(id);
            if (subject == null)
                return false;
            db.Subjects.Remove(subject);
            db.SaveChanges();
            return true;
        }
    }
}
