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


	public class SWShaderProcessColor:SWShaderProcessImage{
		public  SWShaderProcessColor():base()
		{
			type = SWNodeType.color;
			receiveOutputTypes.Add (SWNodeType.alpha);
			receiveOutputTypes.Add (SWNodeType.refract);
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
			CommentHead ();
			Child_Process ();

			StringAddLine (string.Format ("\t\t\t\tfloat4 color{0} = _Color{0};", node.data.iName));
			GoOutput (SWNodeType.alpha);



			SWOutputSub sub = new SWOutputSub ();
			sub.processor = this;
			sub.depth = node.data.depth;
			sub.param = string.Format ("color{0}",node.data.iName);
			sub.op = node.data.effectDataColor.op;
			sub.opFactor =string.Format("{0}*({1})",sub.opFactor,node.data.effectDataColor.param);
			result.outputs.Add (sub);
			return result;
		}
	}


	public class SWShaderProcessReceiveColor:SWShaderProcessReceiveBase{
		public SWShaderProcessReceiveColor():base()
		{
			type = SWNodeType.color;
		}








		/// <summary>
		/// Add:Keep alpha,only add rgb
		/// Mul:Simple multiple color
		/// Lerp:
		/// </summary>
		public override void ProcessOutputSingle (SWShaderProcessBase processor, SWOutputSub item,bool first)
		{
			base.ProcessOutputSingle (processor, item,first);
			if (first) {
				processor.StringAddLine (string.Format ("\t\t\t\tresult = {0};", item.param, item.opFactor));
				return;
			}

			if (item.op == SWOutputOP.blend) {
				processor.StringAddLine( string.Format ("\t\t\t\tresult = lerp(result,float4({0}.rgb,1),clamp({0}.a*{1},0,1));    ",
					item.param, item.opFactor));
			}
			if (item.op == SWOutputOP.blendInner) {
				processor.StringAddLine( string.Format ("\t\t\t\tresult = lerp(result,float4({0}.rgb,rootTexColor.a),clamp({0}.a*{1},0,1));    ",
					item.param, item.opFactor));
//				processor.StringAddLine( string.Format ("\t\t\t\tresult = lerp(result,float4({0}.rgb,result.a),clamp({0}.a*{1},0,1));    ",
//					item.param, item.opFactor));
			}


			if(item.op == SWOutputOP.add)
				processor.StringAddLine( string.Format("\t\t\t\tresult = result+float4({0}.rgb*{0}.a*{1},{0}.a*{1});",item.param,item.opFactor));
			if (item.op == SWOutputOP.addInner) {
				processor.StringAddLine( string.Format("\t\t\t\tresult = result+float4({0}.rgb*{0}.a*{1},{0}.a*{1}*(rootTexColor.a - result.a));",item.param,item.opFactor));
				//processor.StringAddLine( string.Format("\t\t\t\tresult = result+float4({0}.rgb*{0}.a*{1},0);",item.param,item.opFactor));
			}



			if (item.op == SWOutputOP.mul)
				processor.StringAddLine (string.Format ("result = result *lerp(float4(1,1,1,1),{0},{0}.a*{1});",item.param,item.opFactor));
			if (item.op == SWOutputOP.mulIntersect) {
				processor.StringAddLine( string.Format("\t\t\t\tresult = result*{0}*{1};",item.param,item.opFactor));
			}
		}
	}
}