precision mediump float;
#define LOWPREC lowp
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

#define _YY_GLSLES_ 1
//   @jujuadams   v8.0.0   2021-12-15
precision highp float;

#define PROPORTIONAL_BORDER_SCALE false
#define PREMULTIPLY_ALPHA false
#define ROUNDED_BORDERS false

varying vec2  v_vTexcoord;
varying vec4  v_vColour;
varying float v_fPixelScale;
varying float v_fTextScale;

uniform vec2  u_vTexel;
uniform float u_fMSDFRange;
uniform float u_fMSDFThicknessOffset;
uniform vec4  u_vShadowColour;
uniform vec3  u_vShadowOffsetAndSoftness;
uniform vec3  u_vBorderColour;
uniform float u_fBorderThickness;
uniform float u_fSecondDraw;
uniform vec4  u_vFlash;

float median(vec3 v)
{
    return max(min(v.x, v.y), min(max(v.x, v.y), v.z));
}

float MSDFSignedDistance(vec4 sample)
{
    return median(sample.rgb) + u_fMSDFThicknessOffset - 0.5;
}

float SDFSignedDistance(vec4 sample)
{
    return sample.a + u_fMSDFThicknessOffset - 0.5;
}

float MSDFAlpha(float signedDistance, float pixelSize, float outerBorder)
{
    return clamp(u_fMSDFRange*pixelSize*signedDistance + outerBorder + 0.5, 0.0, 1.0);
}

float MSDFAlphaSoft(float signedDistance, float pixelSize, float outerBorder, float softness)
{
    return clamp((u_fMSDFRange*pixelSize*signedDistance + outerBorder)/softness + 0.5, 0.0, 1.0);
}

void main()
{
    vec4 sample = texture2D(gm_BaseTexture, v_vTexcoord);
    float distBase = MSDFSignedDistance(sample);
    gl_FragColor = vec4(v_vColour.rgb, v_vColour.a*MSDFAlpha(distBase, v_fPixelScale, 0.0));
    
    if (u_fSecondDraw < 0.5)
    {
        if (u_fBorderThickness > 0.0)
        {
            float borderDist = ROUNDED_BORDERS? SDFSignedDistance(sample) : MSDFSignedDistance(sample);
            float alphaBorder = MSDFAlpha(borderDist, v_fPixelScale, PROPORTIONAL_BORDER_SCALE? (v_fPixelScale*u_fBorderThickness) : u_fBorderThickness);
            gl_FragColor.rgb = mix(u_vBorderColour, gl_FragColor.rgb, gl_FragColor.a);
            gl_FragColor.a = max(gl_FragColor.a, alphaBorder);
        }
        
        if (u_vShadowColour.a > 0.0)
        {
            vec4 shadowSample = texture2D(gm_BaseTexture, v_vTexcoord - u_vTexel*u_vShadowOffsetAndSoftness.xy/v_fPixelScale);
            float shadowDist = ROUNDED_BORDERS? SDFSignedDistance(shadowSample) : MSDFSignedDistance(shadowSample);
            float alphaShadow = MSDFAlphaSoft(shadowDist, v_fPixelScale, PROPORTIONAL_BORDER_SCALE? (v_fPixelScale*u_fBorderThickness) : u_fBorderThickness, u_vShadowOffsetAndSoftness.z);
            
            float preAlpha = gl_FragColor.a;
            gl_FragColor = mix(vec4(u_vShadowColour.rgb, alphaShadow), gl_FragColor, gl_FragColor.a);
            gl_FragColor.a = max(preAlpha, u_vShadowColour.a*alphaShadow);
        }
    }
    
    gl_FragColor.rgb = mix(gl_FragColor.rgb, u_vFlash.rgb, u_vFlash.a);
    
    if (PREMULTIPLY_ALPHA)
    {
        gl_FragColor.rgb *= gl_FragColor.a;
    }
}
