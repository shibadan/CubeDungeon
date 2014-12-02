package game;
import java.awt.Graphics;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;


public class Map extends Mapdata{

	BlockManager blocks = new BlockManager();
	TrapManager traps = new TrapManager();
	Kid kid;
	int blockSize = Block.size;
	int[][] mapSeed = new int[25][20];

	public Map(String pass){

		String str;
		String[] data;

		try{
			BufferedReader br = new BufferedReader(new FileReader(new File("D:/pleiades/workspace/MyGame/Images/map/map1.txt")));
			for(int i = 0; i < 20; i++){
				str = br.readLine();
				data = str.split(",");
				for(int j = 0; j < 25; j++){
					mapSeed[j][i] = Integer.parseInt(data[j]);
				}
			}
			br.close();
		}catch(FileNotFoundException e){
			System.out.println(e);
		}catch(IOException e){
		}


		for(int i = 0; i < 25; i++){
			for(int j = 0; j < 20; j++){
				int s;
				switch(s = mapSeed[i][j]){
				case 1:
					blocks.add(new GroundBlock(i*32, j*32));
					break;
				case 2:
					blocks.add(new GrassBlock(i*32, j*32));
					break;
				case 3:
				case 4:
				case 5:
				case 6:
					blocks.add(new Spike(i*32, j*32, s-3));
					break;
				case 7:
					blocks.add(new DeathHole(i*32, j*32));
				}
			}
		}
		
		
		traps.add(new VanishGrassBlock(3*32, 19*32));
		traps.add(new VanishGrassBlock(6*32, 19*32));
		traps.add(new VanishGrassBlock(1*32, 14*32));
		traps.add(new VanishGrassBlock(2*32, 14*32));
		traps.add(new VanishGroundBlock(13*32, 10*32));
		traps.add(new VanishGroundBlock(14*32, 10*32));
		traps.add(new VanishGroundBlock(15*32, 10*32));
		traps.add(new AppearGroundBlock(5*32, 3*32));
		traps.add(new AppearGroundBlock(5*32, 4*32));
		for(int i = 0; i < traps.size(); i++){
			blocks.add(traps.getBlock(i));
		}

		blocks.add(new MovingBlock(1*32, 10*32, 1, 6));
		blocks.add(new MovingBlock(22*32,10*32, 0, 5));
		

		initialize();
	}

	private void initialize(){
		clearData();
		for(Block v: blocks){
			v.move();
			updateMapData(v);
		}
	}

	public void setKid(Kid k){
		kid = k;
	}

	private void updateMapData(Block block){
		int x = block.getPosX(), y = block.getPosY();
		int[][] blockData = block.getData();
		for(int i = 0; i < blockSize; i++){
			for(int j = 0; j < blockSize; j++){
				if(blockData[i][j] > 0){
					data[x+i][y+j] = blockData[i][j];
				}
			}
		}
	}

	public int getMapData(int x, int y){
		return data[x][y];
	}

	public void update(){
		clearData();
		traps.check(kid);
		for(Block v: blocks){
			v.move();
			updateMapData(v);
		}
	}

	public void draw(Graphics g){
		for(Block v: blocks){
			v.draw(g);
		}
	}

}
