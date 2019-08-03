// Author: Cláuvin
// Title: Shader 03 - Red Line

#ifdef GL_ES
precision mediump float;
#endif

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

void main() {
	vec2 st = gl_FragCoord.xy/u_resolution;

    float y = st.x;

    vec3 color = vec3(y);

    // Plot a line
    float pct = plot(st,y);
    color = (1.0-pct)*color+pct*vec3(1.0,0.0,0.0);

	gl_FragColor = vec4(color,1.0);
}




