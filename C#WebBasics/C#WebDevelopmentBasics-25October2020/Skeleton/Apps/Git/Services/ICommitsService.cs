namespace Git.Services
{
    public interface ICommitsService
    {
        string Create(string description, string creatorId, string repId);
    }
}
