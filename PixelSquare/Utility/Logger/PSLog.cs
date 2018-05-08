using UnityEngine;

namespace PixelSquare.Utility.Logger
{
	public static class PSLog
	{
		private static ILogger s_instance = null;

		static PSLog()
		{
			if(null == s_instance)
			{
				s_instance = new PSCustomLog();
			}
		}

		public static void debug(params object[] p_objects)
		{
			if(null == s_instance)
			{
				return;
			}

			s_instance.debug(p_objects);
		}

		public static void debug(Color p_color, params object[] p_objects)
		{
			if(null == s_instance)
			{
				return;
			}

			s_instance.debug(p_color, p_objects);
		}

		public static void info(params object[] p_objects)
		{
			if(null == s_instance)
			{
				return;
			}

			s_instance.info(p_objects);
		}

		public static void info(Color p_color, params object[] p_objects)
		{
			if(null == s_instance)
			{
				return;
			}

			s_instance.info(p_color, p_objects);
		}

		public static void warning(params object[] p_objects)
		{
			if(null == s_instance)
			{
				return;
			}

			s_instance.warning(p_objects);
		}

		public static void warning(Color p_color, params object[] p_objects)
		{
			if(null == s_instance)
			{
				return;
			}

			s_instance.warning(p_color, p_objects);
		}

		public static void error(params object[] p_objects)
		{
			if(null == s_instance)
			{
				return;
			}

			s_instance.error(p_objects);
		}

		public static void error(Color p_color, params object[] p_objects)
		{
			if(null == s_instance)
			{
				return;
			}

			s_instance.error(p_color, p_objects);
		}
	}
}
