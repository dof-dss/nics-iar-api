namespace IAR.Domain.LookupLists
{
    public class AssetValue
    {
        /// <summary>
        /// Gets or sets an <see cref="int"/> which represents the unique automatically generated Id of the asset value.
        /// </summary>
        public int AssetValueId { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> which contains a description of the asset value.
        /// </summary>
        public string Description { get; set; }
    }
}
