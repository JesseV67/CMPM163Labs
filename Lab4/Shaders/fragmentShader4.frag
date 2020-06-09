varying vec2 vUv;
uniform sampler2D texture1;

void main(){
	vec2 tile = vUv * vec2(2);
	if(vUv.x < 0.5 && vUv.y < 0.5){
		gl_FragColor = texture2D(texture1, tile - vec2(0,0));
	}
	if(vUv.x < 0.5 && vUv.y > 0.5){
		gl_FragColor = texture2D(texture1, tile - vec2(0,1));
	}
	if(vUv.x > 0.5 && vUv.y < 0.5){
		gl_FragColor = texture2D(texture1, tile - vec2(1,0));
	}
	if(vUv.x > 0.5 && vUv.y > 0.5){
		gl_FragColor = texture2D(texture1, tile - vec2(1,1));
	}
}