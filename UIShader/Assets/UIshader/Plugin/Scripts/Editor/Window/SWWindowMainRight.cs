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

	public partial class SWWindowMain:SWWindowLayoutV{
		protected float leftWidth = 90;
		public override void DrawRight ()
		{
			base.DrawRight ();
			GUILayout.BeginHorizontal ();
			GUILayout.Space (position.width-rightupWidth-al_scrollBarWidth*1.8f + SWGlobalSettings.UIGap);
			GUILayout.BeginVertical ();


			if (!showRight) {
				Rect rect = new Rect (position.width - 50 - al_scrollBarWidth * 1f, position.height - 50 - al_scrollBarWidth, 50, 50);
				GUI.DrawTexture(rect,SWEditorUI.Texture(SWUITex.effectRight1));
				if (rect.Contains (Event.current.mousePosition)
					&& Event.current.type == EventType.MouseDown)
					showRight = true;
			} else {
				Rect rect = new Rect (position.width - rightupWidth - 50 - al_scrollBarWidth * 1.8f, position.height - 50 - al_scrollBarWidth, 50, 50);
				GUI.DrawTexture(rect,SWEditorUI.Texture(SWUITex.effectRight2));
				if (rect.Contains (Event.current.mousePosition)
					&& Event.current.type == EventType.MouseDown)
					showRight = false;

				DrawRightUp ();
			}
			GUILayout.EndVertical ();
		}
		void DrawRightUp()
		{
			DrawBG (rightUpRect);
			GUILayout.Space (position.height * 0.3f);

			GUILayout.Space (5);
			GUILayout.BeginHorizontal ();
			GUILayout.Space (5);
			DrawModuleTitle ("Settings");
			Tooltip_Rec (SWTipsText.Settings_Module);

			GUILayout.EndHorizontal ();
			GUILayout.Space (10);

			GUILayout.BeginHorizontal (GUILayout.Width(170));
			newName = EditorGUILayout.TextField (newName,GUILayout.Width(96));
			if (GUILayout.Button ("Rename"))
				PressRename ();
			GUILayout.EndHorizontal ();

			GUILayout.Space (10);
		


			string[] strs = { "Default", "Sprite", "UI", "Text" };

			GUILayout.BeginHorizontal ();
			GUILayout.Label ("Shader Type:",SWEditorUI.Style_Get(SWCustomStyle.eTxtSmallLight),GUILayout.Width(leftWidth));
			var tmpType = (SWShaderType)EditorGUILayout.Popup((int)SWWindowMain.Instance.data.shaderType,strs,GUILayout.Width(rightupWidth-10-leftWidth));
			if (SWWindowMain.Instance.data.shaderType != tmpType) {
				SWUndo.Record (SWWindowMain.Instance);
				SWWindowMain.Instance.data.shaderType = tmpType; 
				if (tmpType == SWShaderType.normal)
					nRoot.texture = nRoot.texForNormal;
				else 
					nRoot.texture = nRoot.texForSprite;
			}
			GUILayout.EndHorizontal ();
			SWTooltip.Rec (SWTipsText.Settings_Type);

			ChooseSpriteLightType ();
			ChooseShaderModel ();


			GUILayout.BeginHorizontal ();
			GUILayout.Label ("Exclude Root:",SWEditorUI.Style_Get(SWCustomStyle.eTxtSmallLight),GUILayout.Width(leftWidth));
			var tmp0 = EditorGUILayout.Toggle(SWWindowMain.Instance.data.excludeRoot,GUILayout.Width(rightupWidth-10-leftWidth));
			if (SWWindowMain.Instance.data.excludeRoot != tmp0) {
				SWUndo.Record (SWWindowMain.Instance);
				SWWindowMain.Instance.data.excludeRoot = tmp0; 
			}
			GUILayout.EndHorizontal ();
			SWTooltip.Rec (SWTipsText.Settings_ExcludeRoot);


			GUILayout.BeginHorizontal ();
			GUILayout.Label ("Blend Mode:",SWEditorUI.Style_Get(SWCustomStyle.eTxtSmallLight),GUILayout.Width(leftWidth));
			var tmpType2 = (SWShaderBlend)EditorGUILayout.EnumPopup(SWWindowMain.Instance.data.shaderBlend,GUILayout.Width(rightupWidth-10-leftWidth));
			if (SWWindowMain.Instance.data.shaderBlend != tmpType2) {
				SWUndo.Record (SWWindowMain.Instance);
				SWWindowMain.Instance.data.shaderBlend = tmpType2; 
			}
			GUILayout.EndHorizontal ();
			SWTooltip.Rec (SWTipsText.Settings_Blend);


			GUILayout.BeginHorizontal ();
			GUILayout.Label ("Render Order:",SWEditorUI.Style_Get(SWCustomStyle.eTxtSmallLight),GUILayout.Width(leftWidth));
			var tmpType3 = (SWShaderQueue)EditorGUILayout.EnumPopup(SWWindowMain.Instance.data.shaderQueue,GUILayout.Width(170-leftWidth));
			if (SWWindowMain.Instance.data.shaderQueue != tmpType3) {
				SWUndo.Record (SWWindowMain.Instance);
				SWWindowMain.Instance.data.shaderQueue = tmpType3; 
			}
			GUILayout.Label ("+",SWEditorUI.Style_Get(SWCustomStyle.eTxtSmallLight),GUILayout.Width(14));
			var tmp4 = EditorGUILayout.IntField (SWWindowMain.Instance.data.shaderQueueOffset,GUILayout.Width(30));
			if (tmp4 != SWWindowMain.Instance.data.shaderQueueOffset) {
				SWUndo.Record (SWWindowMain.Instance);
				SWWindowMain.Instance.data.shaderQueueOffset = tmp4;
			}
			GUILayout.Label ("= "+
				((int)SWWindowMain.Instance.data.shaderQueue+SWWindowMain.Instance.data.shaderQueueOffset),SWEditorUI.Style_Get(SWCustomStyle.eTxtSmallLight),GUILayout.Width(60));
			GUILayout.EndHorizontal ();
			SWTooltip.Rec (SWTipsText.Settings_Queue);


			GUILayout.BeginHorizontal ();
			GUILayout.Label ("Alpha Clip:",SWEditorUI.Style_Get(SWCustomStyle.eTxtSmallLight),GUILayout.Width(leftWidth));
			var tmp5 = EditorGUILayout.FloatField(SWWindowMain.Instance.data.clipValue,GUILayout.Width(rightupWidth-10-leftWidth));
			if (SWWindowMain.Instance.data.clipValue != tmp5) {
				SWUndo.Record (SWWindowMain.Instance);
				SWWindowMain.Instance.data.clipValue = tmp5; 
			}
			GUILayout.EndHorizontal ();
			SWTooltip.Rec (SWTipsText.Settings_Clip);

			GUILayout.BeginHorizontal ();
			GUILayout.Label ("Fallback:",SWEditorUI.Style_Get(SWCustomStyle.eTxtSmallLight),GUILayout.Width(leftWidth));
			var fallbackPress = GUILayout.Button(data.fallback,GUILayout.Width(rightupWidth-10-leftWidth));
			var xtype = Event.current.type;
			var xrect = GUILayoutUtility.GetLastRect ();
			if (xtype == EventType.Repaint) {
				fallbackRect = new Rect(xrect.x,xrect.y,xrect.width,xrect.height);
			}
			if (fallbackPress) {
				DisplayShaderContext(fallbackRect);
			}
			GUILayout.EndHorizontal ();
			SWTooltip.Rec (SWTipsText.Settings_Fallback);

			GUI.color = Color.gray;
			GUILayout.Label ("________________________",SWEditorUI.Style_Get(SWCustomStyle.eTxtSmallLight));
			GUI.color = Color.white;

			GUILayout.Label ("Preview Mouse Over Size",SWEditorUI.Style_Get(SWCustomStyle.eTxtSmallLight));
			viewWindow.scale = EditorGUILayout.Slider (viewWindow.scale, 1, 5,GUILayout.Width(170));

		
			GUILayout.Space (10);
			GUI.color = Color.gray;
			GUILayout.Label ("________________________",SWEditorUI.Style_Get(SWCustomStyle.eTxtSmallLight));
			GUI.color = Color.white;

			Factor_CustomParamCreation ();
		}

		void ChooseSpriteLightType()
		{
			if (SWWindowMain.Instance.data.shaderType == SWShaderType.sprite) {
				string[] strs = { "No", "Diffuse" };

				GUILayout.BeginHorizontal ();
				GUILayout.Label ("Sprite Light:",SWEditorUI.Style_Get(SWCustomStyle.eTxtSmallLight),GUILayout.Width(leftWidth));
				var tmpType = (SWSpriteLightType)EditorGUILayout.Popup((int)SWWindowMain.Instance.data.spriteLightType,strs,GUILayout.Width(rightupWidth-10-leftWidth));
				if (SWWindowMain.Instance.data.spriteLightType != tmpType) {
					SWUndo.Record (SWWindowMain.Instance);
					SWWindowMain.Instance.data.spriteLightType = tmpType; 
				}
				GUILayout.EndHorizontal ();
				SWTooltip.Rec (SWTipsText.Settings_SpriteLight);
			}
		}

		void ChooseShaderModel()
		{
			string[] strs = { "auto","1.0", "2.0","3.0","4.0","5.0" };

			GUILayout.BeginHorizontal ();
			GUILayout.Label ("Shader Model:",SWEditorUI.Style_Get(SWCustomStyle.eTxtSmallLight),GUILayout.Width(leftWidth));
			var tmpType = (SWShaderModel)EditorGUILayout.Popup((int)SWWindowMain.Instance.data.shaderModel,strs,GUILayout.Width(rightupWidth-10-leftWidth));
			if (SWWindowMain.Instance.data.shaderModel != tmpType) {
				SWUndo.Record (SWWindowMain.Instance);
				SWWindowMain.Instance.data.shaderModel = tmpType; 
			}
			GUILayout.EndHorizontal ();
			SWTooltip.Rec (SWTipsText.Settings_ShaderModel);
		}

		#region fallback
		Rect fallbackRect;  
		MenuCommand mc;
		private void DisplayShaderContext(Rect r) {
			try{
				if( mc == null )
				{
					mc = new MenuCommand( this, 0 );
					Shader shader = Shader.Find("Standard");
					Material temp = new Material(shader); 
					UnityEditorInternal.InternalEditorUtility.SetupShaderMenu( temp );
				}
				EditorUtility.DisplayPopupMenu( r, "CONTEXT/ShaderPopup", mc );
			}
			catch(System.Exception e) {
				Debug.Log (e.ToString ());
			}
		}
		private void OnSelectedShaderPopup( string command, Shader shader ) {
			if( shader != null ) {
				data.fallback = shader.name;
				//Debug.Log("Clicked shader: " + shader.name);
			}
		}
		#endregion
	}
}
	