//----------------------------------------------
//            Shader Weaver
//      Copyright© 2017 Jackie Lo
//----------------------------------------------
namespace ShaderWeaver
{
	using UnityEngine;
	using System.Collections;
	using System.Collections.Generic;

	/// <summary>
	/// Create Shader
	/// </summary>
	public partial class SWShaderCreaterBase{
		public static SWShaderCreaterBase Instance; 
		protected SWWindowMain window;
		protected string txt;

		//True: UI UIText
		public bool IsTextureSampleAdd;
		//True: Sprite UI
		public bool IsSprite;

		public SWShaderCreaterBase(SWWindowMain _window)
		{
			Instance = this;
			window = _window;
		}


		#region Screen nodes:refraction refraction   grab pass and calculate screen pos
		protected void Screen_PropertyField()
		{
			if (HasChildNodeType (SWNodeType.reflect)) {
				StringAddLine ("\t\t_ReflectionLine (\"Reflection Line\", Range(0,1)) = 1");
				StringAddLine ("\t\t_ReflectionHeight (\"Reflection Height\", Range(0.1,3)) = 1");
			}
		}

		protected void Screen_Grab_Pass()
		{
			if (HasChildNodeType (SWNodeType.refract) || HasChildNodeType (SWNodeType.reflect)) {
				StringAddLine ("\t\tGrabPass{ }");
			}
		}
		protected void Screen_Struct_v2f()
		{
			if (HasChildNodeType (SWNodeType.refract) || HasChildNodeType (SWNodeType.reflect)) {
				StringAddV2d ("float2", "_uv_Screen", "TEXCOORD3");
			}
		}
		protected void Screen_PropertyDeclare()
		{
			if (HasChildNodeType (SWNodeType.refract) || HasChildNodeType (SWNodeType.reflect)) {
				StringAddLine ("\t\t\tuniform sampler2D _GrabTexture;");
			}
			if (HasChildNodeType (SWNodeType.reflect)) {
				StringAddLine ("\t\t\tfloat _ReflectionLine;");
				StringAddLine ("\t\t\tfloat _ReflectionHeight;");
			}
		}
		protected void Screen_Functions()
		{
			if (HasChildNodeType (SWNodeType.reflect)) {
				StringAddLine ("\t\t\tfloat2 FlipUV_Y(float2 uv,float midY)\n\t\t\t{\n\t\t\t\tfloat y = uv.y - midY;\n\t\t\t\treturn float2(uv.x,midY - y* 1/_ReflectionHeight);\n\t\t\t}");
			}
		}
		protected void Screen_Vert()
		{
			if (HasChildNodeType (SWNodeType.refract) || HasChildNodeType (SWNodeType.reflect)) {
				if(this is SWShaderCreaterSpriteLight)
					StringAddLine ("\t\t\t\tfloat4 wpos = mul(UNITY_MATRIX_MVP,IN.vertex);");
				else
					StringAddLine ("\t\t\t\tfloat4 wpos = OUT.pos;");
				StringAddLine ("\t\t\t\t#if UNITY_UV_STARTS_AT_TOP");
				StringAddLine ("\t\t\t\t\tfloat grabSign = -_ProjectionParams.x;");
				StringAddLine ("\t\t\t\t#else");
				StringAddLine ("\t\t\t\t\tfloat grabSign = _ProjectionParams.x;");
				StringAddLine ("\t\t\t\t#endif");
				StringAddLine ("\t\t\t\tOUT._uv_Screen = wpos.xy / wpos.w;");
				StringAddLine ("\t\t\t\tOUT._uv_Screen.y *= _ProjectionParams.x;");
				StringAddLine ("\t\t\t\tOUT._uv_Screen = float2(1,grabSign)*OUT._uv_Screen*0.5+0.5;");
			}
		}
		protected void Screen_Fragment()
		{
			if (HasChildNodeType (SWNodeType.refract) || HasChildNodeType (SWNodeType.reflect)) {
				
			}
		}
		#endregion




