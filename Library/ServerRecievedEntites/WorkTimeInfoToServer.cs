using System;

namespace TransferEntites.ServerRecievedEntites
{
    public class WorkTimeInfoToServer
    {
        public string Guid { set; get; }
        public string PathExe { set; get; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan WorkTime { get; set; }
    }
}
