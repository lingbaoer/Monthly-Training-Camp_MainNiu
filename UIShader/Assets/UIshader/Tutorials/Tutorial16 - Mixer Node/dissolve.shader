// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

//ShaderWeaverData{"shaderQueue":3000,"shaderQueueOffset":0,"shaderType":1,"spriteLightType":0,"shaderModel":0,"shaderBlend":0,"excludeRoot":false,"version":121,"pixelPerUnit":200.0,"spriteRect":{"serializedVersion":"2","x":0.0,"y":0.86572265625,"width":0.13427734375,"height":0.13427734375},"title":"dissolve","materialGUID":"abd7c54011f11624baa4b359df14bcdf","masksGUID":[],"paramList":[{"type":0,"name":"_pcg","min":0.0,"max":1.0,"defaultValue":0.0}],"nodes":[{"useNormal":false,"id":"463d1404_76ac_4080_a668_589900cf5c1c","name":"ROOT","depth":1,"type":0,"parentPortNumber":1,"parent":[],"parentPort":[],"childPortNumber":1,"children":["b9fda4a8_4f8c_4cfc_a66e_62e6294d447d","0a7e96b6_96de_4fed_aaf4_b3129ddf77dd"],"childrenPort":[0,0],"textureExGUID":"","textureGUID":"","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"8fb98a6035269e64a998f9b56828fc4f","spriteName":"RobotBoyIdle00","rect":{"serializedVersion":"2","x":766.0,"y":430.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":0.0,"y":0.0},"r_angle":0.0,"s_scale":{"x":1.0,"y":1.0},"t_speed":{"x":0.0,"y":0.0},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"(1)","pop_channel":3,"useLoop":true,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":true,"color":{"r":0.75,"g":0.75,"b":0.75,"a":1.0},"op":0,"param":"(1)"},"effectDataUV":{"op":0,"param":"(1)","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[0],"inputType":[0,1,3],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":0,"strs":[]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]},{"useNormal":false,"id":"78096084_cb2b_4aec_9b17_625021c7ac33","name":"refract1","depth":1,"type":10,"parentPortNumber":1,"parent":["0a7e96b6_96de_4fed_aaf4_b3129ddf77dd"],"parentPort":[0],"childPortNumber":1,"children":["b9fda4a8_4f8c_4cfc_a66e_62e6294d447d"],"childrenPort":[0],"textureExGUID":"","textureGUID":"","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":273.0,"y":399.0,"width":144.0,"height":130.0},"effectData":{"t_startMove":{"x":0.0,"y":0.0},"r_angle":0.0,"s_scale":{"x":1.0,"y":1.0},"t_speed":{"x":0.0,"y":0.0},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"(1)","pop_channel":3,"useLoop":true,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":1,"param":"(_pcg*0.8)"},"effectDataUV":{"op":0,"param":"(1)","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[0],"inputType":[1,3,0],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":0,"strs":[]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]},{"useNormal":false,"id":"b9fda4a8_4f8c_4cfc_a66e_62e6294d447d","name":"uv2","depth":1,"type":4,"parentPortNumber":1,"parent":["463d1404_76ac_4080_a668_589900cf5c1c","78096084_cb2b_4aec_9b17_625021c7ac33"],"parentPort":[0,0],"childPortNumber":1,"children":[],"childrenPort":[],"textureExGUID":"","textureGUID":"e80c3c84ea861404d8a427db8b7abf04","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":65.0,"y":208.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":0.0,"y":0.0},"r_angle":0.0,"s_scale":{"x":1.0,"y":1.0},"t_speed":{"x":0.0,"y":-0.1171875},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"(1)","pop_channel":3,"useLoop":true,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":0,"param":"(1)"},"effectDataUV":{"op":0,"param":"_pcg","amountR":{"x":0.0,"y":0.009999999776482582},"amountG":{"x":0.009999999776482582,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[1],"inputType":[1],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":0,"strs":["463d1404_76ac_4080_a668_589900cf5c1c","78096084_cb2b_4aec_9b17_625021c7ac33"]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]},{"useNormal":false,"id":"f7174d0f_3605_4960_beb5_a2f6d5ccf0e8","name":"color3","depth":1,"type":3,"parentPortNumber":1,"parent":["0a7e96b6_96de_4fed_aaf4_b3129ddf77dd"],"parentPort":[0],"childPortNumber":1,"children":[],"childrenPort":[],"textureExGUID":"","textureGUID":"","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":266.0,"y":554.0,"width":144.0,"height":130.0},"effectData":{"t_startMove":{"x":0.0,"y":0.0},"r_angle":0.0,"s_scale":{"x":1.0,"y":1.0},"t_speed":{"x":0.0,"y":0.0},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"(1)","pop_channel":3,"useLoop":true,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":true,"color":{"r":3.0,"g":2.7690000534057619,"b":1.569000005722046,"a":1.0},"op":1,"param":"(1)"},"effectDataUV":{"op":0,"param":"(1)","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[0],"inputType":[3],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":0,"strs":[]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]},{"useNormal":false,"id":"3839af3e_6192_4fee_a98c_246d93119f27","name":"color4","depth":1,"type":3,"parentPortNumber":1,"parent":["0a7e96b6_96de_4fed_aaf4_b3129ddf77dd"],"parentPort":[0],"childPortNumber":1,"children":[],"childrenPort":[],"textureExGUID":"","textureGUID":"","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":266.0,"y":698.0,"width":144.0,"height":130.0},"effectData":{"t_startMove":{"x":0.0,"y":0.0},"r_angle":0.0,"s_scale":{"x":1.0,"y":1.0},"t_speed":{"x":0.0,"y":0.0},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"(1)","pop_channel":3,"useLoop":true,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":true,"color":{"r":3.0,"g":0.0,"b":0.0,"a":1.0},"op":1,"param":"(1)"},"effectDataUV":{"op":0,"param":"(1)","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[0],"inputType":[3],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":0,"strs":[]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]},{"useNormal":false,"id":"0a7e96b6_96de_4fed_aaf4_b3129ddf77dd","name":"mixer5","depth":1,"type":12,"parentPortNumber":1,"parent":["463d1404_76ac_4080_a668_589900cf5c1c"],"parentPort":[0],"childPortNumber":3,"children":["78096084_cb2b_4aec_9b17_625021c7ac33","f7174d0f_3605_4960_beb5_a2f6d5ccf0e8","3839af3e_6192_4fee_a98c_246d93119f27"],"childrenPort":[0,1,2],"textureExGUID":"","textureGUID":"fa3108da2fe38a748bfce58b4c9b5410","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":507.0,"y":574.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":0.0,"y":0.0},"r_angle":0.0,"s_scale":{"x":1.0,"y":1.0},"t_speed":{"x":0.0,"y":-0.07421875},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":1.0,"pop_speed":-2.0,"pop_Param":"_pcg","pop_channel":0,"useLoop":true,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":0,"param":"(1)"},"effectDataUV":{"op":0,"param":"(1)","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[0,1,3],"inputType":[0,1,3],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":1,"strs":["463d1404_76ac_4080_a668_589900cf5c1c","78096084_cb2b_4aec_9b17_625021c7ac33","b9fda4a8_4f8c_4cfc_a66e_62e6294d447d","f7174d0f_3605_4960_beb5_a2f6d5ccf0e8","3839af3e_6192_4fee_a98c_246d93119f27"]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[{"frames":[{"time":0.0,"value":1.0},{"time":0.20000000298023225,"value":1.0}]},{"frames":[{"time":0.20000000298023225,"value":1.0},{"time":0.30000001192092898,"value":0.0}]},{"frames":[{"time":0.20000000298023225,"value":0.0},{"time":0.30000001192092898,"value":1.0}]}]}],"clipValue":0.0,"fallback":"Standard"}
Shader "Shader Weaver/dissolve"{   
	Properties {   
		[HDR]_Color ("Color", Color) = (0.75,0.75,0.75,1)
		[HDR]_Color_ROOT ("Color ROOT", Color) = (0.75,0.75,0.75,1)
		_Color_refract1 ("Color refract1", Color) = (1,1,1,1)
		[HDR]_Color_color3 ("Color color3", Color) = (3,2.769,1.569,1)
		[HDR]_Color_color4 ("Color color4", Color) = (3,0,0,1)
		_MainTex ("_MainTex", 2D) = "white" { }
		_Noise ("_Noise", 2D) = "white" { }
		_wave ("_wave", 2D) = "white" { }
		_pcg ("_pcg", Range(0,1)) = 0
		[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
	}   
	SubShader {   
		Tags {
			"Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="Transparent" 
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}
		GrabPass{ }
		pass {   
		Cull Off
		Lighting Off
		ZWrite Off
		Blend One OneMinusSrcAlpha
			CGPROGRAM  
			#pragma vertex vert   
			#pragma fragment frag   
			#pragma multi_compile _ PIXELSNAP_ON
			#include "UnityCG.cginc"   
			fixed4 _Color;
			float4 _Color_ROOT;
			float4 _Color_refract1;
			float4 _Color_color3;
			float4 _Color_color4;
			float4 _MainTex_ST;
			sampler2D _MainTex;   
			sampler2D _Noise;   
			sampler2D _wave;   
			float _pcg; 
			uniform sampler2D _GrabTexture;
			sampler2D _AlphaTex;
			float _AlphaSplitEnabled;
			int _useSpriteAnimation;
			float4 _AnimatedRect;
			struct appdata_t {
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
			};
			struct v2f {   
				float4  pos : SV_POSITION;
				fixed4  color : COLOR;
				float2  _uv_MainTex : TEXCOORD0;
				float2  _uv_STD : TEXCOORD1;
				float2  _uv_Screen : TEXCOORD3;
				float4  rect_Sprite : COLOR1;
			};   
			float2 UV_RotateAround(float2 center,float2 uv,float rad)
			{
				float2 fuv = uv - center;
				float2x2 ma = float2x2(cos(rad),sin(rad),-sin(rad),cos(rad));
				fuv = mul(ma,fuv)+center;
				return fuv;
			}
			float4 Blur(sampler2D sam, float2 _uv,float2 offset)
			{
			    int num =12;
				float2 divi[12] = {float2(-0.326212f, -0.40581f),

				float2(-0.840144f, -0.07358f),

				float2(-0.695914f, 0.457137f),

				float2(-0.203345f, 0.620716f),

				float2(0.96234f, -0.194983f),

				float2(0.473434f, -0.480026f),

				float2(0.519456f, 0.767022f),

				float2(0.185461f, -0.893124f),

				float2(0.507431f, 0.064425f),

				float2(0.89642f, 0.412458f),

				float2(-0.32194f, -0.932615f),

				float2(-0.791559f, -0.59771f)};
				float4 col = float4(0,0,0,0);



				for(int i=0;i<num;i++)
				{
					float2 uv = _uv+ offset*divi[i];
					col += tex2D(sam,uv);
				}
				col /= num;
				return col;
			}
			float2 UV_STD2Rect(float2 uv,float4 rect)
			{
				uv.x = lerp(rect.x,rect.x+rect.z, uv.x);
				uv.y = lerp(rect.y,rect.y+rect.w, uv.y);
				return uv;
			}
			float4 AnimationSheet_RectSub(float row,float col,float rowMax,float colMax)
			{
				float4 w = float4(0,0,0,0);
				w.x =  col/colMax;
				w.y =  row/rowMax;
				w.z =  1/colMax;
				w.w =  1/rowMax;
				return w;
			}
			float4 AnimationSheet_Rect(int numTilesX,int numTilesY,bool isLoop,bool singleRow,int rowIndex, int startFrame,float factor)
			{
				int count = singleRow? numTilesX : numTilesX*numTilesY;
				int f = factor;
				if(isLoop)
					f = (startFrame+f)%count;
				else
					f = clamp((startFrame+f),0,count-1);

				int row = singleRow? rowIndex : (f / numTilesX);
				row = numTilesY - 1 - row;
				int col = singleRow? f : f % numTilesX;
				return  AnimationSheet_RectSub(row,col,numTilesY,numTilesX);
			}
			float GradientEvaluate(float _listTime[2],float _listValue[2],float count,float pcg)
			{
				if(count==0)
					return 0;
				if(pcg<_listTime[0])
					return 0;
				if(pcg>_listTime[count-1])
					return 0;

				for(int i= 1;i<count;i++)
				{
					if(pcg <= _listTime[i])
					{
						float v1= _listValue[i-1];
						float v2= _listValue[i];
						float t1= _listTime[i-1];
						float t2= _listTime[i];
						return lerp(v1,v2, (pcg - t1) / (t2-t1));
					}
				}
				return 0;
			}
			v2f vert (appdata_t IN) {
				v2f OUT;   
				if(_useSpriteAnimation==1)
					OUT.rect_Sprite = _AnimatedRect;
				else
				OUT.rect_Sprite = float4(0,0.8657227,0.1342773,0.1342773);
				OUT.pos = UnityObjectToClipPos(IN.vertex);   
				OUT.color = IN.color * _Color;
				OUT._uv_MainTex = TRANSFORM_TEX(IN.texcoord,_MainTex);
				float4 wpos = OUT.pos;
				#if UNITY_UV_STARTS_AT_TOP
					float grabSign = -_ProjectionParams.x;
				#else
					float grabSign = _ProjectionParams.x;
				#endif
				OUT._uv_Screen = wpos.xy / wpos.w;
				OUT._uv_Screen.y *= _ProjectionParams.x;
				OUT._uv_Screen = float2(1,grabSign)*OUT._uv_Screen*0.5+0.5;
				OUT._uv_STD = float2((IN.texcoord.x - OUT.rect_Sprite.x)/OUT.rect_Sprite.z,(IN.texcoord.y - OUT.rect_Sprite.y)/OUT.rect_Sprite.w);
				OUT._uv_STD = TRANSFORM_TEX(OUT._uv_STD,_MainTex);  
				#ifdef PIXELSNAP_ON
				OUT.pos = UnityPixelSnap (OUT.pos);
				#endif
				return OUT;
			}   
			float4 frag (v2f i) : COLOR {
				float4 result = float4(0,0,0,0);


				//====================================
				//============ uv2 ============   
				float2  uv_uv2 = i._uv_STD;
				float2 center_uv2 = float2(0.5,0.5);    
				uv_uv2 = uv_uv2-center_uv2;    
				uv_uv2 = uv_uv2+fixed2(0,0);    
				uv_uv2 = uv_uv2+fixed2(0,0.1171875)*(_Time.y);    
				uv_uv2 = UV_RotateAround(fixed2(0,0),uv_uv2,0);    
				uv_uv2 = uv_uv2/fixed2(1,1);    
				float2 dir_uv2 = uv_uv2/length(uv_uv2);    
				uv_uv2 = uv_uv2-dir_uv2*fixed2(0,0)*(_Time.y);    
				uv_uv2 = UV_RotateAround(fixed2(0,0),uv_uv2,0*(_Time.y));    
				uv_uv2 = uv_uv2+center_uv2;    
				float2 uv_uv2orgin = uv_uv2;
				uv_uv2 = float2(uv_uv2.x >0 ?(uv_uv2.x%(1+0)) : (1+0) - abs(uv_uv2.x)%(1+0), uv_uv2.y >0 ?(uv_uv2.y%(1+0)) : (1+0) - abs(uv_uv2.y)%(1+0));
				bool discard_uv2 = false;
				if(uv_uv2.x>1 || uv_uv2.y>1)
					discard_uv2 = true;
				float4 rect_uv2 =  float4(1,1,1,1);
				float4 color_uv2 = tex2D(_Noise,uv_uv2);    
				if(discard_uv2 == true) color_uv2 = float4(0,0,0,0);
				uv_uv2 = -(color_uv2.r*fixed2(0,0.01) + color_uv2.g*fixed2(0.01,0) + color_uv2.b*fixed2(0,0) +  color_uv2.a*fixed2(0,0));    


				//====================================
				//============ refract1 ============   
				float2  uv_refract1 = i._uv_Screen;
				float2 center_refract1 = float2(0.5,0.5);    
				uv_refract1 = uv_refract1-center_refract1;    
				uv_refract1 = uv_refract1+fixed2(0,0);    
				uv_refract1 = uv_refract1+fixed2(0,0)*(_Time.y);    
				uv_refract1 = UV_RotateAround(fixed2(0,0),uv_refract1,0);    
				uv_refract1 = uv_refract1/fixed2(1,1);    
				float2 dir_refract1 = uv_refract1/length(uv_refract1);    
				uv_refract1 = uv_refract1-dir_refract1*fixed2(0,0)*(_Time.y);    
				uv_refract1 = UV_RotateAround(fixed2(0,0),uv_refract1,0*(_Time.y));    
				uv_refract1 = uv_refract1+center_refract1;    
				uv_refract1 = uv_refract1 + uv_uv2*1*(_pcg);
				float2 uv_refract1orgin = uv_refract1;
				uv_refract1 = float2(uv_refract1.x >0 ?(uv_refract1.x%(1+0)) : (1+0) - abs(uv_refract1.x)%(1+0), uv_refract1.y >0 ?(uv_refract1.y%(1+0)) : (1+0) - abs(uv_refract1.y)%(1+0));
				bool discard_refract1 = false;
				if(uv_refract1.x>1 || uv_refract1.y>1)
					discard_refract1 = true;
				float4 rect_refract1 =  float4(1,1,1,1);
				float4 color_refract1 = tex2D(_GrabTexture,uv_refract1);    
				if(discard_refract1 == true) color_refract1 = float4(0,0,0,0);
				color_refract1 = color_refract1*_Color_refract1;


				//====================================
				//============ color3 ============   
				float4 color_color3 = _Color_color3;


				//====================================
				//============ color4 ============   
				float4 color_color4 = _Color_color4;


				//====================================
				//============ mixer5 ============   
				float2  uv_mixer5 = i._uv_STD;
				float2 center_mixer5 = float2(0.5,0.5);    
				uv_mixer5 = uv_mixer5-center_mixer5;    
				uv_mixer5 = uv_mixer5+fixed2(0,0);    
				uv_mixer5 = uv_mixer5+fixed2(0,0.07421875)*(_Time.y);    
				uv_mixer5 = UV_RotateAround(fixed2(0,0),uv_mixer5,0);    
				uv_mixer5 = uv_mixer5/fixed2(1,1);    
				float2 dir_mixer5 = uv_mixer5/length(uv_mixer5);    
				uv_mixer5 = uv_mixer5-dir_mixer5*fixed2(0,0)*(_Time.y);    
				uv_mixer5 = UV_RotateAround(fixed2(0,0),uv_mixer5,0*(_Time.y));    
				uv_mixer5 = uv_mixer5+center_mixer5;    
				float2 uv_mixer5orgin = uv_mixer5;
				uv_mixer5 = float2(uv_mixer5.x >0 ?(uv_mixer5.x%(1+0)) : (1+0) - abs(uv_mixer5.x)%(1+0), uv_mixer5.y >0 ?(uv_mixer5.y%(1+0)) : (1+0) - abs(uv_mixer5.y)%(1+0));
				bool discard_mixer5 = false;
				if(uv_mixer5.x>1 || uv_mixer5.y>1)
					discard_mixer5 = true;
				float4 rect_mixer5 =  float4(1,1,1,1);
				float4 color_mixer5 = tex2D(_wave,uv_mixer5);    
				if(discard_mixer5 == true) color_mixer5 = float4(0,0,0,0);
				float mixer_mixer5 = 1 +-2*(_pcg) + color_mixer5.r;
				mixer_mixer5 = clamp(mixer_mixer5,0,1);
				float gra_mixer5_0ListTime[2] = {0,0.2};
				float gra_mixer5_0ListValue[2] = {1,1};
				float gra_mixer5_0 = GradientEvaluate(gra_mixer5_0ListTime,gra_mixer5_0ListValue,2,mixer_mixer5);
				float gra_mixer5_1ListTime[2] = {0.2,0.3};
				float gra_mixer5_1ListValue[2] = {1,0};
				float gra_mixer5_1 = GradientEvaluate(gra_mixer5_1ListTime,gra_mixer5_1ListValue,2,mixer_mixer5);
				float gra_mixer5_2ListTime[2] = {0.2,0.3};
				float gra_mixer5_2ListValue[2] = {0,1};
				float gra_mixer5_2 = GradientEvaluate(gra_mixer5_2ListTime,gra_mixer5_2ListValue,2,mixer_mixer5);


				//====================================
				//============ ROOT ============   
				float2  uv_ROOT = i._uv_STD;
				float2 center_ROOT = float2(0.5,0.5);    
				uv_ROOT = uv_ROOT-center_ROOT;    
				uv_ROOT = uv_ROOT+fixed2(0,0);    
				uv_ROOT = uv_ROOT+fixed2(0,0)*(_Time.y);    
				uv_ROOT = UV_RotateAround(fixed2(0,0),uv_ROOT,0);    
				uv_ROOT = uv_ROOT/fixed2(1,1);    
				float2 dir_ROOT = uv_ROOT/length(uv_ROOT);    
				uv_ROOT = uv_ROOT-dir_ROOT*fixed2(0,0)*(_Time.y);    
				uv_ROOT = UV_RotateAround(fixed2(0,0),uv_ROOT,0*(_Time.y));    
				uv_ROOT = uv_ROOT+center_ROOT;    
				uv_ROOT = uv_ROOT + uv_uv2*1*(_pcg);
				float2 uv_ROOTorgin = uv_ROOT;
				uv_ROOT = float2(uv_ROOT.x >0 ?(uv_ROOT.x%(1+0)) : (1+0) - abs(uv_ROOT.x)%(1+0), uv_ROOT.y >0 ?(uv_ROOT.y%(1+0)) : (1+0) - abs(uv_ROOT.y)%(1+0));
				bool discard_ROOT = false;
				if(uv_ROOT.x>1 || uv_ROOT.y>1)
					discard_ROOT = true;
				float4 rect_ROOT =  i.rect_Sprite;
				uv_ROOT = UV_STD2Rect(uv_ROOT,rect_ROOT);
				float4 color_ROOT = tex2D(_MainTex,uv_ROOT);    
				if(discard_ROOT == true) color_ROOT = float4(0,0,0,0);
				float4 rootTexColor = color_ROOT;
				color_ROOT = color_ROOT*_Color_ROOT;
				result = color_ROOT;
				result = lerp(result,float4(color_refract1.rgb,rootTexColor.a),clamp(color_refract1.a*1*((_pcg*0.8))*gra_mixer5_0,0,1));    
				result = lerp(result,float4(color_color3.rgb,rootTexColor.a),clamp(color_color3.a*1*((1))*gra_mixer5_1,0,1));    
				result = lerp(result,float4(color_color4.rgb,rootTexColor.a),clamp(color_color4.a*1*((1))*gra_mixer5_2,0,1));    
				result = lerp(result,float4(color_refract1.rgb,rootTexColor.a),clamp(color_refract1.a*1*((_pcg*0.8))*gra_mixer5_0,0,1));    
				result = lerp(result,float4(color_color3.rgb,rootTexColor.a),clamp(color_color3.a*1*((1))*gra_mixer5_1,0,1));    
				result = lerp(result,float4(color_color4.rgb,rootTexColor.a),clamp(color_color4.a*1*((1))*gra_mixer5_2,0,1));    
				#if UNITY_TEXTURE_ALPHASPLIT_ALLOWED
				if (_AlphaSplitEnabled)
				result.a = tex2D (_AlphaTex, uv).r;
				#endif 
				result = result*i.color;
				result.rgb*= result.a;
				clip(result.a - 0);    
				return result;
			}  
			ENDCG
		}
	}
	fallback "Standard"
}
