// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

//ShaderWeaverData{"shaderQueue":3000,"shaderQueueOffset":0,"shaderType":0,"spriteLightType":0,"shaderModel":0,"shaderBlend":0,"excludeRoot":false,"version":121,"pixelPerUnit":0.0,"spriteRect":{"serializedVersion":"2","x":0.0,"y":0.0,"width":0.0,"height":0.0},"title":"alpha","materialGUID":"d8be69d252e0171489f7a5f9c9997699","masksGUID":[],"paramList":[{"type":0,"name":"_p","min":0.0,"max":1.0,"defaultValue":0.0}],"nodes":[{"useNormal":false,"id":"c3fffbd3_7fb6_4e50_9c31_78a792235fca","name":"ROOT","depth":1,"type":0,"parentPortNumber":1,"parent":[],"parentPort":[],"childPortNumber":1,"children":["945ecab3_7963_416d_b60a_97c3fe504abc"],"childrenPort":[0],"textureExGUID":"","textureGUID":"5096aba325b0ca94d8784ec4c3087d0e","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":720.0,"y":319.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":0.0,"y":0.0},"r_angle":0.0,"s_scale":{"x":1.0,"y":1.0},"t_speed":{"x":0.0,"y":0.0},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"1","pop_channel":3,"useLoop":false,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":0,"param":"(1)"},"effectDataUV":{"op":0,"param":"1","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[0],"inputType":[0,1,3],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":0,"strs":[]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]},{"useNormal":false,"id":"945ecab3_7963_416d_b60a_97c3fe504abc","name":"alpha1","depth":1,"type":5,"parentPortNumber":1,"parent":["c3fffbd3_7fb6_4e50_9c31_78a792235fca"],"parentPort":[0],"childPortNumber":1,"children":[],"childrenPort":[],"textureExGUID":"","textureGUID":"fa3108da2fe38a748bfce58b4c9b5410","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":478.0,"y":319.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":0.0,"y":0.0},"r_angle":0.0,"s_scale":{"x":1.0,"y":1.0},"t_speed":{"x":0.0,"y":0.0},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":-1.0,"pop_speed":1.5,"pop_Param":"_p","pop_channel":0,"useLoop":false,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":0,"param":"(1)"},"effectDataUV":{"op":0,"param":"1","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[3],"inputType":[1],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":1,"strs":["c3fffbd3_7fb6_4e50_9c31_78a792235fca"]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]}],"clipValue":0.0,"fallback":"Standard"}
Shader "Shader Weaver/alpha"{   
	Properties {   
		_Color ("Color", Color) = (1,1,1,1)
		_Color_ROOT ("Color ROOT", Color) = (1,1,1,1)
		_MainTex ("_MainTex", 2D) = "white" { }
		_wave ("_wave", 2D) = "white" { }
		_p ("_p", Range(0,1)) = 0
	}   
	SubShader {   
		Tags {
			"Queue"="Transparent"
		}
		pass {   
			Blend SrcAlpha  OneMinusSrcAlpha   
			CGPROGRAM  
			#pragma vertex vert   
			#pragma fragment frag   
			#include "UnityCG.cginc"   
			fixed4 _Color;
			float4 _Color_ROOT;
			float4 _MainTex_ST;
			sampler2D _MainTex;   
			sampler2D _wave;   
			float _p; 
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
				OUT.pos = UnityObjectToClipPos(IN.vertex);
				OUT.color = IN.color * _Color;
				OUT._uv_MainTex = TRANSFORM_TEX(IN.texcoord,_MainTex);
				OUT._uv_STD = TRANSFORM_TEX(IN.texcoord,_MainTex);  
				return OUT;
			}   
			float4 frag (v2f i) : COLOR {
				float4 result = float4(0,0,0,0);


				//====================================
				//============ alpha1 ============   
				float2  uv_alpha1 = i._uv_STD;
				float2 center_alpha1 = float2(0.5,0.5);    
				uv_alpha1 = uv_alpha1-center_alpha1;    
				uv_alpha1 = uv_alpha1+fixed2(0,0);    
				uv_alpha1 = uv_alpha1+fixed2(0,0)*(_Time.y);    
				uv_alpha1 = UV_RotateAround(fixed2(0,0),uv_alpha1,0);    
				uv_alpha1 = uv_alpha1/fixed2(1,1);    
				float2 dir_alpha1 = uv_alpha1/length(uv_alpha1);    
				uv_alpha1 = uv_alpha1-dir_alpha1*fixed2(0,0)*(_Time.y);    
				uv_alpha1 = UV_RotateAround(fixed2(0,0),uv_alpha1,0*(_Time.y));    
				uv_alpha1 = uv_alpha1+center_alpha1;    
				float4 rect_alpha1 =  float4(1,1,1,1);
				float4 color_alpha1 = tex2D(_wave,uv_alpha1);    
				float aplha_alpha1 = -1 +1.5*(_p) + color_alpha1.r;


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
				float4 rect_ROOT =  float4(1,1,1,1);
				float4 color_ROOT = tex2D(_MainTex,uv_ROOT);    
				color_ROOT = float4(color_ROOT.rgb,color_ROOT.a* lerp(1,clamp(aplha_alpha1*1*((1)),0,1),1*((1))));    
				float4 rootTexColor = color_ROOT;
				color_ROOT = color_ROOT*_Color_ROOT;
				result = color_ROOT;
				result = result*i.color;
				clip(result.a - 0);
				return result;
			}  
			ENDCG
		}
	}
	fallback "Standard"
}
