// Author: Cláuvin
// Title: Shader 02 - A square with a mock-up UI

#ifdef GL_ES
precision mediump float;
#endif

//uniform vec2 u_resolution;
//uniform vec2 u_mouse;
//uniform float u_time;

void drawRectangle(float start_x, float end_x, float start_y, float end_y, vec4 color){
    
    if ((gl_FragCoord.x >= start_x) && (gl_FragCoord.x <= end_x) &&
        	(gl_FragCoord.y >= start_y) && (gl_FragCoord.y <= end_y)){
        gl_FragColor = color;
    }
}

void main() {
    vec2 lower_left = vec2(100.0, 100.0);
    vec2 upper_right = vec2(400.0, 400.0);
    vec4 ui_color = vec4(0.0, 0.0, 1.0, 1.0);
    //vec2 st = gl_FragCoord.xy/u_resolution.xy;
    //st.x *= u_resolution.x/u_resolution.y;

    //vec3 color = vec3(0.);
    //color = vec3(st.x,st.y,abs(sin(u_time)));
    
    if ((gl_FragCoord.x > lower_left.x) && (gl_FragCoord.y > lower_left.y) &&
       			(gl_FragCoord.x < upper_right.x) && (gl_FragCoord.y < upper_right.y)){
        
        gl_FragColor = vec4(1.0,1.0,1.0,1.0);
    }
    
    //H
	drawRectangle(0.0, 10.0, 410.0, 500.0, ui_color);
    drawRectangle(0.0, 50.0, 450.0, 460.0, ui_color);
    drawRectangle(40.0, 50.0, 410.0, 500.0, ui_color);
    
    //P
    drawRectangle(60.0, 110.0, 490.0, 500.0, ui_color);
    drawRectangle(60.0, 110.0, 450.0, 460.0, ui_color);
    drawRectangle(60.0, 70.0, 410.0, 500.0, ui_color);
    drawRectangle(100.0, 110.0, 450.0, 500.0, ui_color);
    drawRectangle(100.0, 110.0, 450.0, 500.0, ui_color);
    
    //:
	drawRectangle(120.0, 130.0, 490.0, 500.0, ui_color);
    drawRectangle(120.0, 130.0, 410.0, 420.0, ui_color);
    
    //0:
    drawRectangle(140.0, 150.0, 410.0, 500.0, ui_color);
    drawRectangle(140.0, 190.0, 490.0, 500.0, ui_color);
    drawRectangle(140.0, 190.0, 410.0, 420.0, ui_color);
    drawRectangle(180.0, 190.0, 410.0, 500.0, ui_color);
       
}



