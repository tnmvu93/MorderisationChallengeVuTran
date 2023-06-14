using EntityFrameworkCore.Triggered;

namespace ModernisationChallengeVT.Persistence.Triggers
{
    public class AuditableTrigger : IBeforeSaveTrigger<Domain.Entities.IAuditable>
    {
        private readonly MorderisationChallengeDbContext _dbContext;

        public AuditableTrigger(MorderisationChallengeDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task BeforeSave(ITriggerContext<Domain.Entities.IAuditable> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType == ChangeType.Added)
            {
                var entry = _dbContext.Entry(context.Entity);
                context.Entity.DateCreated = DateTime.UtcNow;
            }

            if (context.ChangeType == ChangeType.Modified)
            {
                var entry = _dbContext.Entry(context.Entity);
                context.Entity.DateModified = DateTime.UtcNow;
            }

            await Task.CompletedTask;
        }
    }
}
