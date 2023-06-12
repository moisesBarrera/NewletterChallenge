using NewsLetterChallenge.Entities.Settings.Endpoints.Guardian;
using NewsLetterChallenge.Entities.Settings.Endpoints.NYTimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsLetterChallenge.Entities.Settings.Endpoints
{
	public class Endpoints
	{
		public NYTimesEndpoint NYTimes { get; set; }
		public GuardianEndpoint Guardian { get; set; }
	}
}
