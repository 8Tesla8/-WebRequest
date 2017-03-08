using System;
using System.Collections.Generic;

namespace TransferEntites.ServerRecievedEntites
{
    public class ProgramInfoToServer 
    {
        public string Guid { get; set; }

        //данные для таблицы Programs
        public string PathExe { get; set; }
        public int CategoryId { get; set; } 
        public string ProductName { get; set; }
        public string CompanyName { get; set; }
        public string ExeFileName { get; set; }
        public string ProcessName { get; set; }
        public string Description { get; set; }

        //данные которые потом пойдут в таблицу WorkTimes
        public DateTime Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan WorkTime { get; set; }


        public ProgramInfoToServer()
        {
            CategoryId = 1;//undefined
        }
        public ProgramInfoToServer(Dictionary<string, string> programInfo) 
                    : this()
        {
            PathExe = programInfo["PathExe"];
            ProductName = programInfo["ProductName"];
            CompanyName = programInfo["CompanyName"];
            ExeFileName = programInfo["ExeFileName"];
            ProcessName = programInfo["ProcessName"];
            Description = programInfo["Description"];
        }

        //для тестов
        public override string ToString()
        {
            return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}#",
                Guid, PathExe, CategoryId, ProductName, CompanyName, ExeFileName, ProcessName, Description,
                Day, StartTime, EndTime);
        }
    }
}
