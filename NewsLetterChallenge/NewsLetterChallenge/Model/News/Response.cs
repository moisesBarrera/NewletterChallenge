using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsLetterChallenge.Model.News
{
	public class Response
	{
		public List<Content> News { get; set; }

		public int Total { get; set; }
	}
}
