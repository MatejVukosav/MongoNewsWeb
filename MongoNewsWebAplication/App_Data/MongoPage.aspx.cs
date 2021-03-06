﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace NBMP_1.projekt.Mongo
{
    public partial class MongoPage : System.Web.UI.Page
    {

        /*

        public string QueryResult { get; set; }
        IMongoDatabase database;
        IMongoCollection<News> collection;

        string itemListKey = "itemListKey";
        public List<News> itemList { get; set; }

        List<News> itemList2 {
            set { itemList = value; }
            get {
                if (Session[itemListKey] == null)
                    Session[itemListKey] = new List<News>();
                return (List<News>)Session[itemListKey];
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                database = MongoConfig.getMongoDatabase();
                collection = database.GetCollection<News>("news");

                populateDb(database);

                showData();
            }

        }

        public void showData()
        {
            itemList = collection.Find(x => true)
                         .SortByDescending(x => x.created)
                         .Limit(10)
                         .ToList();

            productsList.DataSource = itemList;
            productsList.DataBind();
        }
        protected void productsList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListView innerlistview = (ListView)e.Item.FindControl("CommentsListView");

                News itemNews = ((News)e.Item.DataItem);
                innerlistview.DataSource = itemNews.comments;

                //  ((Button)e.Item.FindControl("addNewCommentBtn")).Click += btnAddNewComment_click;

                innerlistview.DataBind();

            }
        }

        protected void btnAddNewComment_click(object sender, EventArgs e)
        {
            //ude ovdje kad kliknem add
            //spremit novi komentar u listu komentara i prikazat ga
        }

        protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (productsList.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.showData();
        }


        public List<News> getNews()
        {
            List<News> news = new List<News>();

            for (int i = 0; i < 20; i++)
            {
                News n = new News();
                n.text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum";
                n.title = "naslov";
                n.author = "Matej";
                n.image = "http://likovna-kultura.ufzg.unizg.hr/konstruktor/radovi/slon.africki.jpg";
                List<Comment> comments = new List<Comment>();
                Comment c = new Comment();
                c.text = "prvi komentar";
                comments.Add(c);

                Comment c2 = new Comment();
                c2.text = "drugi komentar";
                comments.Add(c2);

                n.comments = comments;
                news.Add(n);
            }

            return news;
        }

        public void populateDb(IMongoDatabase database)
        {
            List<News> news = getNews();
            // database.CreateCollection("news");
            InsertManyOptions insertManyOptions = new InsertManyOptions();
            insertManyOptions.IsOrdered = true;
            database.GetCollection<News>("news").InsertMany(news, insertManyOptions);
        }


        public void AddComment(String commentText, int newsId)
        {
            Comment comment = new Comment();
            comment.text = commentText;

            News news = new News();
            news.comments.Add(comment);

            var filter = Builders<BsonDocument>.Filter.Eq("_id", newsId);
            var update = Builders<BsonDocument>.Update
               .Push("comments", comment.ToBsonDocument());

            var collection = database.GetCollection<BsonDocument>("news");
            collection.UpdateOne(filter, update);
        }
        */

    }
}