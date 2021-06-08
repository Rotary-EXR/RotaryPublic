Shader "DynamicShadowProjector/Shadow/Opaque" {
	SubShader {
		Pass {
			ZTest Always Cull Off ZWrite Off
			Fog { Mode Off }
		
			HLSLPROGRAM
			#pragma multi_compile_instancing
			#pragma vertex DSPShadowVertOpaque
			#pragma fragment DSPShadowFragOpaque
			#include "DSPShadow.cginc"
			ENDHLSL
		}
	}
}
