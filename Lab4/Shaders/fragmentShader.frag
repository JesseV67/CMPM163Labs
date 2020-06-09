varying vec2 vUv;
uniform sampler2D texture1;

void main() {
	// sample from the texture based on the uv coordinates
	gl_FragColor = texture2D(texture1, vUv);
}
