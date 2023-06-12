using AutoMapper;
using MorderisationChallengeVT.Contracts.Businesses;
using MorderisationChallengeVT.Contracts.DTOs;
using MorderisationChallengeVT.Domain.Repositories;

namespace MorderisationChallengeVT.Business
{
    public class TaskBusiness : ITaskBusiness
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskBusiness(ITaskRepository taskRepository,
            IMapper mapper)
        {
            this._taskRepository = taskRepository;
            this._mapper = mapper;
        }

        public Task<List<TaskDTO>> List()
        {
            var tasks = _taskRepository.List().ToList();

            var result = _mapper.Map<List<TaskDTO>>(tasks);

            return Task.FromResult(result);
        }

        public Task<TaskDTO> GetById(int id)
        {
            var task = _taskRepository.List().FirstOrDefault(x => x.Id == id);

            return Task.FromResult(_mapper.Map<TaskDTO>(task));
        }

        public async Task Create(TaskDTO task)
        {
            var entity = this._mapper.Map<Domain.Entities.Task>(task);
            
            _taskRepository.Create(entity);

            await _taskRepository.SaveChanges();
        }

        public async Task Update(TaskDTO task)
        {
            var entity = _mapper.Map<Domain.Entities.Task>(task);

            _taskRepository.Update(entity);

            await _taskRepository.SaveChanges();
        }

        public async Task Delete(int taskId)
        {
            _taskRepository.Delete(taskId);

            await _taskRepository.SaveChanges();
        }

        public async Task CompleteTask(int id)
        {
            var task = _taskRepository.List().FirstOrDefault(x => x.Id == id);

            if (task != null)
            {
                task.Completed = true;
                _taskRepository.Update(task);
             
                await _taskRepository.SaveChanges();
            }
        }
    }
}