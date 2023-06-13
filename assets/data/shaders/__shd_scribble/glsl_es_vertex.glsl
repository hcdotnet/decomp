#define LOWPREC lowp
#define	MATRIX_VIEW 					0
#define	MATRIX_PROJECTION 				1
#define	MATRIX_WORLD 					2
#define	MATRIX_WORLD_VIEW 				3
#define	MATRIX_WORLD_VIEW_PROJECTION 	4
#define	MATRICES_MAX					5

uniform mat4 gm_Matrices[MATRICES_MAX]; 

uniform bool gm_LightingEnabled;
uniform bool gm_VS_FogEnabled;
uniform float gm_FogStart;
uniform float gm_RcpFogRange;

#define MAX_VS_LIGHTS	8
#define MIRROR_WIN32_LIGHTING_EQUATION


//#define	MAX_VS_LIGHTS					8
uniform vec4   gm_AmbientColour;							// rgb=colour, a=1
uniform vec4   gm_Lights_Direction[MAX_VS_LIGHTS];		// normalised direction
uniform vec4   gm_Lights_PosRange[MAX_VS_LIGHTS];			// X,Y,Z position,  W range
uniform vec4   gm_Lights_Colour[MAX_VS_LIGHTS];			// rgb=colour, a=1

float CalcFogFactor(vec4 pos)
{
	if (gm_VS_FogEnabled)
	{
		vec4 viewpos = gm_Matrices[MATRIX_WORLD_VIEW] * pos;
		float fogfactor = ((viewpos.z - gm_FogStart) * gm_RcpFogRange);
		return fogfactor;
	}
	else
	{
		return 0.0;
	}
}

vec4 DoDirLight(vec3 ws_normal, vec4 dir, vec4 diffusecol)
{
	float dotresult = dot(ws_normal, dir.xyz);
	dotresult = min(dotresult, dir.w);			// the w component is 1 if the directional light is active, or 0 if it isn't
	dotresult = max(0.0, dotresult);

	return dotresult * diffusecol;
}

vec4 DoPointLight(vec3 ws_pos, vec3 ws_normal, vec4 posrange, vec4 diffusecol)
{
	vec3 diffvec = ws_pos - posrange.xyz;
	float veclen = length(diffvec);
	diffvec /= veclen;	// normalise
	float atten;
	if (posrange.w == 0.0)		// the w component of posrange is 0 if the point light is disabled - if we don't catch it here we might end up generating INFs or NaNs
	{
		atten = 0.0;
	}
	else
	{
#ifdef MIRROR_WIN32_LIGHTING_EQUATION
	// This is based on the Win32 D3D and OpenGL falloff model, where:
	// Attenuation = 1.0f / (factor0 + (d * factor1) + (d*d * factor2))
	// For some reason, factor0 is set to 0.0f while factor1 is set to 1.0f/lightrange (on both D3D and OpenGL)
	// This'll result in no visible falloff as 1.0f / (d / lightrange) will always be larger than 1.0f (if the vertex is within range)
	
		atten = 1.0 / (veclen / posrange.w);
		if (veclen > posrange.w)
		{
			atten = 0.0;
		}	
#else
		atten = clamp( (1.0 - (veclen / posrange.w)), 0.0, 1.0);		// storing 1.0f/range instead would save a rcp
#endif
	}
	float dotresult = dot(ws_normal, diffvec);
	dotresult = max(0.0, dotresult);

	return dotresult * atten * diffusecol;
}

