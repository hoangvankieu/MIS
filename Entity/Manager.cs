namespace MIS.Entity
{
    public class Manager
    {
        public long id {  get; set; }
        public string name { get; set; }
        public List<StatisticManager> statisticManagers { get; set; }
    }
}
