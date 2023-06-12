using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsLetterChallenge.Application.RecentlyNewsApplication;
using NewsLetterChallenge.Model.News;

namespace NewsLetterChallenge.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RecentlyNewsController : ControllerBase
	{
		private IRecentlyNewsApplication _recentlyNewsApplication;
		public RecentlyNewsController(IRecentlyNewsApplication recentlyNewsApplication) => _recentlyNewsApplication = recentlyNewsApplication;

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult Get(int totalPost) => Ok(_recentlyNewsApplication.GetRecentlyNews(totalPost));

	}
}
