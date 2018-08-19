using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterFeed.API.Carriers;
using TwitterFeed.API.Routes;
using TwitterFeed.Logic;
using TwitterFeed.Logic.Follower;
using TwitterFeed.Logic.TwitterUser;

namespace TwitterFeed.API.Controllers
{
	public class TwitterUserController : ControllerBase
	{
		/// <summary>
	/// get user and his/her followers
	/// </summary>
	/// <param name="twitterUserId"></param>
	/// <returns></returns>
		[Route(ApiControllerRoutes.UserController.GetUserFollowers)]
		[ProducesResponseType(typeof(UserFollowersCarrier), 200)]
		[HttpGet]
		public async Task<IActionResult> GetUserUserWithFollowers(string twitterUserId)
		{
			var user = await TwitterUserManager.Instance.GetTwitterUserAsync(long.Parse(twitterUserId)).ConfigureAwait(false);
			var followers = await FollowerManager.Instance.GetTwitterUserFollowersAsync(long.Parse(twitterUserId)).ConfigureAwait(false);
			UserFollowersCarrier userFollowersCarrier = new UserFollowersCarrier();
			//create a Conveter class to map
			userFollowersCarrier.TwitterUserId = user.TwitterUserId;
			userFollowersCarrier.Name = user.Name;
			userFollowersCarrier.Followers = followers;

			return Ok(userFollowersCarrier);
		}
	}
}
