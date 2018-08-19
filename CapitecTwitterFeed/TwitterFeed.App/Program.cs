using System;
using System.Collections.Generic;
using System.IO;
using TwitterFeed.Entities;
using System.Linq;
using System.Text;

namespace TwitterFeed.App
{
	class Program
	{
		static void Main(string[] args)
		{
			List<TwitterUser> users = GetTwitterUsersFromFile();
			List<Tweet> userTweets = GetTweetsFromFile();
			foreach(var user in users)
			{
				Console.WriteLine(user.Name);
				StringBuilder userFeed = new StringBuilder();
				var feeds = userTweets.Where(t => t.TwitterUser == user.Name || user.FollowingUserList.Any(f => f.Name == t.TwitterUser)).ToList();
				foreach(var feed in feeds)
				{
					Console.WriteLine($"   @{feed.TwitterUser}: {feed.TweetMessage}");
				}
			}

			Console.ReadKey(true);
		}
		private static List<TwitterUser> GetTwitterUsersFromFile()
		{
			List<TwitterUser> twitterUsers = new List<TwitterUser>();

			try
			{
				string[] users = File.ReadAllLines("user.txt");
				foreach(var user in users)
				{
					string[] userFollowing = user.Split("follows", StringSplitOptions.None);
					var userName = userFollowing[0].Trim();
					TwitterUser twitterUser = new TwitterUser();
					if (!twitterUsers.Any(u => u.Name == userName))
					{
						twitterUser.Name = userName;
						twitterUsers.Add(twitterUser);
					}
					if(userFollowing.Length>1)
					{
						var followings = userFollowing[1].Split(',');
						for(int i=0; i <= followings.Length-1; i++)
						{
							var following = new TwitterUser();
							following.Name = followings[i].Trim();
							if(!twitterUser.FollowingUserList.Any(f=>f.Name == following.Name))
							{
								twitterUser.FollowingUserList.Add(following);
							}
							if (!twitterUsers.Any(u => u.Name == following.Name))
								{
									twitterUsers.Add(following);
								}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.InnerException);
			}
			return twitterUsers.OrderBy(u=>u.Name).ToList();
		}
		private static List<Tweet> GetTweetsFromFile()
		{
			List<Tweet> userTweets = new List<Tweet>();
			try
			{
				string[] tweets = File.ReadAllLines("tweet.txt");
				foreach (var tweet in tweets)
				{
					var currentUserTweet = tweet.Split('>');
					if (currentUserTweet.Length == 2)
					{
						userTweets.Add(new Tweet
						{
							TwitterUser = currentUserTweet[0].Trim(),
							TweetMessage = currentUserTweet[1]
						});
					}
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.InnerException);
			}
			return userTweets;
		}
		
	}
}
