using NewsLetterChallenge.Model.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsLetterChallenge.Service.NewsProviders
{
	public interface INewsProviderService
	{
		List<Content> GetRecentlyNews();
	}
}
