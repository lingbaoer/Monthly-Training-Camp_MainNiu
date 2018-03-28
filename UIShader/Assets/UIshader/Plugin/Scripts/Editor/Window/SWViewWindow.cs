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
	/// Manage preview
	/// </summary>
	[System.Serializable]
	public class SWViewWindow{
		[SerializeField]
		private Vector3 startPos = new Vector3 (0, -10000, 0);
		[SerializeField]
		public SWPreview preview;
		[SerializeField]
		string name = "preview";
		[SerializeField]
		public Material material;
		[SerializeField]
		public float scale = 2;
		[SerializeField]
		public int largePreviewCounter = 0;

		public SWViewWindow()
		{  
		}

		void Init()
		{
			if (preview == null) {
				GameObject obj = GameObject.Find(name);
				if (obj == null) {
					GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject> (
						SWCommon.ProductFolder()+"/Prefabs/Preview.prefab");
					obj = GameObject.Instantiate (prefab);
					obj.name = name;
					obj.hideFlags = HideFlags.HideInHierarchy;
				}
				preview = obj.GetComponent<SWPreview> ();
				preview.Init (startPos);
			}
		}
			
		public void SetMaterial(Material mat,SWData data,Sprite sprite)
		{
			Init ();
			material = mat;
			preview.SetMaterial (mat, data,sprite);
		}

		public void OnGUI(Rect rect)
		{
			Init ();
			if (preview.cam == null)
				return;
			preview.cam.Render();
			if(SWWindowMain.Instance.data.shaderType == SWShaderType.normal)
				rect = NewRect (rect);
			if(SWWindowMain.Instance.data.shaderType == SWShaderType.sprite 
				||SWWindowMain.Instance.data.shaderType == SWShaderType.ui)
				rect = NewRectSprite (rect);


			if (material != null) {
				if (GUI.Button (rect, "", GUIStyle.none)) {
					Selection.activeObject = material;
					EditorGUIUtility.PingObject (material);
				}

				if (EditorWindow.mouseOverWindow == SWWindowMain.Instance && rect.Contains (Event.current.mousePosition)) {
					largePreviewCounter++;
					if (largePreviewCounter > 120)
						rect = largeRect (rect, scale);
				} else {
					largePreviewCounter = 0;
				}
			}
			GUI.DrawTexture(rect, preview.cam.targetTexture);   
		}

		Rect largeRect(Rect rect,float mul)
		{
			rect = new Rect (rect.x - rect.width*(mul-1), rect.y, rect.width*mul, rect.height*mul);
			return rect;
		}

		public Rect NewRect(Rect rect)
		{
			float ratio = 1;
			if (SWWindowMain.Instance != null 
				&& SWWindowMain.Instance.nRoot != null 
				&& SWWindowMain.Instance.nRoot.texture != null) {

				var tex = SWWindowMain.Instance.nRoot.texture;
				ratio = (float)tex.width / (float)tex.height;
				var center = rect.center;
				var size = rect.size;
				if (ratio >= 1) {
					size = new Vector2 (size.x, size.y/ratio);
				} else {
					size = new Vector2 (size.x * ratio, size.y);
				}
				return SWCommon.RectNew (center, size);
			}
			return rect;
		}
		public Rect NewRectSprite(Rect rect)
		{
			float ratio = 1;
			if (SWWindowMain.Instance != null 
				&& SWWindowMain.Instance.nRoot != null 
				&& SWWindowMain.Instance.nRoot.sprite != null) {

				var tex = SWWindowMain.Instance.nRoot.sprite.rect;
				ratio = (float)tex.width / (float)tex.height;
				var center = rect.center;
				var size = rect.size;
				if (ratio >= 1) {
					size = new Vector2 (size.x, size.y/ratio);
				} else {
					size = new Vector2 (size.x * ratio, size.y);
				}
				return SWCommon.RectNew (center, size);
			}
			return rect;
		}



		public void Clean()
		{
			if (preview == null)
				return;
			if(preview.cam!=null && preview.cam.targetTexture != null)
				GameObject.DestroyImmediate (preview.cam.targetTexture);
			GameObject.DestroyImmediate (preview.gameObject);
		}
	}
}

