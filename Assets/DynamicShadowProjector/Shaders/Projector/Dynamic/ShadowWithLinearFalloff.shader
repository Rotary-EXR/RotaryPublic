﻿Shader "DynamicShadowProjector/Projector/Dynamic/Shadow With Linear Falloff" {
	Properties {
		_ClipScale ("Near Clip Sharpness", Float) = 100
		_Alpha ("Shadow Darkness", Range (0, 1)) = 1.0
		_Ambient ("Ambient", Range (0.01, 1)) = 0.3
		_Offset ("Offset", Range (0, -10)) = -1.0
		_OffsetSlope ("Offset Slope Factor", Range (0, -1)) = -1.0
	}
	Subshader {
		Tags {"Queue"="Transparent-1"}
		UsePass "DynamicShadowProjector/Projector/Shadow With Linear Falloff/PASS"
	}
	CustomEditor "DynamicShadowProjector.ProjectorShaderGUI"
}
