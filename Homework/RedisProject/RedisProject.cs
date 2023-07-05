using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Homework.RedisProject
{
    public class RedisProject
    {
        static void Main(string[] args) {

            string redisHost = "localhost";
            int redisPort = 6379;

            ConnectionMultiplexer redisconn = ConnectionMultiplexer.Connect($"{redisHost}:{redisPort}");
            IDatabase redisDb = redisconn.GetDatabase();


            // Veri eklemek için ;

            string key = "sumuskey";
            string value = "sumusvalue";
            redisDb.StringSet(key, value);
            //redisDb.StringSet("sumuskey", "sumusvalue"); 
            
            string key1 = "firstkey";
            string value1 = "firstvalue";
            redisDb.StringSet(key1, value1);


            // Veri getirmek için ;

            string retrievedValue = redisDb.StringGet(key);
            Console.WriteLine("Alınan deger : " + retrievedValue);

            string retrievedValue1 = redisDb.StringGet(key1);
            Console.WriteLine("Alınan deger 1 : " + retrievedValue1);


            // Veri silmek için ;

            redisDb.KeyDelete("firstkey");
            Console.WriteLine("firstkey silindi..");

          

            // Veriyi tekrar getirmek için ;
            value = redisDb.StringGet("firstKey");
            Console.WriteLine("Geri gelen veri : " + value);

            
        }
    }
}
