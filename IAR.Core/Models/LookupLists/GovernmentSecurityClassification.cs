namespace IAR.Core.Models.LookupLists
{
    public class GovernmentSecurityClassification
    {
        /// <summary>
        /// Gets or sets an <see cref="int"/> which represents the unique automatically generated Id of the government security classification.
        /// </summary>
        public int GovernmentSecurityClassificationId { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> which contains a description of the government security classification.
        /// </summary>
        public string Description { get; set; }
    }
}
