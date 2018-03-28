//----------------------------------------------
//            Shader Weaver
//      Copyright© 2017 Jackie Lo
//----------------------------------------------
namespace ShaderWeaver
{
	using UnityEngine;
	using System.Collections;
	using UnityEditor;
	using System;

	[System.Serializable]
	public class SWNodeColor :SWNodeBase {
		public override void Init (SWDataNode _data, SWWindowMain _window)
		{
			styleID = 0;
			nodeWidth = 144;
			nodeHeight = 130;
			base.Init (_data, _window);
			data.outputType.Add (SWDataType._Color);
			data.inputType.Add (SWDataType._Alpha);
		}

		protected override void DrawNodeWindow (int id)
		{
			base.DrawNodeWindow (id);
			GUILayout.Space (7);
			GUILayout.BeginHorizontal ();
			GUILayout.Space (7);
			GUILayout.BeginVertical ();

			float labelWith = 42;

			EffectDataColor _data = data.effectDataColor;
			string name = _data.hdr ? "[HDR]" : "Color";
			GUILayout.BeginHorizontal ();
			GUILayout.Label (name, SWEditorUI.Style_Get (SWCustomStyle.eTxtSmallLight), GUILayout.Width(labelWith));
			var rect = GUILayoutUtility.GetLastRect ();
			if (SWCommon.GetMouseDown (1) ) {
				if (rect.Contains (Event.current.mousePosition)) {
					data.effectDataColor.hdr = !data.effectDataColor.hdr;
				}
			}
			_data.color = EditorGUILayout.ColorField (new GUIContent(""), _data.color, true, true, _data.hdr, null, GUILayout.Width (128 - labelWith));
			GUILayout.EndHorizontal ();
		
			GUILayout.Space (2);
			GUILayout.BeginHorizontal ();
			GUILayout.Label ("Op", SWEditorUI.Style_Get (SWCustomStyle.eTxtSmallLight), GUILayout.Width(labelWith));
			_data.op = (SWOutputOP)EditorGUILayout.EnumPopup (_data.op,GUILayout.Width(128 - labelWith));
			GUILayout.EndHorizontal ();
			GUILayout.Space (2);
			SWWindowMain.Instance.Factor_Pick (ref _data.param,PickParamType.node,"Factor",null,128);

			GUILayout.Space (2);
			GUILayout.BeginHorizontal ();
			GUILayout.Label ("Depth",  SWEditorUI.Style_Get (SWCustomStyle.eTxtSmallLight), GUILayout.Width(labelWith));
			var dep = EditorGUILayout.IntField (data.depth,GUILayout.Width(128-labelWith));
			if (dep != 0 && dep!= data.depth) {
				SWUndo.Record (this);
				data.depth = dep;
			}
			GUILayout.EndHorizontal ();

			GUILayout.EndVertical ();
			GUILayout.EndHorizontal ();
			DrawNodeWindowEnd ();
		}
	}
}