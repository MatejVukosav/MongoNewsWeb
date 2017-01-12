using System;
using System.Web;

namespace MongoNewsWebAplication.Models
{
    public class Comment 
    {
        public Comment()
        {
            created = DateTime.Now;
        }
        public Guid id = Guid.NewGuid();
        public DateTime created { get; set; }
        public string text { get; set; }
    }
}
