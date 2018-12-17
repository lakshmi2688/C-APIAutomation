using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;


namespace APIAutomationTestSuite
{
    public static class RestAPIHelper
    {
        public static RestClient client;
        public static RestRequest restRequest;
        public static string baseURL = "http://mydomain.com";
        public static string baseURLPost = "http://216.10.245.166";

        public class Location
        {
            public double lat;
            public double lng;
        }

        private class PostRequestBody
        {
            /*
           {
                "location":{
                  "lat" : -38.383494,
                  "lng" : 33.427362
              },
              "accuracy":50,
              "name":"Frontline house",
              "phone_number":"(+91) 983 893 3937",
              "address" : "29, side layout, cohen 09",
              "types": ["shoe park","shop"],
              "website" : "http://google.com",
              "language" : "French-IN"
             }

          */

            public Location location;
            public int accuracy;
            public string name;
            public string phone_number;
            public string address;
            public string[] types;
            public Uri website;
            public string language;

            public PostRequestBody()
            {
                this.location = new Location();
                this.types = new string[] { };
                this.website = new Uri("http://www.google.com");
            }
        }

        private class DeleteRequestBody
        {
            public string place_id;
        }

        public static RestClient SetUrl(string endpoint)
        {
            var url = baseURL + endpoint;
            Console.WriteLine("url : " + url);
            return client = new RestClient(url);
        }

        public static RestClient SetUrlPost(string resource)
        {
            var url = baseURLPost + resource;
            Console.WriteLine("url : " + url);
            return client = new RestClient(url);
        }

        public static RestRequest CreateRequest()
        {
            restRequest = new RestRequest();
            restRequest.Method = Method.GET;
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }


        public static RestRequest CreateRequest(string userid)
        {
            restRequest = new RestRequest();
            restRequest.Method = Method.GET;
            restRequest.Resource = userid;
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        public static RestRequest PostRequest(string postkey)
        {
            restRequest = new RestRequest();
            restRequest.Method = Method.POST;
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddHeader("Accept", "application/json");
            restRequest.Parameters.Clear();
            restRequest.AddParameter("key", postkey, ParameterType.UrlSegment);
            restRequest.AddJsonBody(CreatePostRequestBody());
            return restRequest;
        }

        public static RestRequest DeleteRequest(string deletekey)
        {
            restRequest = new RestRequest();
            restRequest.Method = Method.POST;
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddHeader("Accept", "application/json");
            restRequest.Parameters.Clear();
            restRequest.AddParameter("key", deletekey, ParameterType.UrlSegment);
            restRequest.AddJsonBody(CreateDeleteRequestBody());
            return restRequest;
        }

        public static IRestResponse GetResponse()
        {

            return client.Execute(restRequest);
        }

        private static PostRequestBody CreatePostRequestBody()
        {
            return new PostRequestBody()
            {
                //below line is similar to location.lat = -38.383494, location.lng = 33.427362
                location = new Location() { lat = -38.383494, lng = 33.427362 },
                accuracy = 50,
                name = "Frontline house",
                phone_number = "(+91) 983 893 3937",
                address = "29, side layout, cohen 09",
                types = new string[] { "shoe park", "shop" },
                website = new Uri("http://google.com"),
                language = "French-IN"
            };
        }


        private static DeleteRequestBody CreateDeleteRequestBody()
        {
            return new DeleteRequestBody()
            {
                place_id = "c7c7c2765275e4a5cb9eca6656ba3a42"
            };
        }
    }
}
