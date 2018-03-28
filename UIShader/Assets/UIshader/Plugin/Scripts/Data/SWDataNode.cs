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
	public enum SWLoopMode
	{
		loop=0,
		single=1
	}



	[Serializable]
	public enum SWChannel
	{
		r,
		g,
		b,
		a
	}

	[Serializable]
	public enum SWOutputOP
	{
		blend = 0,
		blendInner = 1,
		add = 2,
		addInner=3,
		mul =4,
		mulIntersect=5,
	}

	[Serializable]
	public enum SWUVop
	{
		add,
		lerp
	}

	[Serializable]
	public enum SWParamType
	{
		RANGE,
		FLOAT
	}

	[Serializable]
	public class SWParam
	{
		public SWParamType type;
		public string name;
		public float min = 0;
		public float max = 1;
		public float defaultValue;
		public SWParam()
		{

		}
		public SWParam(string _name)
		{
			name = _name;
		}
	}
	[Serializable]
	public enum SWNodeType
	{
		root,
		mask,
		remap,
		color,
		uv,
		alpha,
		blur,
		retro,
		cartoon,
		outline,
		refract,
		reflect,
		mixer,
		image
	}

	[Serializable]
	public enum SWDataType
	{
		_Color,
		_UV,
		_Remap,
		_Alpha,
	}

	[Serializable]
	public class EffectData
	{
		public Vector2 t_startMove = Vector2.zero;
		public float r_angle = 0;
		public Vector2 s_scale = new Vector2(1f,1f);

		public Vector2 t_speed = Vector2.zero;
		public float r_speed = 0;
		public Vector2 s_speed = Vector2.zero;

		public string t_Param = "_Time.y";
		public string r_Param = "_Time.y";
		public string s_Param = "_Time.y";

		#region use for Alpha/Mixer Node 

		/// <summary>
		/// Alpha apply only to one node or apply to final graphic
		/// </summary>
		public bool pop_final;
		public float pop_min = 0;
		public float pop_max = 1;
		public float pop_startValue = 0;
		public float pop_speed = 0;
		public string pop_Param = "(1)";
		public SWChannel pop_channel = SWChannel.a;
		#endregion

		public bool useLoop = true;
		public SWLoopMode loopX = SWLoopMode.loop;
		public float gapX;
		public SWLoopMode loopY = SWLoopMode.loop;
		public float gapY;

		#region texture sheet animation
		public bool animationSheetUse;
		public int animationSheetCountX = 1;
		public int animationSheetCountY = 1;
		public bool animationSheetLoop = true;
		public bool animationSheetSingleRow;
		public int animationSheetSingleRowIndex;
		public int animationSheetStartFrame;
		public string animationSheetFrameFactor = "_Time.y";
		#endregion
	} 

	/// <summary>
	/// Use by nodes: Color Refraction Reflection
	/// </summary>
	[Serializable]
	public class EffectDataColor
	{
		public bool hdr;
		public Color color = Color.white;
		public SWOutputOP op;
		/// <summary>
		/// WRONG NAMING.It is opFactor
		/// For op, lerp/add factor
		/// </summary>
		public string param="(1)";
	}

	/// <summary>
	/// Use by UV node
	/// </summary>
	[Serializable]
	public class EffectDataUV
	{
		public SWUVop op;
		/// <summary>
		/// WRONG NAMING.It is opFactor
		/// For op, lerp/add factor
		/// </summary>
		public string param="(1)";

		public Vector2 amountR;
		public Vector2 amountG;
		public Vector2 amountB;
		public Vector2 amountA;
	}

	/// <summary>
	/// Data for each node
	/// </summary>
	[Serializable]
	public class SWDataNode{
		//iNormal
		public bool useNormal;
		public string id="";
		public string name="";
		public string iName
		{
			get{ 
				return "_" + name;
			}
		}

		public int depth = 1;
		public SWNodeType type;

		/// <summary>
		/// Right port count
		/// </summary>
		public int parentPortNumber = 1;
		/// <summary>
		/// All parents
		/// </summary>
		public List<string> parent = new List<string> ();
		/// <summary>
		/// Right port link to parent
		/// </summary>
		public List<int> parentPort = new List<int> ();

		/// <summary>
		/// Left port count
		/// </summary>
		public int childPortNumber = 1;
		/// <summary>
		/// All children
		/// </summary>
		public List<string> children = new List<string>();
		/// <summary>
		/// Left port link to child
		/// </summary>
		public List<int> childrenPort = new List<int> ();



		public string textureExGUID="";
		public string textureGUID="";
		/// <summary>
		/// Use for Mask Node, custom
		/// </summary>
		public bool useGray;
		/// <summary>
		/// Use for Remap Node, custom
		/// </summary>
		public bool useCustomTexture;
		public string textureGUIDGray="";
		public string spriteGUID="";
		public string spriteName="";
		public Rect rect;
		public EffectData effectData = new EffectData();

		/// <summary>
		/// Use by nodes: Color Refraction Reflection
		/// </summary>
		public EffectDataColor effectDataColor = new EffectDataColor();
		public EffectDataUV effectDataUV = new EffectDataUV();
		public SWChannel maskChannel;
		public List<SWDataType> outputType = new List<SWDataType> ();
		public List<SWDataType> inputType = new List<SWDataType>();
		public bool dirty = true;
		public Vector2 remap = new Vector2 (0f, 0.05f);
		public SWLayerMaskString layerMask = new SWLayerMaskString();

		#region new effect
		public float blurX;
		public float blurY;
		public string blurXParam="(1)";
		public string blurYParam="(1)";

		public float retro;
		public string retroParam="(1)";

		public List<SWGradient> gradients = new List<SWGradient>();
		#endregion


		public SWDataNode()
		{
			AssingNewID ();
		}

		public void AssingNewID()
		{
			id = SWDataManager.NewGUID ();
		}

		public string ChildOfPort(int p)
		{
			int id = childrenPort.IndexOf (p);
			return children [id];
		}
		public string ParentOfPort(int p)
		{
			int id = parentPort.IndexOf (p);
			return parent [id];
		}
	}
}
