using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.JunkItem;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Runtime.CompilerServices;
using MongoDB.Bson.Serialization;
using MySql.Data;
using MySql.Data.MySqlClient;
using Models.BasicModels;

namespace Services.Services.JunkService
{
    public class JunkService : IJunkService
    {
        private MongoClient mongoClient;
        private MySqlConnection mysqlClient;
        private String mySqlDB = "junkdb";
        private String mySqlJunkLocationTable = "junk_location";
        private String mongoDBName= "JunkAppDB";
        private String mongoJunkCollectionName = "JunkItems";
        public IJunkItem GetJunkItem(Guid junkId)
        {
            var filter = Builders<IJunkItem>.Filter.Eq("Id", junkId);

            IJunkItem junkItem =
                mongoClient.GetDatabase(mongoDBName)
                      .GetCollection<IJunkItem>(mongoJunkCollectionName)
                      .Find(filter).First();

            return junkItem;
        }

        public void UploadJunkItem(IJunkItem junkItem)
        {
            UploadJunkItemToMongoDB(junkItem);
            UploadJunkLocationToSql(junkItem);
        }
        private void UploadJunkItemToMongoDB(IJunkItem junkItem)
        {
            var collection = mongoClient
                .GetDatabase(mongoDBName)
                .GetCollection<IJunkItem>(mongoJunkCollectionName);
            collection.InsertOne(junkItem);
        }

        private void UploadJunkLocationToSql(IJunkItem junkItem)
        {
            String sqlInsertCommand = $"INSERT INTO {mySqlDB}.{mySqlJunkLocationTable}(id, location) VALUES({junkItem.Id}, " +
                $"POINT({junkItem.Location.Longtitude}, {junkItem.Location.Latitude}))";
            MySqlCommand cmd = new MySqlCommand(sqlInsertCommand, mysqlClient);
            cmd.ExecuteNonQuery();
        }
    }
}
