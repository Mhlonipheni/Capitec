using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterFeed.DataAccess.DataStores
{
	public abstract class DataStore<T>
	{

		public readonly string ConnectionString;

		protected DataStore(string connectionString)
		{
			ConnectionString = connectionString;
		}

		public static void RegisterDataStore(T instance)
		{
			Instance = instance;
		}

		public static T Instance { get; private set; }
	}
}
