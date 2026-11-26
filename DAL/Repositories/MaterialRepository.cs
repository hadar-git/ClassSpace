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

        public async Task<List<Material>> GetMaterialsAsync()
        {
            return await db.Materials
                .Include(m => m.UploadedBy)
                .Include(m => m.Unit)
                .Include(m => m.Assignment)
                .Include(m => m.Question)
                .ToListAsync();
        }

        public async Task<Material> GetMaterialAsync(int id)
        {
            return await db.Materials
                .Include(m => m.UploadedBy)
                .Include(m => m.Unit)
                .Include(m => m.Assignment)
                .Include(m => m.Question)
                .FirstOrDefaultAsync(m => m.MaterialId == id);
        }

        public async Task<Material> AddMaterialAsync(Material material)
        {
            db.Materials.Add(material);
            await db.SaveChangesAsync();
            return material;
        }

        public async Task<Material> UpdateMaterialAsync(Material material)
        {
            db.Materials.Update(material);
            await db.SaveChangesAsync();
            return material;
        }

        public async Task<bool> DeleteMaterialAsync(int id)
        {
            Material material = await db.Materials.FirstOrDefaultAsync(m => m.MaterialId == id);
            if (material == null)
                return false;
            db.Materials.Remove(material);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<List<Material>> GetMaterialsByUnitAsync(int unitId)
        {
            return await db.Materials
                .Include(m => m.UploadedBy)
                .Include(m => m.Unit)
                .Include(m => m.Assignment)
                .Include(m => m.Question)
                .Where(m => m.UnitID == unitId)
                .ToListAsync();
        }

        public async Task<List<Material>> GetMaterialsByAssignmentAsync(int assignmentId)
        {
            return await db.Materials
                .Include(m => m.UploadedBy)
                .Include(m => m.Unit)
                .Include(m => m.Assignment)
                .Include(m => m.Question)
                .Where(m => m.AssignmentID == assignmentId)
                .ToListAsync();
        }

        public async Task<List<Material>> GetMaterialsByQuestionAsync(int questionId)
        {
            return await db.Materials
                .Include(m => m.UploadedBy)
                .Include(m => m.Unit)
                .Include(m => m.Assignment)
                .Include(m => m.Question)
                .Where(m => m.QuestionID == questionId)
                .ToListAsync();
        }
    }
}
