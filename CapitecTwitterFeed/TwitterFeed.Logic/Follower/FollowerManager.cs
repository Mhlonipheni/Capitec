using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitterFeed.DataAccess.Interfaces;
using TwitterFeed.Entities;
namespace TwitterFeed.Logic.Follower
{
    public class FollowerManager
    {
		private static IFollowerDataStore _followerDataStore;
		public static void RegisterManager(FollowerManager instance, IFollowerDataStore followerDataStore)
		{
			Instance = instance;
			_followerDataStore = followerDataStore;
		}
		public static FollowerManager Instance { get; private set; }

		public async Task<List<Entities.Follower>> GetTwitterUserFollowersAsync(long twitterUserId)
		{
			var results = await _followerDataStore.GetTwitterUserFollowers(twitterUserId).ConfigureAwait(false);
			return Mapper.Map(results);
		}
		public async Task<bool> DeleteTwitterUserFollowerAync(long twitterUserId, long followerId)
		{
			await _followerDataStore.DeleteTwitterUserFollower(twitterUserId, followerId).ConfigureAwait(false);
			return true;
		}
		public async Task<Entities.Follower> AddUserFollowerAsync(long twitterUserId, long followedByUserId)
		{
			var result = await _followerDataStore.AddUserFollower(twitterUserId, followedByUserId).ConfigureAwait(false);
			return Mapper.Map(result);
		}
	}
}
