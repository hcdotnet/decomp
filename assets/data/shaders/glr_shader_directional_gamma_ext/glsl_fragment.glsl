#version 120
#define LOWPREC 
#define lowp
#define mediump
#define highp
#define precision
// Uniforms look like they're shared between vertex and fragment shaders in GLSL, so we have to be careful to avoid name clashes

uniform sampler2D gm_BaseTexture;

uniform bool gm_PS_FogEnabled;
uniform vec4 gm_FogColour;
uniform bool gm_AlphaTestEnabled;
uniform float gm_AlphaRefValue;

void DoAlphaTest(vec4 SrcColour)
{
	if (gm_AlphaTestEnabled)
	{
		if (SrcColour.a <= gm_AlphaRefValue)
		{
			discard;
		}
	}
}

void DoFog(inout vec4 SrcColour, float fogval)
{
	if (gm_PS_FogEnabled)
	{
		SrcColour = mix(SrcColour, gm_FogColour, clamp(fogval, 0.0, 1.0)); 
	}
}

#define _YY_GLSL_ 1
varying vec2 v_vTexcoord;
varying vec4 v_vColour;

uniform vec4 uAmbient;
uniform sampler2D uSampler;

void main()
{
    float sAlpha = texture2D( gm_BaseTexture, v_vTexcoord ).a;
    float step_value = step(0.4, sAlpha); 
    gl_FragColor.a = 0.0;//mix(uAmbient.a, 0.0, step_value);
    gl_FragColor.rgb = mix(uAmbient.rgb, v_vColour.rgb, step_value) + (1.0 - floor(texture2D( uSampler, v_vTexcoord ).a));
}

