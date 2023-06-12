using Microsoft.Extensions.Options;
using NewsLetterChallenge.Entities.Settings;
using NewsLetterChallenge.Entities.Settings.Endpoints.NYTimes;
using NewsLetterChallenge.Model.News;
using NewsLetterChallenge.Model.NYTimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsLetterChallenge.Service.NewsProviders.NYTimes
{
	public class NYTimesApiClient : INewsProviderService
	{
		private readonly NYTimesActions _nyTimesActions;
		private RestBase _restBase;

		public NYTimesApiClient(System.Net.Http.HttpClient httpClient, IOptions<Settings> settings)
		{
			var nyTimesEndpoint = settings.Value.Endpoints.NYTimes;
			_nyTimesActions = nyTimesEndpoint.Actions;
			_restBase = new RestBase(nyTimesEndpoint.BaseAddress, nyTimesEndpoint.Timeout, httpClient);
		}

		public List<Content> GetRecentlyNews()
		{
			var response = new List<Content>();
			var apiResponse = new List<NYTimesContent>();

			try
			{
				apiResponse = _restBase.Get<List<NYTimesContent>>(_nyTimesActions.RecentlyNews);
			}
			catch (Exception ex)
			{ }

			foreach (var nyTimesContent in apiResponse)
			{
				response.Add(new Content(nyTimesContent));
			}

			return response;
		}
	}
}
