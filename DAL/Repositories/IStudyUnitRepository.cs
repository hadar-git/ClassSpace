using DAL.Data;

namespace DAL.Repositories
{
    public interface IStudyUnitRepository
    {
        List<StudyUnit> GetStudyUnits();                         // כל היחידות
        StudyUnit GetStudyUnit(int id);                          // יחידה לפי קוד
        StudyUnit AddStudyUnit(StudyUnit studyUnit);             // הוספה
        StudyUnit UpdateStudyUnit(StudyUnit studyUnit);          // עדכון
        bool DeleteStudyUnit(int id);                            // מחיקה לפי קוד
        List<StudyUnit> GetStudyUnitsBySubject(int subjectId);   // היחידות של מקצוע, לפי סדר הפרקים
    }
}
