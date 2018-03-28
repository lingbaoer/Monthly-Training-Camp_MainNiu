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
	public class SWWindowEffectImage : SWWindowEffect {
		public static SWWindowEffectImage Instance;

		public  static void ShowEditor(SWNodeEffector e) { 
			if (Instance != null)
				Instance.Close ();
			var window =EditorWindow.GetWindow<SWWindowEffectImage> (true,"Color");
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
			DrawModuleTitle ("Image");
			Tooltip_Rec (SWTipsText.Right_ImageModule,new Rect(rightUpRect.x,GUILayoutUtility.GetLastRect ().y,rightUpRect.width,GUILayoutUtility.GetLastRect ().height));

			EffectDataColor _data = data.effectDataColor;
			UI_Color("Color",ref _data.color,ref _data.hdr,delegate(SWBaseInfo arg1, bool arg2) {
				SWUndo.Record(info.effector);
			},true,true);
			Tooltip_Rec (SWTipsText.Right_Color,new Rect(rightUpRect.x,GUILayoutUtility.GetLastRect ().y,rightUpRect.width,GUILayoutUtility.GetLastRect ().height));


			GUILayout.BeginHorizontal ();
			var temp = (SWOutputOP)UI_PopEnum ("Blend Op", _data.op,true);
			if (_data.op != temp) {
				SWUndo.Record(info.effector);
				_data.op = temp;
			}
			GUILayout.EndHorizontal ();
			Tooltip_Rec (SWTipsText.Right_BlendOp,new Rect(rightUpRect.x,GUILayoutUtility.GetLastRect ().y,rightUpRect.width,GUILayoutUtility.GetLastRect ().height));

			Tooltip_Rec (SWTipsText.Right_BlendFactor,new Rect(rightUpRect.x,GUILayoutUtility.GetLastRect ().yMax,rightUpRect.width,GUILayoutUtility.GetLastRect ().height));
			Factor_Pick (ref _data.param,true,"Blend Factor");
		}

		protected override Texture2D BottomTexture ()
		{
			if (!info.effector.HasParent ())
				return null;
			if (info.effector.GetParentNode () is SWNodeRemap) {
				return SWWindowMain.Instance.nRoot.texture;
			}
			return info.effector.GetParentTexture ();
		} 
	}
}
