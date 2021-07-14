namespace media_api.Database
{
    public class ImageDBSettings : IImageDBSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName {get; set;}
    }
}
