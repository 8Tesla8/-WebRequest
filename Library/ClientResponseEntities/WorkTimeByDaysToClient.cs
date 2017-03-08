using System;

namespace TransferEntites.ClientResponseEntities
{
    public class WorkTimeByDaysToClient
    {
        public TimeSpan WorkTime { set; get; }
        public int CategoryId { set; get; }
        public string PathExe { set; get; }

        public string ProductName { get; set; }
        public string CompanyName { get; set; }
        public string ExeFileName { get; set; }
        public string ProcessName { get; set; }
        public string Description { get; set; }
    }
}