		public string CreateShaderText()
		{
			txt = "";
			StringAddLine( string.Format("Shader \"{0}/{1}\"{{   ",SWGlobalSettings.ProductTitle,window.data.title));

		
			StringAddLine( "\tProperties {   ");
			PropertyField();
			StringAddLine( "\t}   ");


			StringAddLine( "\tSubShader {   ");

			StringAddLine( "\t\tTags {");
			Tags ();
			StringAddLine( "\t\t}");
			Screen_Grab_Pass ();
			PassWarp ();
			StringAddLine( "\t}");
			AddFallBack ();
			StringAddLine( "}");
			return txt;
		}

		void AddFallBack()
		{
			string fb = window.data.fallback;
			if(!string.IsNullOrEmpty(fb))
				StringAddLine( string.Format("\tfallback \"{0}\"",fb));
		}


		#region init
		protected virtual void PropertyDeclare()
		{
			StringAddLine( "\t\t\tfixed4 _Color;");
			foreach (var item in window.nodes) {
				if (!item.BelongRootTree ())
					continue;
				if (item.HasColorAttribute()){
					StringAddLine (string.Format ("\t\t\tfloat4 _Color{0};", item.data.iName));
				}
			}

			StringAddLine( "\t\t\tfloat4 _MainTex_ST;");
			foreach (var item in window.textures) {
				StringAddLine( string.Format("\t\t\tsampler2D {0};   ",item.Key));
				//StringAddLine( string.Format("\t\t\tfloat4 {0}_ST;   ",item.Key));
			}
			foreach (var item in window.data.paramList) {
				StringAddLine( string.Format("\t\t\tfloat {0}; ",item.name));
			}


			Screen_PropertyDeclare ();

		}

		protected virtual void PropertyField()
		{
			StringAddLine (string.Format("\t\t{0}_Color (\"Color\", Color) = ({1},{2},{3},{4})",
				window.nRoot.data.effectDataColor.hdr? "[HDR]":"",
				window.nRoot.data.effectDataColor.color.r,
				window.nRoot.data.effectDataColor.color.g,
				window.nRoot.data.effectDataColor.color.b,
				window.nRoot.data.effectDataColor.color.a
			));

			foreach (var item in window.nodes) {
				if (!item.BelongRootTree ())
					continue;
				if (item.HasColorAttribute())
				{
					StringAddLine (string.Format("\t\t{0}_Color{1} (\"Color {2}\", Color) = ({3},{4},{5},{6})",
						item.data.effectDataColor.hdr? "[HDR]":"",
						item.data.iName,
						item.data.name,
						item.data.effectDataColor.color.r,
						item.data.effectDataColor.color.g,
						item.data.effectDataColor.color.b,
						item.data.effectDataColor.color.a
					));
				}
			}

			foreach (var item in window.textures) {
				StringAddLine( string.Format("\t\t{0} (\"{1}\", 2D) = \"white\" {{ }}",item.Key,item.Key));
			}

			foreach (var item in window.data.paramList) {
				if(item.type == SWParamType.FLOAT)
					StringAddLine( string.Format("\t\t{0} (\"{0}\", Float) = {1}",item.name,item.defaultValue));
				if(item.type == SWParamType.RANGE)
					StringAddLine( string.Format("\t\t{0} (\"{0}\", Range({1},{2})) = {3}",item.name,item.min,item.max,item.defaultValue));
			}

			Screen_PropertyField ();
		}
	

		protected virtual void Pragma()
		{
			StringAddLine( "\t\t\t#pragma vertex vert   ");
			StringAddLine( "\t\t\t#pragma fragment frag   ");
			PragmaModel ();
		}

