using System;
using System.ComponentModel.DataAnnotations;

namespace MySuls.Data
{
    public class Submission
    {
        public Submission()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(800)]
        public string Code { get; set; }

        [Required]
        [MaxLength(300)]
        public string AchievedResult { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public string ProblemId { get; set; }
        public Problem Problem { get; set; }

        public string UserId  { get; set; }
        public User User { get; set; }
    }
}