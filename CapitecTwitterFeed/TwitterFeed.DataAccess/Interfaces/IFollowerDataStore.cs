using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitterFeed.DataAccess.DAO;

namespace TwitterFeed.DataAccess.Interfaces
{
	public interface IFollowerDataStore
	{
		Task<List<Follower>> GetTwitterUserFollowers(long twitterUserId);
		Task<Follower> AddUserFollower(long twitterUserId, long followerId);
		Task DeleteTwitterUserFollower(long twitterUserId, long followerId);
	}
}