vec4 DoLighting(vec4 vertexcolour, vec4 objectspacepos, vec3 objectspacenormal)
{
	if (gm_LightingEnabled)
	{
		// Normally we'd have the light positions\\directions back-transformed from world to object space
		// But to keep things simple for the moment we'll just transform the normal to world space
		vec4 objectspacenormal4 = vec4(objectspacenormal, 0.0);
		vec3 ws_normal;
		ws_normal = (gm_Matrices[MATRIX_WORLD] * objectspacenormal4).xyz;
		ws_normal = normalize(ws_normal);

		vec3 ws_pos;
		ws_pos = (gm_Matrices[MATRIX_WORLD] * objectspacepos).xyz;

		// Accumulate lighting from different light types
		vec4 accumcol = vec4(0.0, 0.0, 0.0, 0.0);		
		for(int i = 0; i < MAX_VS_LIGHTS; i++)
		{
			accumcol += DoDirLight(ws_normal, gm_Lights_Direction[i], gm_Lights_Colour[i]);
		}

		for(int i = 0; i < MAX_VS_LIGHTS; i++)
		{
			accumcol += DoPointLight(ws_pos, ws_normal, gm_Lights_PosRange[i], gm_Lights_Colour[i]);
		}

		accumcol *= vertexcolour;
		accumcol += gm_AmbientColour;
		accumcol = min(vec4(1.0, 1.0, 1.0, 1.0), accumcol);
		accumcol.a = vertexcolour.a;
		return accumcol;
	}
	else
	{
		return vertexcolour;
	}
}

#define _YY_GLSLES_ 1
//   @jujuadams   v8.0.0   2021-12-15
precision highp float;

#define BLEND_SPRITES true

const int MAX_EFFECTS = 11;
#define SPRITE_FLAG   flagArray[ 0]
#define WAVE_FLAG     flagArray[ 1]
#define SHAKE_FLAG    flagArray[ 2]
#define RAINBOW_FLAG  flagArray[ 3]
#define WOBBLE_FLAG   flagArray[ 4]
#define PULSE_FLAG    flagArray[ 5]
#define WHEEL_FLAG    flagArray[ 6]
#define CYCLE_FLAG    flagArray[ 7]
#define JITTER_FLAG   flagArray[ 8]
#define BLINK_FLAG    flagArray[ 9]
#define SLANT_FLAG    flagArray[10]

const int MAX_ANIM_FIELDS = 21;
#define WAVE_AMPLITUDE    u_aDataFields[ 0]
#define WAVE_FREQUENCY    u_aDataFields[ 1]
#define WAVE_SPEED        u_aDataFields[ 2]
#define SHAKE_AMPLITUDE   u_aDataFields[ 3]
#define SHAKE_SPEED       u_aDataFields[ 4]
#define RAINBOW_WEIGHT    u_aDataFields[ 5]
#define RAINBOW_SPEED     u_aDataFields[ 6]
#define WOBBLE_ANGLE      u_aDataFields[ 7]
#define WOBBLE_FREQUENCY  u_aDataFields[ 8]
#define PULSE_SCALE       u_aDataFields[ 9]
#define PULSE_SPEED       u_aDataFields[10]
#define WHEEL_AMPLITUDE   u_aDataFields[11]
#define WHEEL_FREQUENCY   u_aDataFields[12]
#define WHEEL_SPEED       u_aDataFields[13]
#define CYCLE_SPEED       u_aDataFields[14]
#define CYCLE_SATURATION  u_aDataFields[15]
#define CYCLE_VALUE       u_aDataFields[16]
#define JITTER_MINIMUM    u_aDataFields[17]
#define JITTER_MAXIMUM    u_aDataFields[18]
#define JITTER_SPEED      u_aDataFields[19]
#define SLANT_GRADIENT    u_aDataFields[20]

const int EASE_METHOD_COUNT = 15;
#define EASE_NONE         0
#define EASE_LINEAR       1
#define EASE_QUADRATIC    2
#define EASE_CUBIC        3
#define EASE_QUARTIC      4
#define EASE_QUINTIC      5
#define EASE_SINE         6
#define EASE_EXPONENTIAL  7
#define EASE_CIRCULAR     8
#define EASE_BACK         9
#define EASE_ELASTIC     10
#define EASE_BOUNCE      11
#define EASE_CUSTOM_1    12
#define EASE_CUSTOM_2    13
#define EASE_CUSTOM_3    14

