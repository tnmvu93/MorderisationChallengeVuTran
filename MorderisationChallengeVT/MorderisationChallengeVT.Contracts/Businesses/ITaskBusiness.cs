using MorderisationChallengeVT.Contracts.DTOs;

namespace MorderisationChallengeVT.Contracts.Businesses
{
    public interface ITaskBusiness
    {
        Task<List<TaskDTO>> List();

        Task<TaskDTO> GetById(int id);

        Task Create(TaskDTO task);

        Task Update(TaskDTO task);

        Task Delete(int id);

        Task CompleteTask(int id);
    }
}
