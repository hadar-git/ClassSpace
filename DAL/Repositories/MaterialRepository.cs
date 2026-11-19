using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private ClassSpaceDB db;

        public MaterialRepository(ClassSpaceDB db)
        {
            this.db = db;
        }

        public List<Material> GetMaterials()
        {
            return db.Materials
                .Include(m => m.UploadedBy)
                .Include(m => m.Unit)
                .Include(m => m.Assignment)
                .Include(m => m.Question)
                .ToList();
        }

        public Material GetMaterial(int id)
        {
            return db.Materials
                .Include(m => m.UploadedBy)
                .Include(m => m.Unit)
                .Include(m => m.Assignment)
                .Include(m => m.Question)
                .FirstOrDefault(m => m.MaterialId == id);
        }

        public Material AddMaterial(Material material)
        {
            db.Materials.Add(material);
            db.SaveChanges();
            return material;
        }

        public Material UpdateMaterial(Material material)
        {
            db.Materials.Update(material);
            db.SaveChanges();
            return material;
        }

        public bool DeleteMaterial(int id)
        {
            Material material = db.Materials.FirstOrDefault(m => m.MaterialId == id);
            if (material == null)
                return false;
            db.Materials.Remove(material);
            db.SaveChanges();
            return true;
        }

        public List<Material> GetMaterialsByUnit(int unitId)
        {
            return db.Materials
                .Include(m => m.UploadedBy)
                .Include(m => m.Unit)
                .Include(m => m.Assignment)
                .Include(m => m.Question)
                .Where(m => m.UnitID == unitId)
                .ToList();
        }

        public List<Material> GetMaterialsByAssignment(int assignmentId)
        {
            return db.Materials
                .Include(m => m.UploadedBy)
                .Include(m => m.Unit)
                .Include(m => m.Assignment)
                .Include(m => m.Question)
                .Where(m => m.AssignmentID == assignmentId)
                .ToList();
        }

        public List<Material> GetMaterialsByQuestion(int questionId)
        {
            return db.Materials
                .Include(m => m.UploadedBy)
                .Include(m => m.Unit)
                .Include(m => m.Assignment)
                .Include(m => m.Question)
                .Where(m => m.QuestionID == questionId)
                .ToList();
        }
    }
}