const float MAX_LINES = 1000.0; //Change __SCRIBBLE_MAX_LINES in scribble_init() if you change this value!

const int WINDOW_COUNT = 3;

const float PI = 3.14159265359;



//--------------------------------------------------------------------------------------------------------
// Attributes, Varyings, and Uniforms


attribute vec3  in_Position;     //{X, Y, Packed character & line index}
attribute vec3  in_Normal;       //{dX, Sprite data, Bitpacked effect flags}
attribute vec4  in_Colour;       //Colour. This attribute is used for sprite data if this character is a sprite
attribute vec2  in_TextureCoord; //UVs
attribute vec2  in_Colour2;      //{Scale, dY}

varying vec2 v_vTexcoord;
varying vec4 v_vColour;

uniform vec4  u_vColourBlend;                           //4
uniform vec4  u_vGradient;                              //4
uniform vec2  u_vSkew;                                  //2
uniform vec2  u_vRegionActive;                          //2
uniform vec4  u_vRegionColour;                          //4
uniform float u_fTime;                                  //1
uniform float u_aDataFields[MAX_ANIM_FIELDS];           //21
uniform vec2  u_aBezier[3];                             //6
uniform float u_fBlinkState;                            //1

uniform int   u_iTypewriterMethod;                      //1
uniform int   u_iTypewriterCharMax;                     //1
uniform float u_fTypewriterWindowArray[2*WINDOW_COUNT]; //6
uniform float u_fTypewriterSmoothness;                  //1
uniform vec2  u_vTypewriterStartPos;                    //2
uniform vec2  u_vTypewriterStartScale;                  //2
uniform float u_fTypewriterStartRotation;               //1
uniform float u_fTypewriterAlphaDuration;               //1

float flagArray[MAX_EFFECTS];

//--------------------------------------------------------------------------------------------------------
// Functions
// Scroll all the way down to see the main() function for the vertex shader

//*That* randomisation function.
//I haven't found a better method yet, and this is sufficient for our purposes
float rand(vec2 co)
{
    return fract(sin(dot(co.xy ,vec2(12.9898,78.233))) * 43758.5453);
}

//Rotate by vector
vec2 rotate_by_vector(vec2 position, vec2 centre, vec2 vector)
{
    //Normally I'd do this with a mat2() but for some reason this had issues cross-platform
    vec2 delta = position - centre;
    return centre + vec2(delta.x*vector.x - delta.y*vector.y, delta.x*vector.y + delta.y*vector.x);
}

//Rotate the character
vec2 rotate(vec2 position, vec2 centre, float angle)
{
    return rotate_by_vector(position, centre, vec2(cos(0.00872664625*angle), -sin(0.00872664625*angle)));
}

//Scale the character
vec2 scale(vec2 position, vec2 centre, float scale)
{
    return centre + scale*(position - centre);
}

vec2 scale(vec2 position, vec2 centre, vec2 scale)
{
    return centre + scale*(position - centre);
}

//Oscillate the character
vec2 wave(vec2 position, float characterIndex)
{
    return vec2(position.x, position.y + WAVE_FLAG*WAVE_AMPLITUDE*sin(WAVE_FREQUENCY*characterIndex + WAVE_SPEED*u_fTime));
}

//Wheel the character around
vec2 wheel(vec2 position, float characterIndex)
{
    float time = WHEEL_FREQUENCY*characterIndex + WHEEL_SPEED*u_fTime;
    return position.xy + WHEEL_FLAG*WHEEL_AMPLITUDE*vec2(cos(time), -sin(time));
}

//Wobble the character by rotating around its central point
vec2 wobble(vec2 position, vec2 centre)
{
    return rotate(position, centre, WOBBLE_FLAG*WOBBLE_ANGLE*sin(WOBBLE_FREQUENCY*u_fTime));
}

