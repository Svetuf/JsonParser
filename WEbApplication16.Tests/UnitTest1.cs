using NUnit.Framework;
using WebApplication16.Controllers;
using System.Web.Http;
using System.Net;
using System.IO;
using NUnit;

namespace WEbApplication16.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44334/api/json");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"key\": \"value\"}";

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string result = null;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            Assert.AreEqual(result, "{“levels”: 1}");
        }
    }
}