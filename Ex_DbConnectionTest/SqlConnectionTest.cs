using System;
using Ex_DbConnection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Ex_DbConnectionTest
{
	public class SqlConnectionTest
	{
		[Test]
		public void Test_CanInstantiate()
		{
			var conn = new SqlConnection("SomeString", new TimeSpan(0, 0, 10));
			Assert.That(conn.IsConnected, Is.False);
		}

		[Test]
		public void Test_NullArguments_ShouldThrow()
		{
			Assert.Throws<ArgumentNullException>(() => new SqlConnection("", new TimeSpan(0, 0, 10)));
		}

		[Test]
		public void Test_OpenConnection()
		{
			var sqlConn = new SqlConnection("conn_string", new TimeSpan(0, 0, 10));
			sqlConn.OpenConnection();
			Assert.That(sqlConn.IsConnected, Is.True);
			Assert.Throws<InvalidOperationException>(() => sqlConn.OpenConnection());
		}

		[Test]
		public void Test_CloseConnection()
		{
			var sqlConn = new SqlConnection("conn_string", new TimeSpan(0, 0, 10));
			sqlConn.OpenConnection();
			Assert.That(sqlConn.IsConnected, Is.True);

			sqlConn.CloseConnection();
			Assert.That(sqlConn.IsConnected, Is.False);
		}

		[Test]
		public void Test_CloseConnection_WithNoConnection_ShouldThrow()
		{
			var sqlConn = new SqlConnection("conn_string", new TimeSpan(0, 0, 10));
			Assert.That(sqlConn.IsConnected, Is.False);
			Assert.Throws<InvalidOperationException>(() => sqlConn.CloseConnection());
		}
	}
}
