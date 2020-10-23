using MySuls.Data;
using MySuls.ViewModels.Problems;
using MySuls.ViewModels.Submissions;
using System.Collections.Generic;
using System.Linq;

namespace MySuls.Services
{
    public class ProblemService : IProblemService
    {
        private readonly ApplicationDbContext db;

        public ProblemService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, ushort points)
        {
            Problem problem = new Problem
            {
                Name = name,
                Points = points
            };

            this.db.Problems.Add(problem);
            this.db.SaveChanges();
        }

        public IEnumerable<HomePageProblemViewModel> GetAll()
        {
            var problems = this.db
                .Problems
                .Select(x => new HomePageProblemViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Count = x.Submissions.Count()
                })
                .ToList();

            return problems;
        }

        public ProblemViewModel GetById(string id)
        {
            return this.db.Problems
                .Where(x => x.Id == id)
                .Select(x => new ProblemViewModel
                {
                    Name = x.Name,
                    Submissions = x.Submissions.Select(s => new SubmissionViewModel
                    {
                        CreatedOn = s.CreatedOn,
                        SubmissionId = s.Id,
                        AchievedResult = int.Parse(s.AchievedResult),
                        Username = s.User.Username,
                        MaxPoints = x.Points,
                    })
                })
                .FirstOrDefault();
        }

        public string GetNameById(string id)
        {
            return this.db.Problems
                .Where(x => x.Id == id)
                .Select(x => x.Name)
                .FirstOrDefault();
        }
    }
}
