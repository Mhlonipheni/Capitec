using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterFeed.API.Carriers
{
	public class UserFollowersCarrier
	{
		public UserFollowersCarrier()
		{
			Followers = new List<Entities.Follower>();
		}
		public long TwitterUserId { get; set; }
		public string Name { get; set; }
		public List<Entities.Follower> Followers { get; set; }
	}
}
