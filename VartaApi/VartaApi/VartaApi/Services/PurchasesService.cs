using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using VartaApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace VartaApi.Services
{
    public class PurchasesService
    {
        string login = "2500650000019";
        string pass = "3157";

        string sessionUrl = "http://cabinet.vartacarta.by/api2/session.json";
        string purchasesUrl = "http://cabinet.vartacarta.by/api2/purchases";

        public IEnumerable<PurchaseModel> Get()
        {
            var sessionData = GetHttp(sessionUrl, string.Format("type:card,login:{0},password:{1}", login, pass));

            var jsession = JObject.Parse(sessionData);
            var sid = (string)jsession["sid"];
            var purchasesData = GetHttp(string.Format("{0}?sid:{1}", purchasesUrl, sid), null, "GET");

            return new List<PurchaseModel>();
        }

        public string GetHttp(string url, string data = null, string method = "POST")
        {
            HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(url);
            rq.CookieContainer = new CookieContainer();

            rq.Method = method;

            if (method == "POST")
            {
                StreamWriter requestWriter = new StreamWriter(rq.GetRequestStream());
                if (data != null)
                    requestWriter.Write(data);
                requestWriter.Close();
            }


            StreamReader responseReader = new StreamReader(rq.GetResponse().GetResponseStream());
            string responseData = responseReader.ReadToEnd();

            responseReader.Close();
            rq.GetResponse().Close();

            return responseData;
        }
    }
}