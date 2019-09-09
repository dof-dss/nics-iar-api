namespace IAR.Domain.LookupLists
{
    public class AssetStatus
    {
        public AssetStatus()
        {

        }

        /// <summary>
        /// Gets or sets an <see cref="int"/> which represents the unique automatically generated Id of the asset status.
        /// </summary>
        public int AssetStatusId { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> which contains a description of the asset status.
        /// </summary>
        public string Description { get; set; }
    }
}
