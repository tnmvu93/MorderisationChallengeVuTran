namespace MorderisationChallengeVT.Domain.Entities
{
    public interface ISoftDelete
    {
        DateTime? DateDeleted { get; set; }
    }
}
