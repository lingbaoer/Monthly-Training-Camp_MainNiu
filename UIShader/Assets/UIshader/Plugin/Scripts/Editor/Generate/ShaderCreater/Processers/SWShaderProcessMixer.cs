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


	public class SWShaderProcessMixer:SWShaderProcessBase{
		public  SWShaderProcessMixer():base()
		{
			type = SWNodeType.mixer;
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

		public override bool ProcessCondition ()
		{
			return node.HasChild ();
		}

		public override void ProcessSub (SWOutputSub sub)
		{
			int MaxCount = SWNodeMixer.Gradient_MaxFrameCount ();
			string alphaParam = string.Format ("mixer{0}", node.data.iName);
			StringAddLine (string.Format ("\t\t\t\tfloat {0} = {1} +{2}*({3}) + color{4}.{5};",
				alphaParam,
				node.data.effectData.pop_startValue,
				node.data.effectData.pop_speed,
				node.data.effectData.pop_Param,
				node.data.iName,
				node.data.effectData.pop_channel.ToString()));
			StringAddLine (string.Format ("\t\t\t\t{0} = clamp({0},{1},{2});",alphaParam,node.data.effectData.pop_min,node.data.effectData.pop_max));





			for (int i = 0; i < node.data.gradients.Count; i++) {
				string graParam = string.Format ("gra{0}_{1}",node.data.iName,i);
				var frames = node.data.gradients [i].frames;
				if (frames.Count == 0) {
					StringAddLine (string.Format ("\t\t\t\tfloat {0} = 0;",graParam));
				} else {
					string strList = (string.Format ("\t\t\t\tfloat {0}ListTime[{1}] = {{", graParam, MaxCount));
					for (int j = 0; j < MaxCount; j++) {
						if (j < frames.Count)
							strList += ("" + node.data.gradients [i].frames [j].time);
						else
							strList += ("-1");
						if (j != MaxCount - 1)
							strList += (",");
					}
					strList += ("};");
					StringAddLine (strList);


					strList = (string.Format ("\t\t\t\tfloat {0}ListValue[{1}] = {{", graParam, MaxCount));
					for (int j = 0; j < MaxCount; j++) {
						if (j < frames.Count)
							strList += ("" + node.data.gradients [i].frames [j].value);
						else
							strList += ("-1");
						if (j != MaxCount - 1)
							strList += (",");
					}
					strList += ("};");
					StringAddLine (strList);

					StringAddLine (string.Format ("\t\t\t\tfloat {0} = GradientEvaluate({0}ListTime,{0}ListValue,{1},{2});", graParam, frames.Count, alphaParam));
				}
			}

			PortBelong ();

			foreach (var op in childOutputs) {
				foreach (var item in op.outputs) {
					int index = portBelongs [item.node.data.id];
					string graParam = string.Format ("gra{0}_{1}",node.data.iName,index);
					item.opFactor =string.Format("{0}*{1}",item.opFactor,graParam);
					result.outputs.Add (item);
				}
			}
		}


		Dictionary<string,int> portBelongs = new Dictionary<string, int> ();
		void PortBelong()
		{
			for (int i = 0; i < node.data.children.Count; i++) {
				PortTraverse (node.data.children [i], node.data.childrenPort [i]);
			}
		}

		void PortTraverse(string node,int id)
		{
			if (!portBelongs.ContainsKey (node)) {
				portBelongs.Add (node, id);
			}
			foreach (var item in SWWindowMain.Instance.NodeAll()[node].data.children) {
				PortTraverse (item, id);
			}
		}
	}
}