//Pulse the character by scaling it up and down
vec2 pulse(vec2 position, vec2 centre, float characterIndex)
{
    float adjustedScale = 1.0 +  PULSE_FLAG*PULSE_SCALE*(0.5 + 0.5*sin(PULSE_SPEED*(250.0*characterIndex + u_fTime)));
    return scale(position, centre, adjustedScale);
}

//Shake the character along the x/y axes
//We use integer time steps so that at low speeds characters don't jump around too much
//Lots of magic numbers in here to try to get a nice-looking shake
vec2 shake(vec2 position, float characterIndex)
{
    float time = SHAKE_SPEED*u_fTime + 0.5;
    float floorTime = floor(time);
    float merge = 1.0 - abs(2.0*(time - floorTime) - 1.0);
    
    //Use some misc prime numbers to try to get a varied-looking shake
    vec2 delta = vec2(rand(vec2(characterIndex/149.0 + floorTime/13.0, characterIndex/727.0 - floorTime/331.0)),
                      rand(vec2(characterIndex/501.0 - floorTime/19.0, characterIndex/701.0 + floorTime/317.0)));
    
    return position + SHAKE_FLAG*SHAKE_AMPLITUDE*merge*(2.0*delta - 1.0);
}

//Jitter the character scale, using a similar method to above
vec2 jitter(vec2 position, vec2 centre, float characterIndex)
{
    float floorTime = floor(JITTER_SPEED*u_fTime + 0.5);
    
    //Use some misc prime numbers to try to get a varied-looking jitter
    float delta = rand(vec2(characterIndex/149.0 + floorTime/13.0, characterIndex/727.0 - floorTime/331.0));
    
    return scale(position, centre, mix(JITTER_MINIMUM, JITTER_MAXIMUM, delta));
}

float filterSprite(float spriteData)
{
    float imageSpeed = floor(spriteData / 4096.0);
    float imageMax   = floor((spriteData - 4096.0*imageSpeed) / 64.0);
    float image      = spriteData - (4096.0*imageSpeed + 64.0*imageMax);
    
    float displayImage = floor(mod(imageSpeed*u_fTime/1024.0, imageMax));
    return ((abs(image-displayImage) < 1.0/255.0)? 1.0 : 0.0);
}

//HSV->RGB conversion function
vec3 hsv2rgb(vec3 c)
{
    vec4 K = vec4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
    vec3 P = abs(fract(c.xxx + K.xyz) * 6.0 - K.www);
    return c.z * mix(K.xxx, clamp(P - K.xxx, 0.0, 1.0), c.y);
}

//Colour cycling for the rainbow effect
vec4 rainbow(float characterIndex, vec4 colour)
{
    return vec4(mix(colour.rgb, hsv2rgb(vec3(0.02*characterIndex + RAINBOW_SPEED*u_fTime, 1.0, 1.0)), RAINBOW_FLAG*RAINBOW_WEIGHT), colour.a);
}
                           
