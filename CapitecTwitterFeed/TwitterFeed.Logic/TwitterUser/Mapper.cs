using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterFeed.Logic.TwitterUser
{
	public static class Mapper
	{
		public static Entities.TwitterUser Map(DataAccess.DAO.TwitterUser dao)
		{
			return new Entities.TwitterUser
			{
				TwitterUserId = dao.TwitterUserId,
				Name = dao.Name
			};
		}
	}
}
