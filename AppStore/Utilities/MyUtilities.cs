namespace Store.Utilities
{
	public static class MyUtilities
	{
		private static readonly string _filePath = "C:\\Users\\Elham\\OneDrive\\Desktop\\Store\\Store\\Store\\Logs\\Logs.txt";

		public static string AppendLogs(string message)
		{
			File.AppendAllText(_filePath, $"\n{message}-{DateTime.Now}");

			File.AppendAllText(_filePath, "\n-----------------------------------------------");

			return "Internal Server Error";
		}
	}
}
