using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitterFeed.DataAccess.DAO;

namespace TwitterFeed.DataAccess.Interfaces
{
	public interface ITwitterUserDataStore
	{
		Task<TwitterUser> GetTwitterUser(long twitterUserId);
	}
}
