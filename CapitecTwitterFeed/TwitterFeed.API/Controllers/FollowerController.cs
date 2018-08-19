using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterFeed.API.Routes;
using TwitterFeed.Logic.Follower;

namespace TwitterFeed.API.Controllers
{
    public class FollowerController: ControllerBase
    {
		/// <summary>
		/// add follower to a user
		/// </summary>
		/// <param name="twitterUserId"></param>
		/// <param name="followedById"></param>
		/// <returns></returns>
		[Route(ApiControllerRoutes.FollwerController.AddUserFollower)]
		[ProducesResponseType(typeof(Entities.Follower), 200)]
		[HttpGet]
		public async Task<IActionResult> AddUserFollower(string twitterUserId, string followedById)
		{
			var follower = await FollowerManager.Instance.AddUserFollowerAsync(long.Parse(twitterUserId), long.Parse(followedById)).ConfigureAwait(false);
			return Ok(follower);
		}
		/// <summary>
		/// delete a follower from a user
		/// </summary>
		/// <param name="twitterUserId"></param>
		/// <param name="followedById"></param>
		/// <returns></returns>
		[Route(ApiControllerRoutes.FollwerController.DeleteUserFollower)]
		[ProducesResponseType(typeof(bool), 200)]
		[HttpGet]
		public async Task<IActionResult> DeleteFollower(string twitterUserId, string followedById)
		{
			var result = await FollowerManager.Instance.DeleteTwitterUserFollowerAync(long.Parse(twitterUserId), long.Parse(followedById)).ConfigureAwait(false);
			return Ok(result);
		}
	}
}
