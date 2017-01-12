
using MongoDB.Driver;

namespace MongoNewsWebApplication.App_Data
{

    public class MongoConfig
    {

        public MongoConfig()
        {

        }

        public static IMongoDatabase getMongoDatabase()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("newsdb");
            return database;
        }
    }
}
