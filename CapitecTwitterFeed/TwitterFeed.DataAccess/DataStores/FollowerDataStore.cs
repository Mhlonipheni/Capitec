using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterFeed.DataAccess.DAO;
using TwitterFeed.DataAccess.Interfaces;

namespace TwitterFeed.DataAccess.DataStores
{
    public class FollowerDataStore: DataStore<IFollowerDataStore>, IFollowerDataStore
	{
		public FollowerDataStore(string connectionString) : base(connectionString)
		{

		}
		public async Task<List<Follower>> GetTwitterUserFollowers(long twitterUserId)
		{
			using (var connection = new SqlConnection(ConnectionString))
			{
				await connection.OpenAsync().ConfigureAwait(false);
				var results = await connection.QueryAsync<Follower>(SqlStatements.GetTwitterUserFollowers,
					new
					{
						twitterUserId
					},
					commandType: CommandType.Text).ConfigureAwait(false);
				return results.ToList();
			}
		}
		public async Task<Follower> AddUserFollower(long twitterUserId, long followedByUserId)
		{
			using (var connection = new SqlConnection(ConnectionString))
			{
				await connection.OpenAsync().ConfigureAwait(false);
				await connection.ExecuteAsync(SqlStatements.AddTwitterUserFollower, 
					new {
						twitterUserId,
						followedByUserId
					}, commandType: CommandType.Text).ConfigureAwait(false);
				var results = await connection.QueryAsync<Follower>(SqlStatements.GetTwitterUserFollower,
					new
					{
						twitterUserId,
						followedByUserId
					},
					commandType: CommandType.Text).ConfigureAwait(false);
				return results.FirstOrDefault();
			}

		}
		public async Task DeleteTwitterUserFollower(long twitterUserId, long followerId)
		{
			using (var connection = new SqlConnection(ConnectionString))
			{
				await connection.OpenAsync().ConfigureAwait(false);
				await connection.ExecuteAsync(SqlStatements.DeleteTwitterUserFollower,
					new
					{
						twitterUserId,
						followerId
					}, commandType: CommandType.Text).ConfigureAwait(false);
			}
		}
	}
}
