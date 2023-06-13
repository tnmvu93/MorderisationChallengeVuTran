namespace MorderisationChallengeVT.Domain.Entities
{
    public interface IAuditable
    {
        /// <summary>
        /// DateCreated should be not null
        /// However, we don't know what the current data is so keep the legacy code.
        /// </summary>
        DateTime? DateCreated { get; set; }

        DateTime? DateModified { get; set; }
    }
}
