namespace TvMazeScraper.App.Extensions
{
    public static class ActorExtensions
    {
        /// <summary>
        /// Convert to the Model.
        /// </summary>
        /// <param name="actor">The entity to convert.</param>
        /// <returns>The model instance.</returns>
        public static Models.Actor ToModel(this Db.Entities.Actor actor)
        {
            return new Models.Actor()
            {
                Id = actor.Id,
                Name = actor.Name,
                BirthDate = actor.Birthdate,
            };
        }
    }
}
