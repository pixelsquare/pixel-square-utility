using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PixelSquare.Utility.EventListener
{
	using Parameters;

	interface IEvent
	{
		void addObserver(string p_name, Action p_callback);
		void addObserver(string p_name, Action<PSParameters> p_callback);

		void removeObserver(string p_name, Action p_callback);
		void removeObserver(string p_name, Action<PSParameters> p_callback);

		void notifyObserver(string p_name);
		void notifyObserver(string p_name, PSParameters p_params);

		void dispose(string p_name);

		int getEmptyEventCount(string p_name);
		int getParamEventCount(string p_name);
		int getTotalEventCount(string p_name);
	}
}
