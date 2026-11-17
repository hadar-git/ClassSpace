namespace DAL.Data
{
    public class AssignmentUnit
    {
        public int AssignmentID { get; set; }
        public Assignment? Assignment { get; set; }

        public int UnitID { get; set; }
        public StudyUnit? Unit { get; set; }
    }
}
