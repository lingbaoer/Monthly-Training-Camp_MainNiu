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
	public class SWNodeBase:ScriptableObject{
	//	private static int nextIndex = 1;
		[SerializeField]
		public int index;
		[SerializeField]
		public SWDataNode data;
		[SerializeField]
		public Texture2D texture;
		[SerializeField]
		public Texture2D textureGray;
		[SerializeField]
		public SWTexture2DEx textureEx;
		public Texture2D Texture{
			get
			{
				if (texture != null)
					return texture;
				if (!textureEx.IsNull)
					return textureEx.Texture;
				return null;
			}
		}	
		[SerializeField]
		public Sprite sprite;
		[SerializeField]
		public Rect rectBig; 
		[SerializeField]
		public List<Rect> rectLefts = new List<Rect>();
		[SerializeField]
		public List<Rect> rectRights = new List<Rect> ();
		[SerializeField]
		public SWOutput shaderOutput;
		[SerializeField]
		bool titleEditing = false;
		[SerializeField]
		string nameEditing;

		#region layout
		public static readonly float NodeWidth = 100;
		public static readonly float NodeHeight = 130;
		[SerializeField]
		public float nodeWidth = NodeWidth;
		[SerializeField]
		public float nodeHeight = NodeHeight;


		protected static readonly float headerHeight = 20;
		protected float contentWidth
		{
			get{ 
				return nodeWidth - gap * 2;
			}
		}
		protected static readonly float buttonHeight = 18;
		protected float gap = 5;
		[SerializeField]
		protected Rect rectTop;
		[SerializeField]
		protected Rect rectArea;
		[SerializeField]
		protected Rect rectBotButton; 

		[SerializeField]
		protected float portWidth = 12;
		[SerializeField]
		protected float portHeight = 18;

		/// <summary>
		/// Different Colors
		/// </summary>
		[SerializeField]
		public int styleID;

		[SerializeField]
		public int textureDuplicatedSuffix = 0;
		#endregion

		#region SerializedProperty
		public SerializedObject so;
		protected virtual void SerializedInit()
		{
			so = new SerializedObject (this);
		}
		#endregion

		#region init
		public virtual void Init(SWDataNode _data,SWWindowMain _window)
		{
			SerializedInit ();
			data = _data;
			index = SWWindowMain.Instance.GetNextIndex ();
			if (string.IsNullOrEmpty (data.name))
				data.name = data.type.ToString () + index;
			if (this is SWNodeRoot) {
				data.name = "ROOT";
			}

			InitLayout ();
			SetRectsAll ();
			data.outputType.Clear ();
			data.inputType.Clear ();
		}
		public virtual void InitLayout()
		{
			rectTop = new Rect (0, 1, nodeWidth, headerHeight+2);
			rectBotButton = new Rect (gap, nodeHeight - gap - buttonHeight, contentWidth, buttonHeight);
			rectArea = new Rect (gap, headerHeight + gap, contentWidth, 
				nodeHeight - headerHeight - gap*2 - (rectBotButton.height+gap));
		}

		#endregion
		public SWCustomStyle _Style
		{
			get{
				return (SWCustomStyle)System.Enum.Parse (typeof(SWCustomStyle), "eNode" + styleID);
			}
		}
		public GUIStyle Style
		{
			get{
				return SWEditorUI.Style_Get (_Style);
			}
		}

		public virtual string TextureName()
		{
			return Texture.name;
		}

		public virtual string TextureShaderName()
		{
			if(this is SWNodeRoot || (SWWindowMain.Instance.nRoot.texture !=null && texture == SWWindowMain.Instance.nRoot.texture))
				return "MainTex";

			string name = textureDuplicatedSuffix == 0 ? SWCommon.NameLegal (Texture.name) : SWCommon.NameLegal (Texture.name) + "_" + textureDuplicatedSuffix;
			return name;
		}
			
		public Texture2D GetParentTexture()
		{ 
			if (GetParentNode ().data.type == SWNodeType.mask) {
				SWNodeMask mask = (SWNodeMask)GetParentNode ();
				return mask.texMask.Texture;
				//return mask.info.texPreview;
			} else {
				return GetParentNode ().Texture;
			}
		}

		public virtual Texture2D GetChildTexture()
		{
			if (data.children.Count == 0)
				return null;
			return SWWindowMain.Instance.NodeAll()[data.children[0]].Texture;
		}

		#region node
		public virtual void Delete()
		{
			DeleteAllChild ();
			DeleteAllParent ();
		}
		#region parent
		public List<SWNodeBase> GetParentNodeAllAllList()
		{
			List<SWNodeBase> list = new List<SWNodeBase> ();
			foreach (var item in GetParentNodeAllAll()) {
				list.Add (item.Value);
			}
			list.Reverse ();
			return list;
		}
		public Dictionary<string,SWNodeBase> GetParentNodeAllAll()
		{
			Dictionary<string,SWNodeBase> dic = new Dictionary<string, SWNodeBase> ();
			foreach (var item in  data.parent) {
				GetParentNodeAllAllSub (dic, SWWindowMain.Instance.NodeAll () [item]);
			}
			return dic;
		}
		public void GetParentNodeAllAllSub( Dictionary<string,SWNodeBase> dic,SWNodeBase e)
		{
			if(!dic.ContainsKey(e.data.id))
				dic.Add (e.data.id,e);
			foreach (var item in  e.data.parent) {
				GetParentNodeAllAllSub (dic, SWWindowMain.Instance.NodeAll () [item]);
			}
		}
		public Dictionary<string,SWNodeBase> GetChildNodeAllAll()
		{
			Dictionary<string,SWNodeBase> dic = new Dictionary<string, SWNodeBase> ();
			foreach (var item in  data.children) {
				GetChildNodeAllAllSub (dic, SWWindowMain.Instance.NodeAll () [item]);
			}
			return dic;
		}
		public void GetChildNodeAllAllSub( Dictionary<string,SWNodeBase> dic,SWNodeBase e)
		{
			if(!dic.ContainsKey(e.data.id))
				dic.Add (e.data.id,e);
			foreach (var item in  data.children) {
				GetChildNodeAllAllSub (dic, SWWindowMain.Instance.NodeAll () [item]);
			}
		}


	


		public SWNodeBase GetParentNode()
		{
			if (data.parent.Count == 0)
				return null;

			return SWWindowMain.Instance.NodeAll() [data.parent [0]];
		}

		public List<SWNodeBase> GetParentNodes()
		{
			List<SWNodeBase> parentNodes = new List<SWNodeBase> ();
			var pnode = GetParentNode ();
			while (pnode != null) {
				parentNodes.Add (pnode);
				pnode = pnode.GetParentNode ();
			}
			parentNodes.Reverse ();
			return parentNodes;
		}



		public bool HasParent()
		{ 
			return data.parent.Count>0 && SWWindowMain.Instance.NodeAll().ContainsKey( data.parent[0]);
		}
		public bool HasChild()
		{
			return data.children.Count > 0 && SWWindowMain.Instance.NodeAll().ContainsKey( data.children[0]);
		}
		#endregion

		#region child
		public Rect GetRectRight(string parent)
		{
			int id = data.parent.IndexOf (parent);
			int index = data.parentPort [id];
			return rectRights [index];
		}
		public Rect GetRectLeft(string children)
		{
			int id = data.children.IndexOf (children);
			int index = data.childrenPort [id];
			return rectLefts [index];
		}

		public void DeleteAllParent()
		{
			for (int i = data.parent.Count - 1; i >= 0; i--) {
				string obj = data.parent [i];
				RemoveConnection (SWWindowMain.Instance.NodeAll () [obj],this);
			}
		}

		public void DeleteAllChild()
		{
			for (int i = data.children.Count - 1; i >= 0; i--) {
				string obj = data.children [i];
				RemoveConnection (this, SWWindowMain.Instance.NodeAll () [obj]);
			}
		}

		public static void AddConnection(SWNodeBase leftNode,int leftPort,SWNodeBase rightNode,int rightPort)
		{
			leftNode.data.parent.Add(rightNode.data.id);
			leftNode.data.parentPort.Add (leftPort);


			rightNode.data.children.Add(leftNode.data.id);
			rightNode.data.childrenPort.Add (rightPort);
		}

		public static void RemoveConnection(SWNodeBase parent,SWNodeBase child)
		{
			int id = parent.data.children.IndexOf (child.data.id);
			parent.data.children.RemoveAt (id);
			parent.data.childrenPort.RemoveAt (id);

			id = child.data.parent.IndexOf (parent.data.id);
			child.data.parent.RemoveAt (id);
			child.data.parentPort.RemoveAt (id);
		}

		#endregion
		#endregion



		#region update
		public virtual void Update()
		{
			ReImport ();
		}


		public virtual void ReImport() {
			if (Texture != null) {
				try
				{
					Texture.GetPixel(0, 0);
				}
				catch(UnityException e)
				{
					SWCommon.TextureReImport (Texture);
				}
			}
		}
		#endregion

		#region ui
		public void Draw()
		{
			data.rect = GUI.Window(index, data.rect, DrawNodeWindow, "",Style); 
	//		GUI.BeginGroup(data.rect);
	//		DrawNodeWindow(0);
	//		GUI.EndGroup();
			DrawHead ();


			if (SWWindowMain.Instance.selection.Contains (data.id)) {
				Rect frameRect = SWCommon.GetRect (data.rect.center, new Vector2(
					data.rect.size.x + 20f,data.rect.size.y + 18f));
				GUI.Box (frameRect, "", SWEditorUI.Style_Get (SWCustomStyle.eNodeSelected));
			}
		}

		public bool LeftAvailable()
		{
			if (data.inputType.Count > 0)
				return true;
			return false;
		}
		public bool RightAvailable()
		{
			if (data.outputType.Count > 0)
				return true;
			return false;
		}
			

		protected virtual void DrawLeftRect(int id,Rect rect)
		{
			
		}
		protected virtual void DrawRightRect(int id,Rect rect)
		{

		}

		void SetRectsAll()
		{
			SetRects (rectLefts, data.rect.x - portWidth, data.childPortNumber);
			SetRects (rectRights,data.rect.x + data.rect.width, data.parentPortNumber);
		}
		void SetRects(List<Rect> rects, float xPos,int count = 1)
		{
			float spacing = 5;
			rects.Clear ();
			for (int i = 0; i < count; i++) {
				rects.Add(new Rect (xPos, data.rect.y+data.rect.height * 0.5f - portHeight * 0.5f  
					- count/2 * (spacing+portHeight) + (spacing+portHeight)*i
					, portWidth, portHeight));
			}
		}


		protected virtual void DrawHead()
		{
			
			SetRectsAll ();

			rectBig = new Rect ();
			rectBig.size = data.rect.size * 1.25f;
			rectBig.center = data.rect.center + new Vector2 (0, -10);

			if (LeftAvailable()) {
				if (!SWWindowMain.Instance.lineStartNodeFromLeft && SWWindowMain.Instance.lineStartNode != null && NodeMatch (this, SWWindowMain.Instance.lineStartNode))
					GUI.color = SWEditorUI.ColorPalette (SWColorPl.green);
				else
					GUI.color = SWEditorUI.ColorPalette (SWColorPl.light);

				foreach(var rect in rectLefts)
					GUI.DrawTexture (rect, EditorGUIUtility.whiteTexture);
				GUI.color = Color.white;
			}

			if (RightAvailable()) {
				if (SWWindowMain.Instance.lineStartNodeFromLeft && SWWindowMain.Instance.lineStartNode != null && NodeMatch (SWWindowMain.Instance.lineStartNode, this))
					GUI.color = SWEditorUI.ColorPalette (SWColorPl.green);
				else
					GUI.color = SWEditorUI.ColorPalette (SWColorPl.light);
				if (data.type != SWNodeType.root) {
				
					foreach(var rect in rectRights)
						GUI.DrawTexture (rect, EditorGUIUtility.whiteTexture);
				}
				GUI.color = Color.white;
			}

			for (int i = 0; i < rectLefts.Count; i++) {
				DrawLeftRect (i,rectLefts[i]);
			}
			for (int i = 0; i < rectRights.Count; i++) {
				DrawRightRect (i,rectRights[i]);
			}
		}

		protected virtual void DrawNodeWindow(int id) {
			if ((this is SWNodeRoot) || !titleEditing) {
				GUI.Label (rectTop, data.name, SWEditorUI.Style_Get (SWCustomStyle.eNodeTitle));
				if (Event.current.type == EventType.mouseUp &&
				    rectTop.Contains (Event.current.mousePosition)) {
					titleEditing = true;
					nameEditing = data.name;
				}
			} else {
				if (Event.current.type == EventType.KeyUp && Event.current.keyCode == KeyCode.Return) {
					titleEditing = false;

					nameEditing = SWCommon.NameLegal(nameEditing);
					if (NameUnique (nameEditing)) {
						data.name = SWCommon.NameLegal(nameEditing);
					}
				}
				nameEditing = EditorGUI.TextField (rectTop, nameEditing,SWEditorUI.Style_Get (SWCustomStyle.eNodeTitle));
			}
			GUILayout.Space (headerHeight);
		}
	
		protected void SelectTexture()
		{
			var tex = (Texture2D)EditorGUI.ObjectField (rectArea, texture, typeof(Texture2D), true);
			if (tex != texture) {
				SWUndo.Record (this);
				texture = tex;


				//iNormal
				string assetPath = AssetDatabase.GetAssetPath( texture );
				var tImporter = AssetImporter.GetAtPath( assetPath ) as TextureImporter;
				data.useNormal = tImporter.textureType == TextureImporterType.NormalMap;
			}
		}
		protected void SelectTextureGray()
		{
			var tex = (Texture2D)EditorGUI.ObjectField (rectArea, textureGray, typeof(Texture2D), true);
			if (tex != textureGray) {
				SWUndo.Record (this);
				textureGray = tex;
			}
		}

		bool NameUnique(string name)
		{
			if (string.IsNullOrEmpty (name))
				return false;
			foreach (var item in SWWindowMain.Instance.NodeAll()) {
				if (item.Value.data.name == name)
					return false;
			}
			return true;
		}

		protected virtual void DrawNodeWindowEnd() {
		}
		public virtual void DrawSelection() {
		}
		#endregion

		public static bool NodeMatch(SWNodeBase parent,SWNodeBase child)
		{
			//cant connect self
			if (parent.data.id == child.data.id)
				return false;
			//connected already
			if (parent.data.children.Contains (child.data.id))
				return false;
			//cant connect circle
			if (parent.GetParentNodeAllAll ().ContainsKey (child.data.id))
				return false;

			foreach (var item in parent.data.inputType) {
				if (child.data.outputType.Contains (item))
					return true;
			}
			return false;
		}

		public virtual void BeforeSave()
		{
			if (texture != null) {
				data.textureGUID = SWEditorTools.ObjectToGUID (texture);
			} else {
				data.textureGUID = "";
			}

			if (textureGray != null) {
				data.textureGUIDGray = SWEditorTools.ObjectToGUID (textureGray);
			} else {
				data.textureGUIDGray = "";
			}
			if (!textureEx.IsNull) {
				data.textureExGUID = SWEditorTools.ObjectToGUID (textureEx);
			} else {
				data.textureExGUID = "";
			}


			if (sprite != null) {
				data.spriteName = sprite.name;
				data.spriteGUID =  SWEditorTools.ObjectToGUID(sprite);
			}
		}
		public virtual void AfterLoad()
		{
			if (!string.IsNullOrEmpty (data.textureGUID)) {
				texture = SWEditorTools.GUIDToObject<Texture2D>(data.textureGUID);
			}
			if (!string.IsNullOrEmpty (data.textureGUIDGray)) {
				textureGray = SWEditorTools.GUIDToObject<Texture2D>(data.textureGUIDGray);
			}
			if (!string.IsNullOrEmpty (data.textureExGUID)) {
				var tex  = SWEditorTools.GUIDToObject<Texture2D>(data.textureExGUID);
				textureEx = new SWTexture2DEx (tex);
			}

			if (!string.IsNullOrEmpty (data.spriteGUID)) {
				string path = AssetDatabase.GUIDToAssetPath (data.spriteGUID);
				Object[] objs = AssetDatabase.LoadAllAssetsAtPath (path);
				foreach (var item in objs) {
					if (item is Sprite && item.name == data.spriteName) {
						//Debug.Log ("Found");
						sprite = (Sprite)item;
					}
				}
			}
		}

		public virtual void OnEnable()
		{
			hideFlags = HideFlags.DontSave;
		}
			
		/// <summary>
		/// True:This node is under root tree or root itself
		/// </summary>
		public bool BelongRootTree()
		{
			Dictionary<string,SWNodeBase> allNodes = SWWindowMain.Instance.NodeAll ();
			return BelongRootTreeSub (allNodes, this);
		}

		protected bool BelongRootTreeSub(Dictionary<string,SWNodeBase> allNodes,SWNodeBase node)
		{
			if (node.data.type == SWNodeType.root)
				return true;
			else {
				foreach (var item in node.data.parent) {
					if (BelongRootTreeSub (allNodes, allNodes [item]))
						return true;
				}
			}
			return false;
		}

		public bool HasColorAttribute()
		{
			return data.outputType.Count == 1 && data.outputType [0] == SWDataType._Color;
		}
	}
}