using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitterFeed.DataAccess.DAO;
using TwitterFeed.Entities;

namespace TwitterFeed.Logic.Follower
{
	public static class Mapper
	{
		public static List<Entities.Follower> Map(List<DataAccess.DAO.Follower> followers)
		{
			return followers.Select(follower => Map(follower)).ToList();
		}

		public static Entities.Follower Map(DataAccess.DAO.Follower follower)
		{
			return new Entities.Follower
			{
				FollowerId = follower.FollowerId,
				TwitterUserId = follower.TwitterUserId,
				Name = follower.Name,
				FollowedByUserId = follower.FollowedByUserId
			};
		}
	}
}
