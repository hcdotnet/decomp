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
varying vec4 v_blurTexCoords[6];
 
void main()
{
    vec4 col = texture2D(gm_BaseTexture, v_vTexcoord);
    vec4 result_color = vec4(0.0, 0.0, 0.0, col.a);
     
    result_color.rgb += texture2D(gm_BaseTexture, v_blurTexCoords[0].xy).rgb*0.00895781211794;
    result_color.rgb += texture2D(gm_BaseTexture, v_blurTexCoords[1].xy).rgb*0.0215963866053;
    result_color.rgb += texture2D(gm_BaseTexture, v_blurTexCoords[2].xy).rgb*0.0443683338718;
    result_color.rgb += texture2D(gm_BaseTexture, v_blurTexCoords[3].xy).rgb*0.0776744219933;
    result_color.rgb += texture2D(gm_BaseTexture, v_blurTexCoords[4].xy).rgb*0.115876621105;
    result_color.rgb += texture2D(gm_BaseTexture, v_blurTexCoords[5].xy).rgb*0.147308056121;
    result_color.rgb += col.rgb*0.159576912161;
    result_color.rgb += texture2D(gm_BaseTexture, v_blurTexCoords[0].zw).rgb*0.147308056121;
    result_color.rgb += texture2D(gm_BaseTexture, v_blurTexCoords[1].zw).rgb*0.115876621105;
    result_color.rgb += texture2D(gm_BaseTexture, v_blurTexCoords[2].zw).rgb*0.0776744219933;
    result_color.rgb += texture2D(gm_BaseTexture, v_blurTexCoords[3].zw).rgb*0.0443683338718;
    result_color.rgb += texture2D(gm_BaseTexture, v_blurTexCoords[4].zw).rgb*0.0215963866053;
    result_color.rgb += texture2D(gm_BaseTexture, v_blurTexCoords[5].zw).rgb*0.00895781211794; 
      
    gl_FragColor =  result_color;
}

 
