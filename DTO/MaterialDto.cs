namespace DTO
{
    public class MaterialDto
    {
        public int MaterialId { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadedAt { get; set; }
        public int UploadedByID { get; set; }
        public string UploadedByFullName { get; set; }
        public int UnitID { get; set; }
        public string UnitUnitName { get; set; }
        public int? AssignmentID { get; set; }
        public int? QuestionID { get; set; }
    }
}