		protected void PragmaModel()
		{
			if(window.data.shaderModel == SWShaderModel.m10)
				StringAddLine( "\t\t\t#pragma target 1.0   ");
			else if(window.data.shaderModel == SWShaderModel.m20)
				StringAddLine( "\t\t\t#pragma target 2.0   ");
			else if(window.data.shaderModel == SWShaderModel.m30)
				StringAddLine( "\t\t\t#pragma target 3.0   ");
			else if(window.data.shaderModel == SWShaderModel.m40)
				StringAddLine( "\t\t\t#pragma target 4.0   ");
			else if(window.data.shaderModel == SWShaderModel.m50)
				StringAddLine( "\t\t\t#pragma target 5.0   ");
		}

		protected virtual void Tags()
		{
			//StringAddLine( "\t\t\t\"Queue\"=\"Transparent\"");

			if(window.data.shaderQueueOffset == 0)
				StringAddLine( string.Format("\t\t\t\"Queue\"=\"{0}\"",window.data.shaderQueue.ToString()));
			else 	if(window.data.shaderQueueOffset > 0)
				StringAddLine( string.Format("\t\t\t\"Queue\"=\"{0}+{1}\"",window.data.shaderQueue.ToString(),window.data.shaderQueueOffset));
			else 	if(window.data.shaderQueueOffset < 0)
				StringAddLine( string.Format("\t\t\t\"Queue\"=\"{0}{1}\"",window.data.shaderQueue.ToString(),window.data.shaderQueueOffset));
		}

		protected virtual void Ops()
		{
			if(window.data.shaderBlend == SWShaderBlend.blend)
				StringAddLine( "\t\t\tBlend SrcAlpha  OneMinusSrcAlpha   ");
			else if(window.data.shaderBlend == SWShaderBlend.add)
				StringAddLine( "\t\t\tBlend SrcAlpha  One   ");
			else if(window.data.shaderBlend == SWShaderBlend.mul)
				StringAddLine( "\t\t\tBlend zero  SrcColor   ");
		}

		protected virtual void Includes()
		{
			StringAddLine( "\t\t\t#include \"UnityCG.cginc\"   ");
		}

		protected virtual void Struct_Appdata()
		{
			StringAddLine ("\t\t\tstruct appdata_t {");
			StringAddLine ("\t\t\t\tfloat4 vertex   : POSITION;");
			StringAddLine ("\t\t\t\tfloat4 color    : COLOR;");
			StringAddLine ("\t\t\t\tfloat2 texcoord : TEXCOORD0;");
			StringAddLine ("\t\t\t};");
		}


		protected virtual void Struct_v2fWarp()
		{
			StringAddLine( "\t\t\tstruct v2f {   ");
			Struct_v2f ();
			StringAddLine( "\t\t\t};   ");
		}

		/// <summary>
		/// For Sprite Lighting
		/// uv_xx naming will lead to error,so name them starting with _uv_xx
		/// </summary>
		protected virtual void Struct_v2f()
		{
			if(!(this is SWShaderCreaterSpriteLight))
				StringAddV2d ("float4", "pos", "SV_POSITION");

			//COLOR:color COLOR1:rect_Sprite COLOR2:worldPosition//Use for UI Clipping 				
			StringAddV2d ("fixed4", "color", "COLOR");

			//TEXCOORD0:_uv_MainTex	TEXCOORD1:_uv_STD TEXCOORD2:_uv_Screen 
			StringAddV2d ("float2", "_uv_MainTex", "TEXCOORD0");
			StringAddV2d ("float2", "_uv_STD", "TEXCOORD1");
			Screen_Struct_v2f ();
		}



		#endregion

		#region pass
		public virtual void PassWarp()
		{
			StringAddLine( "\t\tpass {   ");
			Pass ();
			StringAddLine( "\t\t}");
		}

		public virtual void Pass()
		{
			Ops ();
			StringAddLine( "\t\t\tCGPROGRAM  ");
			Pragma ();
			Includes ();
			PropertyDeclare ();
			Struct_Appdata ();

			Struct_v2fWarp ();

			Functions ();

			VertWrap ();
			FragWarp ();

			StringAddLine( "\t\t\tENDCG");
		}
		#endregion

