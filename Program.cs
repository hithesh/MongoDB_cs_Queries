using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class Program
    {
        //private static string connectionstring = "127.0.0.1:27017";
        //private static string connectionstring = "mongodb://oodlyadmin:ZHS4CHOE2JPUK9EEOJSKI6Q8UUYTG1G38URQ4XUH@candidate.5.mongolayer.com:10613,candidate.6.mongolayer.com:10495/Oodly-classic-new";
        private static MongoClient client = new MongoClient();
        private static IMongoDatabase database = client.GetDatabase("test");
        public static IMongoCollection<BsonDocument> Users = database.GetCollection<BsonDocument>("users");
        public static void Main(string[] args)
        {
            testing().Wait();
            Console.WriteLine("Query results end here!!!");
        }
        public static async Task testing()
        {
            var collection = database.GetCollection<BsonDocument>("restaurants");
            //var filter = Builders<BsonDocument>.Filter.Eq("grades.grade", "A");
            //var result =  await collection.Find(filter).ToListAsync();
            //Console.WriteLine(result.Count);
            var filter = new BsonDocument();
            var count = 0;
            using (var cursor = await collection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var batch = cursor.Current;
                    foreach (var document in batch)
                    {
                        Console.WriteLine(document.Names);
                        count++;
                    }
                }
            }*/
        }
    }
}
