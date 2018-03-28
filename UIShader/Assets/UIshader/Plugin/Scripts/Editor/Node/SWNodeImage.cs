//----------------------------------------------
//            Shader Weaver
//      Copyright© 2017 Jackie Lo
//----------------------------------------------
namespace ShaderWeaver
{
	using UnityEngine;
	using System.Collections;
	using UnityEditor;

	[System.Serializable]
	public class SWNodeImage :SWNodeEffector {
		public override void Init (SWDataNode _data, SWWindowMain _window)
		{
			styleID = 0;
			base.Init (_data, _window);
			data.outputType.Add (SWDataType._Color);
			data.inputType.Add (SWDataType._UV);
			data.inputType.Add (SWDataType._Alpha);

			//Color node can be child node of color node
			data.inputType.Add (SWDataType._Color);
		}

		public override void InitLayout()
		{
			rectTop = new Rect (0, 1, NodeWidth, headerHeight+2);
			rectBotButton = new Rect (gap, NodeHeight - gap - buttonHeight, contentWidth, buttonHeight);
			rectArea = new Rect (gap, headerHeight + gap, contentWidth, 
				NodeHeight - headerHeight - gap*2 - (rectBotButton.height+gap)*1.8f);
		}

		protected override void DrawNodeWindow (int id)
		{
			base.DrawNodeWindow (id);
			SelectTexture ();


			Rect rL = new Rect (gap, NodeHeight - 1.84f*(gap + buttonHeight), contentWidth*0.5f, buttonHeight);
			Rect rR = new Rect (gap+contentWidth*0.5f, NodeHeight - 1.84f*(gap + buttonHeight), contentWidth*0.5f, 0.8f*buttonHeight);
			GUI.Label (rL,"Depth",SWEditorUI.Style_Get(SWCustomStyle.eTxtSmallLight));
			var dep = EditorGUI.IntField (rR,"", data.depth);
			if (dep != 0 && dep!= data.depth) {
				SWUndo.Record (this);
				data.depth = dep;
			}

			if (texture != null) {
				if (GUI.Button (rectBotButton,"Edit",SWEditorUI.MainSkin.button)) {
					SWWindowEffectImage.ShowEditor (this);
				}
			}
			DrawNodeWindowEnd ();
		}
	}
}