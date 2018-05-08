using System;
using System.Collections.Generic;

namespace PixelSquare.Utility.EventListener
{
	using Parameters;

	internal class PSObjectListener
	{
		private List<Action> m_emptyEvents				= null;
		private List<Action<PSParameters>> m_paramEvents	= null;

		public PSObjectListener()
		{
			m_emptyEvents = new List<Action>();
			m_paramEvents = new List<Action<PSParameters>>();
		}

		public void addObserver(Action p_callback)
		{
			m_emptyEvents.Add(p_callback);
		}

		public void addObserver(Action<PSParameters> p_callback)
		{
			m_paramEvents.Add(p_callback);
		}

		public void removeObserver(Action p_callback)
		{
			m_emptyEvents.Remove(p_callback);
		}

		public void removeObserver(Action<PSParameters> p_callback)
		{
			m_paramEvents.Remove(p_callback);
		}

		public void dispose()
		{
			m_emptyEvents.Clear();
			m_paramEvents.Clear();
		}

		public void notifyObservers()
		{
			for(int i = 0; i < m_emptyEvents.Count; i++)
			{
				Action callback = m_emptyEvents[i];

				if(null != callback)
				{
					callback();
				}
			}
		}

		public void notifyObservers(PSParameters p_params)
		{
			for(int i = 0; i < m_paramEvents.Count; i++)
			{
				Action<PSParameters> callback = m_paramEvents[i];

				if(null != callback)
				{
					callback(p_params);
				}
			}
		}

		public int getEmptyEventCount()
		{
			return m_emptyEvents.Count;
		}

		public int getParamEventCount()
		{
			return m_paramEvents.Count;
		}

		public int getTotalEventCount()
		{
			return m_emptyEvents.Count + m_paramEvents.Count;
		}
	}
}
