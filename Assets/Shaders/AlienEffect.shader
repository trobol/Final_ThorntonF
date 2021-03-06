﻿
Shader "Custom/Alien"
{
	Properties
	{
		_Color ("Tint", Color) = (1,1,1,1)
		[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
		_NoiseTex ("Noise", 2D) = "white" {}
	}
 
	SubShader
	{
		
		Tags
		{ 
			"Queue"="Transparent+1" 
			"RenderType"="Transparent" 
			"CanUseSpriteAtlas"="True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		
		Blend DstAlpha One 
		
	  
		Pass
		{


		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile _ PIXELSNAP_ON
			#include "UnityCG.cginc"
			
			struct appdata_t
			{
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				float2 rot : POSITION1;
				fixed4 color    : COLOR;
				float2 texcoord  : TEXCOORD0;
			};
			
			fixed4 _Color;

			v2f vert(appdata_t IN)
			{
				v2f OUT;
				OUT.vertex = UnityObjectToClipPos(IN.vertex);
				OUT.texcoord = IN.texcoord;
				OUT.color = IN.color * _Color;
				
				
				
				return OUT;
			}

			sampler2D _NoiseTex;
		
			fixed4 frag(v2f IN) : SV_Target
			{
				fixed2 c = IN.texcoord*2-1;
				c.x = round(c.x*80)/80;
				c.y = round(c.y*80)/80;
				float dist = length(c);	
				int dir = sin(_Time*0.5);
				float b = sin(100*(0.1*dist+_Time*0.5));
				float a = step(0.6, b)/2;

				a += step(0.95, b)*0.5;
				a *= 1-dist*dist;

				
				float2 l1 = IN.rot;

				float2 l2 = c;

				float fade = dist*dist;

				a -= fade/2;
				return IN.color * a;
			}
		ENDCG
		}
	}
}