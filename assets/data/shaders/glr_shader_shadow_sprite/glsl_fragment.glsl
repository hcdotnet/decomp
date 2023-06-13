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

uniform vec2 LightOffset; 
uniform float uScale; 
 

void main()
{

  vec2 offset = (v_vTexcoord - LightOffset)*uScale ;  
  vec2 coord = v_vTexcoord;
  
  float alpha = 0.0; 
  for(int i=0; i < 4 ; i++)
  {
     coord -= offset;
     vec4 sample = texture2D(gm_BaseTexture, coord ); 
          alpha += sample.a; 
  }
    gl_FragColor.a = alpha;
}

