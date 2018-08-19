using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterFeed.DataAccess.DAO
{
	public class Follower : TwitterUser
	{
		public long FollowerId { get; set; }
		public long FollowedByUserId { get; set; }
	}
}