//Colour cycling through a defined palette
vec4 cycle(float characterIndex, vec4 colour)
{
    float max_h = 4.0; //Default to a 4-colour cycle
    
    //Special cases for 0- and 1-colour cycles
    if (colour.r < 0.003) return colour;
    if (colour.g < 0.003) return vec4(hsv2rgb(vec3(colour.r, CYCLE_SATURATION/255.0, CYCLE_VALUE/255.0)), 1.0);
    if (colour.a < 0.003) max_h = 3.0; //3-colour cycle
    if (colour.b < 0.003) max_h = 2.0; //2-colour cycle
    
    float h = abs(mod((CYCLE_SPEED*u_fTime - characterIndex)/10.0, max_h));
    
    //vec3 rgbA = hsv2rgb(vec3(colour[int(h)], CYCLE_SATURATION/255.0, CYCLE_VALUE/255.0));
    //vec3 rgbB = hsv2rgb(vec3(colour[int(mod(h + 1.0, max_h))], CYCLE_SATURATION/255.0, CYCLE_VALUE/255.0));
    
    // rgbA
    int ih = int(h); // int h
    float c1 = 0.0; // colour 1
    if (ih == 0) c1 = colour[0];
    else if (ih == 1) c1 = colour[1];
    else if (ih == 2) c1 = colour[2];
    else if (ih == 3) c1 = colour[3];
    
    // rgbB
    int ih2 = int(mod(h + 1.0, max_h)); // int h 2
    float c2 = 0.0; // colour 2
    if (ih2 == 0) c2 = colour[0];
    else if (ih2 == 1) c2 = colour[1];
    else if (ih2 == 2) c2 = colour[2];
    else if (ih2 == 3) c2 = colour[3];
    
    vec3 rgbA = hsv2rgb(vec3(c1, CYCLE_SATURATION/255.0, CYCLE_VALUE/255.0));
    vec3 rgbB = hsv2rgb(vec3(c2, CYCLE_SATURATION/255.0, CYCLE_VALUE/255.0));
    
    return vec4(mix(rgbA, rgbB, fract(h)), 1.0);
}

//Fade effect for typewriter etc.
float fade(float windowArray[2*WINDOW_COUNT], float smoothness, float index, bool invert)
{
    float result = 0.0;
    float f      = 1.0;
    float head   = 0.0;
    float tail   = 0.0;
    
    for(int i = 0; i < 2*WINDOW_COUNT; i += 2)
    {
        head = windowArray[i  ];
        tail = windowArray[i+1];
        
        if (u_fTypewriterSmoothness > 0.0)
        {
            f = 1.0 - min(max((index - tail) / smoothness, 0.0), 1.0);
        }
        else
        {
            f = 1.0;
        }
        
        f *= step(index, head);
        
        result = max(f, result);
    }
    
    if (invert) result = 1.0 - result;
    
    return result;
}

vec2 bezier(float t, vec2 p1, vec2 p2, vec2 p3)
{
    float inv_t = 1.0 - t;
    return 3.0*inv_t*inv_t*t*p1 + 3.0*inv_t*t*t*p2 + t*t*t*p3;
}

vec2 bezierDerivative(float t, vec2 p1, vec2 p2, vec2 p3)
{
    float inv_t = 1.0 - t;
    return 3.0*inv_t*inv_t*p1 + 6.0*inv_t*t*(p2 - p1) + 3.0*t*t*(p3 - p2);
}



//--------------------------------------------------------------------------------------------------------



float easeQuad(float time)
{
	return time*time;
}

float easeCubic(float time)
{
	return time*time*time;
}

float easeQuart(float time)
{
	return time*time*time*time;
}

float easeQuint(float time)
{
	return time*time*time*time*time;
}

float easeSine(float time)
{
    return 1.0 - cos(0.5*(time*PI));
}

float easeExpo(float time)
{
    if (time == 0.0) return 0.0;
    return pow(2.0, 10.0*time - 10.0);
}

float easeCirc(float time)
{
    return 1.0 - sqrt(1.0 - time*time);
}

float easeBack(float time)
{
    float param = 1.70158;
	return time*time*((param + 1.0)*time - param);
}

float easeElastic(float time)
{
    if (time == 0.0) return 0.0;
    if (time == 1.0) return 1.0;
    return -pow(2.0, 10.0*time - 10.0) * sin((time*10.0 - 10.75) * (2.0*PI) / 3.0);
}

float easeBounce(float time)
{
	float n1 = 7.5625;
	float d1 = 2.75;
    
    time = 1.0 - time;
    
	if (time < 1.0 / d1)
    {
		return 1.0 - n1*time*time;
	}
    else if (time < 2.0 / d1)
    {
        time -= 1.5/d1;
		return 1.0 - (n1*time*time + 0.75);
	}
    else if (time < 2.5 / d1)
    {
        time -= 2.25/d1;
		return 1.0 - (n1*time*time + 0.9375);
	}
    else
    {
        time -= 2.625/d1;
		return 1.0 - (n1*time*time + 0.984375);
	}
}



