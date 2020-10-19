using SulsExamPrep.Data;
using SulsExamPrep.ViewModels.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SulsExamPrep.Services
{
    public class ProblemService : IProblemService
    {
        private ApplicationDbContext db;

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
            List<HomePageProblemViewModel> problems = this.db
                .Problems
                .Select(x => new HomePageProblemViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Count = x.Submissions.Count
                })
               .ToList();

            return problems;
        }

        public string GetNameById(string id)
        {
            string problemName = this.db
                .Problems
                .Where(x => x.Id == id)
                .Select(x => x.Name)
                .FirstOrDefault();

            return problemName;
        }

        public ProblemViewModel GetById(string id)
        {
            return this.db
                .Problems
                .Where(x => x.Id == id)
                .Select(x => new ProblemViewModel
                {
                    Name = x.Name,
                    Submissions = x.Submissions.Select(s => new SubmissionViewModel
                    {
                        CreatedOn = s.CreatedOn,
                        SubmissionId = s.Id,
                        AchievedResult = s.AchievedResult,
                        Username = s.User.Username,
                        MaxPoints = x.Points
                    })
                })
                .FirstOrDefault();
        }
    }
}
