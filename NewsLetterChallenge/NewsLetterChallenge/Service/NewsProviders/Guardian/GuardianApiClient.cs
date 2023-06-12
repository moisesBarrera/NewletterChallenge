using Microsoft.Extensions.Options;
using NewsLetterChallenge.Entities.Settings;
using NewsLetterChallenge.Entities.Settings.Endpoints.Guardian;
using NewsLetterChallenge.Model.Guardian;
using NewsLetterChallenge.Model.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsLetterChallenge.Service.NewsProviders.Guardian
{
	public class GuardianApiClient : INewsProviderService
	{
		private readonly GuardianActions _guardianActions;
		private RestBase _restBase;

		public GuardianApiClient(System.Net.Http.HttpClient httpClient, IOptions<Settings> settings)
		{
			var guardianEndpoint = settings.Value.Endpoints.Guardian;
			_guardianActions = guardianEndpoint.Actions;
			_restBase = new RestBase(guardianEndpoint.BaseAddress, guardianEndpoint.Timeout, httpClient);
		}

		public List<Content> GetRecentlyNews() 
		{
			var response = new List<Content>();
			var apiResponse = new List<GuardianContent>();

			try
			{
				apiResponse = _restBase.Get<List<GuardianContent>>(_guardianActions.RecentlyNews);
			}
			catch (Exception ex)
			{ }

			foreach (var guardianContent in apiResponse)
			{
				response.Add(new Content(guardianContent));
			}
			return response;
		}

	}
}
