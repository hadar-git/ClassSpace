namespace DAL.Data
{
    public class StudyUnit
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int OrderIndex { get; set; }

        public int SubjectID { get; set; }
        public Subject? Subject { get; set; }
    }
}
