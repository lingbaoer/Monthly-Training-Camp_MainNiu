//----------------------------------------------
//            Shader Weaver
//      Copyright© 2017 Jackie Lo
//----------------------------------------------
namespace ShaderWeaver
{
	using UnityEngine;
	using System.Collections;
	using System.Collections.Generic;
	using System.IO;
	using System;


	[System.Serializable]
	public enum SWShaderQueue
	{
		Background = 1000,
		Geometry = 2000,
		AlphaTest = 2450,
		Transparent = 3000,
		Overlay = 4000
	}

	[System.Serializable]
	public enum SWShaderType
	{
		normal = 0,
		sprite = 1,
		ui = 2,
		uiFont =3,
	}

	[System.Serializable]
	public enum SWShaderModel
	{
		auto=0,
		m10=1,
		m20=2,
		m30=3,
		m40=4,
		m50=5
	}

	[System.Serializable]
	public enum SWSpriteLightType
	{
		no = 0,
		diffuse = 1
	}

	[Serializable]
	public enum SWShaderBlend
	{
		blend,
		add,
		mul
	}

	/// <summary>
	/// Save as Json
	/// </summary>
	[Serializable]
	public class SWData
	{
		public SWShaderQueue shaderQueue = SWShaderQueue.Transparent;
		public int shaderQueueOffset;
		public SWShaderType shaderType;
		public SWSpriteLightType spriteLightType;
		public SWShaderModel shaderModel;
		public SWShaderBlend shaderBlend;
		public bool excludeRoot;
		public int version = 1;
		public float pixelPerUnit;
		public Rect spriteRect;
		public string title = "effect1";
		public string materialGUID;
		public List<string> masksGUID = new List<string> ();

		public List<SWParam> paramList = new List<SWParam>();
		public List<SWDataNode> nodes = new List<SWDataNode>();
		public float clipValue;

		public string fallback = "Standard";
		public SWData()
		{

		}
	}

	/// <summary>
	/// Write all data into shader file as Json
	/// </summary>
	public class SWDataManager{
		public static bool IsSWShader(string fullPath)
		{
			return File.ReadAllText (fullPath).Contains ("ShaderWeaverData");
		}

		public static void Save(string path,SWData data)
		{
			string s = JsonUtility.ToJson (data);
			s = "//"+ SWGlobalSettings.ShaderID + s + "\n";
			s += File.ReadAllText (path);
			File.WriteAllText (path, s);
		}

		public static SWData Load(string path)
		{
			string jsonTxt = GetShaderJson (File.ReadAllLines (path));
			if (!string.IsNullOrEmpty (jsonTxt)) {
				SWData e = JsonUtility.FromJson<SWData> (jsonTxt);
				VersionUpdate (e);
				return e;
			}
			return null;
		}

		private static string GetShaderJson(string[] lines)
		{
			foreach (var line in lines) {
				if (line.Contains (SWGlobalSettings.ShaderID)) {
					var cArray = line.ToCharArray ();
					for (int i = 0; i < cArray.Length; i++) {
						if (cArray [i] == '{') {
							return line.Substring (i);
						}
					}
				}
			}
			return "";
		}

		public static string DataToText(List<SWDataNode> nodes)
		{
			SWData data = new SWData ();
			data.nodes = nodes;
			string s = JsonUtility.ToJson (data);
			return s;
		}

		public static List<SWDataNode> TextToData(string text)
		{
			SWData e = JsonUtility.FromJson<SWData> (text);
			return e.nodes;
		}

		public static bool StringIsData(string txt)
		{
			return txt.Contains ("shaderQueue");
		}

		public static void VersionUpdate(SWData data)
		{
			if (data.version >= SWGlobalSettings.version)
				return;
			if (data.version < 120)
				VersionUpdate_120 (data);
			if (data.version < 121)
				VersionUpdate_121 (data);
			FixParams (data);
			data.version = SWGlobalSettings.version;
		}

		protected static void VersionUpdate_120(SWData data)
		{
			//new blend options
			foreach (var item in data.nodes) {
				if (item.effectDataColor.op == SWOutputOP.blendInner) {
					item.effectDataColor.op = SWOutputOP.addInner;
				}
				if (item.effectDataColor.op == SWOutputOP.add) {
					item.effectDataColor.op = SWOutputOP.mul;
				}
			}
			//Add masks GUID
			List<string> masksGUID = new List<string>();
			foreach (var item in data.nodes) {
				if (item.type == SWNodeType.mask) {
					if (!masksGUID.Contains (item.textureGUID)) {
						masksGUID.Add (item.textureGUID);
					}
				}
			}
			data.masksGUID = masksGUID;
		}
		protected static void VersionUpdate_121(SWData data)
		{
			foreach (var node in data.nodes) {
				//color node now name as image node
				if (node.type == SWNodeType.color) {
					node.name = node.name.Replace ("color", "image");
					node.type = SWNodeType.image;
				}

				//new ports
				foreach (var item in node.parent) {
					node.parentPort.Add (0);
				}
				foreach (var item in node.children) {
					node.childrenPort.Add (0);
				}
			}
		}

		public static void FixParams(SWData data)
		{
			foreach (var item in data.nodes) {
				FixParam (data,ref item.effectData.t_Param);
				FixParam (data,ref item.effectData.r_Param);
				FixParam (data,ref item.effectData.s_Param);
				FixParam (data,ref item.effectData.pop_Param);
				FixParam (data,ref item.effectDataUV.param);
				FixParam (data,ref item.effectDataColor.param);
			}
		}
		public static void FixParam(SWData data,ref string param)
		{
			//1 _TimeAll->_Time      _TimeMod->1
			param = param.Replace ("_TimeAll", "_Time");
			param = param.Replace ("_TimeMod", "1");

			//_Time.y*2 ->(_Time.y*2)
			if (!ParamIsPredefined (data, param)) {
				if (param [0] != '(' || param [param.Length - 1] != ')') {
					param = string.Format ("({0})",param);
				}
			}
		}

		public static bool ParamIsPredefined(SWData data,string param)
		{
			if (param == "_Time.y")
				return true;
			foreach (var item in data.paramList) {
				if (item.name == param)
					return true;
			}
			return false;
		}

		public static string NewGUID()
		{
			System.Guid guid =	System.Guid.NewGuid ();
			string str = guid.ToString ();
			str = str.Replace ('-', '_');
			return str;
		}
	}
}
