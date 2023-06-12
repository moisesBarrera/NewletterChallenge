using Microsoft.Extensions.Options;
using NewsLetterChallenge.Entities.Settings;
using NewsLetterChallenge.Model.News;
using NewsLetterChallenge.Service.NewsProviders;
using NewsLetterChallenge.Service.NewsProviders.Guardian;
using NewsLetterChallenge.Service.NewsProviders.NYTimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsLetterChallenge.Application.RecentlyNewsApplication
{
	public class RecentlyNewsApplication : IRecentlyNewsApplication
	{
		private INewsProviderService _guardianApiClient;
		private INewsProviderService _nyTimesApiClient;

		public RecentlyNewsApplication(System.Net.Http.HttpClient httpClient, IOptions<Settings> settings)
		{
			_guardianApiClient = new GuardianApiClient(httpClient, settings);
			_nyTimesApiClient = new NYTimesApiClient(httpClient, settings);
		}

		public Response GetRecentlyNews(int elementsRequest)
		{
			var news = new List<Content>();

			news.AddRange(_guardianApiClient.GetRecentlyNews());
			news.AddRange(_nyTimesApiClient.GetRecentlyNews());

			news = news.OrderByDescending(x => x.PublishAt).Take(elementsRequest).ToList();

			var response = new Response()
			{
				News = news,
				Total = news.Count
			};

			return response;
		}
	}
}
