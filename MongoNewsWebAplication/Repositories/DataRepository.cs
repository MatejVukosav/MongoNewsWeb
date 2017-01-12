using System;
using System.Collections.Generic;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoNewsWebAplication.Models;
using MongoNewsWebApplication.App_Data;

namespace MongoNewsWebAplication.Repositories
{
    public class DataRepository
    {
        IMongoDatabase database;
        IMongoCollection<News> collection;

        static DataRepository instance;

        public static DataRepository getInstance()
        {
            if (instance == null)
            {
                instance = new DataRepository();
            }
            return instance;
        }

        private DataRepository()
        {
            database = MongoConfig.getMongoDatabase();
            collection = database.GetCollection<News>("news");
        }


        public List<News> getNews()
        {
            List<News> news = collection.Find(x => true)
                         .SortByDescending(x => x.createdAt)
                         .Limit(10)
                         .ToList();
            return news;
        }

        public void addComment(Comment comment, Guid newsId)
        {

            //News news = (News)collection.Find(x => x.id == newsId);
            //news.comments.Add(comment);

            //  var filter = Builders<BsonDocument>.Filter.Eq("_id", newsId);
            //  var update = Builders<BsonDocument>.Update .Push("comments", comment.ToBsonDocument());
            // var collection = database.GetCollection<BsonDocument>("news");


            var filter = Builders<News>.Filter.Eq("_id", newsId);
            var update = Builders<News>.Update.Push("comments", comment);
            collection.UpdateOne(filter, update);
        }

        public void addNewsList(List<News> news)
        {

            // database.CreateCollection("news");
            InsertManyOptions insertManyOptions = new InsertManyOptions();
            insertManyOptions.IsOrdered = true;
            database.GetCollection<News>("news").InsertMany(news, insertManyOptions);

        }

        public void addNews(News news)
        {
            InsertOneOptions insertOneOptions = new InsertOneOptions();
            database.GetCollection<News>("news").InsertOne(news, insertOneOptions);
        }

    }
}
