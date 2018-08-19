using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterFeed.DataAccess
{
	public static class SqlStatements
	{

		public const string AddTwitterUserFollower = @"INSERT INTO Follower
																										(
																											[TwitterUserId], [FollowedByUserId]
																										)
																									VALUES
																										(
																											@TwitterUserId, @FollowedByUserId
																										)";
		public const string GetTwitterUserFollowers = @"SELECT [F].FollowerId,[F].FollowedByUserId,[T].TwitterUserId,[T].Name, 
																										FROM Follower [F] INNER JOIN 
																										TwitterUser [T] ON [F].FollowedByUserId = [T].TwitterUserId
																										WHERE TwitterUserId = @TwitterUserId";
		public const string GetTwitterUserFollower = @"SELECT [F].FollowerId,[F].FollowedByUserId,[T].TwitterUserId,[T].Name, 
																										FROM Follower [F] INNER JOIN 
																										TwitterUser [T] ON [F].FollowedByUserId = [T].TwitterUserId
																										WHERE [T].TwitterUserId = @TwitterUserId
																										AND [F].FollowedByUserId = @FollowedByUserId";

		public const string DeleteTwitterUserFollower = @" DELETE FROM Follower WHERE TwitterUserId = @TwitterUserId AND FollowedByUserId = @FollowerId";
		public const string GetTwitterUser = @"SELECT TwitterUserId, Name FROM TwitterUser WHERE TwitterUserId = @TwitterUserId";

	}
}
