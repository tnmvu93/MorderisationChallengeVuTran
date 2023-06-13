using EntityFrameworkCore.Triggered;
using Microsoft.EntityFrameworkCore;

namespace MorderisationChallengeVT.Persistence.Triggers
{
    public class SoftDeleteTrigger : IBeforeSaveTrigger<Domain.Entities.ISoftDelete>
    {
        private readonly MorderisationChallengeDbContext _dbContext;

        public SoftDeleteTrigger(MorderisationChallengeDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task BeforeSave(ITriggerContext<Domain.Entities.ISoftDelete> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType == ChangeType.Deleted)
            {
                var entry = _dbContext.Entry(context.Entity);
                context.Entity.DateDeleted = DateTime.UtcNow;
                entry.State = EntityState.Modified;
            }

            await Task.CompletedTask;
        }
    }
}
