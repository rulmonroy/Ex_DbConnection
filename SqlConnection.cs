using System;

namespace Ex_DbConnection
{
	public class SqlConnection : DbConnection
	{
		public SqlConnection(string connectionString, TimeSpan timeout)
			: base(connectionString, timeout)
		{
			connectionHandle = "";
		}

		string connectionHandle;

		public override void CloseConnection()
		{
			if (!IsConnected())
			{
				throw new InvalidOperationException("Cannot close connection. There is no active SQL Server connection");
			}
			else
			{
				connectionHandle = "";
				Console.WriteLine($"SQL Server connection closed on: {DateTime.UtcNow}\n");
			}
		}

		public override void OpenConnection()
		{
			if (IsConnected())
			{
				throw new InvalidOperationException("Cannot open a connection since there is already an existing one.");
			}
			else
			{
				var delay = DateTime.UtcNow.AddSeconds(3);
				connectionHandle = "DB='MyDatabase';User='Rigoberto';Permits=0001101100011";
				Console.WriteLine("Initiating SQL Server connection...");

				while (DateTime.UtcNow < delay)
				{
				}

				Console.WriteLine($"Successfully connected to SQL Server on {DateTime.Now}\n");
			}
		}

		public override bool IsConnected() => !string.IsNullOrEmpty(connectionHandle);
	}
}
