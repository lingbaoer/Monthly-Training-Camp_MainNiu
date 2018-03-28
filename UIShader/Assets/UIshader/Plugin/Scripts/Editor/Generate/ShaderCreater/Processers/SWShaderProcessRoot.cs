using System.Collections;
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
	using System;


	public class SWShaderProcessRoot:SWShaderProcessBase{
		List<SWOutputSub> colors = new List<SWOutputSub> ();
		public  SWShaderProcessRoot():base()
		{
			type = SWNodeType.root;
			receiveOutputTypes.Add (SWNodeType.alpha);
			receiveOutputTypes.Add (SWNodeType.blur);
			receiveOutputTypes.Add (SWNodeType.cartoon);
			receiveOutputTypes.Add (SWNodeType.color);
			receiveOutputTypes.Add (SWNodeType.mask);
			receiveOutputTypes.Add (SWNodeType.outline);
			receiveOutputTypes.Add (SWNodeType.refract);
			receiveOutputTypes.Add (SWNodeType.reflect);
			receiveOutputTypes.Add (SWNodeType.remap);
			receiveOutputTypes.Add (SWNodeType.retro);
			receiveOutputTypes.Add (SWNodeType.root);
			receiveOutputTypes.Add (SWNodeType.uv);
		}

		/// <summary>
		/// For Root Node. 
		/// Default/Sprite/UI:
		/// will be computed in full rect,so uv set to full rect UV here.        
		/// Sprite/UI:
		/// UV will transit to sprite rect before sampling. 
		/// UIText:
		/// Sprite has one sprite rect at one time, but UIText has multiple rects for letters.
		/// So UIText will be computed in atlas space, so just pass atlas space(texcoord) here directly
		/// </summary>
		protected override void UVParamInit ()
		{
			uvParam = string.Format ("uv{0}", node.data.iName);
			if(SWShaderCreaterBase.Instance is SWShaderCreaterUIFont)
				StringAddLine( string.Format("\t\t\t\tfloat2  {0} = i._uv_MainTex;",uvParam));
			else
				StringAddLine( string.Format("\t\t\t\tfloat2  {0} = i._uv_STD;",uvParam));
		}

		public override void AfterAllTextureSample ()
		{
			if (SWShaderCreaterBase.Instance.IsTextureSampleAdd)
				StringAddLine (string.Format("\t\t\t\tcolor{0} += _TextureSampleAdd;",node.data.iName));
			base.AfterAllTextureSample ();
		}

		public override SWOutput Process(SWNodeBase _node)
		{
			
			//step 1: Add colors
			colors = new List<SWOutputSub> ();

			if (window.data.excludeRoot) {
				node = _node;
				Child_Process ();
			} else {
				base.Process (_node);
			}
			foreach (var item in childOutputs) {
				foreach (var item2 in item.outputs) {
					if (item2.type == SWDataType._Color) {
						colors.Add (item2);
					}
				}
			}


			//step 2: Process colors
			colors.Sort (delegate(SWOutputSub x, SWOutputSub y) {
				return x.depth - y.depth;	
			});
			var c = new SWShaderProcessReceiveColor ();

			for (int i = 0; i < colors.Count; i++) {
				var item = colors [i];
				c.ProcessOutputSingle (this,item,i == 0);
			}

			//step 3: Process Alpha
			GoOutput (SWNodeType.alpha,"final");
			return null;
		}

		public override void ProcessSub (SWOutputSub sub)
		{
			base.ProcessSub (sub);
			StringAddLine( string.Format("\t\t\t\tfloat4 rootTexColor = color{0};",node.data.iName));
			StringAddLine( string.Format("\t\t\t\tcolor{0} = color{0}*_Color{0};",node.data.iName));
			sub.depth = 0;
			sub.type = SWDataType._Color;
			sub.op = SWOutputOP.blend;
			sub.param = string.Format ("color{0}", node.data.iName);
			sub.opFactor = "1";
			colors.Add (sub);
		}
	}
}