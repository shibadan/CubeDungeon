package game;

public abstract class TrapBlock extends Block implements Trap {

	public TrapBlock(int cx, int cy) {
		super(cx, cy);
	}

	public abstract Block getBlock();

	public abstract boolean check(Kid kid);

}
