#if !defined(DSP_SHADOW_CGINC_INCLUDED)
#define DSP_SHADOW_CGINC_INCLUDED
#include "../EnableCbuffer.cginc"
#include "UnityCG.cginc"

struct DSP_SHADOW_VERTEXATTRIBUTES {
	float4 vertex : POSITION;
	UNITY_VERTEX_INPUT_INSTANCE_ID
};

struct DSP_V2F_SHADOW_OPAQUE {
	float4 pos : SV_POSITION;
	UNITY_VERTEX_OUTPUT_STEREO
};

DSP_V2F_SHADOW_OPAQUE DSPShadowVertOpaque(DSP_SHADOW_VERTEXATTRIBUTES v)
{
	DSP_V2F_SHADOW_OPAQUE o;
	UNITY_SETUP_INSTANCE_ID(v);
	UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
	o.pos = UnityObjectToClipPos(v.vertex);
	return o;
}

fixed4 DSPShadowFragOpaque() : SV_Target
{
	return fixed4(0,0,0,1);
}

struct DSP_V2F_SHADOW_TRANS {
	float4 pos : SV_POSITION;
	float2 uv  : TEXCOORD0;
	UNITY_VERTEX_OUTPUT_STEREO
};
CBUFFER_START(UnityPerMaterial)
fixed4 _Color;
float4 _MainTex_ST;
CBUFFER_END
DSP_V2F_SHADOW_TRANS DSPShadowVertTrans(DSP_SHADOW_VERTEXATTRIBUTES v, float4 texcoord : TEXCOORD0)
{
	DSP_V2F_SHADOW_TRANS o;
	UNITY_SETUP_INSTANCE_ID(v);
	UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
	o.pos = UnityObjectToClipPos(v.vertex);
	o.uv = TRANSFORM_TEX(texcoord, _MainTex);
	return o;
}

sampler2D _MainTex;
fixed4 DSPShadowFragTrans(DSP_V2F_SHADOW_TRANS i) : SV_Target
{
	fixed a = tex2D(_MainTex, i.uv).a * _Color.a;
	return fixed4(0,0,0,a);
}

#if defined(_ALPHABLEND_ON) || defined(_ALPHATEST_ON) || defined(_ALPHAPREMULTIPLY_ON)
DSP_V2F_SHADOW_TRANS DSPShadowVertStandard(DSP_SHADOW_VERTEXATTRIBUTES v, float4 texcoord : TEXCOORD0)
{
	return DSPShadowVertTrans(v, texcoord);
}
fixed4 DSPShadowFragStandard(DSP_V2F_SHADOW_TRANS i) : SV_Target
{
	return DSPShadowFragTrans(i);
}
#else
DSP_V2F_SHADOW_OPAQUE DSPShadowVertStandard(DSP_SHADOW_VERTEXATTRIBUTES v)
{
	return DSPShadowVertOpaque(v);
}
fixed4 DSPShadowFragStandard() : SV_Target
{
	return DSPShadowFragOpaque();
}
#endif

#endif // !defined(DSP_SHADOW_CGINC_INCLUDED)
