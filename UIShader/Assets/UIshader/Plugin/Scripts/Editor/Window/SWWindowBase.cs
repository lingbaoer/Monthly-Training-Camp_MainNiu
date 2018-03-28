//----------------------------------------------
//            Shader Weaver
//      Copyright© 2017 Jackie Lo
//----------------------------------------------
namespace ShaderWeaver
{
	using UnityEngine;
	using System.Collections;
	using UnityEditor;


	/// <summary>
	/// All sw editor windows' base class
	/// </summary>
	[System.Serializable]
	public class SWWindowBase:EditorWindow,ISerializationCallbackReceiver{
		[SerializeField]
		public static GUISkin skinDefault;
		[SerializeField]
		public string folderPath; 
		[SerializeField]
		public string dataPath;  
		[SerializeField]
		protected bool needInit = false;

		[SerializeField]
		public Vector2 mousePos;
		[SerializeField]
		public Vector2 mousePosDown;
		[SerializeField]
		public Vector2 mousePosLast;
		[SerializeField]
		public Vector2 mousePosOut;
		[SerializeField]
		public Vector2 mousePosOutLast;
		[SerializeField]
		public bool mousePressing;

		#region SerializedProperty
		public SerializedObject so;
		protected virtual void SerializedInit()
		{
			so = new SerializedObject (this);
		}
		#endregion



		#region Init & Serialization
		public virtual void Awake()
		{
			SerializedInit ();
		}

		public virtual void OnBeforeSerialize()  
		{
	//		Debug.Log ("OnBeforeSerialize");   
		} 
		 
		public virtual void OnAfterDeserialize()
		{
	//		Debug.Log ("OnAfterDeserialize"); 
	//		SerializedInit ();
		}

		public bool CanUpdate()
		{
			return (!needInit);
		}

		/// <summary>
		/// Reals the init.
		/// </summary>
		public virtual void InitOnce()
		{
			needInit = true;
		}

		/// <summary>
		/// UI Init
		/// </summary>
		public virtual void InitUI()
		{
			minSize = new Vector2 (770.0f, 590.0f);
			wantsMouseMove = true;
		}

		void OnDestroy()
		{
			Clean ();
		}
		public virtual void Clean()
		{

		}
		#endregion
		  

		public virtual void OnGUI()
		{
			if (so == null)
				SerializedInit ();
			so.Update ();
	
			SWTooltip.Start (this);
			mousePosOut = Event.current.mousePosition;

			if (needInit) { 
				needInit = false;
				InitUI ();
			}
		}

		public virtual void GUIEnd()
		{
			SWTooltip.Show ();
			KeyCommandsOut ();

			so.ApplyModifiedProperties ();
		}

		public virtual void Update()
		{
			Repaint ();
		}
			
		#region key command
	

		public void KeyCommands()
		{
			mousePos = Event.current.mousePosition;
			if(Event.current.type == EventType.keyDown)
			{
				KeyCmd_HotkeyDown (Event.current.keyCode);

				if(Event.current.keyCode == KeyCode.Delete || Event.current.keyCode == KeyCode.Backspace)
				{
					KeyCmd_Delete ();
				}
			}
			if(Event.current.type == EventType.keyUp)
			{
				KeyCmd_HotkeyUp (Event.current.keyCode);
				KeyCmd_CopyPaste ();
			}

			if (Event.current.alt) {
				if (Event.current.type == EventType.ScrollWheel) {
					KeyCmd_Scroll (Event.current.delta);
				} 
				//1 drag map
				else if (SWCommon.GetMouse (0)) {
					Vector2 move = Event.current.mousePosition - mousePosLast;
					KeyCmd_Dragmove (move);
				}
			} else {
				KeyCmd_Select ();
			}


			if (SWCommon.GetMouseDown (0)) {
				mousePosDown = Event.current.mousePosition;
				mousePosLast = Event.current.mousePosition;
				mousePressing = true;
			}
			if (SWCommon.GetMouse (0)) {
				mousePosLast = Event.current.mousePosition;
			}
			if (SWCommon.GetMouseUp (0)) {
				mousePressing = false;
			}
		}

		public virtual void KeyCmd_Delete()
		{

		}

		public virtual void KeyCmd_Dragmove(Vector2 delta)
		{

		}
		public virtual void KeyCmd_Scroll(Vector2 delta)
		{

		}

		public void KeyCmd_CopyPaste()
		{
			if (EditorGUIUtility.editingTextField)
				return;
			if(Event.current.control)
			{
				if (Event.current.keyCode  == KeyCode.C) {
					//Debug.Log ("Copy");
					Copy ();
				}
				if (Event.current.keyCode  == KeyCode.V) {
					//Debug.Log ("Paste");
					Paste();
				}
			}
		}

		public virtual void Copy()
		{
		}

		public virtual void Paste()
		{

		}

		public virtual void KeyCmd_Select()
		{
		}
			
		public virtual void KeyCmd_HotkeyDown(KeyCode code)
		{
			if (code == KeyCode.S && Event.current.alt) {
				if(SWWindowMain.Instance.ProjectIsSaved)
					SWWindowMain.Instance.PressUpdate ();
				else
					SWWindowMain.Instance.PressSave ();
			}
			if (code == KeyCode.O && Event.current.alt) {
				SWWindowMain.Instance.PressOpen ();
			}
		}
		public virtual void KeyCmd_HotkeyUp(KeyCode code)
		{

		}


		public void KeyCommandsOut()
		{

			if (Event.current.alt) {
				if (SWCommon.GetMouse (0)) {
					Vector2 move = Event.current.mousePosition - mousePosOutLast;
					KeyCmd_DragmoveOut (move);
					mousePosOutLast = Event.current.mousePosition;
				}
			}

			if (SWCommon.GetMouseDown (0)) {
				mousePosOutLast = Event.current.mousePosition;
			}
			if (SWCommon.GetMouse (0)) {
				mousePosOutLast = Event.current.mousePosition;
			}
		}
		public virtual void KeyCmd_DragmoveOut(Vector2 delta)
		{

		}

		public void DrawBG(Rect rect,bool frame = true,bool isLight = false)
		{
			var defColor = GUI.color;
			GUI.color = EditorGUIUtility.isProSkin
				? (Color)new Color32(56, 56, 56, 255)
				: (Color)new Color32(194, 194, 194, 255);
			
			GUI.color = new Color32 (56, 56, 56, 255);
			if(isLight)
				GUI.color = new Color32 (194, 194, 194, 255);

			GUI.DrawTexture(rect, EditorGUIUtility.whiteTexture);
			GUI.color = defColor;
			if(frame)
				GUI.Box(rect,"",SWEditorUI.Style_Get(SWCustomStyle.eLine));
		}
		#endregion

		protected void DrawFrame(Rect rect)
		{
			GUI.Box (rect, "", SWEditorUI.Style_Get (SWCustomStyle.eImageFrame));
		}

		protected virtual void OnFocus()
		{

		}
		protected virtual void OnLostFocus()
		{
			Cursor.visible = true; 
		}
	}
}