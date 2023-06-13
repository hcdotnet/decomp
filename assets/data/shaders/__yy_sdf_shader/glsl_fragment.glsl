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
//
// SDF fragment shader
//
varying vec2 v_vTexcoord;
varying vec4 v_vColour;

void main()
{
	vec4 texcol = texture2D( gm_BaseTexture, v_vTexcoord );
	
	float spread = fwidth(texcol.a);	
	spread = max(spread * 0.75, 0.001);	
	texcol.a = smoothstep(0.5 - spread, 0.5 + spread, texcol.a);			
	
	if (texcol.a <= 0.0)
		discard;
			
    gl_FragColor = v_vColour * texcol;
}
