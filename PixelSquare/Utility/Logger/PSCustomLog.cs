using UnityEngine;

namespace PixelSquare.Utility.Logger
{
	internal class PSCustomLog : ILogger
	{
		private PSLogger m_psLogger = null;

		public PSCustomLog()
		{
			m_psLogger = PSLogger.instance as PSLogger;
		}

		public void debug(params object[] p_objects)
		{
			m_psLogger.printDebugLog(p_objects);
		}

		public void debug(Color p_color, params object[] p_objects)
		{
			m_psLogger.printDebugLog(p_color, p_objects);
		}

		public void info(params object[] p_objects)
		{
			m_psLogger.printInfoLog(p_objects);
		}

		public void info(Color p_color, params object[] p_objects)
		{
			m_psLogger.printInfoLog(p_color, p_objects);
		}

		public void warning(params object[] p_objects)
		{
			m_psLogger.printWarningLog(p_objects);
		}

		public void warning(Color p_color, params object[] p_objects)
		{
			m_psLogger.printWarningLog(p_color, p_objects);
		}

		public void error(params object[] p_ojbects)
		{
			m_psLogger.printErrorLog(p_ojbects);
		}

		public void error(Color p_color, params object[] p_objects)
		{
			m_psLogger.printErrorLog(p_color, p_objects);
		}
	}
}
