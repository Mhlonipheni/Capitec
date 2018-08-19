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
    public class TwitterUserDataStore : DataStore<ITwitterUserDataStore>, ITwitterUserDataStore
    {
		public TwitterUserDataStore(string connectionString) : base(connectionString)
		{

		}
		public async Task<TwitterUser> GetTwitterUser(long twitterUserId)
		{
			using (var connection = new SqlConnection(ConnectionString))
			{
				await connection.OpenAsync().ConfigureAwait(false);
				var queryAsync = await connection.QueryAsync<TwitterUser>(SqlStatements.GetTwitterUser,
					new
					{
						twitterUserId
					},
					commandType: CommandType.Text).ConfigureAwait(false);
				return queryAsync.FirstOrDefault();
			}
		}
	}
}
