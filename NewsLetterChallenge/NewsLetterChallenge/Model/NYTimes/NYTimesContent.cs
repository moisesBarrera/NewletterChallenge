using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static NewsLetterChallenge.Model.Enums;

namespace NewsLetterChallenge.Model.NYTimes
{
	public class NYTimesContent
	{
		public int Id { get; set; }
		public Guid PostUniqueId { get; set; }
		public string PostUrl { get; set; }
		public string CoverPhoto { get; set; }
		public Category Tag { get; set; }
		public string ContentTitle { get; set; }
		public string Content { get; set; }
		public string PublishedBy { get; set; }
		public DateTime PublishedAt { get; set; }
		public string Source { get; set; }
	}
}
