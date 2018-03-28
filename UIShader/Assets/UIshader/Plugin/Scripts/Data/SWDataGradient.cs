//----------------------------------------------
//            Shader Weaver
//      Copyright© 2017 Jackie Lo
//----------------------------------------------
namespace ShaderWeaver
{
	using UnityEngine;
	using System.Collections;
	using System.Collections.Generic;
	using System;


	[Serializable]
	public enum SWGradientMode
	{
		no,
		select,
		move,
	}

	[Serializable]
	public class SWGradientFrame
	{
		[SerializeField]
		public float time; 
		[SerializeField]
		public float value=1;
	}

	[Serializable]
	public class SWGradient
	{
		private Texture2D tex;
		public Texture2D Tex
		{
			get{
				if (tex == null) {
					tex = new Texture2D (512, 1,TextureFormat.ARGB32,false,true);
					tex.wrapMode = TextureWrapMode.Clamp;
					tex.filterMode = FilterMode.Point;
				}

				var pixel = tex.GetPixels ();
				for (int i = 0; i < pixel.Length; i++) {
					var value = Evaluate ((float)i / pixel.Length);
					pixel [i] = new Color (0, value, 0, value);
				}
				tex.SetPixels (pixel);
				tex.Apply ();
				return tex;
			}
		}


		[SerializeField]
		public List<SWGradientFrame> frames = new List<SWGradientFrame> ();
		public void Sort()
		{
			frames.Sort (delegate(SWGradientFrame x, SWGradientFrame y) {
				if(x.time > y.time)
					return 1;
				if(x.time < y.time)
					return -1;
				return 0;
			});
		}

		public float Evaluate(float time)
		{
			int count = frames.Count;
			if(frames.Count ==0)
				return 0;
			if(time < frames[0].time)
				return 0;
			if(time > frames[count-1].time)
				return 0;


			for(int i= 1;i<count;i++)
			{
				if(time <= frames[i].time)
				{
					float v1= frames[i-1].value;;
					float v2=frames[i].value;
					float t1= frames[i-1].time;
					float t2= frames[i].time;
					return Mathf.Lerp(v1,v2, (time - t1) / (t2-t1));
				}
			}
			return 0;
		}
	}
}