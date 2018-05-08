using UnityEngine;

namespace PixelSquare.Utility.Logger
{
	internal interface ILogger
	{
		void debug(params object[] p_objects);
		void debug(Color p_color, params object[] p_objects);

		void info(params object[] p_objects);
		void info(Color p_color, params object[] p_objects);

		void warning(params object[] p_objects);
		void warning(Color p_color, params object[] p_objects);

		void error(params object[] p_ojbects);
		void error(Color p_color, params object[] p_objects);
	}
}
