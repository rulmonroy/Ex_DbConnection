using System;

namespace Ex_DbConnection
{
	public class OracleConnection : DbConnection
	{
		public OracleConnection(string connectionString, TimeSpan timeout)
			: base(connectionString, timeout)
		{
			connectionHandle = "";
		}

		string connectionHandle;

		public override void CloseConnection()
		{
			if (!IsConnected())
			{
				throw new InvalidOperationException("Cannot close since there is no active ORACLE connection");
			}
			else
			{
				connectionHandle = null;
				Console.WriteLine($"ORACLE connection closed on: {DateTime.UtcNow}\n");
			}
		}

		public override void OpenConnection()
		{
			if (IsConnected())
			{
				throw new InvalidOperationException("An open ORACLE connection already exists.");
			}
			else
			{
				var delay = DateTime.UtcNow.AddSeconds(3);
				connectionHandle = "DB='MyDatabase';User='Rigoberto';Permits=0001101100011";
				Console.WriteLine("Initiating ORACLE connection...");

				while (DateTime.UtcNow < delay)
				{
				}

				Console.WriteLine($"Successfully connected to ORACLE on {DateTime.Now}\n");
			}
		}

		public override bool IsConnected() => !string.IsNullOrEmpty(connectionHandle);
	}
}
