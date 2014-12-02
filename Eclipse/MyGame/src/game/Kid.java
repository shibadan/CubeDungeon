package game;
import java.awt.Graphics;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;


public class Kid extends Entity {

	BufferedImage[][] img = new BufferedImage[4][5];

	int direction = 0; //向いている方向→が0, ←が1;
	int situation = 0; //状態：0がストップ, 1が歩き, 2が落下, 3がジャンプ
	int frame = 10;
	int[] maxFrame ={49, 49, 39, 39};
	int jumpCount = 2;
	int moving = 0;
	int height = 21;
	boolean alive = true;

	Map map;
	int[][] mapData;

	//当たり判定は左右端から４マス空き、上１マス空きの長方形

	public Kid(int cx, int cy, Map m) {
		super(cx, cy);
		imageSetter();
		accelerate(0, 0.05);
		speed.setMax(1, 2.2);
		map = m;
	}

	private void imageSetter(){
		try{
			for(int i = 1; i < 5; i++){
				img[0][i] = ImageIO.read(new File("Images/kid/Stopped" + Integer.toString(i) + ".png"));
				img[1][i] = ImageIO.read(new File("Images/kid/Walk" + Integer.toString(i) + ".png"));
			}
			for(int i = 1; i < 4; i++){
				img[2][i] = ImageIO.read(new File("Images/kid/Fall" + Integer.toString(i) + ".png"));
				img[3][i] = ImageIO.read(new File("Images/kid/Jump" + Integer.toString(i) + ".png"));
			}
		}catch (IOException e){
		}
	}

	public void update(){
		if(speed.getY() <= -1){ //上昇中なら状態遷移
			situation = 3;
		}
		else if(speed.getY() >= 1){ //下降中なら状態遷移
			situation = 2;
		}
		else if(map.getMapData((int)getPosX() + 10,(int)getPosY() + 21) == 1 && moving != 0){ //着地したら状態遷移
			situation = 1;
		}
		else if(map.getMapData((int)getPosX()+3,(int)getPosY() + 21) == 1 || map.getMapData((int)getPosX() + 17,(int)getPosY() + 21) == 1){
			situation = 0;
		}

		frame++;
		if(situation == 1){
			frame += 2;
		}
		if(frame > maxFrame[situation]){
			frame = 10;
		}
		speed.setX(moving);
		move();
	}

	public void goRight(){
		situation = 1;
		moving = 1;
		direction = 0;
	}

	public void goLeft(){
		situation = 1;
		moving = -1;
		direction = 1;
	}


	public void space(){
		if(jumpCount > 0){
			if(situation >1){
				jumpCount = 1;
			}
			speed.setY(-3);
			jumpCount--;
		}
	}

	public void spaceReleased(){
		if(speed.getY() < 0){
			speed.setY(0);
		}
	}
	
	public void stopRight(){
		if(moving > 0)
			moving = 0;
	}

	public void stopLeft(){
		if(moving < 0)
			moving = 0;
	}

	private void moveCheck(){
		int x1 = (int)(getPosX() + speed.getX()), y1 = (int)getPosY();
		int x2 = (int)getPosX(), y2 = (int)(getPosY() + speed.getY());



		for(int i = 4; i < 20; i++){
			for(int j = 1; j < height; j++){
				if(map.getMapData(x1+i+1, y1+j) == 1 || map.getMapData(x1+i-1, y1+j) == 1 ){
					speed.setX(0);
				}
				if(map.getMapData(x2+i, y2+j-1) == 1){
					speed.setY(0);
				}
				else if(map.getMapData(x2+i, y2+j+1) == 1){
					speed.setY(0);
					if(situation != 1){
						situation = 0;
					}
					jumpCount = 2;
				}
			}
		}
		for(int i = 7; i < 17; i++){
			for(int j = 3; j < height-1; j++){
				if(map.getMapData(x1+i, y1+j) == 2 || map.getMapData(x1+i-1, y1+j) == 2 || map.getMapData(x2+i, y2+j) == 2 || map.getMapData(x2+i, y2+j-1) == 2){
					killed();
				}
			}
		}
	}

	public void posCheck(){
		int x = (int)pos.getX() + 5, y = (int)pos.getY() + 19;
		int dir = -1;
		boolean isonblock = false; //動く台の上にいる

		for(int i = 0; i < 15; i++){
			if(map.getMapData(x+i, y) / 10 == 1){ //１０の位が１なら動く台の上にいる
				isonblock = true;
				dir = map.getMapData(x+i, y) % 10;
			}
		}
		if(isonblock){
			autoMove(dir);
			if(situation != 1){
				situation = 0;
			}
			else{
				situation = 1;
			}
		}
	}

	private void autoMove(int d){
		switch(d){
		case 0:
			if(jumpCount == 2)
				speed.setY(-0.5);
			break;
		case 1:
			speed.addX(0.5);
			break;
		case 2:
			if(jumpCount == 2)
				speed.setY(0.5);
			break;
		case 3:
			speed.addX(-0.5);
			break;
		}

	}

	public void move(){
		speed.addX(acceleration.getX());
		speed.addY(acceleration.getY());
		posCheck();
		moveCheck();
		pos.addX(speed.getX());
		pos.addY(speed.getY());

	}

	public void killed(){
		alive = false;
	}

	public boolean isAlive(){
		return alive;
	}

	public void draw(Graphics g){
		int x = (int)pos.getX(), y = (int)pos.getY();
		int width = img[situation][frame/10].getWidth();
		if(direction == 0){
			g.drawImage(img[situation][frame/10], x, y, null);
		}
		else{
			g.drawImage(img[situation][frame/10], x + width, y, -width, img[situation][frame/10].getHeight(), null);
		}
	}

}