		#region functions
		protected virtual void Functions()
		{
			StringAddLine ("\t\t\tfloat2 UV_RotateAround(float2 center,float2 uv,float rad)\n\t\t\t{\n\t\t\t\tfloat2 fuv = uv - center;\n\t\t\t\tfloat2x2 ma = float2x2(cos(rad),sin(rad),-sin(rad),cos(rad));\n\t\t\t\tfuv = mul(ma,fuv)+center;\n\t\t\t\treturn fuv;\n\t\t\t}");
			Functions_Blur ();
			Functions_AnimationSheet ();
			Screen_Functions ();

			int Gradient_MaxFrameCount = SWNodeMixer.Gradient_MaxFrameCount ();
			if (Gradient_MaxFrameCount > 0) {
				StringAddLine (string.Format ("\t\t\tfloat GradientEvaluate(float _listTime[{0}],float _listValue[{0}],float count,float pcg)", Gradient_MaxFrameCount));
				StringAddLine ("\t\t\t{\n\t\t\t\tif(count==0)\n\t\t\t\t\treturn 0;\n\t\t\t\tif(pcg<_listTime[0])\n\t\t\t\t\treturn 0;\n\t\t\t\tif(pcg>_listTime[count-1])\n\t\t\t\t\treturn 0;\n\n\t\t\t\tfor(int i= 1;i<count;i++)\n\t\t\t\t{\n\t\t\t\t\tif(pcg <= _listTime[i])\n\t\t\t\t\t{\n\t\t\t\t\t\tfloat v1= _listValue[i-1];\n\t\t\t\t\t\tfloat v2= _listValue[i];\n\t\t\t\t\t\tfloat t1= _listTime[i-1];\n\t\t\t\t\t\tfloat t2= _listTime[i];\n\t\t\t\t\t\treturn lerp(v1,v2, (pcg - t1) / (t2-t1));\n\t\t\t\t\t}\n\t\t\t\t}\n\t\t\t\treturn 0;\n\t\t\t}");
			}
		}

	

		protected void Functions_Blur()
		{
			StringAddLine ("\t\t\tfloat4 Blur(sampler2D sam, float2 _uv,float2 offset)\n\t\t\t{\n\t\t\t    int num =12;\n\t\t\t\tfloat2 divi[12] = {float2(-0.326212f, -0.40581f),\n\n\t\t\t\tfloat2(-0.840144f, -0.07358f),\n\n\t\t\t\tfloat2(-0.695914f, 0.457137f),\n\n\t\t\t\tfloat2(-0.203345f, 0.620716f),\n\n\t\t\t\tfloat2(0.96234f, -0.194983f),\n\n\t\t\t\tfloat2(0.473434f, -0.480026f),\n\n\t\t\t\tfloat2(0.519456f, 0.767022f),\n\n\t\t\t\tfloat2(0.185461f, -0.893124f),\n\n\t\t\t\tfloat2(0.507431f, 0.064425f),\n\n\t\t\t\tfloat2(0.89642f, 0.412458f),\n\n\t\t\t\tfloat2(-0.32194f, -0.932615f),\n\n\t\t\t\tfloat2(-0.791559f, -0.59771f)};\n\t\t\t\tfloat4 col = float4(0,0,0,0);\n\n\n\n\t\t\t\tfor(int i=0;i<num;i++)\n\t\t\t\t{\n\t\t\t\t\tfloat2 uv = _uv+ offset*divi[i];\n\t\t\t\t\tcol += tex2D(sam,uv);\n\t\t\t\t}\n\t\t\t\tcol /= num;\n\t\t\t\treturn col;\n\t\t\t}");
		}

