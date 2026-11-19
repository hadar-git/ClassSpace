namespace DAL.Data
{
    public class Vote
    {
        public int QuestionID { get; set; }
        public Question? Question { get; set; }

        public int StudentID { get; set; }
        public User? Student { get; set; }
    }
}
