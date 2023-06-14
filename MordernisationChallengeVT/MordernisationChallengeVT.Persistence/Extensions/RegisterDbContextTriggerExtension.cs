using Microsoft.EntityFrameworkCore;
using ModernisationChallengeVT.Persistence.Triggers;

namespace ModernisationChallengeVT.Persistence.Extensions
{
    public static class RegisterDbContextTriggerExtension
    {
        public static void RegisterDbContextTrigger (this DbContextOptionsBuilder builder)
        {
            builder.UseTriggers(options => 
            {
                options.AddTrigger<SoftDeleteTrigger>();
                options.AddTrigger<AuditableTrigger>();
            });
        }
    }
}
