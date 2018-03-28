// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

//ShaderWeaverData{"shaderQueue":3000,"shaderQueueOffset":0,"shaderType":0,"spriteLightType":0,"shaderModel":0,"shaderBlend":0,"excludeRoot":false,"version":121,"pixelPerUnit":0.0,"spriteRect":{"serializedVersion":"2","x":0.0,"y":0.0,"width":0.0,"height":0.0},"title":"lightening","materialGUID":"10b1f56ee5293ed44a488cc64983507b","masksGUID":["1cc2500e3898d3c4b8a796ab2cdf00b1"],"paramList":[],"nodes":[{"useNormal":false,"id":"0f65a711_42e1_434a_9150_e94161feb4e6","name":"ROOT","depth":1,"type":0,"parentPortNumber":1,"parent":[],"parentPort":[],"childPortNumber":1,"children":["66039a2b_1167_461c_b3f8_a67e300691bb"],"childrenPort":[0],"textureExGUID":"","textureGUID":"35b9f5d688815d445b5fa6c8068f87fe","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":966.0,"y":386.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":0.0,"y":0.0},"r_angle":0.0,"s_scale":{"x":1.0,"y":1.0},"t_speed":{"x":0.0,"y":0.0},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"1","pop_channel":3,"useLoop":false,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":0,"param":"(1)"},"effectDataUV":{"op":0,"param":"1","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[0],"inputType":[0,1,3],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":0,"strs":[]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]},{"useNormal":false,"id":"63770a84_5fc2_48aa_b0fa_b60b4efa048a","name":"image1","depth":3,"type":13,"parentPortNumber":1,"parent":["66039a2b_1167_461c_b3f8_a67e300691bb"],"parentPort":[0],"childPortNumber":1,"children":["98ebba93_1f6c_4dd4_a79c_c08a6f4109ac"],"childrenPort":[0],"textureExGUID":"","textureGUID":"c6317ed9a1afb7446a1fb60b00732053","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":525.0,"y":383.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":-0.03125,"y":0.248046875},"r_angle":0.0,"s_scale":{"x":0.701171875,"y":0.39420729875564577},"t_speed":{"x":0.0,"y":0.0},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"1","pop_channel":3,"useLoop":false,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":3,"param":"(1)"},"effectDataUV":{"op":0,"param":"1","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[0],"inputType":[1,3,0],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":-1,"strs":["0f65a711_42e1_434a_9150_e94161feb4e6","66039a2b_1167_461c_b3f8_a67e300691bb","98ebba93_1f6c_4dd4_a79c_c08a6f4109ac","8a1b45c0_0959_49bb_a38f_60b90c0eb070"]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]},{"useNormal":false,"id":"66039a2b_1167_461c_b3f8_a67e300691bb","name":"mask2","depth":1,"type":1,"parentPortNumber":1,"parent":["0f65a711_42e1_434a_9150_e94161feb4e6"],"parentPort":[0],"childPortNumber":1,"children":["63770a84_5fc2_48aa_b0fa_b60b4efa048a","8a1b45c0_0959_49bb_a38f_60b90c0eb070"],"childrenPort":[0,0],"textureExGUID":"","textureGUID":"1cc2500e3898d3c4b8a796ab2cdf00b1","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":735.0,"y":386.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":0.0,"y":0.0},"r_angle":0.0,"s_scale":{"x":1.0,"y":1.0},"t_speed":{"x":0.0,"y":0.0},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"1","pop_channel":3,"useLoop":false,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":0,"param":"(1)"},"effectDataUV":{"op":0,"param":"1","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[0,1,3],"inputType":[0,1,3],"dirty":false,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":1,"strs":["0f65a711_42e1_434a_9150_e94161feb4e6","63770a84_5fc2_48aa_b0fa_b60b4efa048a","98ebba93_1f6c_4dd4_a79c_c08a6f4109ac","8a1b45c0_0959_49bb_a38f_60b90c0eb070"]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]},{"useNormal":false,"id":"98ebba93_1f6c_4dd4_a79c_c08a6f4109ac","name":"alpha3","depth":1,"type":5,"parentPortNumber":1,"parent":["63770a84_5fc2_48aa_b0fa_b60b4efa048a"],"parentPort":[0],"childPortNumber":1,"children":[],"childrenPort":[],"textureExGUID":"","textureGUID":"f0c751e3e6b99b549bfc463f96fc132f","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":303.0,"y":384.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":0.0,"y":0.0},"r_angle":0.0,"s_scale":{"x":1.0,"y":1.0},"t_speed":{"x":-0.00390625,"y":-0.3984375},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":-1.0,"pop_speed":1.0,"pop_Param":"_Time.y%1<0.2?(_Time.y%0.04<0.02?1:0):0","pop_channel":3,"useLoop":false,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":0,"param":"(1)"},"effectDataUV":{"op":0,"param":"1","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[3],"inputType":[1],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":-1,"strs":["0f65a711_42e1_434a_9150_e94161feb4e6","63770a84_5fc2_48aa_b0fa_b60b4efa048a","66039a2b_1167_461c_b3f8_a67e300691bb"]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]},{"useNormal":false,"id":"8a1b45c0_0959_49bb_a38f_60b90c0eb070","name":"image4","depth":1,"type":13,"parentPortNumber":1,"parent":["66039a2b_1167_461c_b3f8_a67e300691bb"],"parentPort":[0],"childPortNumber":1,"children":[],"childrenPort":[],"textureExGUID":"","textureGUID":"ef6061ba80c02934f89138a77849e122","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":529.0,"y":213.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":-0.024382054805755616,"y":0.20947575569152833},"r_angle":0.0,"s_scale":{"x":0.721840500831604,"y":0.4173038601875305},"t_speed":{"x":0.0,"y":0.0},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"1","pop_channel":3,"useLoop":false,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":0,"param":"(1)"},"effectDataUV":{"op":0,"param":"1","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[0],"inputType":[1,3,0],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":5,"strs":["0f65a711_42e1_434a_9150_e94161feb4e6","63770a84_5fc2_48aa_b0fa_b60b4efa048a","66039a2b_1167_461c_b3f8_a67e300691bb","98ebba93_1f6c_4dd4_a79c_c08a6f4109ac"]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]}],"clipValue":0.5,"fallback":"Standard"}
Shader "Shader Weaver/lightening"{   
	Properties {   
		_Color ("Color", Color) = (1,1,1,1)
		_Color_ROOT ("Color ROOT", Color) = (1,1,1,1)
		_Color_image1 ("Color image1", Color) = (1,1,1,1)
		_Color_image4 ("Color image4", Color) = (1,1,1,1)
		_MainTex ("_MainTex", 2D) = "white" { }
		_lightening ("_lightening", 2D) = "white" { }
		_lightening_mask0 ("_lightening_mask0", 2D) = "white" { }
		_ramp ("_ramp", 2D) = "white" { }
		_lighteningBg ("_lighteningBg", 2D) = "white" { }
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
			float4 _Color_image1;
			float4 _Color_image4;
			float4 _MainTex_ST;
			sampler2D _MainTex;   
			sampler2D _lightening;   
			sampler2D _lightening_mask0;   
			sampler2D _ramp;   
			sampler2D _lighteningBg;   
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
				float4 color_lightening_mask0 = tex2D(_lightening_mask0,i._uv_STD);    
				float4 result = float4(0,0,0,0);


				//====================================
				//============ alpha3 ============   
				float2  uv_alpha3 = i._uv_STD;
				float2 center_alpha3 = float2(0.5,0.5);    
				uv_alpha3 = uv_alpha3-center_alpha3;    
				uv_alpha3 = uv_alpha3+fixed2(0,0);    
				uv_alpha3 = uv_alpha3+fixed2(0.00390625,0.3984375)*(_Time.y);    
				uv_alpha3 = UV_RotateAround(fixed2(0,0),uv_alpha3,0);    
				uv_alpha3 = uv_alpha3/fixed2(1,1);    
				float2 dir_alpha3 = uv_alpha3/length(uv_alpha3);    
				uv_alpha3 = uv_alpha3-dir_alpha3*fixed2(0,0)*(_Time.y);    
				uv_alpha3 = UV_RotateAround(fixed2(0,0),uv_alpha3,0*(_Time.y));    
				uv_alpha3 = uv_alpha3+center_alpha3;    
				float4 rect_alpha3 =  float4(1,1,1,1);
				float4 color_alpha3 = tex2D(_ramp,uv_alpha3);    
				float aplha_alpha3 = -1 +1*(_Time.y%1<0.2?(_Time.y%0.04<0.02?1:0):0) + color_alpha3.a;


				//====================================
				//============ image1 ============   
				float2  uv_image1 = i._uv_STD;
				float2 center_image1 = float2(0.5,0.5);    
				uv_image1 = uv_image1-center_image1;    
				uv_image1 = uv_image1+fixed2(0.03125,-0.2480469);    
				uv_image1 = uv_image1+fixed2(0,0)*(_Time.y);    
				uv_image1 = UV_RotateAround(fixed2(0,0),uv_image1,0);    
				uv_image1 = uv_image1/fixed2(0.7011719,0.3942073);    
				float2 dir_image1 = uv_image1/length(uv_image1);    
				uv_image1 = uv_image1-dir_image1*fixed2(0,0)*(_Time.y);    
				uv_image1 = UV_RotateAround(fixed2(0,0),uv_image1,0*(_Time.y));    
				uv_image1 = uv_image1+center_image1;    
				float4 rect_image1 =  float4(1,1,1,1);
				float4 color_image1 = tex2D(_lightening,uv_image1);    
				color_image1 = float4(color_image1.rgb,color_image1.a* lerp(1,clamp(aplha_alpha3*1*((1)),0,1),1*((1))));    
				color_image1 = color_image1*_Color_image1;


				//====================================
				//============ image4 ============   
				float2  uv_image4 = i._uv_STD;
				float2 center_image4 = float2(0.5,0.5);    
				uv_image4 = uv_image4-center_image4;    
				uv_image4 = uv_image4+fixed2(0.02438205,-0.2094758);    
				uv_image4 = uv_image4+fixed2(0,0)*(_Time.y);    
				uv_image4 = UV_RotateAround(fixed2(0,0),uv_image4,0);    
				uv_image4 = uv_image4/fixed2(0.7218405,0.4173039);    
				float2 dir_image4 = uv_image4/length(uv_image4);    
				uv_image4 = uv_image4-dir_image4*fixed2(0,0)*(_Time.y);    
				uv_image4 = UV_RotateAround(fixed2(0,0),uv_image4,0*(_Time.y));    
				uv_image4 = uv_image4+center_image4;    
				float4 rect_image4 =  float4(1,1,1,1);
				float4 color_image4 = tex2D(_lighteningBg,uv_image4);    
				color_image4 = color_image4*_Color_image4;


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
				float4 rootTexColor = color_ROOT;
				color_ROOT = color_ROOT*_Color_ROOT;
				result = color_ROOT;
				result = lerp(result,float4(color_image4.rgb,1),clamp(color_image4.a*1*((1))*color_lightening_mask0.r,0,1));    
				result = result+float4(color_image1.rgb*color_image1.a*1*((1))*color_lightening_mask0.r,color_image1.a*1*((1))*color_lightening_mask0.r*(rootTexColor.a - result.a));
				result = result*i.color;
				clip(result.a - 0.5);
				return result;
			}  
			ENDCG
		}
	}
	fallback "Standard"
}
