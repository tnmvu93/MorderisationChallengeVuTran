using Microsoft.EntityFrameworkCore;
using MorderisationChallengeVT.Persistence.Triggers;

namespace MorderisationChallengeVT.Persistence.Extensions
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
