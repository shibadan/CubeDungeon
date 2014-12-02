package game;
import java.awt.Graphics;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import java.util.ArrayList;

import javax.imageio.ImageIO;


public class Gamebody {

	Map map1;
	Kid kid, token= new Kid(1*32, 560, map1);;
	boolean end = false;
	ArrayList<Blood> blood = new ArrayList<Blood>();

	BufferedImage gameover;

	public Gamebody(){
		map1 = new Map("map1");
		kid = new Kid(1*32, 560, map1);
		map1.setKid(kid);
		try{
			gameover = ImageIO.read(new File("Images/another/gameover.png"));
		}catch (IOException e){
		}
	}

	public void update(){
		if(end){
			for(Blood v: blood){
				v.move();
			}
			map1.setKid(token);
			map1.update();
		}
		else if(!kid.isAlive()){
			end = true;
			death();
		}
		else{
			map1.setKid(kid);
			map1.update();
			kid.update();
		}

	}

	//血を生成
	public void death(){
		double rnd;
		for(int i = 0; i < 1440; i++){
			rnd = 4*Math.random();
			blood.add(new Blood(kid.getPosX()+12, kid.getPosY()+10, rnd*Math.sin(i*Math.PI/360), rnd*Math.cos(i*Math.PI/360), map1));
		}
	}

	//キーを押されたときの挙動
	public void key_func(int k){
		switch(k){
		case 37: //←
			kid.goLeft();
			break;
		case 39: //→
			kid.goRight();
			break;
		case 32: //space
			kid.space();
			break;
		case 81: //Q
			kid.killed();
			break;
		case 82: //R
			map1 = new Map("map1");
			kid = new Kid(1*32, 560, map1);
			blood.clear();
			end = false;
		}
		//キーコードチェック用
		//System.out.println(k);
	}

	public void keyReleased(int k){
		switch(k){
		case 37: //←
			kid.stopLeft();
			break;
		case 39: //→
			kid.stopRight();
			break;
		case 32:
			kid.spaceReleased();
			break;
		}
	}

	public void draw(Graphics g){
		map1.draw(g);
		if(kid.isAlive()){
			kid.draw(g);
		}
		else{
			for(Blood v: blood){
				v.draw(g);
			}
			g.drawImage(gameover, 0, 200, null);
		}
	}

}
