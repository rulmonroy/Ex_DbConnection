using System;

namespace Ex_DbConnection
{
	public abstract class DbConnection
	{
		public DbConnection(string connectionString, TimeSpan timeout)
		{
			if (string.IsNullOrEmpty(connectionString) || timeout == null)
			{
				throw new ArgumentNullException("Connection string and timeout cannot be null.");
			}
			ConnectionString = connectionString;
			Timeout = timeout;
		}

		public string ConnectionString { get; set; }
		public TimeSpan Timeout { get; set; }

		public abstract void OpenConnection();

		public abstract void CloseConnection();

		public abstract bool IsConnected();
	}
}