		protected void Functions_AnimationSheet()
		{
			StringAddLine ("\t\t\tfloat2 UV_STD2Rect(float2 uv,float4 rect)\n\t\t\t{\n\t\t\t\tuv.x = lerp(rect.x,rect.x+rect.z, uv.x);\n\t\t\t\tuv.y = lerp(rect.y,rect.y+rect.w, uv.y);\n\t\t\t\treturn uv;\n\t\t\t}");
			StringAddLine ("\t\t\tfloat4 AnimationSheet_RectSub(float row,float col,float rowMax,float colMax)\n\t\t\t{\n\t\t\t\tfloat4 w = float4(0,0,0,0);\n\t\t\t\tw.x =  col/colMax;\n\t\t\t\tw.y =  row/rowMax;\n\t\t\t\tw.z =  1/colMax;\n\t\t\t\tw.w =  1/rowMax;\n\t\t\t\treturn w;\n\t\t\t}");
			StringAddLine ("\t\t\tfloat4 AnimationSheet_Rect(int numTilesX,int numTilesY,bool isLoop,bool singleRow,int rowIndex, int startFrame,float factor)\n\t\t\t{\n\t\t\t\tint count = singleRow? numTilesX : numTilesX*numTilesY;\n\t\t\t\tint f = factor;\n\t\t\t\tif(isLoop)\n\t\t\t\t\tf = (startFrame+f)%count;\n\t\t\t\telse\n\t\t\t\t\tf = clamp((startFrame+f),0,count-1);\n\n\t\t\t\tint row = singleRow? rowIndex : (f / numTilesX);\n\t\t\t\trow = numTilesY - 1 - row;\n\t\t\t\tint col = singleRow? f : f % numTilesX;\n\t\t\t\treturn  AnimationSheet_RectSub(row,col,numTilesY,numTilesX);\n\t\t\t}");
		}
		#endregion
	
		#region Vert
		protected virtual void VertWrap()
		{
			StringAddLine( "\t\t\tv2f vert (appdata_t IN) {");
			StringAddLine( "\t\t\t\tv2f OUT;   ");
			Vert ();
			StringAddLine( "\t\t\t\treturn OUT;");
			StringAddLine( "\t\t\t}   ");
		}
		protected virtual void Vert()
		{
			StringAddLine( "\t\t\t\tOUT.pos = mul(UNITY_MATRIX_MVP,IN.vertex);");
			StringAddLine ("\t\t\t\tOUT.color = IN.color * _Color;");
			StringAddLine ("\t\t\t\tOUT._uv_MainTex = TRANSFORM_TEX(IN.texcoord,_MainTex);");
			Screen_Vert ();
			Vert_UV_STD ();
		} 

		protected virtual void Vert_UV_STD()
		{
			StringAddLine ("\t\t\t\tOUT._uv_STD = TRANSFORM_TEX(IN.texcoord,_MainTex);  ");
		}
		#endregion

		#region fragment
		protected virtual void FragWarp()
		{
			StringAddLine( "\t\t\tfloat4 frag (v2f i) : COLOR {");
			Frag ();
			StringAddLine("\t\t\t\treturn result;");
			StringAddLine( "\t\t\t}  ");
		}
		protected virtual void Frag()
		{
			Screen_Fragment ();
			foreach (var item in window.textures) {
				if (item.Key.Contains ("mask")) {
					StringAddLine( string.Format("\t\t\t\tfloat4 color{0} = tex2D({0},i._uv_STD);    ",item.Key));
				}
			}
			ProcessAll(window.nRoot);
		} 
		#endregion

		#region node
		public virtual  void ProcessAll(  SWNodeBase root)
		{
			StringAddLine( "\t\t\t\tfloat4 result = float4(0,0,0,0);");
			Process (root);
			StringAddLine ("\t\t\t\tresult = result*i.color;");
			StringAddLine( string.Format("\t\t\t\tclip(result.a - {0});",
				window.data.clipValue));
			if(window.data.shaderBlend == SWShaderBlend.mul)
				StringAddLine ("\t\t\t\tresult = lerp(half4(1,1,1,1), result, result.a);");
		}

