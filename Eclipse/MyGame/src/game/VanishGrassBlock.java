package game;

import java.awt.Graphics;

public class VanishGrassBlock extends TrapBlock {

	boolean isVanished = false;
	GrassBlock block;

	//生成する場所の座標のみ受け取る
	public VanishGrassBlock(int x, int y){
		super(x, y);
		block = new GrassBlock(x, y);
		fillData(1);
	}


	public VanishGrassBlock getBlock(){
		return this;
	}


	public boolean check(Kid kid) {
		int x = (int)(block.getPosX() - kid.getPosX());
		int y = (int)(block.getPosY()-3 - kid.getPosY());
		if(x > 20 || x < -32 || y > 24 || y < -38){
			return false;
		}
		else{
			isVanished = true;
			fillData(0);
			return true; //近づいていたらtrue
		}
	}


	public void draw(Graphics g) {
		if(!isVanished){
			block.draw(g);
		}
	}

}
