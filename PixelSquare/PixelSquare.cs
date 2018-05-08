using UnityEngine;
using UnityEditor;

namespace PixelSquare
{
	using Utility.Logger;

	public static class PixelSquare
	{
		private static string m_pluginName	= "PixelSquare";
		private static string m_version		= "0.0.01";

		public static string pluginName
		{
			get { return m_pluginName; }
		}

		public static string version
		{
			get { return m_version; }
		}

		static PixelSquare()
		{
			PSLog.info(string.Format("Initializing PixelSquare Plugin v{0}", m_version));
		}
	}
}
