using System.Collections;//----------------------------------------------
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


	public class SWShaderProcessOutline:SWShaderProcessBase{
		public  SWShaderProcessOutline():base()
		{
			type = SWNodeType.outline;
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

		public override SWOutput Process (SWNodeBase _node)
		{
			node = _node;
			SWOutput sw = new SWOutput ();
			SWOutputSub sub = new SWOutputSub ();
			sub.type = SWDataType._UV;
			sub.processor = this;
			sub.opFactor = string.Format ("float2( {0}*{1} ,{2}*{3})", node.data.blurX, node.data.blurXParam, node.data.blurY, node.data.blurYParam);
			sw.outputs.Add (sub);
			return sw;
		}
	}

	public class SWShaderProcessReceiveOutline:SWShaderProcessReceiveBase{
		public SWShaderProcessReceiveOutline():base()
		{
			type = SWNodeType.outline;
		}
		public override void ProcessOutput (SWShaderProcessBase processor, string keyword = "")
		{
			base.ProcessOutput (processor, keyword);
			processor.StringAddLine (string.Format ("\t\t\t\tfloat4 color{0} = float4(0,0,0,0);", processor.node.data.iName));

			foreach (var outp in processor.childOutputs) {
				foreach (var item in outp.outputs) {
					if (item.data.type == type) {
						ProcessOutpBlur(processor, item);
					}
				}
			}
		}
		protected void ProcessOutpBlur(SWShaderProcessBase processor, SWOutputSub sub)
		{
			string uvParam = string.Format ("uv{0}", processor.node.data.iName);
			processor.StringAddLine (string.Format ("\t\t\t\t\tcolor{0} = Blur(_{1},{2},{3});", processor.node.data.iName,processor.node.TextureShaderName(),uvParam,sub.opFactor));
		}
	}
}