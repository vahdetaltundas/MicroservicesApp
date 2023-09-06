namespace FreeCourse.Services.Catagol.Settings
{
    public class DataBaseSettings : IDatabaseSettings
    {
        public string CourseCollactionName { get; set; }
        public string CategoryCollactionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
