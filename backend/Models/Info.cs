using System;
namespace backend.Models
{
    public class Info
    {
        public string version { get; set; }
        public bool databaseConnectionEstablished { get; set; }
        public DateTime time { get; set; }

        public Info()
        {
        }
    }
}
