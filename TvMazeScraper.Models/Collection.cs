namespace TvMazeScraper.Models
{
    /// <summary>
    /// Definition for the representation for a collection of models.
    /// </summary>
    /// <typeparam name="T">The class of the items in the collection.</typeparam>
    public class Collection<T>
        where T : AbstractModel
    {
        /// <summary>
        /// Gets or sets the items on the collection.
        /// </summary>
        public System.Collections.Generic.List<T> Items { get; set; }
    }
}
