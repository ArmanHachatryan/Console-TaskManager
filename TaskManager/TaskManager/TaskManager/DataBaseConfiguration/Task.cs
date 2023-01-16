namespace TaskManager.DataBaseConfiguration
{

    public class Tasks
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public TimeSpan DateTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

}