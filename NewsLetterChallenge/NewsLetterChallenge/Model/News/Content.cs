using NewsLetterChallenge.Model.Guardian;
using NewsLetterChallenge.Model.NYTimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static NewsLetterChallenge.Model.Enums;

namespace NewsLetterChallenge.Model.News
{
	public class Content
	{
		public Content()
		{
			Id = Guid.NewGuid();
		}

		public Content(GuardianContent guardianContent)
		{
			Id = Guid.NewGuid();
			Url = guardianContent.Url;
			Thumbnail = guardianContent.Thumbnail;
			Category = guardianContent.Category;
			PostTitle = guardianContent.PostTitle;
			PostContent = guardianContent.PostDescription;
			PublishAt = guardianContent.CreatedAt;
			PublishedBy = guardianContent.PostedBy;
			Source = Source.Guardian;
		}

		public Content(NYTimesContent nyTimesContent)
		{
			Id = Guid.NewGuid();
			Url = nyTimesContent.PostUrl;
			Thumbnail = nyTimesContent.CoverPhoto;
			Category = nyTimesContent.Tag;
			PostTitle = nyTimesContent.ContentTitle;
			PostContent = nyTimesContent.Content;
			PublishAt = nyTimesContent.PublishedAt;
			PublishedBy = nyTimesContent.PublishedBy;
			Source = Source.NYTimes;
		}

		public Guid Id { get; set; }

		public string Url { get; set; }

		public string Thumbnail { get; set; }

		public Category Category { get; set; }

		public string PostTitle { get; set; }

		public string PostContent { get; set; }

		public DateTime PublishAt { get; set; }

		public string PublishedBy { get; set; }

		public Source Source { get; set; }
	}
}
