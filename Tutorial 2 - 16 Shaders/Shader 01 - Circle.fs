// Author: Cláuvin
// Title: Shader 01 - A white square in a black background

#ifdef GL_ES
precision mediump float;
#endif

//uniform vec2 u_resolution;
//uniform vec2 u_mouse;
//uniform float u_time;

void main() {
    vec2 upper_left = vec2(100.0, 100.0);
    vec2 lower_right = vec2(400.0, 400.0);
    //vec2 st = gl_FragCoord.xy/u_resolution.xy;
    //st.x *= u_resolution.x/u_resolution.y;

    //vec3 color = vec3(0.);
    //color = vec3(st.x,st.y,abs(sin(u_time)));

    if ((gl_FragCoord.x > upper_left.x) && (gl_FragCoord.y > upper_left.y) &&
        (gl_FragCoord.x < lower_right.x) && (gl_FragCoord.y < lower_right.y))
        gl_FragColor = vec4(1.0,1.0,1.0,1.0);
    //gl_FragColor = vec4(color,1.0);
}