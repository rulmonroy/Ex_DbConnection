using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_DbConnection
{
	class Program
	{
		static void Main(string[] args)
		{
			var sql = new SqlConnection("dbname='odyssey';user='raul';password='caralampio'", new TimeSpan(0, 0, 30));
			var oracle = new OracleConnection("dbname='aa';user='bb';password='cc'", new TimeSpan(0, 0, 15));
			oracle.OpenConnection();

			var command1 = new DbCommand(sql, "SELECT * FROM Sales");
			command1.Execute();

			var command2 = new DbCommand(oracle, "SELECT * FROM Sales");
			command2.Execute();
		}
	}
}
