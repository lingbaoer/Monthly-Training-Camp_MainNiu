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

	/// <summary>
	/// Main Window
	/// </summary>
	[System.Serializable]
	public partial class SWWindowMain:SWWindowLayoutV{
		public static SWWindowMain Instance; 
		protected Rect rightUpRect
		{
			get{ 
				return new Rect (position.width - rightupWidth - al_scrollBarWidth * 1.8f, al_topHeight + position.height*0.3f , rightupWidth + al_scrollBarWidth * 0.8f, position.height*0.7f - al_topHeight - al_scrollBarWidth);
			}
		}

		[SerializeField]
		public SWData data = new SWData();
		[SerializeField]
		Shader shader;
		[SerializeField]
		public List<string> selection = new List<string>();
		[SerializeField]
		SWViewWindow viewWindow;
		public Dictionary<string,Texture2D> textures = new Dictionary<string, Texture2D> ();

		[SerializeField]
		public Rect backgroundRect;
		[SerializeField]
		public Rect bgUV;
		[SerializeField]
		public float bgUVRatio;
		[SerializeField]
		public bool lineStartNodeFromLeft;
		[SerializeField]
		public int lineStartNodePort;
		[SerializeField]
		public SWNodeBase lineStartNode;


		#region dictionary
		[SerializeField]
		public SWNodeRoot nRoot;
		/// <summary>
		/// All nodes include root node
		/// </summary>
		[SerializeField]
		public List<SWNodeBase> nodes = new List<SWNodeBase>();
		protected string prefKey{
			get{
				return string.Format ("{0}dataPath", SWGlobalSettings.ProductName);
			}
		}
		/// <summary>
		/// Use when save as a new file
		/// </summary>
		public bool newCopy;
		[SerializeField]
		public string newName;

		public void NodeClear()
		{
			nodes.Clear ();
		}

		/// <summary>
		/// All nodes include root node
		/// </summary>
		public Dictionary<string,SWNodeBase> NodeAll()
		{
			Dictionary<string,SWNodeBase> dic = new Dictionary<string, SWNodeBase> ();
			foreach (var item in nodes)
				dic.Add (item.data.id, item);
			return dic;
		}
		public void NodeRemoveAt(string key)
		{
			//Debug.Log ("NodeRemoveAt");
			if (key == nRoot.data.id) {
				nRoot.Delete ();
				nRoot = null;
			}
			Remove (nodes, key);
		}
		public bool Remove<T>(List<T> ns,string key)
			where T:SWNodeBase
		{
			for (int i = ns.Count - 1; i >= 0; i--) {
				if (ns [i].data.id == key) {
					ns [i].Delete ();
					ns.RemoveAt (i);
					return true;
				}
			}
			return false;
		}
			
		public override void InitOnce ()
		{
			al_startY = 21;
			rightupWidth = 280;
			base.InitOnce ();  
			NodeClear ();

			backgroundRect = new Rect (-5000, -5000, 10000, 10000);
			float xy = backgroundRect.width / backgroundRect.height;
			bgUV = new Rect (0, 0, xy * 50f, 50f);
			titleContent = new GUIContent (SWGlobalSettings.ProductName);
		}

		public override void InitUI ()
		{
			base.InitUI ();
			viewWindow = new SWViewWindow ();
			CreateNode (SWNodeType.root);

			List<SWSlot> slotsNodebox = new List<SWSlot> ();
			slotsNodebox.Add(new SWSlot("Color",SWTipsText.Main_t_Color,null,KeyCode.None,0));
			slotsNodebox.Add(new SWSlot("Image",SWTipsText.Main_t_Image,null,KeyCode.None,0));
			slotsNodebox.Add(new SWSlot("Refract",SWTipsText.Main_t_Refraction,null,KeyCode.None,0));
			slotsNodebox.Add(new SWSlot("Reflect",SWTipsText.Main_t_Reflect,null,KeyCode.None,0));

			slotsNodebox.Add(new SWSlot("UV",SWTipsText.Main_t_UV,null,KeyCode.None,2));
			slotsNodebox.Add(new SWSlot("Remap",SWTipsText.Main_t_UV,null,KeyCode.None,2));
			slotsNodebox.Add(new SWSlot("Blur",SWTipsText.Main_t_Blur,null,KeyCode.None,2));
			slotsNodebox.Add(new SWSlot("Retro",SWTipsText.Main_t_Retro,null,KeyCode.None,2));

			slotsNodebox.Add(new SWSlot("Alpha",SWTipsText.Main_t_Alpha,null,KeyCode.None,3));

			slotsNodebox.Add(new SWSlot("Mask",SWTipsText.Main_t_Mask,null,KeyCode.None,1));
			slotsNodebox.Add(new SWSlot("Mixer",SWTipsText.Main_t_Alpha,null,KeyCode.None,1));
			//slotsNodebox.Add(new SWSlot("Cartoon",SWTipsText.Main_t_UV));
			//slotsNodebox.Add(new SWSlot("Outline",SWTipsText.Main_t_UV));

			slotBox_left = ScriptableObject.CreateInstance<SWSlotBox_Drag> ();
			slotBox_left.InitSlot(this,new Rect(0,al_slotStartY+al_topHeight+al_spacing,al_leftWidth,position.height-al_spacing-al_topHeight),slotsNodebox,OnReleaseNode,new Vector2(al_leftWidth,al_leftWidth*0.6f));
		

			//Path Manage 1: Open from Shader Inspector
			if (shader!=null) {
				string adbPath = AssetDatabase.GetAssetPath (shader);
				string path =  SWCommon.AssetDBPath2Path (adbPath);
				ProcessPath (path);
				Load ();
				ProcessTitle(SWCommon.GetName (path));
				shader = null;
			}
		}
		#endregion

		[MenuItem("Window/Shader Weaver")]
		static void ShowEditor() { 
			if (Instance != null)
				Instance.Close ();
			var window = EditorWindow.GetWindow<SWWindowMain> ();
			window.InitOnce ();
		}
		public static void OpenFromInspector(Shader shader)
		{
			if (Instance != null)
				Instance.Close ();
			var window = EditorWindow.GetWindow<SWWindowMain> ();
			window.shader = shader;
			window.InitOnce ();
		}

		protected override void SerializedInit ()
		{
			base.SerializedInit ();

			if(slotBox_left!=null)
				slotBox_left.Init (OnReleaseNode);
		}
			
		public override void Awake ()
		{
			al_topHeight = SWGlobalSettings.al_topHeightMain;
			base.Awake ();
			Instance = this;
		}


		public override void Update ()
		{
			if (!CanUpdate ())
				return;
			base.Update ();
			foreach (var item in NodeAll()) {  
				item.Value.Update ();
			}
		}


		public void Save()
		{
			data.version = SWGlobalSettings.version;
			data.nodes.Clear ();
			foreach (var item in NodeAll()) {
				item.Value.BeforeSave ();
				data.nodes.Add (item.Value.data);
			}
			SWDataManager.Save (SWCommon.Path2FullPath(dataPath), data);
		}
		public void Load()
		{
			data.nodes.Clear ();
			NodeClear ();
			data = SWDataManager.Load (SWCommon.Path2FullPath(dataPath));
			Material mat = SWEditorTools.GUIDToObject<Material> (data.materialGUID);

			foreach (var item in data.nodes) {
				CreateNode (item);
			}
			foreach (var node in NodeAll()) {
				node.Value.AfterLoad (); 
			}
			viewWindow.SetMaterial (mat,data,nRoot.sprite);
		}

		public override void Clean ()
		{
			base.Clean ();
			if (viewWindow!=null) {
				viewWindow.Clean (); 
			}
		}

		public override void OnAfterDeserialize ()
		{
			base.OnAfterDeserialize ();
			Instance = this;
		}
			
		void OnReleaseNode(SWSlot slot,Vector2 posInRegion)
		{
			SWNodeType type = (SWNodeType)System.Enum.Parse (typeof(SWNodeType), slot.name.ToLower ());
			SWUndo.Record (this);
			CreateNode (type, mousePos);
		}

		public bool IsLoadFromStartup()
		{
			return !needInit && ( nRoot == null || nRoot.data == null);
		}
		public override void OnGUI ()
		{
			if (IsLoadFromStartup ()) {
				InitOnce ();
				needInit = true;
			}
			base.OnGUI ();
		}

		void TopBt(Rect rect,string txt,string tooltip,SWUITex tex,System.Action dele)
		{
			if (GUI.Button (rect,SWEditorUI.Texture(tex),SWEditorUI.Style_Get(SWCustomStyle.none))) 
			{
				if (dele != null)
					dele ();
			}

			Tooltip_Rec (tooltip,rect);
			GUI.Label (new Rect(rect.x,rect.y + rect.height,rect.width,10),txt,SWEditorUI.Style_Get(SWCustomStyle.eTxtLight));
		}

		public bool ProjectIsDirty
		{
			get{
				return false;
			}
		}
		public bool ProjectIsSaved
		{
			get{
				return !string.IsNullOrEmpty (dataPath);
			}
		}
		public override void DrawTop ()
		{
			base.DrawTop ();
			float spacing = 20;
			Rect rect = new Rect (10, 5, 40, 40);
			TopBt (rect, "Open", SWTipsText.Main_Open, SWUITex.open, PressOpen);
			rect.x += rect.width + spacing;
			TopBt (rect, "Save", SWTipsText.Main_Save, SWUITex.save, PressSave);
			rect.x += rect.width + spacing;
			if (ProjectIsSaved) {
				TopBt (rect, "Update", SWTipsText.Main_Update, SWUITex.update, PressUpdate);
			} else {
				GUI.color = Color.gray;
				TopBt (rect, "Update", SWTipsText.Main_Update, SWUITex.updateGray, null);
				GUI.color = Color.white;
			}
		}

		public override void DrawLeft ()
		{
			base.DrawLeft ();
		}

		public override void DrawMainBot ()
		{
			base.DrawMainBot ();
		}

		public override void DrawMainInside1 ()
		{
			base.DrawMainInside1 ();
			GUI.DrawTextureWithTexCoords(backgroundRect, 
				SWEditorUI.Texture(SWUITex.canvasBG),bgUV, true);
		}
		public override void DrawMainMid ()
		{
			base.DrawMainMid ();
			GUI.DrawTexture( al_rectMain,SWEditorUI.Texture(SWUITex.canvasFG),ScaleMode.StretchToFill); 
		}
		public override void DrawMainInside2 ()
		{
			UpdateNodes ();
			DrawNodes();
			base.DrawMainInside2 ();

		}
		public override void SetInsideRects ()
		{
			base.SetInsideRects ();
			foreach (var item in NodeAll()) {
				item.Value.data.rect = SetInsideRect (item.Value.data.rect);
			}
		}	

		public override void OnGUITop ()
		{
			base.OnGUITop ();
			if(viewWindow!=null)
				viewWindow.OnGUI (new Rect(position.width - 200 -20,al_topHeight + 20,200,200));
		}

		public void ProcessTitle(string newTitle)
		{
			data.title = newTitle;
			newName = newTitle;
			dataPath = string.Format ("{0}{1}.shader", folderPath, data.title); 
		}
		public void ProcessPath(string path)
		{
			string[] ary = path.Split ('/');
			if (ary.Length == 1)
				folderPath = "";
			else
				folderPath = path.Substring (0, path.Length - ary [ary.Length - 1].Length - 1) + "/";
			dataPath = path;
		}

		public void PressRename()
		{
			if (newName == data.title)
				return;
			//Path Manage 4: Rename
			//Mask Texture
			foreach (var guid in data.masksGUID) {
				RenameAssetGUID (guid);
			}
			//Material
			RenameAssetGUID (data.materialGUID);
			//Remap Texture
			foreach (var item in NodeAll()) {
				if (item.Value.data.type == SWNodeType.remap) {
					RenameAssetGUID (item.Value.data.textureExGUID);
				}
			}
			//Shader File
			string path = string.Format ("{0}{1}.shader", folderPath, data.title);
			//string fullPath = SWCommon.Path2FullPath (path);
			string adbPath =  SWCommon.Path2AssetDBPath (path);
			RenameAssetPath (adbPath);
			//Data
			ProcessTitle(newName);
		}
		void RenameAssetGUID(string guid)
		{
			if (string.IsNullOrEmpty (guid))
				return;
			string path = AssetDatabase.GUIDToAssetPath (guid);
			RenameAssetPath (path);
		}
		void RenameAssetPath(string adbPath)
		{
			if (string.IsNullOrEmpty (adbPath))
				return;
			string fileOldName = SWCommon.GetName(adbPath);
			if (fileOldName.Contains ("_")) {
				int index = fileOldName.IndexOf ("_");
				AssetDatabase.RenameAsset (adbPath, newName + fileOldName.Substring(index));
			}
			else if(fileOldName == data.title)
				AssetDatabase.RenameAsset (adbPath, newName);
		}



		public void PressSave()
		{
			if (!NodesOk ())
				return;
			string str = "Assets/";
			if (EditorPrefs.HasKey (prefKey)) {
				var path = EditorPrefs.GetString (prefKey);
				string id = AssetDatabase.AssetPathToGUID (path);
				if (!string.IsNullOrEmpty (id))
					str = path;
			}



			string adbpath = EditorUtility.SaveFilePanelInProject ("Save", string.Format("{0}.shader",data.title), "shader","Plz",str);
			if (!string.IsNullOrEmpty (adbpath) && adbpath.Contains ("Assets")) {

				string path = SWCommon.AssetDBPath2Path (adbpath);
				string[] ary = path.Split ('/');
				string newTitle = ary [ary.Length - 1].Split ('.') [0];
			
				newCopy = path != dataPath || newTitle != data.title;
				//Path Manage 3: Save from Shader Weaver menu
				ProcessPath (path);
				ProcessTitle (newTitle);
				string folderPath = adbpath.Substring (0, adbpath.Length - ary [ary.Length - 1].Length);
				EditorPrefs.SetString(prefKey,folderPath);
				SaveUpdate ();
			}
		}

		public void PressUpdate()
		{
			if (!NodesOk ())
				return;
			SaveUpdate ();
		}


		bool NodesOk()
		{

			foreach (var item in nodes) {
				if (!item.BelongRootTree())
					continue;

				if (item is SWNodeImage || item is SWNodeUV || item is SWNodeAlpha || item is SWNodeMixer) {
					if (item.texture == null) {
						EditorUtility.DisplayDialog ("Before Save", string.Format ("Please assign {0}'s texture.",item.data.name), "OK");
						return false;
					}
				}


				if (item is SWNodeRemap) {
					if (!item.HasChild()) {
						EditorUtility.DisplayDialog ("Before Save", string.Format ("Please assign {0}'s child.", item.data.name), "OK");
						return false;
					}
				}
			}
			return true;
		}

		public void PressOpen()
		{
			string str = SWGlobalSettings.AssetsFullPath;
			if (EditorPrefs.HasKey (prefKey)) {
				var path = str.Substring (0, str.Length - 6) + EditorPrefs.GetString (prefKey);
				if (System.IO.Directory.Exists (path))
					str = path;
			}

			string fullpath = EditorUtility.OpenFilePanel ("Data", str, "shader");
			if (!string.IsNullOrEmpty (fullpath) && fullpath.Contains ("Assets")) {
				string path = SWCommon.FullPath2Path (fullpath);
				if (SWDataManager.IsSWShader (fullpath)) {
					//Path Manage 2: Open from Shader Weaver menu
					ProcessPath (path);
					Load ();
					ProcessTitle (SWCommon.GetName (path));
					EditorPrefs.SetString (prefKey, "Assets/" + path);
				} else {
					EditorUtility.DisplayDialog ("Shader", "Shader is not a Shader Weaver Shader.", "Close");
				}
			}
		}







		void UpdateNodes()
		{
			foreach (var item in NodeAll()) {
				//remove empty child
				for(int i = item.Value.data.children.Count-1;i>=0;i--)
				{
					string child = item.Value.data.children [i];
					if (!NodeAll().ContainsKey (child))
						item.Value.data.children.Remove (child);
				}

				//remove empty parent
				for(int i = item.Value.data.parent.Count-1;i>=0;i--)
				{
					string par = item.Value.data.parent [i];
					if (!NodeAll().ContainsKey (par))
						item.Value.data.parent.Remove (par);
				}
			}
		}
		void DrawNodes()
		{
			BeginWindows();
			foreach (var item in NodeAll()) {
				item.Value.Draw ();
				foreach(var child in item.Value.data.children)
				{
					var childNode = NodeAll () [child];
					if (childNode.RightAvailable () && item.Value.LeftAvailable ()) {
						//Sometime child's parent didnt contain parent's id
						if (!childNode.data.parent.Contains (item.Value.data.id)) {
							childNode.data.parent.Add (item.Value.data.id);
							childNode.data.parentPort.Add (0);
						}
						var rectLeft = item.Value.GetRectLeft (childNode.data.id);
						var rectRight = childNode.GetRectRight (item.Value.data.id);
						DrawNodeCurve (rectRight,rectLeft);
					}	
				}
			}
			EndWindows();
			DragNodeLine ();
		}


	
		void DragNodeLine()
		{
			//Break connection
			if ((Event.current.alt||Event.current.control) && SWCommon.GetMouseDown (0)) {
				foreach (var item in NodeAll()) {
					for (int i = 0; i < item.Value.rectLefts.Count; i++) {
						int port = i;
						var rect = item.Value.rectLefts [i];

						if (rect.Contains (Event.current.mousePosition)) {
							SWUndo.Record (item.Value);
							foreach (var ii in item.Value.data.children) {
								SWUndo.Record (NodeAll () [ii]);
							}
							item.Value.DeleteAllChild ();
						}
					}

					for (int i = 0; i < item.Value.rectRights.Count; i++) {
						int port = i;
						var rect = item.Value.rectRights [i];

						if (rect.Contains (Event.current.mousePosition)) {
							SWUndo.Record (item.Value);
							foreach (var ii in item.Value.data.children) {
								SWUndo.Record (NodeAll () [ii]);
							}
							item.Value.DeleteAllParent ();
						}
					}
				}
				return;
			}

			//start drag a line
			if (SWCommon.GetMouseDown (0)) {
				foreach (var item in NodeAll()) {
					var node = item.Value;
					if (node.LeftAvailable ()) {
						for (int i = 0; i < node.rectLefts.Count; i++) {
							var rect = node.rectLefts [i];
							if (rect.Contains (Event.current.mousePosition)) {
								lineStartNode = item.Value;
								lineStartNodePort = i;
								lineStartNodeFromLeft = true;
							}
						}
					}

					if (node.RightAvailable ()) {
						for (int i = 0; i < node.rectRights.Count; i++) {
							var rect = node.rectRights [i];
							if (rect.Contains (Event.current.mousePosition)) {
								lineStartNode = item.Value;
								lineStartNodePort = i;
								lineStartNodeFromLeft = false;
							}
						}
					}
				}
			}

			//make connection
			if (lineStartNode != null && SWCommon.GetMouseUp (0)) {
				foreach (var item in NodeAll()) {
					var node = item.Value;

					if (lineStartNodeFromLeft && node.RightAvailable()) {
						for (int i = 0; i < node.rectRights.Count; i++) {
							var rect = node.rectRights [i];
							if (rect.Contains (Event.current.mousePosition) && SWNodeBase.NodeMatch (lineStartNode, item.Value)) {
								SWUndo.Record (lineStartNode);
								SWUndo.Record (item.Value);

								SWNodeBase.AddConnection (item.Value,i,lineStartNode,lineStartNodePort);

							
							}
						}
					}
					if (!lineStartNodeFromLeft && node.LeftAvailable()) {
						for (int i = 0; i < node.rectLefts.Count; i++) {
							var rect = node.rectLefts [i];
							if (rect.Contains (Event.current.mousePosition) && SWNodeBase.NodeMatch (item.Value, lineStartNode)) {
								SWUndo.Record (lineStartNode);
								SWUndo.Record (item.Value);

								SWNodeBase.AddConnection (lineStartNode,lineStartNodePort,item.Value,i);
							}
						}
					}
				}
				lineStartNode = null;
			}

			if (lineStartNode != null) {
				if (lineStartNodeFromLeft) {
					var rect = lineStartNode.rectLefts [lineStartNodePort];

					if (!rect.Contains (Event.current.mousePosition)) {
						Vector2 p = new Vector2 (rect.xMin, rect.center.y);
						DrawNodeCurve (Event.current.mousePosition, p);
					}
				} else {
					var rect = lineStartNode.rectRights [lineStartNodePort];

					if (!rect.Contains (Event.current.mousePosition)) {
						Vector2 p = new Vector2 (rect.xMax, rect.center.y);
						DrawNodeCurve (p, Event.current.mousePosition);
					}
				}
			}
		}

		#region key command
		public override void KeyCmd_Dragmove (Vector2 delta)
		{
			//		Debug.Log (delta);
			base.KeyCmd_Dragmove (delta);
			foreach (var item in NodeAll()) {
				item.Value.data.rect.center += new Vector2 (1f * delta.x, 1f * delta.y);
			}
			backgroundRect.center  += new Vector2 (1f * delta.x, 1f * delta.y);
		}





		public enum SelectMode
		{
			no,
			move,
			one,
			rect
		}
		public SelectMode selectMode;

		SWNodeBase mouseDownNode;

		bool showSelectionRect = false; 
		Rect selectRect;


		void KeyCmd_SelectClean()
		{
			selectMode = SelectMode.no;
			mouseDownNode = null;
			showSelectionRect = false;
		}

		public override void KeyCmd_Select()
		{
			if ( SWCommon.GetMouseDown (0)) {
				Vector2 mp = Event.current.mousePosition;

				//1 out of map
				if (!al_rectMainInsideZoom.Contains (Event.current.mousePosition)) {
					selectMode = SelectMode.no;
					return;
				}


				KeyCmd_SelectClean ();
				foreach(var item in NodeAll())
				{
					var orect = item.Value.data.rect;
					if(orect.Contains(Event.current.mousePosition))
					{
						//2 select node
						mouseDownNode = item.Value;
						break;
					}
				}

				if (mouseDownNode!=null) {
					if (selection.Contains (mouseDownNode.data.id)) {
						selectMode = SelectMode.move;
					} else {
						selection.Clear ();
						selection.Add (mouseDownNode.data.id);
						selectMode = SelectMode.move;
					}
				} else {
					bool outside = true;
					foreach(var item in NodeAll())
					{
						var orect = item.Value.rectBig;
						if(orect.Contains(Event.current.mousePosition))
						{
							outside = false;
							break;
						}
					}

					if (outside) {
						selection.Clear ();
						selectMode = SelectMode.rect;
						EditorGUIUtility.editingTextField = false;
					}
				}
			}
			if (selectMode == SelectMode.move) {
				if (SWCommon.GetMouse (0)) {
					Vector2 v = Event.current.mousePosition - mousePosLast;
					foreach (var item in selection) {
						NodeAll() [item].data.rect.center += v;
					}
				}

				if (SWCommon.GetMouseUp (0)) {
					selectMode = SelectMode.no;
				}
			}


			if (selectMode == SelectMode.rect) {
				if (SWCommon.GetMouse (0)) {
					Vector3 v1 = Event.current.mousePosition;
					Vector3 v2 = mousePosDown;
					float mag = (v1 - v2).magnitude;

					showSelectionRect = mag > 30;


					if (showSelectionRect) {
						float x = Mathf.Min (v1.x, v2.x);
						float y = Mathf.Min (v1.y, v2.y);
						float w = Mathf.Abs (v1.x - v2.x);
						float h = Mathf.Abs (v1.y - v2.y);
						selectRect = new Rect (x, y, w, h);
					}
				}
				if (showSelectionRect) {
					GUI.Box (selectRect, "",SWEditorUI.Style_Get(SWCustomStyle.eSelectRect));
					//SWEditorTools.DrawOutline (selectRect, Color.white);


					if (Event.current.type == EventType.MouseUp
						||Event.current.type == EventType.ContextClick
						||Event.current.type == EventType.Ignore) {
						foreach (var item in NodeAll()) {
							var orect = item.Value.data.rect;
							if (selectRect.Contains (orect.center)) {
								selection.Add (item.Key);
								//break;
							}
						}
						KeyCmd_SelectClean ();
					}
				}
			}

			if (selectMode == SelectMode.one) {
				if (SWCommon.GetMouseUp (0)) {
					foreach(var item in NodeAll())
					{
						var orect = item.Value.data.rect;
						if(orect.Contains(Event.current.mousePosition))
						{
							if (item.Value == mouseDownNode) {
								selection.Add (item.Key);
							}
							//break;
						}
					}
					KeyCmd_SelectClean ();
				}
			}
		} 
		public override void KeyCmd_Delete ()
		{
			SWUndo.Record (this);
			base.KeyCmd_Delete ();

			foreach (var item in selection) {
				if (NodeAll().ContainsKey (item)) {
					if (!(NodeAll() [item] is SWNodeRoot)) {
						NodeRemoveAt (item);
					}
				}
			}
			selection.Clear ();
		}

		public override void Copy ()
		{
			base.Copy ();
			List<SWDataNode> datas = new List<SWDataNode> ();
			foreach (var item in selection) {
				NodeAll()[item].BeforeSave ();
				datas.Add (NodeAll() [item].data);
			}

			string str = SWDataManager.DataToText (datas);
			EditorGUIUtility.systemCopyBuffer = str;
		} 


		public override void Paste ()
		{
			selection.Clear ();
			base.Paste ();
			string buffer = EditorGUIUtility.systemCopyBuffer;
			if (!SWDataManager.StringIsData (buffer)) {
				//Debug.Log ("its not data:" + buffer);
				return;
			}


			List<SWDataNode> datas = new List<SWDataNode> ();
			try {
				datas = SWDataManager.TextToData (buffer);
			}
			catch (System.Exception e) {
				Debug.LogError (e);
				return;
			}
			Vector2 offset = new Vector2(120,30);
			foreach(var item in datas)
			{
				if (item.type == SWNodeType.root)
					continue;

				//check for id conflict
				while (NodeAll().ContainsKey (item.id)) {
					string oldId = item.id;
					item.AssingNewID ();
					string newId = item.id;
					item.rect.center += offset*0.5f;

					foreach (var go in datas) {
						for (int i = go.parent.Count - 1; i >= 0; i--) {
							if (go.parent [i] == oldId)
								go.parent [i] = newId; 
						}
					}

					foreach (var go in datas) {
						for (int i = go.children.Count - 1; i >= 0; i--) {
							if (go.children [i] == oldId)
								go.children [i] = newId; 
						}
					}
				}

			
				//check for name conflict
				bool hasSameName = true;
				while (hasSameName) {
					bool has = false;
					foreach (var nn in NodeAll()) {
						if (nn.Value.data.name == item.name) {
							has = true;
						}
					}
					hasSameName = has;
					if (hasSameName) {
						item.name = item.name + "copy";
						item.rect.center += offset;
					}
				}


				var node = CreateNode(item);
				item.layerMask.Clear ();
				node.AfterLoad ();
				selection.Add (node.data.id);
			}
	


			foreach (var item in datas) {
				for (int i = item.parent.Count - 1; i >= 0; i--) {
					bool has = false;
					foreach (var item2 in datas) {
						if (item2.id == item.parent [i]) {
							has = true;
						}
					}
					if (!has) {
						item.parent.RemoveAt (i);
					}
				}
				for (int i = item.children.Count - 1; i >= 0; i--) {
					bool has = false;
					foreach (var item2 in datas) {
						if (item2.id == item.children [i]) {
							has = true;
						}
					}
					if (!has) {
						item.children.RemoveAt (i);
					}
				}
			}
		}
		#endregion





		#region baisc function
		void DrawNodeCurve(Rect start, Rect end) {
			DrawNodeCurve(new Vector2(start.x + start.width, start.y + start.height / 2), new Vector2(end.x, end.y + end.height / 2));
		}

		void DrawNodeCurve(Vector3 left, Vector3 right) {
			float dis = Vector3.Distance (left, right);
			float fac = dis * 0.25f;
			//fac = Mathf.Clamp (fac,1f,50f);

			Vector3 startTan = left + Vector3.right * fac;
			Vector3 endTan = right + Vector3.left * fac;
			Color shadowCol = new Color(0, 0.5f, 0, 0.06f);
			for (int i = 0; i < 3; i++) 
				Handles.DrawBezier(left, right, startTan, endTan, shadowCol, null, 10);
			Handles.DrawBezier(left, right, startTan, endTan, SWEditorUI.ColorPalette(SWColorPl.green), null, 5);
		}

		/// <summary>
		/// (1)When create a new map: Create Root  
		/// </summary>
		public SWNodeBase CreateNode(SWNodeType _type)
		{
			return CreateNode (_type, GetNextPos ());
		}
		/// <summary>
		/// (1)Drag a node to map 
		/// (2)Invoked when create a new map
		/// </summary>
		public SWNodeBase CreateNode(SWNodeType _type,Vector2 pos)
		{
			SWDataNode data = new SWDataNode ();
			data.type = _type;
			SWNodeBase node = CreateNode (data);
			data.rect = SWCommon.RectNew (pos, new Vector2 (node.nodeWidth, node.nodeHeight));
			return node;
		}

		/// <summary>
		/// (1)Load / Paste
		/// (2)Invoked by all upper CreateNode method
		/// </summary>
		public SWNodeBase CreateNode(SWDataNode data)
		{
			SWNodeBase node = null;
			if (data.type == SWNodeType.root) {
				nRoot = ScriptableObject.CreateInstance<SWNodeRoot> ();
				node = nRoot;
			}
			else if (data.type == SWNodeType.color) {
				node = ScriptableObject.CreateInstance<SWNodeColor> ();
			}
			else if (data.type == SWNodeType.image) {
			 	node = ScriptableObject.CreateInstance<SWNodeImage> ();
			}
			else if (data.type == SWNodeType.uv) {
			 	node = ScriptableObject.CreateInstance<SWNodeUV> ();
			}
			else if (data.type == SWNodeType.mask) {
			 	node = ScriptableObject.CreateInstance<SWNodeMask> ();
			}
			else if (data.type == SWNodeType.remap) {
			 	node = ScriptableObject.CreateInstance<SWNodeRemap> ();
			}
			else if (data.type == SWNodeType.alpha) {
				node = ScriptableObject.CreateInstance<SWNodeAlpha> ();
			}
			else if (data.type == SWNodeType.mixer) {
				node = ScriptableObject.CreateInstance<SWNodeMixer> ();
			}
			else if (data.type == SWNodeType.blur) {
				node = ScriptableObject.CreateInstance<SWNodeBlur> ();
			}
			else if (data.type == SWNodeType.retro) {
				node = ScriptableObject.CreateInstance<SWNodeRetro> ();
			}
			else if (data.type == SWNodeType.outline) {
				node = ScriptableObject.CreateInstance<SWNodeOutline> ();
			}
			else if (data.type == SWNodeType.cartoon) {
				node = ScriptableObject.CreateInstance<SWNodeCartoon> ();
			}
			else if (data.type == SWNodeType.refract) {
				node = ScriptableObject.CreateInstance<SWNodeRefraction> ();
			}
			else if (data.type == SWNodeType.reflect) {
				node = ScriptableObject.CreateInstance<SWNodeReflection> ();
			}
			node.Init(data, this);
			nodes.Add (node);
			node.data.rect = SWCommon.Ceil (node.data.rect);
			return node;
		}

		public Vector2 GetNextPos()
		{
			if( nRoot == null)
				return new Vector2 (xHalf - SWNodeBase.NodeWidth*0.5f, 
					yHalf- SWNodeBase.NodeHeight*0.5f);
			SWNodeBase botRightNode = null;
			foreach(var item in NodeAll())
			{
				botRightNode = item.Value;
			}
			return new Vector2 (botRightNode.data.rect.x - 200, botRightNode.data.rect.y + 0);
		}

		public int GetNextIndex()
		{
			if( nodes.Count == 0)
				return 0;

			int max = int.MinValue;
			foreach (var item in NodeAll()) {
				if (item.Value.index > max) {
					max = item.Value.index;
				}
			}
			return max + 1;
		}
		#endregion

		#region export
		void SaveUpdate()
		{
			float f = Time.realtimeSinceStartup;
			EditorUtility.DisplayProgressBar (SWGlobalSettings.ProductTitle, "Processsing maps", 0.2f);
			ProcessRemap ();
			EditorUtility.DisplayProgressBar (SWGlobalSettings.ProductTitle, "Processsing masks", 0.4f);
			ProcessMasks ();
			EditorUtility.DisplayProgressBar (SWGlobalSettings.ProductTitle, "Processsing Textures", 0.6f);
			ProcessTextures ();
			EditorUtility.DisplayProgressBar (SWGlobalSettings.ProductTitle, "Creating Materials", 0.8f);
			Material mat = SWMaterialManager.CreateMaterial (this);
			EditorUtility.DisplayProgressBar (SWGlobalSettings.ProductTitle, "Setting Materials", 0.9f);
			viewWindow.SetMaterial (mat,data,nRoot.sprite);
			EditorUtility.DisplayProgressBar (SWGlobalSettings.ProductTitle, "Finish", 1f);
			Save ();
			EditorUtility.ClearProgressBar ();
			//Debug.Log ("Finish:"+(Time.realtimeSinceStartup - f));
		}

		/// <summary>
		/// Write remap texture as png. If use custom,just return
		/// </summary>
		void ProcessRemap()
		{
			foreach (var item in NodeAll()) {
				if (item.Value.data.type == SWNodeType.remap){
					//CUSTOM
					if (item.Value.data.useCustomTexture)
						continue;
					if (!newCopy && !item.Value.data.dirty)
						continue;
					item.Value.data.dirty = false;
					SWNodeRemap e = (SWNodeRemap)item.Value;
					var t = item.Value.textureEx;
					string guid = SWEditorTools.ObjectToGUID (t.Texture);
					if (newCopy || string.IsNullOrEmpty (guid)) {
						item.Value.textureEx = SWCommon.SaveReloadTexture2d (e.textureEx,string.Format("{0}{1}_{2}.png",
							folderPath,data.title,e.data.name),true);
					} else {
						SWCommon.Texture2dResave (t, AssetDatabase.GetAssetPath (t.Texture));
					}
				}
			}
		}



		void ProcessMasks()
		{
			List<string> guids = new List<string> ();


			//step 1:gather all masks
			List<SWNodeMask> masks = new List<SWNodeMask> ();
			foreach (var item in NodeAll()) {
				if (item.Value.data.type == SWNodeType.mask ){
					SWNodeMask e = (SWNodeMask)item.Value;

					//CUSTOM:If this mask node use custom mask,it will be always dirty,force texture merge
					e.GrayApply ();
					masks.Add (e);
				}
			}
			float x = masks.Count / 4f;

			//4 in one group
			int groupNum = Mathf.CeilToInt (x);

			for (int i = 0; i < groupNum; i++) {
				if (!newCopy && !AnyDirty (masks, i * 4)) {
					string tguid = "";
					if (i < data.masksGUID.Count)
						tguid = data.masksGUID [i];
					else {
						string pp = string.Format ("{0}{1}_{2}.png", folderPath, data.title, "mask" + i);
						tguid = AssetDatabase.AssetPathToGUID (SWCommon.Path2AssetDBPath (pp));
					}
					if (!string.IsNullOrEmpty (tguid)) {
						guids.Add (tguid);
						continue;
					}
				}
				string path = ""; 
				if(newCopy || i>=data.masksGUID.Count)
					path = string.Format ("{0}{1}_{2}.png", folderPath, data.title, "mask" + i);
				else
					path = SWCommon.AssetDBPath2Path(AssetDatabase.GUIDToAssetPath (data.masksGUID [i]));

				Texture2D tmpTex =AssetDatabase.LoadAssetAtPath<Texture2D> (SWCommon.Path2AssetDBPath(path));
				SWTexture2DEx t;
				if (tmpTex == null) {
					t = SWCommon.TextureCreate (512, 512, TextureFormat.ARGB32);
					var colors = t.GetPixels ();
					int index = i * 4 + 0;
					Color[] ra = masks.Count > index ? masks [index].texMask.GetPixels () : null;
					index = i * 4 + 1;
					Color[] ga = masks.Count > index ? masks [index].texMask.GetPixels () : null;
					index = i * 4 + 2;
					Color[] ba = masks.Count > index ? masks [index].texMask.GetPixels () : null;
					index = i * 4 + 3;
					Color[] aa = masks.Count > index ? masks [index].texMask.GetPixels () : null;

					for (int j = 0; j < colors.Length; j++) {
						float r = ra != null ? ra [j].a : 0;
						float g = ga != null ? ga [j].a : 0;
						float b = ba != null ? ba [j].a : 0;
						float a = aa != null ? aa [j].a : 0;
						colors [j] = new Color (r, g, b, a);
					}
					t.SetPixels (colors);
					t.Apply ();
					t = SWCommon.SaveReloadTexture2d (t, path, false);
					//Debug.Log (t.format.ToString ());
				} else {
					t = new SWTexture2DEx (tmpTex);
					//Debug.Log (t.format.ToString ());
					var colors = t.GetPixels ();
					int index = i * 4 + 0;
					Color[] ra = masks.Count > index ? masks [index].texMask.GetPixels () : null;
					index = i * 4 + 1;
					Color[] ga = masks.Count > index ? masks [index].texMask.GetPixels () : null;
					index = i * 4 + 2;
					Color[] ba = masks.Count > index ? masks [index].texMask.GetPixels () : null;
					index = i * 4 + 3;
					Color[] aa = masks.Count > index ? masks [index].texMask.GetPixels () : null;

					for (int j = 0; j < colors.Length; j++) {
						float r = ra != null ? ra [j].a : 0;
						float g = ga != null ? ga [j].a : 0;
						float b = ba != null ? ba [j].a : 0;
						float a = aa != null ? aa [j].a : 0;
						colors [j] = new Color (r, g, b, a);
					}
					t.SetPixels (colors);
					t.Apply ();
					SWCommon.Texture2dResave (t, AssetDatabase.GetAssetPath (t.Texture));
				}

				SetMask (masks,i * 4 + 0, "mask" + i, SWChannel.r,t);
				SetMask (masks,i * 4 + 1, "mask" + i, SWChannel.g,t);
				SetMask (masks,i * 4 + 2, "mask" + i, SWChannel.b,t);
				SetMask (masks,i * 4 + 3, "mask" + i, SWChannel.a,t);

				string guid = SWEditorTools.ObjectToGUID (t.Texture);
				guids.Add (guid);
			}
			foreach (var item in masks) {
				item.data.dirty = false;
			}
			data.masksGUID = guids;
		}

		bool AnyDirty(List<SWNodeMask> masks,int start)
		{
			for(int i=0;i<4;i++)
			{
				int index = start + i;
				if (index < masks.Count && masks [index].data.dirty)
					return true;
			}
			return false;
		}

		void SetMask(List<SWNodeMask> masks,int index, string name,SWChannel ch,SWTexture2DEx _tex)
		{
			if (index >= masks.Count)
				return;
			SWNodeMask node = masks [index];
			//node.data.name = name;
			node.data.maskChannel = ch;
			node.texture = _tex.Texture;
		}

		/// <summary>
		/// If there are two abc.png in different folders used in SW. They will appear in shader as abc and abc_1
		/// </summary>
		void ProcessTexturesSuffix()
		{
			Dictionary<string,List<string>> name_guidPair = new Dictionary<string, List<string>> ();
			foreach (var item in NodeAll()){
				var tex = item.Value.Texture;
				if (tex == null)
					continue;
				string guid = SWCommon.ObjectGUID (tex);

				if (!name_guidPair.ContainsKey (tex.name)) {
					name_guidPair.Add (tex.name, new List<string> ());
				}

				if (!name_guidPair [tex.name].Contains (guid)) {
					name_guidPair [tex.name].Add (guid);
				}
			}


			foreach (var item in NodeAll()){
				var tex = item.Value.Texture;
				if (tex == null)
					continue;
				string guid = SWCommon.ObjectGUID (tex);
				for (int i = 0; i<name_guidPair [tex.name].Count; i++) {
					if (name_guidPair [tex.name] [i] == guid) {
						item.Value.textureDuplicatedSuffix = i;
					}
				}
			}
		}

		void ProcessTextures()
		{
			ProcessTexturesSuffix ();
			textures.Clear ();
			foreach (var item in NodeAll()) {
				Texture2D tex = item.Value.Texture;
				if (item.Value.data.type == SWNodeType.root) {
					textures.Add ("_" + item.Value.TextureShaderName (), tex);
				} else {
					if(!item.Value.BelongRootTree())
						continue;
					if (tex == nRoot.texture)
						continue;
					if (tex == null)
						continue;
					if (textures.ContainsKey ("_" + item.Value.TextureShaderName ())) 
						continue;
					textures.Add ("_" + item.Value.TextureShaderName (), tex);
				}
			}
		}
		#endregion

		protected override void OnLostFocus ()
		{
			base.OnLostFocus ();

			if (selectMode == SelectMode.rect) {
				selectMode = SelectMode.no;
			}
		}
	}
}

