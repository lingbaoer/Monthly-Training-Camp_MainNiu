// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

//ShaderWeaverData{"shaderQueue":3000,"shaderQueueOffset":0,"shaderType":0,"spriteLightType":0,"shaderModel":0,"shaderBlend":0,"excludeRoot":false,"version":121,"pixelPerUnit":0.0,"spriteRect":{"serializedVersion":"2","x":0.0,"y":0.0,"width":0.0,"height":0.0},"title":"wolf","materialGUID":"3ab9fc6495525604ea8ac12fbc0ed0ee","masksGUID":["80a9a7d037a944d43a2540a8e7c3e0f9"],"paramList":[],"nodes":[{"useNormal":false,"id":"88954ad0_8b0f_41cc_b931_2e1621c04b5a","name":"ROOT","depth":1,"type":0,"parentPortNumber":1,"parent":[],"parentPort":[],"childPortNumber":1,"children":["cea208a4_1610_44cb_8e24_414c60d7c08a"],"childrenPort":[0],"textureExGUID":"","textureGUID":"2d64cbc1d0e905c4f909c7f5753bcd18","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":922.0,"y":281.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":0.0,"y":0.0},"r_angle":0.0,"s_scale":{"x":1.0,"y":1.0},"t_speed":{"x":0.0,"y":0.0},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"1","pop_channel":3,"useLoop":false,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":0,"param":"(1)"},"effectDataUV":{"op":0,"param":"1","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[0],"inputType":[0,1,3],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":0,"strs":[]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]},{"useNormal":false,"id":"cea208a4_1610_44cb_8e24_414c60d7c08a","name":"mask1","depth":1,"type":1,"parentPortNumber":1,"parent":["88954ad0_8b0f_41cc_b931_2e1621c04b5a"],"parentPort":[0],"childPortNumber":1,"children":["3d7e5192_57b9_40aa_9e88_aedc0a480a11"],"childrenPort":[0],"textureExGUID":"","textureGUID":"80a9a7d037a944d43a2540a8e7c3e0f9","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":761.0,"y":281.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":0.0,"y":0.0},"r_angle":0.0,"s_scale":{"x":1.0,"y":1.0},"t_speed":{"x":0.0,"y":0.0},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"1","pop_channel":3,"useLoop":false,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":0,"param":"(1)"},"effectDataUV":{"op":0,"param":"1","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[0,1,3],"inputType":[0,1,3],"dirty":false,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":1,"strs":["88954ad0_8b0f_41cc_b931_2e1621c04b5a","3d7e5192_57b9_40aa_9e88_aedc0a480a11","e43ef0e4_8118_45fc_8e34_896d055e3e35","235e6080_5004_4811_a1a1_a426df2e47a5","2770434e_3899_47b5_b2d3_3485f7107436","73da3ac3_4dc2_4bba_88a7_d77a8f4b7ad3","f6d83e71_f475_401a_9ff0_1639c516418f","403fc233_1af8_4106_8df1_e2fdffae22b9"]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]},{"useNormal":false,"id":"3d7e5192_57b9_40aa_9e88_aedc0a480a11","name":"image4","depth":8,"type":13,"parentPortNumber":1,"parent":["cea208a4_1610_44cb_8e24_414c60d7c08a"],"parentPort":[0],"childPortNumber":1,"children":["e43ef0e4_8118_45fc_8e34_896d055e3e35"],"childrenPort":[0],"textureExGUID":"","textureGUID":"8c08083f0f3823145b2598f2cfbe7bea","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":600.0,"y":281.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":-0.041015803813934329,"y":0.19140625},"r_angle":0.0,"s_scale":{"x":0.7608381509780884,"y":0.4642876386642456},"t_speed":{"x":0.0,"y":0.0},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"1","pop_channel":3,"useLoop":false,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":0,"param":"(1)"},"effectDataUV":{"op":0,"param":"1","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[0],"inputType":[1,3,0],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":31,"strs":["88954ad0_8b0f_41cc_b931_2e1621c04b5a","cea208a4_1610_44cb_8e24_414c60d7c08a","e43ef0e4_8118_45fc_8e34_896d055e3e35","235e6080_5004_4811_a1a1_a426df2e47a5","2770434e_3899_47b5_b2d3_3485f7107436","73da3ac3_4dc2_4bba_88a7_d77a8f4b7ad3","f6d83e71_f475_401a_9ff0_1639c516418f","403fc233_1af8_4106_8df1_e2fdffae22b9"]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]},{"useNormal":false,"id":"e43ef0e4_8118_45fc_8e34_896d055e3e35","name":"image5","depth":9,"type":13,"parentPortNumber":1,"parent":["3d7e5192_57b9_40aa_9e88_aedc0a480a11"],"parentPort":[0],"childPortNumber":1,"children":["235e6080_5004_4811_a1a1_a426df2e47a5","73da3ac3_4dc2_4bba_88a7_d77a8f4b7ad3","403fc233_1af8_4106_8df1_e2fdffae22b9"],"childrenPort":[0,0,0],"textureExGUID":"","textureGUID":"219bb867436b904419324b830ee8ead6","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":436.0,"y":280.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":0.03125,"y":0.248046875},"r_angle":-0.022294560447335244,"s_scale":{"x":0.46171271800994875,"y":0.23604828119277955},"t_speed":{"x":0.0,"y":0.0},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"1","pop_channel":3,"useLoop":false,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":0,"param":"(1)"},"effectDataUV":{"op":0,"param":"1","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[0],"inputType":[1,3,0],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":19,"strs":["88954ad0_8b0f_41cc_b931_2e1621c04b5a","cea208a4_1610_44cb_8e24_414c60d7c08a","d87d72be_2922_48cb_a86f_f23db9e58850","4fbbfcad_f95d_49df_9e2b_20a6c510e6eb","3d7e5192_57b9_40aa_9e88_aedc0a480a11","235e6080_5004_4811_a1a1_a426df2e47a5","2770434e_3899_47b5_b2d3_3485f7107436"]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]},{"useNormal":false,"id":"235e6080_5004_4811_a1a1_a426df2e47a5","name":"mask6","depth":1,"type":1,"parentPortNumber":1,"parent":["e43ef0e4_8118_45fc_8e34_896d055e3e35"],"parentPort":[0],"childPortNumber":1,"children":["2770434e_3899_47b5_b2d3_3485f7107436"],"childrenPort":[0],"textureExGUID":"","textureGUID":"80a9a7d037a944d43a2540a8e7c3e0f9","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":251.0,"y":280.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":0.0,"y":0.0},"r_angle":0.0,"s_scale":{"x":1.0,"y":1.0},"t_speed":{"x":0.0,"y":0.0},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"1","pop_channel":3,"useLoop":false,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":0,"param":"(1)"},"effectDataUV":{"op":0,"param":"1","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":1,"outputType":[0,1,3],"inputType":[0,1,3],"dirty":false,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":51,"strs":["88954ad0_8b0f_41cc_b931_2e1621c04b5a","cea208a4_1610_44cb_8e24_414c60d7c08a","d87d72be_2922_48cb_a86f_f23db9e58850","4fbbfcad_f95d_49df_9e2b_20a6c510e6eb","3d7e5192_57b9_40aa_9e88_aedc0a480a11","e43ef0e4_8118_45fc_8e34_896d055e3e35","2770434e_3899_47b5_b2d3_3485f7107436"]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]},{"useNormal":false,"id":"2770434e_3899_47b5_b2d3_3485f7107436","name":"image7","depth":22,"type":13,"parentPortNumber":1,"parent":["235e6080_5004_4811_a1a1_a426df2e47a5"],"parentPort":[0],"childPortNumber":1,"children":[],"childrenPort":[],"textureExGUID":"","textureGUID":"f0c751e3e6b99b549bfc463f96fc132f","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":69.0,"y":280.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":0.0,"y":0.0},"r_angle":0.0,"s_scale":{"x":1.0,"y":1.0},"t_speed":{"x":0.0,"y":-0.138671875},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"1","pop_channel":3,"useLoop":false,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":0.0,"g":0.8222108483314514,"b":0.9852941036224365,"a":1.0},"op":3,"param":"(1)"},"effectDataUV":{"op":0,"param":"1","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[0],"inputType":[1,3,0],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":115,"strs":["88954ad0_8b0f_41cc_b931_2e1621c04b5a","cea208a4_1610_44cb_8e24_414c60d7c08a","d87d72be_2922_48cb_a86f_f23db9e58850","4fbbfcad_f95d_49df_9e2b_20a6c510e6eb","3d7e5192_57b9_40aa_9e88_aedc0a480a11","e43ef0e4_8118_45fc_8e34_896d055e3e35","235e6080_5004_4811_a1a1_a426df2e47a5"]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]},{"useNormal":false,"id":"73da3ac3_4dc2_4bba_88a7_d77a8f4b7ad3","name":"image8","depth":23,"type":13,"parentPortNumber":1,"parent":["e43ef0e4_8118_45fc_8e34_896d055e3e35"],"parentPort":[0],"childPortNumber":1,"children":[],"childrenPort":[],"textureExGUID":"","textureGUID":"3a56997b82e6e2f4b9188e194bd481db","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":252.0,"y":116.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":-0.095703125,"y":0.068359375},"r_angle":0.0,"s_scale":{"x":1.0,"y":0.416015625},"t_speed":{"x":0.115234375,"y":0.0},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"1","pop_channel":3,"useLoop":false,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":3,"param":"(1)"},"effectDataUV":{"op":0,"param":"1","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[0],"inputType":[1,3,0],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":51,"strs":["88954ad0_8b0f_41cc_b931_2e1621c04b5a","cea208a4_1610_44cb_8e24_414c60d7c08a","d87d72be_2922_48cb_a86f_f23db9e58850","4fbbfcad_f95d_49df_9e2b_20a6c510e6eb","3d7e5192_57b9_40aa_9e88_aedc0a480a11","e43ef0e4_8118_45fc_8e34_896d055e3e35","235e6080_5004_4811_a1a1_a426df2e47a5","2770434e_3899_47b5_b2d3_3485f7107436"]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]},{"useNormal":false,"id":"f6d83e71_f475_401a_9ff0_1639c516418f","name":"uv9","depth":1,"type":4,"parentPortNumber":1,"parent":["403fc233_1af8_4106_8df1_e2fdffae22b9"],"parentPort":[0],"childPortNumber":1,"children":[],"childrenPort":[],"textureExGUID":"","textureGUID":"ba2b92c5602f6584099e57edcb4a153d","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":67.0,"y":441.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":0.0,"y":7.152557373046875e-7},"r_angle":0.0,"s_scale":{"x":0.3024035096168518,"y":0.25200286507606509},"t_speed":{"x":0.044921875,"y":0.025389909744262697},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"1","pop_channel":3,"useLoop":false,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":0,"param":"(1)"},"effectDataUV":{"op":0,"param":"1","amountR":{"x":-0.00390625,"y":0.021483659744262697},"amountG":{"x":0.017578125,"y":0.015624284744262696},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":0,"outputType":[1],"inputType":[1],"dirty":true,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":563,"strs":["88954ad0_8b0f_41cc_b931_2e1621c04b5a","cea208a4_1610_44cb_8e24_414c60d7c08a","d87d72be_2922_48cb_a86f_f23db9e58850","4fbbfcad_f95d_49df_9e2b_20a6c510e6eb","3d7e5192_57b9_40aa_9e88_aedc0a480a11","e43ef0e4_8118_45fc_8e34_896d055e3e35","235e6080_5004_4811_a1a1_a426df2e47a5","2770434e_3899_47b5_b2d3_3485f7107436","73da3ac3_4dc2_4bba_88a7_d77a8f4b7ad3","403fc233_1af8_4106_8df1_e2fdffae22b9"]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]},{"useNormal":false,"id":"403fc233_1af8_4106_8df1_e2fdffae22b9","name":"mask10","depth":1,"type":1,"parentPortNumber":1,"parent":["e43ef0e4_8118_45fc_8e34_896d055e3e35"],"parentPort":[0],"childPortNumber":1,"children":["f6d83e71_f475_401a_9ff0_1639c516418f"],"childrenPort":[0],"textureExGUID":"","textureGUID":"80a9a7d037a944d43a2540a8e7c3e0f9","useGray":false,"useCustomTexture":false,"textureGUIDGray":"","spriteGUID":"","spriteName":"","rect":{"serializedVersion":"2","x":248.0,"y":440.0,"width":100.0,"height":130.0},"effectData":{"t_startMove":{"x":0.0,"y":0.0},"r_angle":0.0,"s_scale":{"x":1.0,"y":1.0},"t_speed":{"x":0.0,"y":0.0},"r_speed":0.0,"s_speed":{"x":0.0,"y":0.0},"t_Param":"_Time.y","r_Param":"_Time.y","s_Param":"_Time.y","pop_final":false,"pop_min":0.0,"pop_max":1.0,"pop_startValue":0.0,"pop_speed":0.0,"pop_Param":"1","pop_channel":3,"useLoop":false,"loopX":0,"gapX":0.0,"loopY":0,"gapY":0.0,"animationSheetUse":false,"animationSheetCountX":1,"animationSheetCountY":1,"animationSheetLoop":true,"animationSheetSingleRow":false,"animationSheetSingleRowIndex":0,"animationSheetStartFrame":0,"animationSheetFrameFactor":"_Time.y"},"effectDataColor":{"hdr":false,"color":{"r":1.0,"g":1.0,"b":1.0,"a":1.0},"op":0,"param":"(1)"},"effectDataUV":{"op":0,"param":"1","amountR":{"x":0.0,"y":0.0},"amountG":{"x":0.0,"y":0.0},"amountB":{"x":0.0,"y":0.0},"amountA":{"x":0.0,"y":0.0}},"maskChannel":2,"outputType":[0,1,3],"inputType":[0,1,3],"dirty":false,"remap":{"x":0.0,"y":0.05000000074505806},"layerMask":{"mask":63,"strs":["88954ad0_8b0f_41cc_b931_2e1621c04b5a","cea208a4_1610_44cb_8e24_414c60d7c08a","3d7e5192_57b9_40aa_9e88_aedc0a480a11","e43ef0e4_8118_45fc_8e34_896d055e3e35","235e6080_5004_4811_a1a1_a426df2e47a5","2770434e_3899_47b5_b2d3_3485f7107436","73da3ac3_4dc2_4bba_88a7_d77a8f4b7ad3","f6d83e71_f475_401a_9ff0_1639c516418f"]},"blurX":0.0,"blurY":0.0,"blurXParam":"(1)","blurYParam":"(1)","retro":0.0,"retroParam":"(1)","gradients":[]}],"clipValue":0.009999999776482582,"fallback":"Standard"}
Shader "Shader Weaver/wolf"{   
	Properties {   
		_Color ("Color", Color) = (1,1,1,1)
		_Color_ROOT ("Color ROOT", Color) = (1,1,1,1)
		_Color_image4 ("Color image4", Color) = (1,1,1,1)
		_Color_image5 ("Color image5", Color) = (1,1,1,1)
		_Color_image7 ("Color image7", Color) = (0,0.8222108,0.9852941,1)
		_Color_image8 ("Color image8", Color) = (1,1,1,1)
		_MainTex ("_MainTex", 2D) = "white" { }
		_wolf_mask0 ("_wolf_mask0", 2D) = "white" { }
		_wolfN ("_wolfN", 2D) = "white" { }
		_wolfNN ("_wolfNN", 2D) = "white" { }
		_ramp ("_ramp", 2D) = "white" { }
		_smoke ("_smoke", 2D) = "white" { }
		_wave2 ("_wave2", 2D) = "white" { }
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
			float4 _Color_image4;
			float4 _Color_image5;
			float4 _Color_image7;
			float4 _Color_image8;
			float4 _MainTex_ST;
			sampler2D _MainTex;   
			sampler2D _wolf_mask0;   
			sampler2D _wolfN;   
			sampler2D _wolfNN;   
			sampler2D _ramp;   
			sampler2D _smoke;   
			sampler2D _wave2;   
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
				float4 color_wolf_mask0 = tex2D(_wolf_mask0,i._uv_STD);    
				float4 result = float4(0,0,0,0);


				//====================================
				//============ image7 ============   
				float2  uv_image7 = i._uv_STD;
				float2 center_image7 = float2(0.5,0.5);    
				uv_image7 = uv_image7-center_image7;    
				uv_image7 = uv_image7+fixed2(0,0);    
				uv_image7 = uv_image7+fixed2(0,0.1386719)*(_Time.y);    
				uv_image7 = UV_RotateAround(fixed2(0,0),uv_image7,0);    
				uv_image7 = uv_image7/fixed2(1,1);    
				float2 dir_image7 = uv_image7/length(uv_image7);    
				uv_image7 = uv_image7-dir_image7*fixed2(0,0)*(_Time.y);    
				uv_image7 = UV_RotateAround(fixed2(0,0),uv_image7,0*(_Time.y));    
				uv_image7 = uv_image7+center_image7;    
				float4 rect_image7 =  float4(1,1,1,1);
				float4 color_image7 = tex2D(_ramp,uv_image7);    
				color_image7 = color_image7*_Color_image7;


				//====================================
				//============ image8 ============   
				float2  uv_image8 = i._uv_STD;
				float2 center_image8 = float2(0.5,0.5);    
				uv_image8 = uv_image8-center_image8;    
				uv_image8 = uv_image8+fixed2(0.09570313,-0.06835938);    
				uv_image8 = uv_image8+fixed2(-0.1152344,0)*(_Time.y);    
				uv_image8 = UV_RotateAround(fixed2(0,0),uv_image8,0);    
				uv_image8 = uv_image8/fixed2(1,0.4160156);    
				float2 dir_image8 = uv_image8/length(uv_image8);    
				uv_image8 = uv_image8-dir_image8*fixed2(0,0)*(_Time.y);    
				uv_image8 = UV_RotateAround(fixed2(0,0),uv_image8,0*(_Time.y));    
				uv_image8 = uv_image8+center_image8;    
				float4 rect_image8 =  float4(1,1,1,1);
				float4 color_image8 = tex2D(_smoke,uv_image8);    
				color_image8 = color_image8*_Color_image8;


				//====================================
				//============ uv9 ============   
				float2  uv_uv9 = i._uv_STD;
				float2 center_uv9 = float2(0.5,0.5);    
				uv_uv9 = uv_uv9-center_uv9;    
				uv_uv9 = uv_uv9+fixed2(0,-7.152557E-07);    
				uv_uv9 = uv_uv9+fixed2(-0.04492188,-0.02538991)*(_Time.y);    
				uv_uv9 = UV_RotateAround(fixed2(0,0),uv_uv9,0);    
				uv_uv9 = uv_uv9/fixed2(0.3024035,0.2520029);    
				float2 dir_uv9 = uv_uv9/length(uv_uv9);    
				uv_uv9 = uv_uv9-dir_uv9*fixed2(0,0)*(_Time.y);    
				uv_uv9 = UV_RotateAround(fixed2(0,0),uv_uv9,0*(_Time.y));    
				uv_uv9 = uv_uv9+center_uv9;    
				float4 rect_uv9 =  float4(1,1,1,1);
				float4 color_uv9 = tex2D(_wave2,uv_uv9);    
				uv_uv9 = -(color_uv9.r*fixed2(-0.00390625,0.02148366) + color_uv9.g*fixed2(0.01757813,0.01562428) + color_uv9.b*fixed2(0,0) +  color_uv9.a*fixed2(0,0));    


				//====================================
				//============ image5 ============   
				float2  uv_image5 = i._uv_STD;
				float2 center_image5 = float2(0.5,0.5);    
				uv_image5 = uv_image5-center_image5;    
				uv_image5 = uv_image5+fixed2(-0.03125,-0.2480469);    
				uv_image5 = uv_image5+fixed2(0,0)*(_Time.y);    
				uv_image5 = UV_RotateAround(fixed2(0,0),uv_image5,-0.02229456);    
				uv_image5 = uv_image5/fixed2(0.4617127,0.2360483);    
				float2 dir_image5 = uv_image5/length(uv_image5);    
				uv_image5 = uv_image5-dir_image5*fixed2(0,0)*(_Time.y);    
				uv_image5 = UV_RotateAround(fixed2(0,0),uv_image5,0*(_Time.y));    
				uv_image5 = uv_image5+center_image5;    
				uv_image5 = uv_image5 + uv_uv9*1*(1)*color_wolf_mask0.b;
				float4 rect_image5 =  float4(1,1,1,1);
				float4 color_image5 = tex2D(_wolfNN,uv_image5);    
				color_image5 = color_image5*_Color_image5;


				//====================================
				//============ image4 ============   
				float2  uv_image4 = i._uv_STD;
				float2 center_image4 = float2(0.5,0.5);    
				uv_image4 = uv_image4-center_image4;    
				uv_image4 = uv_image4+fixed2(0.0410158,-0.1914063);    
				uv_image4 = uv_image4+fixed2(0,0)*(_Time.y);    
				uv_image4 = UV_RotateAround(fixed2(0,0),uv_image4,0);    
				uv_image4 = uv_image4/fixed2(0.7608382,0.4642876);    
				float2 dir_image4 = uv_image4/length(uv_image4);    
				uv_image4 = uv_image4-dir_image4*fixed2(0,0)*(_Time.y);    
				uv_image4 = UV_RotateAround(fixed2(0,0),uv_image4,0*(_Time.y));    
				uv_image4 = uv_image4+center_image4;    
				float4 rect_image4 =  float4(1,1,1,1);
				float4 color_image4 = tex2D(_wolfN,uv_image4);    
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
				result = lerp(result,float4(color_image4.rgb,1),clamp(color_image4.a*1*((1))*color_wolf_mask0.r,0,1));    
				result = lerp(result,float4(color_image5.rgb,1),clamp(color_image5.a*1*((1))*color_wolf_mask0.r,0,1));    
				result = result+float4(color_image7.rgb*color_image7.a*1*((1))*color_wolf_mask0.g*color_wolf_mask0.r,color_image7.a*1*((1))*color_wolf_mask0.g*color_wolf_mask0.r*(rootTexColor.a - result.a));
				result = result+float4(color_image8.rgb*color_image8.a*1*((1))*color_wolf_mask0.r,color_image8.a*1*((1))*color_wolf_mask0.r*(rootTexColor.a - result.a));
				result = result*i.color;
				clip(result.a - 0.01);
				return result;
			}  
			ENDCG
		}
	}
	fallback "Standard"
}
