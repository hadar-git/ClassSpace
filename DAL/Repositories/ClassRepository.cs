using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private ClassSpaceDB db;

        public ClassRepository(ClassSpaceDB db)
        {
            this.db = db;
        }

        public List<Class> GetClasses()
        {
            return db.Classes
                .ToList();
        }

        public Class GetClass(int id)
        {
            return db.Classes
                .FirstOrDefault(c => c.ClassId == id);
        }

        public Class AddClass(Class classRoom)
        {
            db.Classes.Add(classRoom);
            db.SaveChanges();
            return classRoom;
        }

        public Class UpdateClass(Class classRoom)
        {
            db.Classes.Update(classRoom);
            db.SaveChanges();
            return classRoom;
        }

        public bool DeleteClass(int id)
        {
            Class classRoom = db.Classes.FirstOrDefault(c => c.ClassId == id);
            if (classRoom == null)
                return false;
            db.Classes.Remove(classRoom);
            db.SaveChanges();
            return true;
        }
    }
}
