namespace ModernisationChallengeVT.Domain.Entities
{
    public interface ISoftDelete
    {
        DateTime? DateDeleted { get; set; }
    }
}
