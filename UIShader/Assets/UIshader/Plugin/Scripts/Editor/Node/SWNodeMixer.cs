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
	public class SWNodeMixer :SWNodeEffector {
		public override void Init (SWDataNode _data, SWWindowMain _window)
		{
			styleID = 1;
			base.Init (_data, _window);
			data.outputType.Add (SWDataType._Color);
			data.outputType.Add (SWDataType._UV);
			data.outputType.Add (SWDataType._Alpha);
			data.inputType.Add (SWDataType._Color);
			data.inputType.Add (SWDataType._UV);
			data.inputType.Add (SWDataType._Alpha);
			UpdatePort ();
		}
		protected override void DrawNodeWindow (int id)
		{
			base.DrawNodeWindow (id);
			SelectTexture ();

			float labelWidth = 60;
			GUI.Label (new Rect (rectBotButton.x, rectBotButton.y-rectBotButton.height, labelWidth, rectBotButton.height), "Port Num", SWEditorUI.Style_Get (SWCustomStyle.eTxtSmallLight));
			var portNum = EditorGUI.IntField (new Rect (rectBotButton.x+labelWidth,  rectBotButton.y-rectBotButton.height, rectBotButton.width-labelWidth, rectBotButton.height),data.childPortNumber);
			portNum = Mathf.Clamp (portNum, 1, 5);
			data.childPortNumber = portNum;





			if (texture != null) {
				if (GUI.Button (rectBotButton,"Edit",SWEditorUI.MainSkin.button)) {
					SWWindowEffectMixer.ShowEditor (this);
				}
			}
			DrawNodeWindowEnd ();
		}

		public override void InitLayout ()
		{
			base.InitLayout ();
			rectArea = new Rect (gap, headerHeight + gap, contentWidth, 
				nodeHeight - headerHeight - gap*2 - (rectBotButton.height+gap) - 20);
		}


		protected override void DrawLeftRect (int id, Rect rect)
		{
			UpdatePort ();
			rect = new Rect (rect.x, rect.y,rect.width, rect.height);
			SWEditorTools.DrawTiledTexture (rect, SWEditorTools.backdropTexture);
			GUI.DrawTexture (rect,data.gradients[id].Tex);



			if(SWCommon.GetMouseUp(1) && rect.Contains(Event.current.mousePosition))
				SWWindowMixerEditor.Show (data.gradients [id]);
		}

		public void UpdatePort()
		{
			if (data.childPortNumber < data.gradients.Count) {
				for (int i = data.gradients.Count-1; i>=0; i--) {
					if (i >= data.childPortNumber) {
						data.gradients.RemoveAt (i);
					}
				}
			}
			if (data.childPortNumber > data.gradients.Count) {
				while (data.gradients.Count < data.childPortNumber)
					data.gradients.Add (new SWGradient ());
			}

			for (int i = data.children.Count-1; i>=0; i--) {
				if (data.childrenPort [i] >= data.childPortNumber) {
					string child = data.children [i];
					RemoveConnection(this,SWWindowMain.Instance.NodeAll()[child]);
				}
			}
		}


		public static int Gradient_MaxFrameCount()
		{
			int maxCount = 0;
			foreach (var node in SWWindowMain.Instance.nodes) {
				if (node.data.type == SWNodeType.mixer) {
					foreach (var gradient in node.data.gradients) {
						if (gradient.frames.Count > maxCount)
							maxCount = gradient.frames.Count;
					}
				}
			}
			return maxCount;
		}
	}
}