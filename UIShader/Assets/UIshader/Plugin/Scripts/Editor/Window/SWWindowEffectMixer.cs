//----------------------------------------------
//            Shader Weaver
//      Copyright© 2017 Jackie Lo
//----------------------------------------------
namespace ShaderWeaver
{
	using UnityEngine;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEditor;

	[System.Serializable]
	public class SWWindowEffectMixer : SWWindowEffect {
		public static SWWindowEffectMixer Instance;
		public  static void ShowEditor(SWNodeEffector e) {  
			if (Instance != null)
				Instance.Close ();
			var window = EditorWindow.GetWindow<SWWindowEffectMixer> (true,"Mixer");
			window.Init (e);
			window.InitOnce ();
		} 

		public override void Update ()
		{
			Instance = this;
			base.Update ();
		}

		protected override void DrawExtra ()
		{
			base.DrawExtra ();
			DrawModuleTitle ("Mixer");
			Tooltip_Rec (SWTipsText.Right_MixerModule,new Rect(rightUpRect.x,GUILayoutUtility.GetLastRect ().y,rightUpRect.width,GUILayoutUtility.GetLastRect ().height));


			GUILayout.BeginHorizontal ();
			float wid = SWGlobalSettings.LabelWidthLong + SWGlobalSettings.FieldWidth - 8;
			wid *= 0.25f;
			GUILayout.Label ("Min",SWEditorUI.Style_Get(SWCustomStyle.eTxtSmallLight),GUILayout.Width(wid));
			data.effectData.pop_min = EditorGUILayout.FloatField(data.effectData.pop_min,GUILayout.Width(wid));
			GUILayout.Label ("Max",SWEditorUI.Style_Get(SWCustomStyle.eTxtSmallLight),GUILayout.Width(wid));
			data.effectData.pop_max = EditorGUILayout.FloatField(data.effectData.pop_max,GUILayout.Width(wid));
			GUILayout.EndHorizontal ();
			Tooltip_Rec (SWTipsText.Right_MixerMinMax,new Rect(rightUpRect.x,GUILayoutUtility.GetLastRect ().y,rightUpRect.width,GUILayoutUtility.GetLastRect ().height));


			GUILayout.BeginHorizontal ();
			GUILayout.Label ("Channel",SWEditorUI.Style_Get(SWCustomStyle.eTxtSmallLight),GUILayout.Width(SWGlobalSettings.LabelWidthLong));
			data.effectData.pop_channel = (SWChannel)EditorGUILayout.EnumPopup (
				"",data.effectData.pop_channel,GUILayout.Width(SWGlobalSettings.FieldWidth));
			GUILayout.EndHorizontal ();
			Tooltip_Rec (SWTipsText.Right_MixerChannel,new Rect(rightUpRect.x,GUILayoutUtility.GetLastRect ().y,rightUpRect.width,GUILayoutUtility.GetLastRect ().height));


			UI_Float ("Start", ref data.effectData.pop_startValue,null,false,false,true);
			Tooltip_Rec (SWTipsText.Right_MixerStart,new Rect(rightUpRect.x,GUILayoutUtility.GetLastRect ().y,rightUpRect.width,GUILayoutUtility.GetLastRect ().height));


			UI_Float ("Spd", ref data.effectData.pop_speed,null,false,false,true);
			Tooltip_Rec (SWTipsText.Right_MixerSpeed,new Rect(rightUpRect.x,GUILayoutUtility.GetLastRect ().y,rightUpRect.width,GUILayoutUtility.GetLastRect ().height));

			Tooltip_Rec (SWTipsText.Right_MixerSpeedFactor,new Rect(rightUpRect.x,GUILayoutUtility.GetLastRect ().yMax,rightUpRect.width,GUILayoutUtility.GetLastRect ().height));
			Factor_Pick(ref data.effectData.pop_Param,true,"Spd Factor");
		}

		protected override Texture2D BottomTexture ()
		{
			if (!info.effector.HasParent ())
				return null;
			return info.effector.GetParentTexture ();
		} 

		public override void OnGUITop ()
		{
			base.OnGUITop ();
			TexShowChnEnum ();
		}
	}
}
