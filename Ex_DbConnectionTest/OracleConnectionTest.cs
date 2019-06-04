using System;
using Ex_DbConnection;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Ex_DbConnectionTest
{
	public class OracleConnectionTest
	{
		[Test]
		public void Test_CanInstantiate()
		{
			var conn = new OracleConnection("SomeString", new TimeSpan(0, 0, 10));
			Assert.That(conn.IsConnected, Is.False);
		}

		[Test]
		public void Test_NullArguments_ShouldThrow()
		{
			Assert.Throws<ArgumentNullException>(() => new OracleConnection("", new TimeSpan(0, 0, 10)));
		}

		[Test]
		public void Test_OpenConnection()
		{
			var oraConn = new OracleConnection("conn_string", new TimeSpan(0, 0, 10));
			oraConn.OpenConnection();
			Assert.That(oraConn.IsConnected, Is.True);
			Assert.Throws<InvalidOperationException>(() => oraConn.OpenConnection());
		}

		[Test]
		public void Test_CloseConnection()
		{
			var oraConn = new OracleConnection("conn_string", new TimeSpan(0, 0, 10));
			oraConn.OpenConnection();
			Assert.That(oraConn.IsConnected, Is.True);

			oraConn.CloseConnection();
			Assert.That(oraConn.IsConnected, Is.False);
		}

		[Test]
		public void Test_CloseConnection_WithNoConnection_ShouldThrow()
		{
			var oraConn = new OracleConnection("conn_string", new TimeSpan(0, 0, 10));
			Assert.That(oraConn.IsConnected, Is.False);
			Assert.Throws<InvalidOperationException>(() => oraConn.CloseConnection());
		}
	}
}
