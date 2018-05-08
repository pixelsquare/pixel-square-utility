using System;

namespace PixelSquare.Utility.EventListener
{
	using Parameters;

	public static class PSEventBroadcaster
	{
		private static IEvent s_event = null;

		static PSEventBroadcaster()
		{
			if(null == s_event)
			{
				s_event = new PSEvent();
			}
		}

		public static void addObserver(string p_name, Action p_callback)
		{
			if(null == s_event)
			{
				return;
			}

			s_event.addObserver(p_name, p_callback);
		}

		public static void addObserver(string p_name, Action<PSParameters> p_callback)
		{
			if(null == s_event)
			{
				return;
			}

			s_event.addObserver(p_name, p_callback);
		}

		public static void removeObserver(string p_name, Action p_callback)
		{
			if(null == s_event)
			{
				return;
			}

			s_event.removeObserver(p_name, p_callback);
		}

		public static void removeObserver(string p_name, Action<PSParameters> p_callback)
		{
			if(null == s_event)
			{
				return;
			}

			s_event.removeObserver(p_name, p_callback);
		}

		public static void notifyObserver(string p_name)
		{
			if(null == s_event)
			{
				return;
			}

			s_event.notifyObserver(p_name);
		}

		public static void nofifyObserver(string p_name, PSParameters p_params)
		{
			if(null == s_event)
			{
				return;
			}

			s_event.notifyObserver(p_name, p_params);
		}

		public static void dispose(string p_name)
		{
			if(null == s_event)
			{
				return;
			}

			s_event.dispose(p_name);
		}

		public static int getEmptyEventCount(string p_name)
		{
			return (null != s_event) ? s_event.getEmptyEventCount(p_name) : 0;
		}

		public static int getParamEventCount(string p_name)
		{
			return (null != s_event) ? s_event.getParamEventCount(p_name) : 0;
		}

		public static int getTotalEventCount(string p_name)
		{
			return (null != s_event) ? s_event.getTotalEventCount(p_name) : 0;
		}
	}
}
