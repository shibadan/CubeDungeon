package game;

import java.awt.Graphics;


//近づくと消滅するブロック
public class VanishGroundBlock extends TrapBlock{

	boolean isVanished = false;
	GroundBlock block;

	//生成する場所の座標のみ受け取る
	public VanishGroundBlock(int x, int y){
		super(x, y);
		fillData(1);
		block = new GroundBlock(x, y);
	}

	public VanishGroundBlock getBlock(){
		return this;
	}


	public boolean check(Kid kid) {
		int x = (int)(block.getPosX() - kid.getPosX());
		int y = (int)(block.getPosY()-1 - kid.getPosY());
		if(x > 20 || x < -32 || y > 22 || y < -34){
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