		public   SWOutput Process(  SWNodeBase node)
		{
			if (node.shaderOutput != null)
				return node.shaderOutput;

			SWShaderProcessBase processor = CreateProcessor(node.data.type); 
			node.shaderOutput = processor.Process (node);
			return node.shaderOutput;
		}

		public static SWShaderProcessBase CreateProcessor( SWNodeType type)
		{
			SWShaderProcessBase processor = null;

			if (type == SWNodeType.root){
				processor = new SWShaderProcessRoot ();
			}
			else if (type == SWNodeType.mask){
				processor = new SWShaderProcessMask ();
			}
			else if (type == SWNodeType.color){
				processor = new SWShaderProcessColor ();
			}
			else if (type == SWNodeType.image){
				processor = new SWShaderProcessImage ();
			}
			else if (type == SWNodeType.uv){
				processor = new SWShaderProcessUV ();
			}
			else if (type == SWNodeType.alpha){
				processor = new SWShaderProcessAlpha ();
			}
			else if (type == SWNodeType.mixer){
				processor = new SWShaderProcessMixer ();
			}
			else if (type == SWNodeType.remap){
				processor = new SWShaderProcessRemap ();
			}
			else if (type == SWNodeType.blur){
				processor = new SWShaderProcessBlur ();
			}
			else if (type == SWNodeType.retro){
				processor = new SWShaderProcessRetro ();
			}
			else if (type == SWNodeType.refract){
				processor = new SWShaderProcessRefraction ();
			}
			else if (type == SWNodeType.reflect){
				processor = new SWShaderProcessReflection ();
			}

			else if (type == SWNodeType.cartoon){
				processor = new SWShaderProcessCartoon ();
			}
			else if (type == SWNodeType.outline){
				processor = new SWShaderProcessOutline ();
			}
			return processor;
		}

		public static SWShaderProcessReceiveBase CreateProcessorReceiver( SWNodeType type)
		{
			SWShaderProcessReceiveBase receiver = null;

			if (type == SWNodeType.root){

			}
			else if (type == SWNodeType.mask){
				
			}
			else if (type == SWNodeType.color){
				receiver = new SWShaderProcessReceiveColor ();
			}
			else if (type == SWNodeType.image){

			}
			else if (type == SWNodeType.uv){
				receiver = new SWShaderProcessReceiveUV ();
			}
			else if (type == SWNodeType.alpha){
				receiver = new SWShaderProcessReceiveAlpha ();
			}
			else if (type == SWNodeType.remap){
				receiver = new SWShaderProcessReceiveRemap ();
			}
			else if (type == SWNodeType.blur){
				receiver = new SWShaderProcessReceiveBlur ();
			}
			else if (type == SWNodeType.retro){
				receiver = new SWShaderProcessReceiveRetro ();
			}


			else if (type == SWNodeType.cartoon){
				receiver = new SWShaderProcessReceiveCartoon ();
			}
			else if (type == SWNodeType.outline){
				receiver = new SWShaderProcessReceiveOutline ();
			}
			return receiver;
		}
		#endregion

		#region other
		public bool HasChildNodeType(SWNodeType type)
		{
			foreach (var item in SWWindowMain.Instance.NodeAll()) {
				if (item.Value.BelongRootTree () && item.Value.data.type == type)
					return true;
			}
			return false;
		}

		public void StringAddV2d(string type,string name,string v2f)
		{
			if(this is SWShaderCreaterSpriteLight)
				StringAddLine(string.Format( "\t\t\t\t{0}  {1};",type,name));
			else 
				StringAddLine(string.Format( "\t\t\t\t{0}  {1} : {2};",type,name,v2f));
		}
		public void StringAddLine(string line)
		{
			txt += line;
			txt += "\n";
		}
		#endregion
	}
}