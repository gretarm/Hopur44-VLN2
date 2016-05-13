namespace Mooshak2.Models.Entities
{
    public class SubmissionFile
    {
        public int SubmissionFileID { get; set; }
        public int FileID { get; set; }
        public int SubmissionID { get; set; }

        public virtual File File { get; set; }
        public virtual Submission Submission { get; set; }
    }
}