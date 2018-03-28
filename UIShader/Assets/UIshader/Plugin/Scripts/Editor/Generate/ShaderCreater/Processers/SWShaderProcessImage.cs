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


	public class SWShaderProcessImage:SWShaderProcessBase{
		public  SWShaderProcessImage():base()
		{
			type = SWNodeType.image;
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

		public override void ProcessSub (SWOutputSub sub)
		{
			base.ProcessSub (sub);
			StringAddLine( string.Format("\t\t\t\tcolor{0} = color{0}*_Color{0};",node.data.iName));
			sub.type = SWDataType._Color;
			sub.param = string.Format ("color{0}", node.data.iName);
			sub.op = node.data.effectDataColor.op;
			sub.opFactor =string.Format("{0}*({1})",sub.opFactor,node.data.effectDataColor.param);
			foreach(var outp in childOutputs)
				foreach (var item in outp.outputs) {
					if (item.type == SWDataType._Remap) {
						StringAddLine( string.Format ("\t\t\t\tcolor{0} = float4(color{0}.rgb,color{0}.a*{1});", node.data.iName,item.opFactor));
					}
				}
		} 
	}
}