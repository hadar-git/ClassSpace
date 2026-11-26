using DAL.Data;

namespace DAL.Repositories
{
    public interface IMaterialRepository
    {
        Task<List<Material>> GetMaterialsAsync();                               // כל החומרים
        Task<Material> GetMaterialAsync(int id);                                // חומר לפי קוד
        Task<Material> AddMaterialAsync(Material material);                     // הוספה
        Task<Material> UpdateMaterialAsync(Material material);                  // עדכון
        Task<bool> DeleteMaterialAsync(int id);                                 // מחיקה לפי קוד
        Task<List<Material>> GetMaterialsByUnitAsync(int unitId);               // החומרים של יחידה
        Task<List<Material>> GetMaterialsByAssignmentAsync(int assignmentId);   // החומרים של מטלה
        Task<List<Material>> GetMaterialsByQuestionAsync(int questionId);       // החומרים של שאלה
    }
}
