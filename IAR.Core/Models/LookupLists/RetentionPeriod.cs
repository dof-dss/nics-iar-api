namespace IAR.Core.Models.LookupLists
{
    public class RetentionPeriod
    {
        /// <summary>
        /// Gets or sets an <see cref="int"/> which represents the unique automatically generated Id of the retention period.
        /// </summary>
        public int RetentionPeriodId { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> which contains a description of the retention period.
        /// </summary>
        public string Description { get; set; }
    }
}
