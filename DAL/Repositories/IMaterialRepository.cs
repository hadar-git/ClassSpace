using DAL.Data;

namespace DAL.Repositories
{
    public interface IMaterialRepository
    {
        List<Material> GetMaterials();                               // כל החומרים
        Material GetMaterial(int id);                                // חומר לפי קוד
        Material AddMaterial(Material material);                     // הוספה
        Material UpdateMaterial(Material material);                  // עדכון
        bool DeleteMaterial(int id);                                 // מחיקה לפי קוד
        List<Material> GetMaterialsByUnit(int unitId);               // החומרים של יחידה
        List<Material> GetMaterialsByAssignment(int assignmentId);   // החומרים של מטלה
        List<Material> GetMaterialsByQuestion(int questionId);       // החומרים של שאלה
    }
}
