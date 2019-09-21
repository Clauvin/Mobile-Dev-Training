// Author: Cláuvin
// Title: Shader 11 - Micro-Game

#ifdef GL_ES
precision mediump float;
#endif

#define PI 3.14159265359

uniform vec2 u_resolution;
uniform vec2 u_mouse;
uniform float u_time;

void drawRectangle(float start_x, float end_x, float start_y, float end_y, vec4 color){
    
    if ((gl_FragCoord.x >= start_x) && (gl_FragCoord.x <= end_x) &&
        	(gl_FragCoord.y >= start_y) && (gl_FragCoord.y <= end_y)){
        gl_FragColor = color;
    }
}

// Plot a line on Y using a value between 0.0-1.0
float plot(vec2 st, float pct){
  return  smoothstep( pct-0.02, pct, st.y) -
          smoothstep( pct, pct+0.02, st.y);
}

void sine(){
    
    vec2 st = gl_FragCoord.xy/u_resolution;
    
    float y = sin(u_time + 4. * PI * st.x)/ 2.0 +0.5;
    
    vec3 color = vec3(y);

    // Plot a line
    float pct = plot(st,y);
    color = pct*vec3(0.0,1.0,0.0);

	gl_FragColor = vec4(color,1.0);
}

void experimental_sine(){
    
    vec2 st = gl_FragCoord.xy/u_resolution;
    
    float y = fract(sin(u_time + 4. * PI * st.x)/ 2.0);
    
    vec3 color = vec3(y);

    // Plot a line
    float pct = plot(st,y);
    color = pct*vec3(0.0,1.0,0.0);

	gl_FragColor = vec4(color,1.0);
    
}

void cossine(){
    
    vec2 st = gl_FragCoord.xy/u_resolution;
    
    float z = cos(u_time + 4. * PI * st.x) / 2.0 + 0.5;
    
    vec3 color = vec3(z);

    // Plot a line
    float pct = plot(st,z);
    color = pct*vec3(1.0,0.0,0.0);
    
    if (color != vec3(0.0, 0.0, 0.0)){
        gl_FragColor = vec4(color,1.0);
    }
}

void weird_blue_function(){
    //tangent
    vec2 st = gl_FragCoord.xy/u_resolution;
    
    float w = (sin(u_time + PI * st.x)/cos(u_time + 4. * PI)) / 2.0;
    
    vec3 color = vec3(w);

    // Plot a line
    float pct = plot(st,w);
    color = pct*vec3(0.0,0.0,1.0);
    
    if (color != vec3(0.0, 0.0, 0.0)){
        gl_FragColor = vec4(color,1.0);
    }
}

float ceiling_function(vec2 st){
    
    float y = sin(u_time + sin(u_time) * 0.75 * PI * sin(st.x))/6.0 + 0.75;
    
    float trep_1 = (cos(u_time/0.25) + sin(u_time/0.5)) / 14.0;
    
    return y - trep_1;
}

void ceiling(){
    
    vec2 st = gl_FragCoord.xy/u_resolution;
    
    float y = ceiling_function(st);
    
    vec3 color = vec3(y);

    // Plot a line
    float pct = plot(st,y);
    
    if (st.y > y){
        color = vec3(0.0,1.0,0.0);
    } else {
    	color = pct*vec3(0.0,1.0,0.0);    
    }
    

	gl_FragColor = vec4(color,1.0);
    
    
    
}

float ground_function(vec2 st){
    float y = cos(u_time + cos(u_time/10.) * 2. * PI * st.x) / 6.0
        - sin(pow(u_time, 0.5)) / 11.0 + 0.25;
    
    y = clamp(0.0, y, 0.5);
    
    return y;
    
}

void balls(){
    
    vec2 st = gl_FragCoord.xy/u_resolution;
    
    float pos_1 = ceiling_function(st);
    
    float pos_2 = ground_function(st);
    
    float true_pos = (pos_1+pos_2) / 2. + sin(u_time + sin(0.5 * u_time)) / 20.;
    
    float pct = plot(st, true_pos);
    
    if (((st.x > .1) && (st.x < .15)) || ((st.x > .25) && (st.x < .3)) ||
    	((st.x > .4) && (st.x < .45)) || ((st.x > .55) && (st.x < .6))){
        
         vec3 color = pct*vec3(0.989,1.000,0.959);
        
         if (color != vec3(0.0, 0.0, 0.0)){
         	gl_FragColor = vec4(color,1.0);
         }
        
    }
	
}

void ground(){
	vec2 st = gl_FragCoord.xy/u_resolution;
    
    float z = ground_function(st);
    
    vec3 color = vec3(z);

    // Plot a line
    float pct = plot(st,z);
    
    if (st.y < z){
        color = vec3(0.0,0.0,1.0);
    } else {
    	color = pct*vec3(0.0,0.0,1.0);    
    }
    
    if (color != vec3(0.0, 0.0, 0.0)){
        gl_FragColor = vec4(color,1.0);
    }
}

void mouse(){
    
    vec2 st = gl_FragCoord.xy/u_resolution;
    vec2 mouse_scaled = u_mouse/u_resolution;
    
    vec3 color = vec3(1.0, 1.0, 1.0);
    
    float limit = 0.01;
    
    if ((st.x >= mouse_scaled.x - limit) && (st.x <= mouse_scaled.x + limit) &&
        (st.y >= mouse_scaled.y - limit) && (st.y <= mouse_scaled.y+ limit))
    {
        
		gl_FragColor = vec4(color,1.0);
        
    }
    
}

void game_over(){
    
    vec2 st = gl_FragCoord.xy/u_resolution;
    vec2 mouse_scaled = u_mouse/u_resolution;
    
    vec3 color = vec3(1.0,0.0,0.0);
    float limit = 0.01;
    
    float ceiling_limits = ceiling_function(st);
    
    float ground_limits = ground_function(st);
    
    if (((mouse_scaled.y >= ceiling_limits) ||
        	(mouse_scaled.y <= ground_limits)) && (
    		((st.x >= mouse_scaled.x - limit) && (st.x <= mouse_scaled.x + limit) &&
        	(st.y >= mouse_scaled.y - limit) && (st.y <= mouse_scaled.y+ limit)))){
        
		gl_FragColor = vec4(color,1.0);
        
    }
    
    
}

//y = mod(x,0.5); // return x modulo of 0.5
//y = fract(x); // return only the fraction part of a number
//y = ceil(x);  // nearest integer that is greater than or equal to x
//y = floor(x); // nearest integer less than or equal to x
//y = sign(x);  // extract the sign of x
//y = abs(x);   // return the absolute value of x
//y = clamp(x,0.0,1.0); // constrain x to lie between 0.0 and 1.0
//y = min(0.0,x);   // return the lesser of x and 0.0
//y = max(0.0,x);   // return the greater of x and 0.0 

void main() {
	
    ceiling();
	ground();
    mouse();
	game_over();

}
