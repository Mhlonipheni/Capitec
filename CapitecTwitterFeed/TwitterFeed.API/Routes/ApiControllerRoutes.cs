using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterFeed.API.Routes
{
	public class ApiControllerRoutes
	{

		public class UserController
		{
			public const string GetUserFollowers = "user/{twitterUserId}/followers";
		}
		public class FollwerController
		{
			public const string AddUserFollower = "user/{twitterUserId}/follower/{followedById}/add";
			public const string DeleteUserFollower = "user/{userId}/follower/{followedById}/delete";
		}
	}
}
