package game;


public class GroundBlock extends Block {

	static final String pass = "ground.bmp";

	public GroundBlock(int cx, int cy) {
		super(cx, cy, pass);
		fillData(1);
	}

}
