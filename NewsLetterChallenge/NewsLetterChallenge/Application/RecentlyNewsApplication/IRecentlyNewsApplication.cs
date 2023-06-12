using NewsLetterChallenge.Model.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsLetterChallenge.Application.RecentlyNewsApplication
{
	public interface IRecentlyNewsApplication
	{
		Response GetRecentlyNews(int elementRequest);
	}
}
