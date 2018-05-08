using System.Collections;
using System.Collections.Generic;

namespace PixelSquare.Utility.Parameters
{
	public class PSParameters
	{
		private Dictionary<string, char>		m_charParams		= null;
		private Dictionary<string, bool>		m_boolParams		= null;
		private Dictionary<string, int>			m_intParams			= null;
		private Dictionary<string, string>		m_stringParams		= null;
		private Dictionary<string, float>		m_floatParams		= null;
		private Dictionary<string, double>		m_doubleParams		= null;

		private Dictionary<string, ArrayList>	m_arrayListParams	= null;
		private Dictionary<string, object>		m_objectParams		= null;

		public PSParameters() 
		{
			m_charParams		= new Dictionary<string, char>();
			m_boolParams		= new Dictionary<string, bool>();
			m_intParams			= new Dictionary<string, int>();
			m_stringParams		= new Dictionary<string, string>();
			m_floatParams		= new Dictionary<string, float>();
			m_doubleParams		= new Dictionary<string, double>();

			m_arrayListParams	= new Dictionary<string, ArrayList>();
			m_objectParams		= new Dictionary<string, object>();
		}

		public void putExtra(string p_name, char p_value)
		{
			m_charParams.Add(p_name, p_value);
		}

		public void putExtra(string p_name, bool p_value)
		{
			m_boolParams.Add(p_name, p_value);
		}

		public void putExtra(string p_name, int p_value)
		{
			m_intParams.Add(p_name, p_value);
		}

		public void putExtra(string p_name, string p_value)
		{
			m_stringParams.Add(p_name, p_value);
		}

		public void putExtra(string p_name, float p_value)
		{
			m_floatParams.Add(p_name, p_value);
		}

		public void putExtra(string p_name, double p_value)
		{
			m_doubleParams.Add(p_name, p_value);
		}

		public void putExtra(string p_name, ArrayList p_value)
		{
			m_arrayListParams.Add(p_name, p_value);
		}

		public void putExtra(string p_name, object p_value)
		{
			m_objectParams.Add(p_name, p_value);
		}

		public char getExtra(string p_name, char p_defaultValue)
		{
			return m_charParams.ContainsKey(p_name) ? m_charParams[p_name] : p_defaultValue;
		}

		public bool getExtra(string p_name, bool p_defaultValue)
		{
			return m_boolParams.ContainsKey(p_name) ? m_boolParams[p_name] : p_defaultValue;
		}

		public int getExtra(string p_name, int p_defaultValue)
		{
			return m_intParams.ContainsKey(p_name) ? m_intParams[p_name] : p_defaultValue;
		}

		public string getExtra(string p_name, string p_defaultValue)
		{
			return m_stringParams.ContainsKey(p_name) ? m_stringParams[p_name] : p_defaultValue;
		}

		public float getExtra(string p_name, float p_defaultValue)
		{
			return m_floatParams.ContainsKey(p_name) ? m_floatParams[p_name] : p_defaultValue;
		}

		public double getExtra(string p_name, double p_defaultValue)
		{
			return m_doubleParams.ContainsKey(p_name) ? m_doubleParams[p_name] : p_defaultValue;
		}

		public ArrayList getExtra(string p_name, ArrayList p_defaultValue)
		{
			return m_arrayListParams.ContainsKey(p_name) ? m_arrayListParams[p_name] : p_defaultValue;
		}

		public object getExtra(string p_name, object p_defaultValue)
		{
			return m_objectParams.ContainsKey(p_name) ? m_objectParams[p_name] : p_defaultValue;
		}
	}
}
