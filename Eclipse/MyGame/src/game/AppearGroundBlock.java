package game;

import java.awt.Graphics;

public class AppearGroundBlock extends TrapBlock {

	boolean isVanished = true;
	GroundBlock block;

	//生成する場所の座標のみ受け取る
	public AppearGroundBlock(int x, int y){
		super(x, y);
		block = new GroundBlock(x, y);
	}

	public AppearGroundBlock getBlock(){
		return this;
	}


	public boolean check(Kid kid) {
		int x = (int)(block.getPosX()-3 - kid.getPosX());
		int y = (int)(block.getPosY()-3 - kid.getPosY());
		if(x > 24 || x < -38 || y > 24 || y < -38){
			return true;
		}
		else{
			isVanished = false;
			fillData(1);
			return true; //近づいていたらtrue
		}
	}


	public void draw(Graphics g) {
		if(!isVanished){
			block.draw(g);
		}
	}
}
