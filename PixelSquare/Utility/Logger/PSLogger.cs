using UnityEngine;

using UnityEditor;

using System.IO;
using System.Text;

namespace PixelSquare.Utility.Logger
{
	using FileHelper;

	internal sealed class PSLogger : ScriptableObject
	{
		private static PSLogger s_instance = null;

		public static PSLogger instance
		{
			get
			{

				if(PSFileHelper.directoryExist(LOG_DIRECTORY_NAME + LOG_RESOURCES_NAME, "") && null == s_instance)
				{
					//s_instance = (PSLogger)AssetDatabase.LoadAssetAtPath(PSFileHelper.getFolderPath(LOG_DIRECTORY_NAME), typeof(PSLogger));
					string loggerString = PSFileHelper.getCombinedPath(LOG_DIRECTORY_NAME, LOG_SETTINGS_NAME);
					s_instance = (PSLogger)Resources.Load(loggerString);
				}

				if(null == s_instance)
				{
					s_instance = CreateInstance<PSLogger>();

					PSFileHelper.createDirectory(LOG_DIRECTORY_NAME, "");

					if(PSFileHelper.directoryExist(LOG_DIRECTORY_NAME, ""))
					{
						string fullPath = PSFileHelper.getCombinedPath
						(
							PSFileHelper.getCombinedPath
							(
								"Assets", PSFileHelper.getFolderPath(LOG_DIRECTORY_NAME)
							), 
							PSFileHelper.getCombinedPath
							(
								LOG_RESOURCES_NAME, (LOG_SETTINGS_NAME + LOG_SETTING_EXT)
							)
						);

						AssetDatabase.CreateAsset(s_instance, fullPath);
						AssetDatabase.Refresh();
					}
				}

				return s_instance;
			}
		}

		private const string NATIVE_TEXT_FORMAT		= "<color=#000000>{0}</color>";
		private const string LOG_TEXT_FORMAT		= "<color=#{0}>{1}</color>";
		private const string TAG_TEXT_FORMAT		= "<b><color=#{0}>{1}: </color></b>";

		
		private const string LOG_DIRECTORY_NAME		= "Logger";
		private const string LOG_SETTINGS_NAME		= "LogSettings";
		private const string LOG_RESOURCES_NAME		= "Resources";
		private const string LOG_SETTING_EXT		= ".asset";

		[SerializeField] private bool m_enableLog					= true;
		[SerializeField] private bool m_useNativeLogs				= false;
		[SerializeField] private bool m_enableLogDebug				= true;
		[SerializeField] private bool m_enableLogInfo				= true;
		[SerializeField] private bool m_enableLogWarning			= true;
		[SerializeField] private bool m_enableLogError				= true;

		private Color m_defaultDebugColor			= new Color(0.0f, 0.0f, 0.0f);
		private Color m_defaultInfoColor			= new Color(0.2f, 0.2f, 0.2f);
		private Color m_defaultWarningColor			= new Color(0.3f, 0.3f, 0.0f);
		private Color m_defaultErrorColor			= new Color(0.5f, 0.0f, 0.0f);

		private PSLogger() { }

		internal void printDebugLog(params object[] p_logs)
		{
			if(!m_enableLog || !m_enableLogDebug)
			{
				return;
			}

			string log = formatLogToString("DEBUG", m_defaultDebugColor, m_defaultDebugColor, p_logs);
			Debug.Log(log);
		}

		internal void printDebugLog(Color p_color, params object[] p_logs)
		{
			if(!m_enableLog || !m_enableLogDebug)
			{
				return;
			}

			string log = formatLogToString("DEBUG", m_defaultDebugColor, p_color, p_logs);
			Debug.Log(log);
		}

		internal void printInfoLog(params object[] p_logs)
		{
			if(!m_enableLog || !m_enableLogInfo)
			{
				return;
			}

			string log = formatLogToString("INFO", m_defaultInfoColor, m_defaultInfoColor, p_logs);
			Debug.Log(log);
		}

		internal void printInfoLog(Color p_color, params object[] p_logs)
		{
			if(!m_enableLog || !m_enableLogInfo)
			{
				return;
			}

			string log = formatLogToString("INFO", m_defaultInfoColor, p_color, p_logs);
			Debug.Log(log);
		}

		internal void printWarningLog(params object[] p_logs)
		{
			if(!m_enableLog || !m_enableLogWarning)
			{
				return;
			}

			string log = formatLogToString("WARNING", m_defaultWarningColor, m_defaultWarningColor, p_logs);
			Debug.LogWarning(log);
		}

		internal void printWarningLog(Color p_color, params object[] p_logs)
		{
			if(!m_enableLog || !m_enableLogWarning)
			{
				return;
			}

			string log = formatLogToString("WARNING", m_defaultWarningColor, p_color, p_logs);
			Debug.LogWarning(log);
		}

		internal void printErrorLog(params object[] p_logs)
		{
			if(!m_enableLog || !m_enableLogError)
			{
				return;
			}

			string log = formatLogToString("ERROR", m_defaultErrorColor, m_defaultErrorColor, p_logs);
			Debug.LogError(log);
		}

		internal void printErrorLog(Color p_color, params object[] p_logs)
		{
			if(!m_enableLog || !m_enableLogError)
			{
				return;
			}

			string log = formatLogToString("ERROR", m_defaultErrorColor, p_color, p_logs);
			Debug.LogError(log);
		}

		internal string formatLogToString(string p_tag, Color p_tagColor, Color p_color, params object[] p_logs)
		{
			string tagColorHex = string.Empty;
			string textColorHex = string.Empty;

//# if UNITY_5_1
//            tagColorHex = p_tagColor.ToHexStringRGB();
//            textColorHex = p_color.toHexStringRGB();
//# elif UNITY_5_2
			tagColorHex = ColorUtility.ToHtmlStringRGB(p_tagColor);
			textColorHex = ColorUtility.ToHtmlStringRGB(p_color);
//# endif
			StringBuilder resultString = new StringBuilder();
			resultString.Append(string.Format(TAG_TEXT_FORMAT, tagColorHex, p_tag));

			StringBuilder logString = new StringBuilder();
			for(int i = 0; i < p_logs.Length; i++)
			{
				logString.Append(p_logs[i]);
			}

			if(m_useNativeLogs)
			{
				resultString = new StringBuilder();
				resultString.Append(string.Format(NATIVE_TEXT_FORMAT, logString.ToString()));
			}
			else
			{
				resultString.Append(string.Format(LOG_TEXT_FORMAT, textColorHex, logString.ToString()));
			}

			return resultString.ToString();
		}
	}
}
