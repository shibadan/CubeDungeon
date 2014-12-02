package game;

import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;


public class Spike extends Block {

	static final String pass = "spike.png";

	//dirは向き:上が0で時計回りに1,2,3
	public Spike(int cx, int cy, int dir) {
		super(cx, cy);
		imageSetter("spike" + Integer.toString(dir) + ".png");
		fillData(0);
		setData(dir);
	}

	private void imageSetter(String pass){
		try{
			img = ImageIO.read(new File("Images/block/"+ pass));
		}catch (IOException e){
		}
	}

	private void setData(int dir){
		switch(dir){
		case 0:
			for(int i = 2; i < 33; i++){
				for(int j = 0; j < i/2; j++){
					data[15-j][i-1] = 2;
					data[16+j][i-1] = 2;
				}
			}
			break;
		case 1:
			for(int i = 2; i < 33; i++){
				for(int j = 0; j < i/2; j++){
					data[32-i][15-j] = 2;
					data[32-i][16+j] = 2;
				}
			}
			break;
		case 2:
			for(int i = 2; i < 33; i++){
				for(int j = 0; j < i/2; j++){
					data[15-j][32-i] = 2;
					data[16+j][32-i] = 2;
				}
			}
			break;
		case 3:
			for(int i = 2; i < 33; i++){
				for(int j = 0; j < i/2; j++){
					data[i-1][15-j] = 2;
					data[i-1][16+j] = 2;
				}
			}
			break;
		}
	}

}
