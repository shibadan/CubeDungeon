package game;

public class GrassBlock extends Block {

	static final String pass = "grass.bmp";

	public GrassBlock(int cx, int cy) {
		super(cx, cy, pass);
		fillData(1);
	}

}
