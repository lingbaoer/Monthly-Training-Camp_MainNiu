// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

//ShaderWeaverData{"shaderQueue":3000,"shaderQueueOffset":0,"shaderType":1,"spriteLightType":0,"shaderModel":0,"shaderBlend":0,"excludeRoot":true,"version":121,"pixelPerUnit":0.0,"spriteRect":{"serializedVersion":"2","x":0.0,"y":0.0,"width":1.0,"height":1.0},"title":"refract","materialGUID":"2ab92fdecc08df140942a72352410436","masksGUID":[],"paramList":[{"type":0,"name":"_refract","min":0.0,"max":1.0,"defaultValue":0.0},{"type":0,"name":"_blurX","min":0.0,"max":1.0,"defaultValue":0.0},{"type":0,"name":"_blurY","min":0.0,"max":1.0,"defaultValue":0.0}],"nodes":[{"useNormal":false,"id":"a5211897_91b3_4a13_b3cd_3755f6155d5d","name":"ROOT","depth":1,"type":0,"parentPortNumber":1,"parent":[],"parentPort":[],"childPortNumber":1,"children":["0273b7e1_b3b5_4c2b_99fc_0f1950758a0a"],"childrenPort":[0],"textureExGUID":"","textureGUID":"","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":832.0,"y":249.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":0.0,"y":0.0},"r_angle":0.0,"s_scale":{"x":1.0,"y":1.0},"t_speed":{"x":0.0,"y":0.0},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"(1)","pop_channel":3,"useLoop":false,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":0,"param":"(1)"},"effectDataUV":{"op":0,"param":"(1)","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[0],"inputType":[0,1,3],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":0,"strs":[]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]},{"useNormal":false,"id":"0273b7e1_b3b5_4c2b_99fc_0f1950758a0a","name":"refract1","depth":1,"type":10,"parentPortNumber":1,"parent":["a5211897_91b3_4a13_b3cd_3755f6155d5d"],"parentPort":[0],"childPortNumber":1,"children":["ea9cdfe4_0134_4e0e_a24e_8b1b541fd316","d83c626b_820f_4868_b4c2_9444ed41a913"],"childrenPort":[0,0],"textureExGUID":"","textureGUID":"","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":591.0,"y":249.0,"width":144.0,"height":130.0},"effectData":{"t_startMove":{"x":0.0,"y":0.0},"r_angle":0.0,"s_scale":{"x":1.0,"y":1.0},"t_speed":{"x":0.0,"y":0.0},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"(1)","pop_channel":3,"useLoop":false,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":true,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":0,"param":"(1)"},"effectDataUV":{"op":0,"param":"(1)","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[0],"inputType":[1,3,0],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":0,"strs":[]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]},{"useNormal":false,"id":"ea9cdfe4_0134_4e0e_a24e_8b1b541fd316","name":"uv2","depth":1,"type":4,"parentPortNumber":1,"parent":["0273b7e1_b3b5_4c2b_99fc_0f1950758a0a"],"parentPort":[0],"childPortNumber":1,"children":[],"childrenPort":[],"textureExGUID":"","textureGUID":"5e254b7b0b83a5e419f402ca40b38341","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":387.0,"y":249.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":0.0,"y":0.0},"r_angle":0.0,"s_scale":{"x":3.0,"y":3.0},"t_speed":{"x":0.0,"y":-0.7890625},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"(1)","pop_channel":3,"useLoop":false,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":0,"param":"(1)"},"effectDataUV":{"op":0,"param":"_refract","amountR":{"x":0.0,"y":0.087890625},"amountG":{"x":0.06640625,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[1],"inputType":[1],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":-1,"strs":["a5211897_91b3_4a13_b3cd_3755f6155d5d","0273b7e1_b3b5_4c2b_99fc_0f1950758a0a","d83c626b_820f_4868_b4c2_9444ed41a913"]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]},{"useNormal":false,"id":"d83c626b_820f_4868_b4c2_9444ed41a913","name":"blur3","depth":1,"type":6,"parentPortNumber":1,"parent":["0273b7e1_b3b5_4c2b_99fc_0f1950758a0a"],"parentPort":[0],"childPortNumber":1,"children":[],"childrenPort":[],"textureExGUID":"","textureGUID":"","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":336.0,"y":429.0,"width":152.0,"height":130.0},"effectData":{"t_startMove":{"x":0.0,"y":0.0},"r_angle":0.0,"s_scale":{"x":1.0,"y":1.0},"t_speed":{"x":0.0,"y":0.0},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"(1)","pop_channel":3,"useLoop":false,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":0,"param":"(1)"},"effectDataUV":{"op":0,"param":"(1)","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[1],"inputType":[],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":0,"strs":[]},"blurX":1.0,"blurY":1.0,"blurXParam":"_blurX","blurYParam":"_blurY","retro":0.0,"retroParam":"(1)","gradients":[]}],"clipValue":0.0,"fallback":"Standard"}
Shader "Shader Weaver/refract"{   
	Properties {   
		_Color ("Color", Color) = (1,1,1,1)
		_Color_ROOT ("Color ROOT", Color) = (1,1,1,1)
		[HDR]_Color_refract1 ("Color refract1", Color) = (1,1,1,1)
		_MainTex ("_MainTex", 2D) = "white" { }
		_water ("_water", 2D) = "white" { }
		_refract ("_refract", Range(0,1)) = 0
		_blurX ("_blurX", Range(0,1)) = 0
		_blurY ("_blurY", Range(0,1)) = 0
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
			float4 _MainTex_ST;
			sampler2D _MainTex;   
			sampler2D _water;   
			float _refract; 
			float _blurX; 
			float _blurY; 
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
			v2f vert (appdata_t IN) {
				v2f OUT;   
				if(_useSpriteAnimation==1)
					OUT.rect_Sprite = _AnimatedRect;
				else
				OUT.rect_Sprite = float4(0,0,1,1);
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
				uv_uv2 = uv_uv2+fixed2(0,0.7890625)*(_Time.y);    
				uv_uv2 = UV_RotateAround(fixed2(0,0),uv_uv2,0);    
				uv_uv2 = uv_uv2/fixed2(3,3);    
				float2 dir_uv2 = uv_uv2/length(uv_uv2);    
				uv_uv2 = uv_uv2-dir_uv2*fixed2(0,0)*(_Time.y);    
				uv_uv2 = UV_RotateAround(fixed2(0,0),uv_uv2,0*(_Time.y));    
				uv_uv2 = uv_uv2+center_uv2;    
				float4 rect_uv2 =  float4(1,1,1,1);
				float4 color_uv2 = tex2D(_water,uv_uv2);    
				uv_uv2 = -(color_uv2.r*fixed2(0,0.08789063) + color_uv2.g*fixed2(0.06640625,0) + color_uv2.b*fixed2(0,0) +  color_uv2.a*fixed2(0,0));    


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
				uv_refract1 = uv_refract1 + uv_uv2*1*(_refract);
				float4 rect_refract1 =  float4(1,1,1,1);
				float4 color_refract1 = float4(1,1,1,1);
				color_refract1 = Blur(_GrabTexture,uv_refract1,float2( 1*_blurX*0.1 ,1*_blurY*0.1)*rect_refract1.zw);
				color_refract1 = color_refract1*_Color_refract1;
				result = color_refract1;
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
