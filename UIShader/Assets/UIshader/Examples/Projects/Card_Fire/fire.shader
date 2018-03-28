// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

//ShaderWeaverData{"shaderQueue":3000,"shaderQueueOffset":0,"shaderType":0,"spriteLightType":0,"shaderModel":0,"shaderBlend":0,"excludeRoot":false,"version":121,"pixelPerUnit":0.0,"spriteRect":{"serializedVersion":"2","x":0.0,"y":0.0,"width":0.0,"height":0.0},"title":"fire","materialGUID":"d9575cd229669ef4e8d2fe7146428c51","masksGUID":["dd3a69721bf25594586cc14b9ab6da03"],"paramList":[],"nodes":[{"useNormal":false,"id":"7eb7a8f2_614b_47e3_86ae_95f393665df3","name":"ROOT","depth":1,"type":0,"parentPortNumber":1,"parent":[],"parentPort":[],"childPortNumber":1,"children":["c0dce0ee_588b_49dc_8559_06ffaacacca1"],"childrenPort":[0],"textureExGUID":"","textureGUID":"334828e01a07a4d49be44052ef938ab8","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":912.0,"y":331.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":0.0,"y":0.0},"r_angle":0.0,"s_scale":{"x":1.0,"y":1.0},"t_speed":{"x":0.0,"y":0.0},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"1","pop_channel":3,"useLoop":false,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":0,"param":"(1)"},"effectDataUV":{"op":0,"param":"1","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[0],"inputType":[0,1,3],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":0,"strs":[]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]},{"useNormal":false,"id":"3f60a0b1_38a9_45f2_bf6e_c6494fa65014","name":"image2","depth":5,"type":13,"parentPortNumber":1,"parent":["c0dce0ee_588b_49dc_8559_06ffaacacca1"],"parentPort":[0],"childPortNumber":1,"children":["2f5a09a5_2c98_4c80_9349_fad8ebf312e6","feba9a05_baa9_423f_a5eb_3fb27b3124da"],"childrenPort":[0,0],"textureExGUID":"","textureGUID":"6b50937b678fd4144877b602d623578a","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":559.0,"y":329.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":-0.015510708093643189,"y":0.2230849266052246},"r_angle":0.0,"s_scale":{"x":0.6875,"y":0.44218724966049197},"t_speed":{"x":0.0,"y":0.0},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"1","pop_channel":3,"useLoop":false,"loopX":1,"gapX":0.0,"loopY":1,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":0,"param":"(1)"},"effectDataUV":{"op":0,"param":"1","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[0],"inputType":[1,3,0],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":1,"strs":["7eb7a8f2_614b_47e3_86ae_95f393665df3","c0dce0ee_588b_49dc_8559_06ffaacacca1","2f5a09a5_2c98_4c80_9349_fad8ebf312e6","87cb5309_91a7_4ddc_a931_7ace20e49e0b","feba9a05_baa9_423f_a5eb_3fb27b3124da","ab152e72_55eb_4c9c_a117_18c6003391dd"]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]},{"useNormal":false,"id":"c0dce0ee_588b_49dc_8559_06ffaacacca1","name":"mask3","depth":1,"type":1,"parentPortNumber":1,"parent":["7eb7a8f2_614b_47e3_86ae_95f393665df3"],"parentPort":[0],"childPortNumber":1,"children":["3f60a0b1_38a9_45f2_bf6e_c6494fa65014","ab152e72_55eb_4c9c_a117_18c6003391dd"],"childrenPort":[0,0],"textureExGUID":"","textureGUID":"dd3a69721bf25594586cc14b9ab6da03","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":732.0,"y":331.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":0.0,"y":0.0},"r_angle":0.0,"s_scale":{"x":1.0,"y":1.0},"t_speed":{"x":0.0,"y":0.0},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"1","pop_channel":3,"useLoop":false,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":0,"param":"(1)"},"effectDataUV":{"op":0,"param":"1","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[0,1,3],"inputType":[0,1,3],"dirty":false,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":1,"strs":["7eb7a8f2_614b_47e3_86ae_95f393665df3","3f60a0b1_38a9_45f2_bf6e_c6494fa65014","2f5a09a5_2c98_4c80_9349_fad8ebf312e6","87cb5309_91a7_4ddc_a931_7ace20e49e0b","feba9a05_baa9_423f_a5eb_3fb27b3124da","ab152e72_55eb_4c9c_a117_18c6003391dd"]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]},{"useNormal":false,"id":"2f5a09a5_2c98_4c80_9349_fad8ebf312e6","name":"uv4","depth":1,"type":4,"parentPortNumber":1,"parent":["3f60a0b1_38a9_45f2_bf6e_c6494fa65014"],"parentPort":[0],"childPortNumber":1,"children":[],"childrenPort":[],"textureExGUID":"","textureGUID":"fa3108da2fe38a748bfce58b4c9b5410","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":370.0,"y":330.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":-0.026731550693511964,"y":0.2074243724346161},"r_angle":0.0,"s_scale":{"x":0.703986644744873,"y":0.4262745976448059},"t_speed":{"x":-0.00023490190505981445,"y":0.13911449909210206},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"1","pop_channel":3,"useLoop":false,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":0,"param":"(1)"},"effectDataUV":{"op":0,"param":"1","amountR":{"x":-0.08654969930648804,"y":0.11093500256538391},"amountG":{"x":0.15759092569351197,"y":0.01718500256538391},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[1],"inputType":[1],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":-1,"strs":["7eb7a8f2_614b_47e3_86ae_95f393665df3","3f60a0b1_38a9_45f2_bf6e_c6494fa65014","c0dce0ee_588b_49dc_8559_06ffaacacca1"]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]},{"useNormal":false,"id":"87cb5309_91a7_4ddc_a931_7ace20e49e0b","name":"uv1","depth":1,"type":4,"parentPortNumber":1,"parent":["feba9a05_baa9_423f_a5eb_3fb27b3124da"],"parentPort":[0],"childPortNumber":1,"children":[],"childrenPort":[],"textureExGUID":"","textureGUID":"fa3108da2fe38a748bfce58b4c9b5410","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":185.0,"y":501.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":-0.36328125,"y":0.099609375},"r_angle":0.0,"s_scale":{"x":1.76171875,"y":1.1705245971679688},"t_speed":{"x":0.0,"y":0.16015625},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"1","pop_channel":3,"useLoop":false,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":0,"param":"(1)"},"effectDataUV":{"op":0,"param":"1","amountR":{"x":0.011718511581420899,"y":0.484375},"amountG":{"x":0.4179685115814209,"y":0.28515625},"amountB":{"x":-0.4160158634185791,"y":0.365234375},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[1],"inputType":[1],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":23,"strs":["7eb7a8f2_614b_47e3_86ae_95f393665df3","3f60a0b1_38a9_45f2_bf6e_c6494fa65014","c0dce0ee_588b_49dc_8559_06ffaacacca1","2f5a09a5_2c98_4c80_9349_fad8ebf312e6","feba9a05_baa9_423f_a5eb_3fb27b3124da"]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]},{"useNormal":false,"id":"feba9a05_baa9_423f_a5eb_3fb27b3124da","name":"image2copy","depth":7,"type":13,"parentPortNumber":1,"parent":["3f60a0b1_38a9_45f2_bf6e_c6494fa65014"],"parentPort":[0],"childPortNumber":1,"children":["87cb5309_91a7_4ddc_a931_7ace20e49e0b"],"childrenPort":[0],"textureExGUID":"","textureGUID":"8232b5b711e72f946b2039e6c4f4f373","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":372.0,"y":500.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":-0.015625,"y":-0.173828125},"r_angle":0.0,"s_scale":{"x":0.755859375,"y":0.576171875},"t_speed":{"x":0.0,"y":0.0},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"1","pop_channel":3,"useLoop":true,"loopX":1,"gapX":0.0,"loopY":1,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":0.3659999966621399,"b":0.0,"a":1.0},"op":3,"param":"(1)"},"effectDataUV":{"op":0,"param":"1","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[0],"inputType":[1,3,0],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":7,"strs":["7eb7a8f2_614b_47e3_86ae_95f393665df3","3f60a0b1_38a9_45f2_bf6e_c6494fa65014","c0dce0ee_588b_49dc_8559_06ffaacacca1","2f5a09a5_2c98_4c80_9349_fad8ebf312e6","87cb5309_91a7_4ddc_a931_7ace20e49e0b"]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]},{"useNormal":false,"id":"ab152e72_55eb_4c9c_a117_18c6003391dd","name":"image6","depth":1,"type":13,"parentPortNumber":1,"parent":["c0dce0ee_588b_49dc_8559_06ffaacacca1"],"parentPort":[0],"childPortNumber":1,"children":[],"childrenPort":[],"textureExGUID":"","textureGUID":"9b21924c8bf77f74387d08a607de7a5d","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":558.0,"y":138.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":-0.025313138961791993,"y":0.18567997217178346},"r_angle":0.0,"s_scale":{"x":0.7386264801025391,"y":0.45567089319229128},"t_speed":{"x":0.0,"y":0.0},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"1","pop_channel":3,"useLoop":true,"loopX":1,"gapX":0.0,"loopY":1,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":0,"param":"(1)"},"effectDataUV":{"op":0,"param":"1","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[0],"inputType":[1,3,0],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":5,"strs":["7eb7a8f2_614b_47e3_86ae_95f393665df3","3f60a0b1_38a9_45f2_bf6e_c6494fa65014","c0dce0ee_588b_49dc_8559_06ffaacacca1","2f5a09a5_2c98_4c80_9349_fad8ebf312e6","87cb5309_91a7_4ddc_a931_7ace20e49e0b","feba9a05_baa9_423f_a5eb_3fb27b3124da"]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]}],"clipValue":0.5,"fallback":"Standard"}
Shader "Shader Weaver/fire"{   
	Properties {   
		_Color ("Color", Color) = (1,1,1,1)
		_Color_ROOT ("Color ROOT", Color) = (1,1,1,1)
		_Color_image2 ("Color image2", Color) = (1,1,1,1)
		_Color_image2copy ("Color image2copy", Color) = (1,0.366,0,1)
		_Color_image6 ("Color image6", Color) = (1,1,1,1)
		_MainTex ("_MainTex", 2D) = "white" { }
		_flame ("_flame", 2D) = "white" { }
		_fire_mask0 ("_fire_mask0", 2D) = "white" { }
		_wave ("_wave", 2D) = "white" { }
		_dotsFlame ("_dotsFlame", 2D) = "white" { }
		_fireBG ("_fireBG", 2D) = "white" { }
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
			float4 _Color_image2;
			float4 _Color_image2copy;
			float4 _Color_image6;
			float4 _MainTex_ST;
			sampler2D _MainTex;   
			sampler2D _flame;   
			sampler2D _fire_mask0;   
			sampler2D _wave;   
			sampler2D _dotsFlame;   
			sampler2D _fireBG;   
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
				float4 color_fire_mask0 = tex2D(_fire_mask0,i._uv_STD);    
				float4 result = float4(0,0,0,0);


				//====================================
				//============ uv4 ============   
				float2  uv_uv4 = i._uv_STD;
				float2 center_uv4 = float2(0.5,0.5);    
				uv_uv4 = uv_uv4-center_uv4;    
				uv_uv4 = uv_uv4+fixed2(0.02673155,-0.2074244);    
				uv_uv4 = uv_uv4+fixed2(0.0002349019,-0.1391145)*(_Time.y);    
				uv_uv4 = UV_RotateAround(fixed2(0,0),uv_uv4,0);    
				uv_uv4 = uv_uv4/fixed2(0.7039866,0.4262746);    
				float2 dir_uv4 = uv_uv4/length(uv_uv4);    
				uv_uv4 = uv_uv4-dir_uv4*fixed2(0,0)*(_Time.y);    
				uv_uv4 = UV_RotateAround(fixed2(0,0),uv_uv4,0*(_Time.y));    
				uv_uv4 = uv_uv4+center_uv4;    
				float4 rect_uv4 =  float4(1,1,1,1);
				float4 color_uv4 = tex2D(_wave,uv_uv4);    
				uv_uv4 = -(color_uv4.r*fixed2(-0.0865497,0.110935) + color_uv4.g*fixed2(0.1575909,0.017185) + color_uv4.b*fixed2(0,0) +  color_uv4.a*fixed2(0,0));    


				//====================================
				//============ uv1 ============   
				float2  uv_uv1 = i._uv_STD;
				float2 center_uv1 = float2(0.5,0.5);    
				uv_uv1 = uv_uv1-center_uv1;    
				uv_uv1 = uv_uv1+fixed2(0.3632813,-0.09960938);    
				uv_uv1 = uv_uv1+fixed2(0,-0.1601563)*(_Time.y);    
				uv_uv1 = UV_RotateAround(fixed2(0,0),uv_uv1,0);    
				uv_uv1 = uv_uv1/fixed2(1.761719,1.170525);    
				float2 dir_uv1 = uv_uv1/length(uv_uv1);    
				uv_uv1 = uv_uv1-dir_uv1*fixed2(0,0)*(_Time.y);    
				uv_uv1 = UV_RotateAround(fixed2(0,0),uv_uv1,0*(_Time.y));    
				uv_uv1 = uv_uv1+center_uv1;    
				float4 rect_uv1 =  float4(1,1,1,1);
				float4 color_uv1 = tex2D(_wave,uv_uv1);    
				uv_uv1 = -(color_uv1.r*fixed2(0.01171851,0.484375) + color_uv1.g*fixed2(0.4179685,0.2851563) + color_uv1.b*fixed2(-0.4160159,0.3652344) +  color_uv1.a*fixed2(0,0));    


				//====================================
				//============ image2copy ============   
				float2  uv_image2copy = i._uv_STD;
				float2 center_image2copy = float2(0.5,0.5);    
				uv_image2copy = uv_image2copy-center_image2copy;    
				uv_image2copy = uv_image2copy+fixed2(0.015625,0.1738281);    
				uv_image2copy = uv_image2copy+fixed2(0,0)*(_Time.y);    
				uv_image2copy = UV_RotateAround(fixed2(0,0),uv_image2copy,0);    
				uv_image2copy = uv_image2copy/fixed2(0.7558594,0.5761719);    
				float2 dir_image2copy = uv_image2copy/length(uv_image2copy);    
				uv_image2copy = uv_image2copy-dir_image2copy*fixed2(0,0)*(_Time.y);    
				uv_image2copy = UV_RotateAround(fixed2(0,0),uv_image2copy,0*(_Time.y));    
				uv_image2copy = uv_image2copy+center_image2copy;    
				uv_image2copy = uv_image2copy + uv_uv1*1*(1);
				float2 uv_image2copyorgin = uv_image2copy;
				uv_image2copy = float2(uv_image2copy.x >0 ?(uv_image2copy.x%(1+0)) : (1+0) - abs(uv_image2copy.x)%(1+0), uv_image2copy.y >0 ?(uv_image2copy.y%(1+0)) : (1+0) - abs(uv_image2copy.y)%(1+0));
				bool discard_image2copy = false;
				if(uv_image2copy.x>1 || uv_image2copy.y>1)
					discard_image2copy = true;
				if(uv_image2copyorgin.x<0)
					discard_image2copy = true;
				if(uv_image2copyorgin.x>1)
					discard_image2copy = true;
				if(uv_image2copyorgin.y<0)
					discard_image2copy = true;
				if(uv_image2copyorgin.y>1)
					discard_image2copy = true;
				float4 rect_image2copy =  float4(1,1,1,1);
				float4 color_image2copy = tex2D(_dotsFlame,uv_image2copy);    
				if(discard_image2copy == true) color_image2copy = float4(0,0,0,0);
				color_image2copy = color_image2copy*_Color_image2copy;


				//====================================
				//============ image2 ============   
				float2  uv_image2 = i._uv_STD;
				float2 center_image2 = float2(0.5,0.5);    
				uv_image2 = uv_image2-center_image2;    
				uv_image2 = uv_image2+fixed2(0.01551071,-0.2230849);    
				uv_image2 = uv_image2+fixed2(0,0)*(_Time.y);    
				uv_image2 = UV_RotateAround(fixed2(0,0),uv_image2,0);    
				uv_image2 = uv_image2/fixed2(0.6875,0.4421872);    
				float2 dir_image2 = uv_image2/length(uv_image2);    
				uv_image2 = uv_image2-dir_image2*fixed2(0,0)*(_Time.y);    
				uv_image2 = UV_RotateAround(fixed2(0,0),uv_image2,0*(_Time.y));    
				uv_image2 = uv_image2+center_image2;    
				uv_image2 = uv_image2 + uv_uv4*1*(1);
				float4 rect_image2 =  float4(1,1,1,1);
				float4 color_image2 = tex2D(_flame,uv_image2);    
				color_image2 = color_image2*_Color_image2;


				//====================================
				//============ image6 ============   
				float2  uv_image6 = i._uv_STD;
				float2 center_image6 = float2(0.5,0.5);    
				uv_image6 = uv_image6-center_image6;    
				uv_image6 = uv_image6+fixed2(0.02531314,-0.18568);    
				uv_image6 = uv_image6+fixed2(0,0)*(_Time.y);    
				uv_image6 = UV_RotateAround(fixed2(0,0),uv_image6,0);    
				uv_image6 = uv_image6/fixed2(0.7386265,0.4556709);    
				float2 dir_image6 = uv_image6/length(uv_image6);    
				uv_image6 = uv_image6-dir_image6*fixed2(0,0)*(_Time.y);    
				uv_image6 = UV_RotateAround(fixed2(0,0),uv_image6,0*(_Time.y));    
				uv_image6 = uv_image6+center_image6;    
				float2 uv_image6orgin = uv_image6;
				uv_image6 = float2(uv_image6.x >0 ?(uv_image6.x%(1+0)) : (1+0) - abs(uv_image6.x)%(1+0), uv_image6.y >0 ?(uv_image6.y%(1+0)) : (1+0) - abs(uv_image6.y)%(1+0));
				bool discard_image6 = false;
				if(uv_image6.x>1 || uv_image6.y>1)
					discard_image6 = true;
				if(uv_image6orgin.x<0)
					discard_image6 = true;
				if(uv_image6orgin.x>1)
					discard_image6 = true;
				if(uv_image6orgin.y<0)
					discard_image6 = true;
				if(uv_image6orgin.y>1)
					discard_image6 = true;
				float4 rect_image6 =  float4(1,1,1,1);
				float4 color_image6 = tex2D(_fireBG,uv_image6);    
				if(discard_image6 == true) color_image6 = float4(0,0,0,0);
				color_image6 = color_image6*_Color_image6;


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
				result = lerp(result,float4(color_image6.rgb,1),clamp(color_image6.a*1*((1))*color_fire_mask0.r,0,1));    
				result = lerp(result,float4(color_image2.rgb,1),clamp(color_image2.a*1*((1))*color_fire_mask0.r,0,1));    
				result = result+float4(color_image2copy.rgb*color_image2copy.a*1*((1))*color_fire_mask0.r,color_image2copy.a*1*((1))*color_fire_mask0.r*(rootTexColor.a - result.a));
				result = result*i.color;
				clip(result.a - 0.5);
				return result;
			}  
			ENDCG
		}
	}
	fallback "Standard"
}
