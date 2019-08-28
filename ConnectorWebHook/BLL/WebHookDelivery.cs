using ConnectorWebHook.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ConnectorWebHook.BLL
{
    public class WebHookDelivery : IWebHookDelivery
    {
        private readonly string webhookUrl;

        public WebHookDelivery(string webhookUrl)
        {
            this.webhookUrl = webhookUrl;
        }

        public string SendWebHookPayload(IWebHookPayload payload, bool addAtSymboleToType = true, bool addAtSymboleToContext = true)
        {
            string myJson = JsonConvert.SerializeObject(payload);

            if (addAtSymboleToType)
                myJson = myJson.Replace("\"type\":", "\"@type\":");

            if (addAtSymboleToContext)
                myJson = myJson.Replace("\"context\":", "\"@context\":");

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webhookUrl);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(myJson);
            }
            string result = string.Empty;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }
    }
}
