using System;

namespace Ex_DbConnection
{
	public class DbCommand
	{
		public DbCommand(DbConnection connection, string instruction)
		{
			if (connection == null || string.IsNullOrEmpty(instruction))
			{
				throw new ArgumentNullException("A connection and instruction are required for instantiating a DbCommand.");
			}
			Connection = connection;
			Instruction = instruction;
		}

		public DbConnection Connection { get; set; }
		public string Instruction { get; set; }

		public void Execute()
		{
			if (!Connection.IsConnected())
			{
				Connection.OpenConnection();
			}
			Console.WriteLine($"Executing instruction: {Instruction}");
			Connection.CloseConnection();
		}
	}
}
