// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/TileShader"
{
	Properties
	{
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		
		[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
	}
 
	SubShader
	{
	Colormask 0 Zwrite Off
       Stencil
		{
			Ref 1
            Comp always
        	Pass replace
		}
		
		Tags
		{ 
			"Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="Transparent" 
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Blend One OneMinusSrcAlpha
         // Only render pixels whose value in the stencil buffer equals 1.
      
		Pass
		{

		}
	}
}