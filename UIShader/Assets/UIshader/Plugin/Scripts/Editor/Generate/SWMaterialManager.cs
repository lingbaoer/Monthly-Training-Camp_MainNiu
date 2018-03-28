//----------------------------------------------
//            Shader Weaver
//      Copyright© 2017 Jackie Lo
//----------------------------------------------
namespace ShaderWeaver
{
	using UnityEngine;
	using System.Collections;
	using System.Collections.Generic;
	using System.IO;
	using UnityEditor;

	/// <summary>
	/// Create material
	/// </summary>
	public class SWMaterialManager{
		public static Material CreateMaterial(SWWindowMain edit)
		{
			foreach (var item in edit.NodeAll()) {
				item.Value.shaderOutput = null;
			}

			SWShaderCreaterBase sc = null;
			if (edit.data.shaderType == SWShaderType.normal) {
				sc = new SWShaderCreaterBase (edit);
			}
			if (edit.data.shaderType == SWShaderType.ui) {
				sc = new SWShaderCreaterUI (edit);
			}
			if (edit.data.shaderType == SWShaderType.uiFont) {
				sc = new SWShaderCreaterUIFont (edit);
			}
			if (edit.data.shaderType == SWShaderType.sprite) {
				if(edit.data.spriteLightType == SWSpriteLightType.no)
					sc = new SWShaderCreaterSprite (edit);
				else if(edit.data.spriteLightType == SWSpriteLightType.diffuse)
					sc = new SWShaderCreaterSpriteLight (edit);
			}

			float f = Time.realtimeSinceStartup;


			string txt = sc.CreateShaderText();
			var shader = CreateShader (edit,txt);

			string path = "";
			if (edit.newCopy || string.IsNullOrEmpty (edit.data.materialGUID)) 
				path = string.Format ("{0}{1}.mat", edit.folderPath, edit.data.title);
			else
				path = SWCommon.AssetDBPath2Path(AssetDatabase.GUIDToAssetPath (edit.data.materialGUID));
				
			Material m = AssetDatabase.LoadAssetAtPath<Material> (SWCommon.Path2AssetDBPath(path));
			if (m == null) {
				m = new Material (shader);
				SetMaterialProp (m, edit);
				m = SWCommon.SaveReload<Material> (m, path);
			} else {
				m.shader = shader;
				SetMaterialProp (m, edit);
			}
			edit.data.materialGUID = SWEditorTools.ObjectToGUID (m);
			return m;
		}


		private static Shader CreateShader(SWWindowMain edit,string txt)
		{
			string path = string.Format ("{0}{1}.shader", edit.folderPath, edit.data.title);
			string fullPath = SWCommon.Path2FullPath (path);
			string adbPath =  SWCommon.Path2AssetDBPath (path);
//			string guid = AssetDatabase.AssetPathToGUID (adbPath);
			File.WriteAllText(fullPath, txt );    
			AssetDatabase.ImportAsset(adbPath, ImportAssetOptions.ForceUpdate);
			Shader currentShader = AssetDatabase.LoadAssetAtPath<Shader> ( adbPath);
			return currentShader;
		}
		private static void SetMaterialProp(Material m,SWWindowMain edit)
		{
			foreach (var item in edit.textures) {
				if(item.Value !=null)
					m.SetTexture (item.Key, item.Value);
			}


			foreach (var item in edit.nodes) {
				if (item.HasColorAttribute ()) {
					if(item.data.type == SWNodeType.root)
						m.SetColor (string.Format ("_Color"),item.data.effectDataColor.color);
					else
						m.SetColor (string.Format ("_Color{0}", item.data.iName),item.data.effectDataColor.color);
				}
			}
		}
	}
}