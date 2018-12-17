using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace APIAutomationTestSuite.StepDefinition
{
    [Binding]
    public sealed class APIApplication
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        [Given(@"I have an end point (.*)")]
        public void GivenIHaveAnEndPoint(string endpoint)
        {
            RestAPIHelper.SetUrl(endpoint);
        }

        [When(@"I call the GET method on this endpoint")]
        public void WhenICallTheGETMethodOnThisEndpoint()
        {
            Console.WriteLine("Request : " + RestAPIHelper.CreateRequest());
        }

        [Then(@"the result should be in json format")]
        public void ThenTheResultShouldBeInJsonFormat()
        {
            //var expected = "something";
            var response = RestAPIHelper.GetResponse();
            //Console.WriteLine("response : "+response.Content);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Assert.That(response.Content, Is.EqualTo(5), "Error Message");
            }
        }

        [Given(@"I have a new end point (.*)")]
        public void GivenIHaveANewEndPointUserInformation(string endpoint)
        {
            RestAPIHelper.SetUrl(endpoint);
        }

        [When(@"I call the GET method on this endpoint to get the user information (.*)")]
        public void WhenICallTheGETMethodOnThisEndpointToGetTheUserInformation(string userid)
        {
            Console.WriteLine("userid: " + userid);
            RestAPIHelper.CreateRequest(userid);
           // var req =  RestAPIHelper.CreateRequest(userid);
        }

        [Then(@"I need to get the user information in json format")]
        public void ThenINeedToGetTheUserInformationInJsonFormat()
        {
            var response = RestAPIHelper.GetResponse();
            //Console.WriteLine("response : "+response.Content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("response.StatusCode : "+ response.StatusCode);
                Console.WriteLine("System.Net.HttpStatusCode.OK: " + System.Net.HttpStatusCode.OK);
            }
        }

        [Given(@"I have a resource (.*)")]
        public void GivenIHaveAResourceMapsApiPlaceAdd(string resource)
        {
            Console.WriteLine("resource: " + resource);
            RestAPIHelper.SetUrlPost(resource);
        }

        [When(@"I call the POST method on this endpoint using a key (.*)")]
        public void WhenICallThePOSTMethodOnThisEndpointUsingAKey(string postkey)
        {
            Console.WriteLine("postkey: " +postkey);
            RestAPIHelper.PostRequest(postkey);
        }


        [Then(@"the response should be in json format")]
        public void ThenTheResponseShouldBeInJsonFormat()
        {
            var response = RestAPIHelper.GetResponse();
            Console.WriteLine("response : "+response.Content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("response.StatusCode : " + response.StatusCode);
                Console.WriteLine("System.Net.HttpStatusCode.OK: " + System.Net.HttpStatusCode.OK);
            }
        }

        [Given(@"I have a delete resource (.*)")]
        public void GivenIHaveADeleteResourceMapsApiPlaceDeleteJson(string resource)
        {
            RestAPIHelper.SetUrlPost(resource);
        }

        [When(@"I call the POST method on this endpoint to delete using a key qaclick(.*)")]
        public void WhenICallThePOSTMethodOnThisEndpointToDeleteUsingAKeyQaclick(string deletekey)
        {
            Console.WriteLine("deletekey: " + deletekey);
            RestAPIHelper.DeleteRequest(deletekey);
        }

        [Then(@"the delete response should be in json format")]
        public void ThenTheDeleteResponseShouldBeInJsonFormat()
        {
            var response = RestAPIHelper.GetResponse();
            Console.WriteLine("response : " + response.Content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("response.StatusCode : " + response.StatusCode);
                Console.WriteLine("System.Net.HttpStatusCode.OK: " + System.Net.HttpStatusCode.OK);
            }
        }




    }
}
