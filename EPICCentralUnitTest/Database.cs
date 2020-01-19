using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPICCentralUnitTest
{
	/// <summary>
	/// 
	/// </summary>
	public static class Database
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static void Initialize(TestContext context)
		{
			RunScripts(context.DeploymentDirectory + "\\Database\\Initialize", dataDirectory: GetDataDirectory(context));
		}

		/// <summary>
		/// 
		/// </summary>
		public static void Revert(TestContext context)
		{
			RunScripts(context.DeploymentDirectory + "\\Database\\Revert", true);
		}

		private static void RunScripts(string directory, bool reverse = false, string dataDirectory = null)
		{
			using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Main.ConnectionString"].ConnectionString))
			{
				connection.Open();
				using (var transaction = connection.BeginTransaction())
				{
					RunScripts(transaction, directory, reverse, dataDirectory);
					transaction.Commit();
				}
			}
		}

		private static void RunScripts(SqlTransaction transaction, string directory, bool reverse, string dataDirectory)
		{
			var files = Directory.GetFiles(directory, "*.sql").OrderBy(x => x).ToList();
			if (reverse)
				files.Reverse();
			foreach (var file in files)
			{
				RunScript(transaction, file, dataDirectory);
			}
		}

		private static void RunScript(SqlTransaction transaction, string scriptFile, string dataDirectory)
		{
			var script = File.ReadAllText(scriptFile);
			var commands = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
			foreach (var command in commands.Where(command => command.Trim().Length > 0))
			{
				var sqlCommand = new SqlCommand(command, transaction.Connection, transaction);
				// Scripts that load exported data need this parameter. However, scripts that don't used the
				// parameter will fail if it is defined! Only define it if necessary.
				if (dataDirectory != null && command.Contains("@rootdir"))
				{
					sqlCommand.Parameters.Add(new SqlParameter
												{
													ParameterName = "@rootdir",
													SqlDbType = SqlDbType.VarChar,
													Size = dataDirectory.Length,
													Direction = ParameterDirection.Input,
													Value = dataDirectory
												});
				}
				sqlCommand.ExecuteNonQuery();
			}
		}

		private static string GetDataDirectory(TestContext context)
		{
			var testDataRootSetting = ConfigurationManager.AppSettings["TestDataRoot"];
			return testDataRootSetting != null && testDataRootSetting == "Project" ? context.DeploymentDirectory + "\\Database\\TestData" : TestData.TestDataRoot;
		}
	}
}
