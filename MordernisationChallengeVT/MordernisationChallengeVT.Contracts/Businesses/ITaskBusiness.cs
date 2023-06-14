using ModernisationChallengeVT.Contracts.DTOs;

namespace ModernisationChallengeVT.Contracts.Businesses
{
    public interface ITaskBusiness
    {
        Task<List<TaskDTO>> List();

        Task<TaskDTO?> GetById(int id);

        Task Create(TaskDTO task);

        Task Update(TaskDTO task);

        Task Delete(int id);

        Task CompleteTask(TaskDTO task);
    }
}
