package game;
import java.awt.Graphics;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import java.util.Arrays;

import javax.imageio.ImageIO;

//ブロックの原型
//各種ブロックはこれを継承して作成する
public class Block extends Entity {

	BufferedImage img;
	static final int size = 32;
	int data[][] = new int[size][size];
	
	public Block(int cx, int cy){
		super(cx, cy, 0, 0, 0, 0);
	}

	public Block(int cx, int cy, String pass){
		this(cx, cy, 0, 0, 0, 0, pass);
	}

	public Block(int cx, int cy, int sx, int sy, String pass){
		this(cx, cy, sx, sy, 0, 0, pass);
	}

	public Block(int cx, int cy, int sx, int sy, double ax, double ay, String pass){
		super(cx, cy, sx, sy, ax, ay);
		imageSetter(pass);
		fillData(0);
	}

	//データをdで埋める
	protected void fillData(int d){
		for(int i= 0; i < size; i++){
			Arrays.fill(data[i], d);
		}
	}

	private void imageSetter(String pass){
		try{
			img = ImageIO.read(new File("Images/block/"+ pass));
		}catch (IOException e){
		}
	}

	public int[][] getData(){
		return data;
	}

	public void draw(Graphics g){
		g.drawImage(img, (int)pos.getX(), (int)pos.getY(), null);
	}

}
