using UnityEngine;
using UnityEditor;

using System;
using System.IO;

using JsonFx.Json;

namespace PixelSquare.Data
{
	using Utility;
	using Utility.FileHelper;	

	[JsonName("PixelSquare")]
	public abstract class SaveFileAbstract<T> where T : new()
	{
		private const string SAVE_FILE_FORMAT		= "{0}_{1}";
		private const string SAVE_FILE_EXT			= ".json";

		private const string STREAMING_ASSETS_PATH	= "StreamingAssets";

		private string m_streamingAssetsPath		= null;

		public SaveFileAbstract()
		{
			m_streamingAssetsPath = PSFileHelper.getCombinedPath(PSFileHelper.getBasePath(), STREAMING_ASSETS_PATH);
		}

		public T loadData(int p_dataId = 0)
		{
			string fileId = string.Format(SAVE_FILE_FORMAT, typeof(T).Name, p_dataId);
			string fileName = fileId + SAVE_FILE_EXT;

			string fileContent = File.ReadAllText(PSFileHelper.getCombinedPath(m_streamingAssetsPath, fileName));
			fileContent = fileContent.Trim();

			JsonReaderSettings readerSettings = new JsonReaderSettings();
			readerSettings.TypeHintName = "__Type";

			JsonReader jsonReader = new JsonReader(fileContent);
			T data = jsonReader.Deserialize<T>();

			return data;
		}

		public T loadData(string p_dataName, int p_dataId = 0)
		{
			string fileId = string.Format(SAVE_FILE_FORMAT, p_dataName, p_dataId);
			string fileName = fileId + SAVE_FILE_EXT;

			string fileContent = File.ReadAllText(PSFileHelper.getCombinedPath(m_streamingAssetsPath, fileName));
			fileContent = fileContent.Trim();

			JsonReaderSettings readerSettings = new JsonReaderSettings();
			readerSettings.TypeHintName = "__Type";

			JsonReader jsonReader = new JsonReader(fileContent);
			T data = jsonReader.Deserialize<T>();

			return data;
		}

		public void saveData(int p_dataId)
		{
			createStreamingAssetsPath();

			JsonWriterSettings writerSettings = new JsonWriterSettings();
			writerSettings.TypeHintName = "__Type";
			writerSettings.PrettyPrint = true;

			string fileId = string.Format(SAVE_FILE_FORMAT, typeof(T).Name, p_dataId);
			string fileName = fileId + SAVE_FILE_EXT;

			JsonWriter jsonWriter = new JsonWriter(PSFileHelper.getCombinedPath(m_streamingAssetsPath, fileName), writerSettings);
			jsonWriter.Write(this);
			jsonWriter.TextWriter.Flush();
			jsonWriter.TextWriter.Close();

			AssetDatabase.Refresh();
		}

		public void saveData(string p_dataName, int p_dataId)
		{
			createStreamingAssetsPath();

			JsonWriterSettings writerSettings = new JsonWriterSettings();
			writerSettings.TypeHintName = "__Type";
			writerSettings.PrettyPrint = true;

			string fileId = string.Format(SAVE_FILE_FORMAT, p_dataName, p_dataId);
			string fileName = fileId + SAVE_FILE_EXT;

			JsonWriter jsonWriter = new JsonWriter(PSFileHelper.getCombinedPath(m_streamingAssetsPath, fileName), writerSettings);
			jsonWriter.Write(this);
			jsonWriter.TextWriter.Flush();
			jsonWriter.TextWriter.Close();

			AssetDatabase.Refresh();
		}

		private void createStreamingAssetsPath()
		{
			string streamingAssetsPath = PSFileHelper.getCombinedPath(PSFileHelper.getBasePath(), STREAMING_ASSETS_PATH);

			if(!PSFileHelper.directoryExist(streamingAssetsPath))
			{
				PSFileHelper.createDirectory(streamingAssetsPath);
			}
		}
	}
}
