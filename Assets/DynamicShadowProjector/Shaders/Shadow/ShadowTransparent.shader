Shader "DynamicShadowProjector/Shadow/Transparent" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
	}
	SubShader {
		Pass {
			ZTest Always Cull Off ZWrite Off
			Fog { Mode Off }
			Blend One OneMinusSrcAlpha
		
			HLSLPROGRAM
			#pragma multi_compile_instancing
			#pragma vertex DSPShadowVertTrans
			#pragma fragment DSPShadowFragTrans
			#include "DSPShadow.cginc"
			ENDHLSL
		}
	}
}
