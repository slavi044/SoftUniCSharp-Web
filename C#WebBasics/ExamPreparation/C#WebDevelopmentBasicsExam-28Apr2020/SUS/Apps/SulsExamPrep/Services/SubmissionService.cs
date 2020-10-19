using SulsExamPrep.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SulsExamPrep.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ApplicationDbContext db;
        private readonly Random random;

        public SubmissionService(ApplicationDbContext db, Random random)
        {
            this.db = db;
            this.random = random;
        }

        public void Create(string problemId, string userId, string code)
        {
            int problemMaxPoints = this.db
                .Problems
                .Where(x => x.Id == problemId)
                .Select(x => x.Points)
                .FirstOrDefault();

            Submission submission = new Submission
            {
                Code = code,
                ProblemId = problemId,
                UserId = userId,
                AchievedResult = (ushort)this.random.Next(0, problemMaxPoints + 1),
                CreatedOn = DateTime.UtcNow
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            var submission = this.db.Submissions.Find(id);

            this.db.Submissions.Remove(submission);
            this.db.SaveChanges();
        }
    }
}
