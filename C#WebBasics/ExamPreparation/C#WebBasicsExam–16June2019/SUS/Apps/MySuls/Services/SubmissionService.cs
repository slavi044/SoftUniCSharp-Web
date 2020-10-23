using System;
using System.Linq;
using MySuls.Data;

namespace MySuls.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ApplicationDbContext db;
        private readonly Random random;

        public SubmissionService(ApplicationDbContext db)
        {
            this.db = db;
            this.random = random;
        }

        public void Create(string problemId, string userId, string code)
        {
            var problemMaxPoints = this.db.Problems
                   .Where(x => x.Id == problemId)
                   .Select(x => x.Points).FirstOrDefault();

            Submission submission = new Submission
            {
                Code = code,
                ProblemId = problemId,
                UserId = userId,
                AchievedResult = "30",
                CreatedOn = DateTime.UtcNow
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            Submission submission = this.db
                .Submissions
                .Where(x => x.Id == id)
                .FirstOrDefault();

            this.db.Submissions.Remove(submission);
            this.db.SaveChanges();
        }
    }
}
