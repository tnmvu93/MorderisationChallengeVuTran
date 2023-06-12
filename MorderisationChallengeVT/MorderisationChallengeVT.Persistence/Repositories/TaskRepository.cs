using MorderisationChallengeVT.Domain.Repositories;

namespace MorderisationChallengeVT.Persistence.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly MorderisationChallengeDbContext _dbContext;

        public TaskRepository(MorderisationChallengeDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IQueryable<Domain.Entities.Task> List()
        {
            return _dbContext.Tasks.AsQueryable();
        }

        public void Create(Domain.Entities.Task task)
        {
            _dbContext.Tasks.Add(task);
        }

        public void Update(Domain.Entities.Task task)
        {
            _dbContext.Tasks.Update(task);
        }

        public void Delete(int id)
        {
            var task = _dbContext.Tasks.FirstOrDefault(x => x.Id == id);
            if (task != null)
            {
                _dbContext.Tasks.Remove(task);
            }
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
