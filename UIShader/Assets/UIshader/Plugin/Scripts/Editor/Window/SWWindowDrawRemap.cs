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
	public class RemapWayPoint
	{
		public Vector2 mousePos;
		public float pcg;


		public Vector2 uv;

		public Vector2 pre;
		public Vector2 after;
		public float prePcg;
		public float afterPcg;


		public Vector2 center;

		public Material matArrow;
	}
	[System.Serializable]
	public class RemapLineInfo:ScriptableObject
	{
		public bool stitch;
		public List<RemapWayPoint> pts = new List<RemapWayPoint>();
	}
	[System.Serializable]
	public enum DrawRemapMode
	{
		dir=0, 
		line
	}

	[System.Serializable]  
	public class SWWindowDrawRemap : SWWindowLayoutV {
		public static int size = 512;
		[SerializeField]
		public DrawRemapMode mode;
		public float brushSizeUV
		{
			get{ return (float)brushSize / (float)node.textureEx.width;}
		}
		[SerializeField]
		public int brushSize = 30;
		[SerializeField]
		Vector2 _remap;
		Vector2 remap
		{
			get{ 
				return _remap; 
			}
			set{ 
				_remap = value;
				node.data.remap = value;
			}  
		}
		[SerializeField]
		Rect drawRect;
		[SerializeField]
		SWNodeRemap node;
		[SerializeField]
		Rect windowRect;
		[SerializeField]
		RemapLineInfo info;
		protected static float boxSize = 20;
		[SerializeField]
		public Vector2 ArrowOff;
		[SerializeField]
		bool precise;
		[SerializeField]
		int pixelBack;
		Vector2 lastMousePos;
		bool dragging = false;

		public static SWWindowDrawRemap Instance;

		public static void ShowEditor(SWNodeRemap _node) {
			if (Instance != null)
				Instance.Close ();
			var window =EditorWindow.GetWindow<SWWindowDrawRemap> (true,"Remap");
			window.Init (_node);
			window.InitOnce ();
		}

		#region SerializedProperty
		protected override void SerializedInit ()
		{
			base.SerializedInit ();
			if(slotBox_left!=null)
				slotBox_left.Init (OnSelect);
		}
		#endregion




		public override void OnAfterDeserialize ()
		{
			base.OnAfterDeserialize ();
		}

		public override void Update ()
		{
			Instance = this;
			if (!CanUpdate ())  
				return;
			base.Update ();

			//[Main window close]    or    [related node deleted] ===>  close this window
			if (SWWindowMain.Instance == null || !SWWindowMain.Instance.NodeAll().ContainsKey(node.data.id)) {
				Close ();  
				return;
			}
			SWWindowMain.Instance.NodeAll() [node.data.id] = (SWNodeBase)node;
		}

		public void Init(SWNodeRemap _node)
		{
			node = _node;
			info = ScriptableObject.CreateInstance<RemapLineInfo>();
		}

		public override void InitOnce ()
		{
			base.InitOnce ();
			drawRect = new Rect(0,0,size,size);
		}
		public override void InitUI () 
		{
			base.InitUI ();
			mapTL = new Vector2 (-mapFloatSmall+xHalf, -mapFloatSmall+yHalf);
			mapBR = new Vector2 (mapFloatSmall+xHalf, mapFloatSmall+yHalf);
			mapSize = mapBR - mapTL;

			List<SWSlot> slotsNodebox = new List<SWSlot> ();
			slotsNodebox.Add(new SWSlot("Drag",SWTipsText.Remap_t_Drag,null,KeyCode.D));
			slotsNodebox.Add(new SWSlot("Line",SWTipsText.Remap_t_Line,null,KeyCode.L));
			slotBox_left = ScriptableObject.CreateInstance<SWSlotBox_Select> ();
			slotBox_left.InitSlot(this,new Rect(0,al_slotStartY+al_topHeight+al_spacing,al_leftWidth,position.height-al_spacing-al_topHeight),slotsNodebox,OnSelect,new Vector2(al_leftWidth,al_leftWidth*0.6f));
		}

		void OnSelect(SWSlot slot,Vector2 mp)
		{
			mode = (DrawRemapMode)slotBox_left.selection; 
		}

		public override void Clean ()
		{
			base.Clean ();
		}


		public override void DrawTop ()
		{
			Rect llRect = new Rect (0, 0, 0, 0);
			base.DrawTop ();
			if ( (DrawRemapMode)slotBox_left.selection == DrawRemapMode.dir) {
				var tmp = SWEditorUI.Vector2Field ("Drag:", remap);
				if (tmp != remap) {
					SWUndo.Record (this);
					remap = tmp;
				}
				Tooltip_Rec (SWTipsText.Remap_Drag,TopElementRect(0,190));

				GUILayout.Space (al_spacingBig);
				GUILayout.Label ("Deviation:", SWEditorUI.Style_Get (SWCustomStyle.eTxtSmallLight));
				llRect = GUILayoutUtility.GetLastRect ();
				var tmpPixelBack = EditorGUILayout.IntSlider("",pixelBack,-20,20,
					GUILayout.Width(SWGlobalSettings.SliderWidth) );
				if(tmpPixelBack!= pixelBack)
				{
					SWUndo.Record (this);
					pixelBack = tmpPixelBack;
				}
				Tooltip_Rec (SWTipsText.Remap_Deviation,-llRect.width-10,0);


				GUILayout.Space (al_spacingBig);
				GUILayout.Label ("Precise:",
					SWEditorUI.Style_Get (SWCustomStyle.eTxtSmallLight));
				Tooltip_Rec (SWTipsText.Remap_Precise,0,25);
				var p = GUILayout.Toggle(precise,"");
				if (p != precise) {
					SWUndo.Record (info);
					precise = p;
				}
			} else {
				GUILayout.Label ("Size:", SWEditorUI.Style_Get (SWCustomStyle.eTxtSmallLight));
				llRect = GUILayoutUtility.GetLastRect ();
				var tmpBrushSize = EditorGUILayout.IntSlider("",brushSize,1,60,
					GUILayout.Width(SWGlobalSettings.SliderWidth) );
				if(tmpBrushSize!= brushSize)
				{
					SWUndo.Record (this);
					brushSize = tmpBrushSize;
				}
				Tooltip_Rec (SWTipsText.Remap_Size,-llRect.width-10,0);

				GUILayout.Space (al_spacingBig);
				GUILayout.Label ("Stitch:",
					SWEditorUI.Style_Get (SWCustomStyle.eTxtSmallLight));
				Tooltip_Rec (SWTipsText.Remap_Stitch,0,25);
				var stitch = GUILayout.Toggle(info.stitch,"");
				if (stitch != info.stitch) {
					SWUndo.Record (info);
					info.stitch = stitch;
				}
			}
		}

		public override void SetInsideRects ()
		{
			base.SetInsideRects ();
			drawRect = SetInsideRect (drawRect);

			for (int i = 0; i < info.pts.Count; i++) {
				info.pts [i].mousePos = SetInsidePos (info.pts [i].mousePos);
			}
		}
		public override void DrawMainInside1 ()
		{
			base.DrawMainInside1 ();
			Draw ();
		}
		public override void DrawMainBot ()
		{
			base.DrawMainBot ();
			SWEditorTools.DrawTiledTexture(al_rectMain, SWEditorTools.backdropTexture);
		}



		void Draw()
		{
			GUI.DrawTexture (drawRect,node.texChildResized.Texture,ScaleMode.StretchToFill);
			GUI.DrawTexture (drawRect,node.textureEx.Texture,ScaleMode.StretchToFill);
			if ( (DrawRemapMode)slotBox_left.selection == DrawRemapMode.dir)
				DrawDir ();
			else
				DrawLine ();

			DrawFrame (drawRect);
		}

		void DrawDir()
		{
			Cursor.visible = true;

			var rect = SWCommon.GetRect (drawRect.center + ArrowOff,new Vector2(boxSize,boxSize));
			Set_Material (matBase,Vector2.zero,0,Vector2.one);
			matBase.SetColor ("_Color", dragging ? Color.green:Color.white);
			Graphics.DrawTexture(SWCommon.GetRect (drawRect.center,new Vector2(8,8)),
				SWEditorUI.Texture(SWUITex.effectCenter),matBase);

			matBase.SetFloat ("r", -SWCommon.Vector2Angle(ArrowOff));
			Graphics.DrawTexture(rect,SWEditorUI.Texture(SWUITex.effectArrow),matBase);


			matBase.SetFloat ("r", 0f);
			matBase.SetTexture ("_MainTex", SWEditorUI.Texture (SWUITex.effectLine));
			SWDraw.DrawLine (drawRect.center, rect.center, Color.white,3f,matBase);

			float factor = 1f / drawRect.size.x; 
			if (SWCommon.GetMouseDown (0) && al_rectMain.Contains(mousePosOut+new Vector2(0,al_startY))) {
				if (rect.Contains (Event.current.mousePosition)) {
					dragging = true;
					lastMousePos = Event.current.mousePosition;
				} else
					dragging = false;
			} else if (dragging) {
				if (SWCommon.GetMouse (0)) {
					ArrowOff += Event.current.mousePosition - lastMousePos;

					if (Event.current.shift) {
						if (Mathf.Abs(ArrowOff.x) > Mathf.Abs(ArrowOff.y))
							ArrowOff = new Vector2 (ArrowOff.x, 0);
						else
							ArrowOff = new Vector2 (0,ArrowOff.y);
					}

					lastMousePos = Event.current.mousePosition;
					SWUndo.Record (this);
					remap = new Vector2 (ArrowOff.x * factor, -ArrowOff.y * factor);
				} 
				if (SWCommon.GetMouseUp (0)) {
					dragging = false;
					SWUndo.Record (this);
					remap = new Vector2 (ArrowOff.x * factor, -ArrowOff.y * factor);
				}
			} else {
				ArrowOff = new Vector2(remap.x / factor,-remap.y / factor);
			}



			if (Event.current.type == EventType.keyDown) {
				if (Event.current.keyCode == KeyCode.Return) {
					node.data.dirty = true;
					SWTextureProcess.ProcessRemap_Dir (node.textureEx,node.texChildResized, new Vector2(remap.x,-remap.y),precise,pixelBack);
				}
			}
		}
		void DrawLine()
		{
			//Add Point
			if (SWCommon.GetMouseDown (0) && al_rectMain.Contains(mousePosOut+new Vector2(0,al_startY))) {
				if (!al_rectMain.Contains(mousePosOut + new Vector2(0,al_startY)))
					return;
				if (!drawRect.Contains (mousePos)) {
					return;
				}

				SWUndo.Record (info);
				Vector2 m = Event.current.mousePosition;
				m = m - drawRect.position;
				m = SWTextureProcess.TexUV (size, size, (int)m.x, (int)m.y);

				RemapWayPoint pt = new RemapWayPoint ();
				pt.uv = m;
				pt.mousePos = mousePos;
				pt.matArrow = new Material (SWEditorUI.GetShader ("RectTRS"));
				info.pts.Add (pt);
			}

			DrawPoints ();

			//Draw Cursor
			if (focusedWindow == this) {
				if (al_rectMain.Contains(mousePosOut + new Vector2(0,al_startY)) && drawRect.Contains (mousePos)) {
					GUI.DrawTexture (new Rect (mousePos.x - brushSize * 1f, mousePos.y - brushSize * 1f, brushSize * 2f, brushSize * 2f), SWEditorUI.Texture (SWUITex.cursor));
					GUI.DrawTexture (new Rect (mousePos.x - 8, mousePos.y - 8, 16, 16), SWEditorUI.Texture (SWUITex.cursorCenter));
					Cursor.visible = false;
				} else {
					Cursor.visible = true;
				}
			}
			//Key Command
			if (Event.current.type == EventType.keyDown) {
				if (Event.current.keyCode == KeyCode.Return) {
					node.data.dirty = true;
					SWTextureProcess.ProcessRemap_Line (node.textureEx, info, brushSizeUV);
				}
			}
		}

		void DrawPoints()
		{
			for (int i = 0; i < info.pts.Count; i++) {
				if (i < info.pts.Count - 1 || info.stitch) {
					Vector2 v1 = info.pts [i].mousePos;
					Vector2 v2 = info.pts [(i + 1) % info.pts.Count].mousePos;

					Vector2 dir = (v2 - v1);
					float dis = dir.magnitude;
					dir.Normalize ();
					float angle = SWCommon.Vector2Angle (v2 - v1);


					Set_Material (info.pts [i].matArrow, Vector2.zero, -angle, Vector2.one);


					var item = new Material (SWEditorUI.GetShader ("Rect"));
					Set_Material (item);

					Vector2 mid = (v2 + v1)*0.5f;
					Graphics.DrawTexture (SWCommon.GetRect (mid, new Vector2(20f,20f)), SWEditorUI.Texture (SWUITex.effectArrow),info.pts [i].matArrow);
					SWDraw.DrawLine (v1, v2 , Color.white, 1, item);
				}
				GUI.DrawTexture (new Rect (info.pts [i].mousePos.x - brushSize * 1f, info.pts [i].mousePos.y - brushSize * 1f, brushSize * 2f, brushSize * 2f), 
					SWEditorUI.Texture(SWUITex.cursor));
			}
		}

		public override void KeyCmd_HotkeyDown (KeyCode code)
		{
			base.KeyCmd_HotkeyDown (code);
			if (mode == DrawRemapMode.dir) {
				if (code == KeyCode.LeftBracket) {
					SWUndo.Record (this);
					pixelBack += -1;
				}
				if (code == KeyCode.RightBracket) {
					SWUndo.Record (this);
					pixelBack += 1;
				}
			} else {
				if (code == KeyCode.LeftBracket) {
					SWUndo.Record (this);
					brushSize += -1;
				}
				if (code == KeyCode.RightBracket) {
					SWUndo.Record (this);
					brushSize += 1;
				}
			}
		}

		public override void KeyCmd_Dragmove (Vector2 delta)
		{
			//		Debug.Log (delta);
			base.KeyCmd_Dragmove (delta);
			drawRect.position += new Vector2 (1f * delta.x, 1f * delta.y);

			for (int i = 0; i < info.pts.Count; i++) {
				info.pts[i].mousePos += new Vector2 (1f * delta.x, 1f * delta.y);
			}
		}

		public override void KeyCmd_Delete ()
		{
			base.KeyCmd_Delete ();
			SWUndo.Record (info);
			if (node.textureEx == null) {
				node.textureEx = SWCommon.TextureCreate (512, 512, TextureFormat.ARGB32); 
			} else {
				SWTextureProcess.ProcessTexture_Clean (node.textureEx);
			}
			info.pts.Clear ();
		}
	}
}