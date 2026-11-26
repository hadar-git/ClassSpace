using DAL.Data;

namespace DAL.Repositories
{
    public interface IStudyUnitRepository
    {
        Task<List<StudyUnit>> GetStudyUnitsAsync();                         // כל היחידות
        Task<StudyUnit> GetStudyUnitAsync(int id);                          // יחידה לפי קוד
        Task<StudyUnit> AddStudyUnitAsync(StudyUnit studyUnit);             // הוספה
        Task<StudyUnit> UpdateStudyUnitAsync(StudyUnit studyUnit);          // עדכון
        Task<bool> DeleteStudyUnitAsync(int id);                            // מחיקה לפי קוד
        Task<List<StudyUnit>> GetStudyUnitsBySubjectAsync(int subjectId);   // היחידות של מקצוע, לפי סדר הפרקים
    }
}