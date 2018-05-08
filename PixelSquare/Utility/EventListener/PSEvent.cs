using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PixelSquare.Utility.EventListener
{
	using Parameters;

	internal class PSEvent : IEvent
	{
		private Dictionary<string, PSObjectListener> m_objectListener = null;

		public void addObserver(string p_name, Action p_callback)
		{
			PSObjectListener listener = null;

			if(m_objectListener.ContainsKey(p_name))
			{
				listener = m_objectListener[p_name];
				listener.addObserver(p_callback);
			}
			else
			{
				listener = new PSObjectListener();
				listener.addObserver(p_callback);
				m_objectListener.Add(p_name, listener);
			}
		}

		public void addObserver(string p_name, Action<PSParameters> p_callback)
		{
			PSObjectListener listener = null;

			if(m_objectListener.ContainsKey(p_name))
			{
				listener = m_objectListener[p_name];
				listener.addObserver(p_callback);
			}
			else
			{
				listener = new PSObjectListener();
				listener.addObserver(p_callback);
				m_objectListener.Add(p_name, listener);
			}
		}

		public void removeObserver(string p_name, Action p_callback)
		{
			if(m_objectListener.ContainsKey(p_name))
			{
				m_objectListener[p_name].removeObserver(p_callback);
			}
		}

		public void removeObserver(string p_name, Action<PSParameters> p_callback)
		{
			if(m_objectListener.ContainsKey(p_name))
			{
				m_objectListener[p_name].removeObserver(p_callback);
			}
		}

		public void notifyObserver(string p_name)
		{
			if(m_objectListener.ContainsKey(p_name))
			{
				m_objectListener[p_name].notifyObservers();
			}
		}

		public void notifyObserver(string p_name, PSParameters p_params)
		{
			if(m_objectListener.ContainsKey(p_name))
			{
				m_objectListener[p_name].notifyObservers(p_params);
			}
		}

		public void dispose(string p_name)
		{
			if(m_objectListener.ContainsKey(p_name))
			{
				m_objectListener[p_name].dispose();
			}
		}

		public int getEmptyEventCount(string p_name)
		{
			return m_objectListener.ContainsKey(p_name) ? m_objectListener[p_name].getEmptyEventCount() : 0;
		}

		public int getParamEventCount(string p_name)
		{
			return m_objectListener.ContainsKey(p_name) ? m_objectListener[p_name].getParamEventCount() : 0;
		}

		public int getTotalEventCount(string p_name)
		{
			return m_objectListener.ContainsKey(p_name) ? m_objectListener[p_name].getTotalEventCount() : 0;
		}
	}
}
