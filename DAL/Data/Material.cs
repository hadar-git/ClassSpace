namespace DAL.Data
{
    public class Material
    {
        public int MaterialId { get; set; }

        public string Title { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadedAt { get; set; }

        public int UploadedByID { get; set; }
        public User? UploadedBy { get; set; }

        public int UnitID { get; set; }
        public StudyUnit? Unit { get; set; }

        // מורה מקשרת למטלה, תלמידה מקשרת לשאלה, לכן שניהם לא חובה
        public int? AssignmentID { get; set; }
        public Assignment? Assignment { get; set; }

        public int? QuestionID { get; set; }
        public Question? Question { get; set; }
    }
}
