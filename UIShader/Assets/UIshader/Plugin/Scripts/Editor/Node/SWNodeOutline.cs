//----------------------------------------------
//            Shader Weaver
//      Copyright© 2017 Jackie Lo
//----------------------------------------------
namespace ShaderWeaver
{
	using UnityEngine;
	using System.Collections;
	using UnityEditor;
	using System;

	[System.Serializable]
	public class SWNodeOutline :SWNodeBase {

		public override void Init (SWDataNode _data, SWWindowMain _window)
		{
			nodeWidth = NodeWidth + 70;
			nodeHeight = NodeHeight;

			base.Init (_data, _window);
			data.outputType.Add (SWDataType._UV);
			//data.inputType.Add (SWDataType._Color);
		}

		protected override void DrawHead ()
		{
			base.DrawHead ();
		}

		protected override void DrawNodeWindow (int id)
		{
			base.DrawNodeWindow (id);
			DrawNodeWindowEnd ();
		}


		public override void DrawSelection ()  
		{
			base.DrawSelection ();
		}


		#region save load
		public override void BeforeSave ()
		{
			base.BeforeSave ();
		}

		public override void AfterLoad ()
		{
			base.AfterLoad ();
		}
		#endregion
	}
}