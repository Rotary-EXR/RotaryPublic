Shader "DynamicShadowProjector/Projector/Light With Linear Falloff" {
	Properties {
		[NoScaleOffset] _LightTex ("Cookie", 2D) = "gray" {}
		_ClipScale ("Near Clip Sharpness", Float) = 100
		_Alpha ("Light Intensity", Range (0, 10)) = 1.0
		_Offset ("Offset", Range (0, -10)) = -1.0
		_OffsetSlope ("Offset Slope Factor", Range (0, -1)) = -1.0
	}
	Subshader {
		Tags {"Queue"="Transparent-1"}
		Pass {
			ZWrite Off
			ColorMask RGB
			Blend DstColor One
			Offset [_OffsetSlope], [_Offset]

			HLSLPROGRAM
			#pragma vertex DSPProjectorVertLightLinearFalloff
			#pragma fragment DSPProjectorFragLight
			#pragma shader_feature_local _ FSR_PROJECTOR_FOR_LWRP
			#pragma multi_compile_local _ FSR_RECEIVER 
			#pragma multi_compile_fog
			#pragma multi_compile_instancing
			#include "DSPProjector.cginc"
			ENDHLSL
		}
	}
	CustomEditor "DynamicShadowProjector.ProjectorShaderGUI"
}
