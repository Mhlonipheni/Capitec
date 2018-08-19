using System;
using System.Collections.Generic;

namespace TwitterFeed.Entities
{
	public class TwitterUser
	{
		public TwitterUser()
		{
			FollowingUserList = new List<TwitterUser>();
		}
		public long TwitterUserId { get; set; }
		public string Name { get; set; }
		public List<TwitterUser> FollowingUserList { get; set; }

	}
}
