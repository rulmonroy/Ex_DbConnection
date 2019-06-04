using System;
using Ex_DbConnection;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Ex_DbConnectionTest
{
	public class DbCommandTest
	{
		public DbConnection DbConnectionSql { get; set; }
		public DbConnection DbConnectionOra { get; set; }

		[SetUp]
		public void TestSetup()
		{
			DbConnectionSql = new SqlConnection("connString", new TimeSpan(0, 0, 10));
			DbConnectionOra = new OracleConnection("user='a';pass='b'", new TimeSpan(0, 0, 20));
		}

		[Test]
		public void Test_CanInstantiate()
		{
			Assert.DoesNotThrow(() =>
			{
				new DbCommand(DbConnectionSql, "SELECT * FROM Sales");
			});
		}

		[Test]
		public void Test_NullArguments_ShouldThrow()
		{
			Assert.Throws<ArgumentNullException>(() =>
			{
				new DbCommand(DbConnectionOra, "");
			});

			Assert.Throws<ArgumentNullException>(() =>
			{
				new DbCommand(null, "SELECT * FROM Sales");
			});
		}

		[Test]
		public void Test_Execute()
		{
			var command = new DbCommand(DbConnectionSql, "SELECT * FROM Sales");
			Assert.That(DbConnectionSql.IsConnected, Is.False);
			Assert.DoesNotThrow(command.Execute);
			Assert.That(DbConnectionSql.IsConnected, Is.False);
		}

		[Test]
		public void Test_Execute_ConnectedDb()
		{
			var command = new DbCommand(DbConnectionSql, "SELECT * FROM Sales");
			DbConnectionSql.OpenConnection();
			Assert.That(DbConnectionSql.IsConnected, Is.True);
			Assert.DoesNotThrow(command.Execute);
			Assert.That(DbConnectionSql.IsConnected, Is.False);
		}
	}
}
