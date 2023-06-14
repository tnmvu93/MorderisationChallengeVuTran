using ModernisationChallengeVT.Contracts.Businesses;
using ModernisationChallengeVT.Contracts.DTOs;
using ModernisationChallengeVT.Domain.Repositories;

namespace ModernisationChallengeVT.Business
{
    public class TaskBusiness : ITaskBusiness
    {
        private readonly ITaskRepository _taskRepository;

        public TaskBusiness(ITaskRepository taskRepository)
        {
            this._taskRepository = taskRepository;
        }

        public Task<List<TaskDTO>> List()
        {
            var tasks = _taskRepository.List().ToList();

            var result = tasks.Select(x => new TaskDTO
            {
                Id = x.Id,
                Completed = x.Completed,
                Details = x.Details
            }).ToList();

            return Task.FromResult(result);
        }

        public Task<TaskDTO?> GetById(int id)
        {
            var task = _taskRepository.List().FirstOrDefault(x => x.Id == id);

            TaskDTO? result = null;
            if (task != null)
            {
                result = new TaskDTO
                {
                    Id = task.Id,
                    Details = task.Details,
                    Completed = task.Completed,
                    DateCreated = task.DateCreated,
                    DateDeleted = task.DateDeleted,
                    DateModified = task.DateModified
                };
            }

            return Task.FromResult(result); ;
        }

        public async Task Create(TaskDTO taskDto)
        {
            var task = new Domain.Entities.Task
            {
                Details = taskDto.Details,
                Completed = false,

                // Look strange that we have to update DateModified at creating new
                // So I just update the data for DateCreated in AuditableTrigger, and keep this code Create function.
                DateModified = DateTime.Now
            };

            _taskRepository.Create(task);

            await _taskRepository.SaveChanges();
        }

        public async Task Update(TaskDTO task)
        {
            var currentTask = _taskRepository.List().FirstOrDefault(x => x.Id == task.Id);
            if (currentTask != null)
            {
                currentTask.Details = task.Details;

                _taskRepository.Update(currentTask);

                await _taskRepository.SaveChanges();
            }
        }

        public async Task Delete(int taskId)
        {
            _taskRepository.Delete(taskId);

            await _taskRepository.SaveChanges();
        }

        public async Task CompleteTask(TaskDTO task)
        {
            var currentTask = _taskRepository.List().FirstOrDefault(x => x.Id == task.Id);

            if (currentTask != null)
            {
                currentTask.Completed = task.Completed;
                _taskRepository.Update(currentTask);
             
                await _taskRepository.SaveChanges();
            }
        }
    }
}