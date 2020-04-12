using System;
namespace backend.Models
{
    /*
     * Info model
     * Contains the information shown when requesting the backend status
     */
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
