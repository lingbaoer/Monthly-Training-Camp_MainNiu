-------------------------------------------------------
        Shader Weaver - Easy and funny to create
             Copyright Reserved by Jackie Lo
                    Version 1.2.2
-------------------------------------------------------

Thank you for purchasing Shader Weaver!

If you have any questions, suggestions, comments or feature requests,
please email JackieLo@aliyun.com


---------------------------------------
 Support, documentation, and tutorials
---------------------------------------
Home:
www.shaderweaver.com

Tutorials:
www.shaderweaver.com/tutorials.html


--------------------
Description
--------------------
Shader Weaver is a node-based shader creation tool for Unity 2D,
giving you the artistic freedom to enhance Sprites/UI in a visual and intuitive way.
Distinctive nodes and workflow makes it easy to create impressive 2d effects and save huge time.
Use handles/gizmos to make effects rather than input tedious numbers.
Draw masks and create remap textures with convenient tools inside Shader Weaver.Graphics tablet is supported.
Support both Unity Free and Pro.


--------------------
Features
--------------------
-Growing Samples
A pack of sample effects including shaders and textures to study and use freely.

-Intuitive interface 
Clean and intuitive user interface. 

-Mask Texture Creation
Draw masks to divide areas for individual sub-effects.

-UV Distortion
A visual way to distort uv coordinates.

-UV Remapping
A unique way to make path along effects and object surrounding effects.

-Simple Operation
Use handles/gizmos like what you are used to do.

-Preview
Nice width/height corresponding preview.

-Hot keys
Comfortable hot keys speed up editing and drawing.

-Undo/Redo
Fully support Undo/Redo on nodes,numbers and textures.

-Play Mode
Edit and update in play mode.

-Copy Paste
Support copy and paste. Reuse nodes from other Shader Weaver project.

-Depth
Depth Sorting.

-Visual Modes
View textures' individual rgba channel and choose what to see by setting layermask.

-Sync
No extra files to sync over version control system. All Shader Weaver data are stored in .shader files.  


--------------------
 Quick Start
--------------------
(1)Open editor		: Window -> Shader Weaver
(2)Place nodes 		: Drag nodes from left dock to main canvas
(3)Connect nodes	: Data flows from left to right, drag wires from node ports to create connections.
(4)Edit				: Edit (assign textures, draw masks, create remap texture...)
(5)Save				: Click Save button on the top dock,and outcome will show up on the top-right corner.

--------------------
 Spaces
--------------------
Effect Space: 
The whole effect space, showing as yellow square wireframe in editing window.

Node Space: 
Node's texture coordinate space

Screen Space:
The whole screen. Refract node and reflect node are under screen space. 
For UIText, root node is in font atlas space.For all other nodes, effect space is Screen Space. 

--------------------
 Intro to nodes
--------------------
There are 4 kinds of nodes in Shader Weaver currently.
Blue nodes output color.
Orange nodes output UV.
Red nodes output alpha.
Green nodes are nodes used for blending.

UV node and alpha node behave in effect space independently, if you want them to follow a node like color node,just set same position/rotation/scale/move...

------------
Blue nodes
------------
Root:	
This is the main node.Assign base texture here.

Color:
A solid color.

Image:
Show textures. Depth is for display order, highest depth is shown on the top.

Refract:
Make refraction effects.Interact with background graphics behind.Use child UV nodes to distort background.
Here are some example effects, ground glass, water fall.Support all shader types.

Reflect:
Make reflection effects.Interact with background graphics behind.Use child UV nodes to distort background.
Here are some example effects, water, wet floor.
For Sprite, assign material and add ->Component ->Shader Weaver ->Sprite Reflection.
For Default/UI/Text, set material's Reflection Line /  Reflection Height manually.

------------
Orange nodes
------------
UV:
Use rgba channel of this node'texture to relocate parent's uv coordinates. Use mainly for distortion.Here are some example effects,
floating flags,flowing water. 

Remap:
Supply UV coordinates to the parent node. Drag mode is to lay parental effects on one side of the shape.
Line mode is to make parental effects follow the path you created. In the texture we made,
Red supply  the horizontal coordinates to parent nodes,Green supply  the vertical coordinates.
Axis x:R[0,1]=U[0,1]	
Axis y:G[0,1]=V[0,1]
If you want to use custom texture for remapping,just press '+' button on the remap node and assign texture.

Blur:
Make parent nodes blurry.

Retro:
Pixelate parent nodes.

------------
Red nodes
------------
Alpha:
Use one of the rgba channels in this node's texture to do detailed alpha animation for parent nodes.
It offers a multiplier to (1)color node which use it (2)final graphic.
multiplier = textureSampledColor.channel + start +spd*spdFactor  (clamped in [min,max])

------------
Green nodes
------------
Mask:
Draw mask to masking sub-effects.Mask node's child node effects will ONLY show in the masked area.
If you want to use custom grayscale texture for masking,just press '+' button on the mask node and assign texture.

Mixer:
Use one of the rgba channels in this node's texture to do animated blending for child nodes.
It produces a value.
value = textureSampledColor.channel + start +spd*spdFactor  (clamped in [min,max])
Right click on mixer node's left port, then we can set blend area in [min,max]. Blend area controls how child nodes linked to this port is blended.

--------------------
Q&A
--------------------
How to support Sprite Animation:
Add ->Component ->Shader Weaver ->Sprite Animation to Sprite Render.

How to use Texture Sprite Sheet for nodes:
Open Node Editing Window, press '+' button on the bottom-right corner. Click 'Animation Sheet' toggle.
Set 'Tile X','Tile Y'...
If you wanna use single texture sprite sheet to draw a character multiple times,you need to use Shader Weaver's loop 
rather than use texture's import setting - warp mode 

How to enable HDR color:
1. Edit->Project Settings->Quality  Set Anti Aliasing to Disabled
2. In Camera's inspector, enable HDR
3. Set color attribute in Shader Weaver to HDR by right clicking

How to eliminate seams on boarder:
In texture settings,turn off 'Generate Mip Maps' or set 'Filter Mode' to 'Point'. 

Sometimes there are errors when compiling on mac,why?
Unity has its own built-in variables, so be careful of parameter naming.
It is highly recommended that name your parameter beginning with '_'.

--------------------
 Hotkeys
--------------------
[All windows]
Drag canvas:				Alt + Left Mouse Button 
Scale canvas:				Scrollwheel
Open project:				Alt + O
Save project:				Alt + S (before saved)
Update project:				Alt + S (after saved)
Copy:						Ctrl + C
Paste:						Ctrl + V
Undo:						Ctrl + Z
Redo:						Ctrl + Y
Tiled background switch:	Right Click on it  

[Main window]
Break connections:	Alt/Ctrl + Click node port
Delete selection:	Delete

[Edit windows]
Along x/y axis:		Shift + operation

[Mask window]
Brush/Eraser size:	'[' and ']' 
Opacity:			'-' and '=' 
Tolerance:			'[' and ']' 
Invert: Ctrl + I

[Remap window - Drag]
Deviation:			'[' and ']' 
Delete all:			Delete				

[Remap window - Line]
Size:				'[' and ']' 
Delete all:			Delete	
		

-----------------------------
 Texture Import Settings
-----------------------------
The following settings will be set to texture automatically when it is used in Shader Weaver.
Textures:
Read/Write Enable -> true
Generate Mip Map -> false

Sprites:
Mesh Type -> Full Rect


-----------------------------
 Compatible Assets
-----------------------------
2D Dynamic Lights and Shadows 
2DDL Pro : 2D Dynamic Lights and Shadows
Light2D - GPU Lighting System