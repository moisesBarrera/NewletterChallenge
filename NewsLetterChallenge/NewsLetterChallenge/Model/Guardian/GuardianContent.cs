using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static NewsLetterChallenge.Model.Enums;

namespace NewsLetterChallenge.Model.Guardian
{
	public class GuardianContent
	{
		public int Id { get; set; }
		public string Url { get; set; }
		public string Thumbnail { get; set; }
		public Category Category { get; set; }
		public string PostTitle { get; set; }
		public string PostDescription { get; set; }
		public string PostedBy { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
