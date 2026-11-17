using DAL.Data;

namespace DAL.Repositories
{
    public interface IClassRepository
    {
        List<Class> GetClasses();         // כל הכיתות
        Class GetClass(int id);           // כיתה לפי קוד
        Class AddClass(Class classRoom);      // הוספה
        Class UpdateClass(Class classRoom);   // עדכון
        bool DeleteClass(int id);         // מחיקה לפי קוד
    }
}
