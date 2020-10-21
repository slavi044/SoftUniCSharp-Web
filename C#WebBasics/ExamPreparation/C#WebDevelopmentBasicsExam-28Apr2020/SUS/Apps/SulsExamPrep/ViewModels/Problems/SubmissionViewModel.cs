using System;

namespace SulsExamPrep.ViewModels.Problems
{
    public class SubmissionViewModel
    {
        public string Username { get; set; }

        public string SubmissionId { get; set; }

        public int AchievedResult { get; set; }

        public DateTime CreatedOn { get; set; }

        public int MaxPoints { get; set; }
    }
}
