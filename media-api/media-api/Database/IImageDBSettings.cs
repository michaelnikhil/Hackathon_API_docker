namespace media_api.Database
{
    public interface IImageDBSettings
    {
         string ConnectionString { get; set; }
         string DatabaseName { get; set; }
         string CollectionName { get; set; }
    }
}
