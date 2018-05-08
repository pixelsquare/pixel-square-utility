using UnityEngine;
using System.IO;

namespace PixelSquare.Utility.FileHelper
{
	public static class PSFileHelper
	{
		static PSFileHelper() { }

		public static void createDirectory(string p_path, string p_name = "")
		{
			string rootPath			= Path.Combine(PixelSquare.pluginName, p_path);
			string projectPath		= Path.Combine(Application.dataPath, rootPath);
			string fullPath			= Path.Combine(projectPath, p_name);

			Directory.CreateDirectory(fullPath);
		}

		public static bool directoryExist(string p_path, string p_name = "")
		{
			string rootPath		= Path.Combine(PixelSquare.pluginName, p_path);
			string projectPath	= Path.Combine(Application.dataPath, rootPath);
			string fullPath		= Path.Combine(projectPath, p_name);

			return Directory.Exists(fullPath);
		}

		public static void deleteDirectory(string p_path, string p_name = "")
		{
			string rootPath		= Path.Combine(PixelSquare.pluginName, p_path);
			string projectPath	= Path.Combine(Application.dataPath, rootPath);
			string fullPath		= Path.Combine(projectPath, p_name);

			Directory.Delete(fullPath);
		}

		public static string getFolderPath(string p_name)
		{
			return Path.Combine(PixelSquare.pluginName, p_name);
		}

		public static string getCombinedPath(string p_path1, string p_path2)
		{
			return Path.Combine(p_path1, p_path2);
		}

		public static string getBasePath()
		{
			return Path.Combine(Application.dataPath, PixelSquare.pluginName);
		}
	}
}
