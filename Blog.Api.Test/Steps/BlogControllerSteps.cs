using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using TechTalk.SpecFlow;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Generic;
using FluentAssertions;
using Blog.Core.Dto;
using Blog.Core.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Blog.Core.Interfaces;
using Blog.Api.Test.Fakes;

namespace Blog.Api.Test.Steps
{
    [Binding]
    public class BlogControllerSteps
    {
        private HttpClient _client;

        public BlogControllerSteps()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            //    .WithWebHostBuilder(builder =>
            //{
            //    builder.ConfigureServices(services =>
            //    {
            //       // services.RemoveAll<IReadOnlyRepository<BlogPost>>();
            //      //  services.AddTransient<IReadOnlyRepository<BlogPost>, FakeRepository>();
            //    });
            //});

            _client = appFactory.CreateClient();
        }

        [Given(@"that I am a reader of the blog")]
        public void GivenThatIAmAReaderOfTheBlog()
        {
        }
        
        [When(@"I request a list of blog post titles")]
        public void WhenIRequestAListOfBlogPostTitles()
        {
        }
        
        [When(@"I request blog article (.*)")]
        public void WhenIRequestBlogArticle(int p0)
        {
        }
        
        [Then(@"I should receive a list of blog posts")]
        public async Task ThenIShouldReceiveAListOfBlogPosts()
        {
            var response = await _client.GetAsync(GenerateUrl());

            var data = await response.Content.ReadAsAsync<IEnumerable<PostDto>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.IsSuccessStatusCode.Should().BeTrue();
            data.Should().HaveCount(5);
        }
        
        [Then(@"I should see a number of comments")]
        public async Task ThenIShouldSeeANumberOfComments()
        {
            var response = await _client.GetAsync(GenerateUrl());

            var data = await response.Content.ReadAsAsync<IEnumerable<PostDto>>();

            foreach (var post in data)
            {
                post.Comments.Should().NotBeNull();
            }

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.IsSuccessStatusCode.Should().BeTrue();         
        }
        
        [Then(@"I receive blog article (.*)")]
        public async Task ThenIReceiveBlogArticle(int p0)
        {
            var response = await _client.GetAsync(GenerateUrl(p0));

            var data = await response.Content.ReadAsAsync<PostDto>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.IsSuccessStatusCode.Should().BeTrue();
            data.Body.Should().Be($"Post {p0} body");
            data.Comments.Count.Should().Be(p0);
        }

        private string GenerateUrl(int? id = null) => id.HasValue ? $"/api/blog/{id}" : "/api/blog/";
    }
}
