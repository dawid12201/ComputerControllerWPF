using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ComputerControllerWPF
{

    //{"data":
    //{"cases":
    //{"infections":93,"activeCases":91,"deaths":2,"recovered":0,"mortalityRate":0.0215,"revoveryRate":0},
    //"name":"Poland"},
    //"provider":"TheBaseLab"}



    public class CoronaJson
    {
        //public string data { get; set; }
        public string infections { get; set; }
        public string activeCases { get; set; }
        public string deaths { get; set; }
        public string recovered { get; set; }
        public string mortalityRate { get; set; }
        public string revoveryRate { get; set; }
        public IList<string> cases { get; set; }
        public string name { get; set; }

    }
    public class CoronaVirus
    {
        public string url = "https://covid-19-data.herokuapp.com/api/cases/pol";
        public string testJson = "{\"infections\":93,\"activeCases\":91,\"deaths\":2,\"recovered\":0,\"mortalityRate\":0.0215,\"revoveryRate\":0}";
        public void GetCoronaStatusForPoland()
        {
            using (WebClient webClient = new WebClient())
            {
                string jsonString = webClient.DownloadString(url);

                JObject CoronaJ = JObject.Parse(jsonString);
                IList<JToken> results = CoronaJ["data"]["cases"].Children().ToList();
                IList<CoronaJson> coronaJsons = new List<CoronaJson>();
                foreach (JToken result in results)
                {
                    CoronaJson coronaJson = result.ToObject<CoronaJson>();
                    coronaJsons.Add(coronaJson);
                }

                CoronaJson corona = JsonConvert.DeserializeObject<CoronaJson>(testJson);
                Console.WriteLine(corona.infections);
                Console.WriteLine(corona.activeCases);
                Console.WriteLine(corona.deaths);
                Console.WriteLine(corona.recovered);
                Console.WriteLine(corona.mortalityRate);
                Console.WriteLine(corona.revoveryRate);
            }
        }
    }
}