//--------------------------------------------------------------------------------------------------------



void main()
{
    //Unpack character/line index
    float characterIndex = floor(in_Position.z / MAX_LINES);
    float lineIndex      = in_Position.z - characterIndex*MAX_LINES;
    
    //MAX_EFFECTS = 11
    float flagValue = in_Normal.z;
    float edge;
    edge = step(1024.0, flagValue); flagArray[10] = edge; flagValue -= 1024.0*edge;
    edge = step( 512.0, flagValue); flagArray[ 9] = edge; flagValue -=  512.0*edge;
    edge = step( 256.0, flagValue); flagArray[ 8] = edge; flagValue -=  256.0*edge;
    edge = step( 128.0, flagValue); flagArray[ 7] = edge; flagValue -=  128.0*edge;
    edge = step(  64.0, flagValue); flagArray[ 6] = edge; flagValue -=   64.0*edge;
    edge = step(  32.0, flagValue); flagArray[ 5] = edge; flagValue -=   32.0*edge;
    edge = step(  16.0, flagValue); flagArray[ 4] = edge; flagValue -=   16.0*edge;
    edge = step(   8.0, flagValue); flagArray[ 3] = edge; flagValue -=    8.0*edge;
    edge = step(   4.0, flagValue); flagArray[ 2] = edge; flagValue -=    4.0*edge;
    edge = step(   2.0, flagValue); flagArray[ 1] = edge; flagValue -=    2.0*edge;
    edge = step(   1.0, flagValue); flagArray[ 0] = edge; flagValue -=    1.0*edge;
    
    
    
    //Use the input vertex position from the vertex attributes. We ignore the z-component because it's used for other data
    vec2 pos = in_Position.xy;
    
    
    
    //Unpack the glyph centre
    vec2 centreDelta = vec2(in_Normal.x, in_Colour2.y);
    
    
    
    vec2 centre;
    
    //If we have a valid Bezier curve, apply it
    if ((u_aBezier[2].x != 0.0) || (u_aBezier[2].y != 0.0))
    {
        centre = bezier(in_Position.x, u_aBezier[0], u_aBezier[1], u_aBezier[2]);
        
        vec2 orientation = bezierDerivative(in_Position.x, u_aBezier[0], u_aBezier[1], u_aBezier[2]);
        pos = rotate_by_vector(centre - centreDelta, centre, normalize(orientation));
        
        vec2 perpendicular = normalize(vec2(-u_aBezier[2].y, u_aBezier[2].x));
        pos += in_Position.y*perpendicular;
    }
    else
    {
        centre = pos + centreDelta;
    }
    
    pos += u_vSkew*centre.yx;
    if (SLANT_FLAG > 0.5) pos.x += centreDelta.y*SLANT_GRADIENT;
    
    
    
    //Colour
    v_vColour = in_Colour;
    
    if (CYCLE_FLAG > 0.5) v_vColour = cycle(characterIndex, v_vColour); //Cycle colours through the defined palette
    v_vColour = rainbow(characterIndex, v_vColour); //Cycle colours for the rainbow effect
    
    //Apply the gradient effect
    if (pos.y > centre.y) v_vColour.rgb = mix(v_vColour.rgb, u_vGradient.rgb, u_vGradient.a);
    
    if (!BLEND_SPRITES && (SPRITE_FLAG > 0.5))
    {
        //If we're not RGB blending sprites and this *is* a sprite then only modify the alpha channel
        v_vColour.a *= u_vColourBlend.a;
    }
    else
    {
        //And then blend with the blend colour/alpha
        v_vColour *= u_vColourBlend;
    }
    
    if (SPRITE_FLAG > 0.5) v_vColour.a *= filterSprite(in_Normal.y); //Use packed sprite data to filter out sprite frames that we don't want
    if ((BLINK_FLAG > 0.5) && (u_fBlinkState < 0.5)) v_vColour.a = 0.0;
    
    //Regions
    if ((characterIndex >= u_vRegionActive.x) && (characterIndex <= u_vRegionActive.y)) v_vColour.rgb = mix(v_vColour.rgb, u_vRegionColour.rgb, u_vRegionColour.a);
    
    
    
    //Vertex animation
    pos.xy = wobble(pos, centre);
    pos.xy = pulse( pos, centre, characterIndex);
    if (JITTER_FLAG > 0.5) pos.xy = jitter(pos, centre, characterIndex); //Apply the jitter effect
    
    
    
    //Apply fade (if we're given a method)
    int easeMethod = u_iTypewriterMethod;
    bool fadeOut = (easeMethod >= EASE_METHOD_COUNT);
    if (fadeOut) easeMethod -= EASE_METHOD_COUNT;
    
    if (easeMethod > EASE_NONE)
    {
        float fadeIndex = characterIndex + 1.0;
        if (u_iTypewriterCharMax > 0) fadeIndex = float(u_iTypewriterCharMax) - fadeIndex;
        
        float time = fade(u_fTypewriterWindowArray, u_fTypewriterSmoothness, fadeIndex, fadeOut);
        
        if (u_fTypewriterAlphaDuration == 0.0)
        {
            if (time <= 0.0) v_vColour.a = 0.0;
        }
        else
        {
            v_vColour.a *= clamp(time / u_fTypewriterAlphaDuration, 0.0, 1.0);
        }
             if (easeMethod == EASE_QUADRATIC  ) { time = 1.0 - easeQuad(   1.0 - time); }
        else if (easeMethod == EASE_CUBIC      ) { time = 1.0 - easeCubic(  1.0 - time); }
        else if (easeMethod == EASE_QUARTIC    ) { time = 1.0 - easeQuart(  1.0 - time); }
        else if (easeMethod == EASE_QUINTIC    ) { time = 1.0 - easeQuint(  1.0 - time); }
        else if (easeMethod == EASE_SINE       ) { time = 1.0 - easeSine(   1.0 - time); }
        else if (easeMethod == EASE_EXPONENTIAL) { time = 1.0 - easeExpo(   1.0 - time); }
        else if (easeMethod == EASE_CIRCULAR   ) { time = 1.0 - easeCirc(   1.0 - time); }
        else if (easeMethod == EASE_BACK       ) { time = 1.0 - easeBack(   1.0 - time); }
        else if (easeMethod == EASE_ELASTIC    ) { time = 1.0 - easeElastic(1.0 - time); }
        else if (easeMethod == EASE_BOUNCE     ) { time = 1.0 - easeBounce( 1.0 - time); }
        else if (easeMethod == EASE_CUSTOM_1   ) { /*Custom ease slot 1*/ }
        else if (easeMethod == EASE_CUSTOM_2   ) { /*Custom ease slot 2*/ }
        else if (easeMethod == EASE_CUSTOM_3   ) { /*Custom ease slot 3*/ }
        
        pos = scale(pos, centre, mix(u_vTypewriterStartScale, vec2(1.0), time));
        pos = rotate(pos, centre, mix(-u_fTypewriterStartRotation, 0.0, time));
        pos.xy += mix(u_vTypewriterStartPos, vec2(0.0), time);
    }
    
    
    
    //Vertex
    pos.xy = wave( pos, characterIndex); //Apply the wave effect
    pos.xy = wheel(pos, characterIndex); //Apply the wheel effect
    pos.xy = shake(pos, characterIndex); //Apply the shake effect
    
    
    
    //Final positioning
    gl_Position = gm_Matrices[MATRIX_WORLD_VIEW_PROJECTION]*vec4(pos, 0.0, 1.0);
    
    
    
    //Texture
    v_vTexcoord = in_TextureCoord;
}
