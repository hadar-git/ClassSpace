namespace DTO
{
    public class MaterialPostDto
    {
        public string Title { get; set; }
        public string FilePath { get; set; }
        public int UploadedByID { get; set; }
        public int UnitID { get; set; }
        public int? AssignmentID { get; set; }
        public int? QuestionID { get; set; }
    }
}
