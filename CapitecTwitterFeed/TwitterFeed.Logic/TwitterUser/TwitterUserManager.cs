using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitterFeed.DataAccess.Interfaces;
using TwitterFeed.Entities;
using TwitterFeed.Logic.Follower;

namespace TwitterFeed.Logic.TwitterUser
{
	public class TwitterUserManager
	{
		private static ITwitterUserDataStore _twitterUserDataStore;
		public static void RegisterManager(TwitterUserManager instance, ITwitterUserDataStore twitterUserDataStore)
		{
			Instance = instance;
			_twitterUserDataStore = twitterUserDataStore;
		}
		public static TwitterUserManager Instance {get;private set;}

		public async Task<Entities.TwitterUser> GetTwitterUserAsync(long twitterUserId)
		{
			var result = await _twitterUserDataStore.GetTwitterUser(twitterUserId).ConfigureAwait(false);
			return Mapper.Map(result);
		}
	}
}
