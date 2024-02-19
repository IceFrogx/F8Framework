﻿/*
 *   This file was generated by a tool.
 *   Do not edit it, otherwise the changes will be overwritten.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using F8Framework.F8ExcelDataClass;
using F8Framework.Core;

namespace F8Framework.F8DataManager
{
	public class F8DataManager : Singleton<F8DataManager>
	{
		private table1 p_table1;
		private table2 p_table2;
		private LocalizedStrings p_LocalizedStrings;
		private Entities1 p_Entities1;
		private Entities2 p_Entities2;

		public table1Item Gettable1ByID(Int32 id)
		{
			table1Item t = null;
			p_table1.Dict.TryGetValue(id, out t);
			if (t == null) LogF8.LogError("can't find the id " + id + " in table1");
			return t;
		}

		public Dictionary<int, table1Item> Gettable1()
		{
			return p_table1.Dict;
		}

		public table2Item Gettable2ByID(Int32 id)
		{
			table2Item t = null;
			p_table2.Dict.TryGetValue(id, out t);
			if (t == null) LogF8.LogError("can't find the id " + id + " in table2");
			return t;
		}

		public Dictionary<int, table2Item> Gettable2()
		{
			return p_table2.Dict;
		}

		public LocalizedStringsItem GetLocalizedStringsByID(Int32 id)
		{
			LocalizedStringsItem t = null;
			p_LocalizedStrings.Dict.TryGetValue(id, out t);
			if (t == null) LogF8.LogError("can't find the id " + id + " in LocalizedStrings");
			return t;
		}

		public Dictionary<int, LocalizedStringsItem> GetLocalizedStrings()
		{
			return p_LocalizedStrings.Dict;
		}

		public Entities1Item GetEntities1ByID(Int32 id)
		{
			Entities1Item t = null;
			p_Entities1.Dict.TryGetValue(id, out t);
			if (t == null) LogF8.LogError("can't find the id " + id + " in Entities1");
			return t;
		}

		public Dictionary<int, Entities1Item> GetEntities1()
		{
			return p_Entities1.Dict;
		}

		public Entities2Item GetEntities2ByID(Int32 id)
		{
			Entities2Item t = null;
			p_Entities2.Dict.TryGetValue(id, out t);
			if (t == null) LogF8.LogError("can't find the id " + id + " in Entities2");
			return t;
		}

		public Dictionary<int, Entities2Item> GetEntities2()
		{
			return p_Entities2.Dict;
		}

		public void LoadAll()
		{
			p_table1 = Load("table1") as table1;
			p_table2 = Load("table2") as table2;
			p_LocalizedStrings = Load("LocalizedStrings") as LocalizedStrings;
			p_Entities1 = Load("Entities1") as Entities1;
			p_Entities2 = Load("Entities2") as Entities2;
		}

		public void RuntimeLoadAll(Dictionary<String, System.Object> objs)
		{
			p_table1 = objs["table1"] as table1;
			p_table2 = objs["table2"] as table2;
			p_LocalizedStrings = objs["LocalizedStrings"] as LocalizedStrings;
			p_Entities1 = objs["Entities1"] as Entities1;
			p_Entities2 = objs["Entities2"] as Entities2;
		}

		public IEnumerable LoadAllAsync()
		{
			yield return LoadAsync("table1", result => p_table1 = result as table1);
			yield return LoadAsync("table2", result => p_table2 = result as table2);
			yield return LoadAsync("LocalizedStrings", result => p_LocalizedStrings = result as LocalizedStrings);
			yield return LoadAsync("Entities1", result => p_Entities1 = result as Entities1);
			yield return LoadAsync("Entities2", result => p_Entities2 = result as Entities2);
		}

		private System.Object Load(string name)
		{
			IFormatter f = new BinaryFormatter();
			TextAsset text = AssetManager.Instance.Load<TextAsset>(name);
			using (MemoryStream memoryStream = new MemoryStream(text.bytes))
			{
				return f.Deserialize(memoryStream);
			}
		}
		private IEnumerator LoadAsync(string name, Action<object> callback)
		{
			IFormatter f = new BinaryFormatter();
			var load = AssetManager.Instance.LoadAsyncCoroutine<TextAsset>(name);
			yield return load;
			{
				TextAsset textAsset = AssetManager.Instance.Load<TextAsset>(name);
				if (textAsset != null)
				{
					using (Stream s = new MemoryStream(textAsset.bytes))
					{
						object obj = f.Deserialize(s);
						callback(obj);
					}
				}
			}
		}
	}
}
