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
 
uniform float uOcclusionIntensity;

void main()
{
    float alpha1 = texture2D(gm_BaseTexture, v_vTexcoord).a;
    float result_alpha = 0.0;
     
    const float range = 0.006;
    const vec2 v0 = vec2(-0.2141712512820959,-0.49805961502715945)*range;
    const vec2 v1 = vec2(0.8808212038129568,-0.06784834945574403)*range;
    const vec2 v2 = vec2(-0.36,0.26)*range;
    const vec2 v3 = vec2(-0.09,0.73)*range;
    const vec2 v4 = vec2(-0.6971564781852067,-0.5681228553876281)*range;
    const vec2 v5 = vec2(-0.43363001476973295,0.7330696652643383)*range;
    const vec2 v6 = vec2(-0.6516291736625135,-0.0935323042795062)*range;
    const vec2 v7 = vec2(-0.04,-0.84)*range;
    const vec2 v8 = vec2(0.31,0.25)*range;
    const vec2 v9 = vec2(0.41916688857600093,0.65290737291798)*range;
    const vec2 v10 = vec2(-0.9475995465181768,0.20299295708537102)*range;
    const vec2 v11 = vec2(0.62,-0.41)*range;
    const vec2 v12 = vec2(0.4172360813245177,-0.6570702772587538)*range;
    const vec2 v13 = vec2(0.15,-0.13)*range;
    const vec2 v14 = vec2(-0.27,-0.09)*range;
    const vec2 v15 = vec2(0.07,0.48)*range; 

    const float ratio = 1.0/18.0; 
    result_alpha += alpha1*ratio;

    result_alpha += texture2D(gm_BaseTexture, v_vTexcoord+v0).a*ratio;
    result_alpha += texture2D(gm_BaseTexture, v_vTexcoord+v1).a*ratio;
    result_alpha += texture2D(gm_BaseTexture, v_vTexcoord+v2).a*ratio;
    result_alpha += texture2D(gm_BaseTexture, v_vTexcoord+v3).a*ratio;
    result_alpha += texture2D(gm_BaseTexture, v_vTexcoord+v4).a*ratio;
    result_alpha += texture2D(gm_BaseTexture, v_vTexcoord+v5).a*ratio;
    result_alpha += texture2D(gm_BaseTexture, v_vTexcoord+v6).a*ratio;
    result_alpha += texture2D(gm_BaseTexture, v_vTexcoord+v7).a*ratio;
    result_alpha += texture2D(gm_BaseTexture, v_vTexcoord+v8).a*ratio;
    result_alpha += texture2D(gm_BaseTexture, v_vTexcoord+v9).a*ratio;
    result_alpha += texture2D(gm_BaseTexture, v_vTexcoord+v10).a*ratio;
    result_alpha += texture2D(gm_BaseTexture, v_vTexcoord+v11).a*ratio;
    result_alpha += texture2D(gm_BaseTexture, v_vTexcoord+v12).a*ratio;
    result_alpha += texture2D(gm_BaseTexture, v_vTexcoord+v13).a*ratio;
    result_alpha += texture2D(gm_BaseTexture, v_vTexcoord+v14).a*ratio;
    result_alpha += texture2D(gm_BaseTexture, v_vTexcoord+v15).a*ratio;
  
    result_alpha = step(alpha1-result_alpha,0.0)*result_alpha;  
    gl_FragColor.a =  result_alpha*uOcclusionIntensity;
}

