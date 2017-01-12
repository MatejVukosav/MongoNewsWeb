using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;

namespace MongoNewsWebAplication.Models
{
    public class News 
    {
        public News()
        {
            createdAt = DateTime.Now;
            comments = new List<Comment>();
        }

        public Guid id = Guid.NewGuid();

        //     public int id { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public string author { get; set; }

        public byte[] image { get; set; }
        public DateTime createdAt { get; set; }
        public List<Comment> comments { get; set; }
    }
}
