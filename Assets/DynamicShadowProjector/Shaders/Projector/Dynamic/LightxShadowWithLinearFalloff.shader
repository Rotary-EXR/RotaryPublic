﻿Shader "DynamicShadowProjector/Projector/Dynamic/Light x Shadow With Linear Falloff" {
	Properties {
		[NoScaleOffset] _LightTex ("Light Cookie", 2D) = "gray" {}
		_ClipScale ("Near Clip Sharpness", Float) = 100
		_Alpha ("Light Intensity", Range (0, 10)) = 1.0
		_Offset ("Offset", Range (0, -10)) = -1.0
		_OffsetSlope ("Offset Slope Factor", Range (0, -1)) = -1.0
	}
	Subshader {
		Tags {"Queue"="Transparent-1"}
		UsePass "DynamicShadowProjector/Projector/Light x Shadow With Linear Falloff/PASS"
	}
	CustomEditor "DynamicShadowProjector.ProjectorShaderGUI"
}
