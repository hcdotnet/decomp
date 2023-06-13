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

uniform vec2 frameBufSize;

const float FXAA_SPAN_MAX = 8.0;
const float FXAA_REDUCE_MUL = 1.0/8.0;
const float FXAA_REDUCE_MIN = 1.0/128.0;
 
void main( void ) {
    vec3 rgbNW=texture2D(gm_BaseTexture,v_vTexcoord+(vec2(-1.0,-1.0)/frameBufSize)).xyz;
    vec3 rgbNE=texture2D(gm_BaseTexture,v_vTexcoord+(vec2(1.0,-1.0)/frameBufSize)).xyz;
    vec3 rgbSW=texture2D(gm_BaseTexture,v_vTexcoord+(vec2(-1.0,1.0)/frameBufSize)).xyz;
    vec3 rgbSE=texture2D(gm_BaseTexture,v_vTexcoord+(vec2(1.0,1.0)/frameBufSize)).xyz;
    vec4 rgbaM=texture2D(gm_BaseTexture,v_vTexcoord);
 
    vec3 luma=vec3(0.299, 0.587, 0.114);
    float lumaNW = dot(rgbNW, luma);
    float lumaNE = dot(rgbNE, luma);
    float lumaSW = dot(rgbSW, luma);
    float lumaSE = dot(rgbSE, luma);
    float lumaM  = dot(rgbaM.xyz,  luma);
 
    float lumaMin = min(lumaM, min(min(lumaNW, lumaNE), min(lumaSW, lumaSE)));
    float lumaMax = max(lumaM, max(max(lumaNW, lumaNE), max(lumaSW, lumaSE)));
 
    vec2 dir;
    dir.x = -((lumaNW + lumaNE) - (lumaSW + lumaSE));
    dir.y =  ((lumaNW + lumaSW) - (lumaNE + lumaSE));
 
    float dirReduce = max(
        (lumaNW + lumaNE + lumaSW + lumaSE) * (0.25 * FXAA_REDUCE_MUL),
        FXAA_REDUCE_MIN);
 
    float rcpDirMin = 1.0/(min(abs(dir.x), abs(dir.y)) + dirReduce);
 
    dir = clamp(dir * rcpDirMin,
                vec2(-FXAA_SPAN_MAX),
                vec2(FXAA_SPAN_MAX)) / frameBufSize;
 
    vec3 rgbA = (1.0/2.0) * (
        texture2D(gm_BaseTexture, v_vTexcoord.xy + dir * (1.0/3.0 - 0.5)).xyz +
        texture2D(gm_BaseTexture, v_vTexcoord.xy + dir * (2.0/3.0 - 0.5)).xyz);
    vec3 rgbB = rgbA / -2.0 + (1.0/4.0) * (
        texture2D(gm_BaseTexture, v_vTexcoord.xy + dir * (0.0/3.0 - 0.5)).xyz +
        texture2D(gm_BaseTexture, v_vTexcoord.xy + dir * (3.0/3.0 - 0.5)).xyz);
    float lumaB = dot(rgbB + rgbA, luma);

    gl_FragColor.xyzw=vec4(rgbA + step(lumaMin, lumaB) * step(lumaB, lumaMax) * rgbB,rgbaM.w);
}
