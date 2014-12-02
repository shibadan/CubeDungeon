package game;

import java.awt.Graphics;

public class MoveSpike extends TrapBlock {

	Spike spike;
	private boolean isVanished;
	

	//初期座標、飛ぶ方向、飛ぶ早さ、最大移動マス、移動後消えるかどうか
	public MoveSpike(int cx, int cy, int dir, int sp, int m, boolean will) {
		super(cx, cy);
		fillData(0);

	}

	@Override
	public MoveSpike getBlock() {
		return this;
	}

	@Override
	public boolean check(Kid kid) {

		return false;
	}
	
	public void draw(Graphics g) {
		if(!isVanished){
			spike.draw(g);
		}
	}

}
