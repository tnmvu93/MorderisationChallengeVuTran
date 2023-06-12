namespace MorderisationChallengeVT.Domain.Repositories
{
    public interface ITaskRepository
    {
        IQueryable<Entities.Task> List();

        void Create(Entities.Task task);

        void Update(Entities.Task task);

        void Delete(int id);

        Task SaveChanges();

    }
}
