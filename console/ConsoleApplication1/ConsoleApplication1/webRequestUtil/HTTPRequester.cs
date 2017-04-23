using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace ConsoleApplication1.webRequestUtil
{
    class HTTPRequester
    {
        public static readonly string POST_REQUEST = "POST";
        public static readonly string GET_REQUEST = "GET";
        public static readonly string DELETE_REQUEST = "DELETE";
        public static string ContentType = "application/x-www-form-urlencoded";

        private ResponseData request(string url, string data, string method, Dictionary<string,string> headers)
        {
            ResponseData responseData = new ResponseData();
             WebRequest webRequest = WebRequest.Create(url);
            if(headers != null)
            {
                foreach (KeyValuePair<string, string> entry in headers)
                {
                    webRequest.Headers.Add(entry.Key, entry.Value);
                }
            }
            webRequest.ContentType = ContentType;
            if (method == null)
            {
                webRequest.Method = GET_REQUEST;
            }else
            {
                webRequest.Method = method;
            }

            if(data != null)
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(data);
                webRequest.ContentLength = byteArray.Length;
                Stream stream = webRequest.GetRequestStream();
                stream.Write(byteArray, 0, byteArray.Length);
                stream.Close();
            }

            WebResponse webResponse = webRequest.GetResponse();
            HttpWebResponse httpWebResponse = (HttpWebResponse)webResponse;
            responseData.statusCode =  (int) httpWebResponse.StatusCode;
            Stream responseStream = webResponse.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream);
            responseData.content = streamReader.ReadToEnd();
            streamReader.Close();
            responseStream.Close();
            webResponse.Close();
            return responseData;
        }


        public ResponseData GET(string url)
        {
            return this.request(url, null, GET_REQUEST, null);
        }

    }
}
