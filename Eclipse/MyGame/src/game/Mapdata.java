package game;
import java.util.Arrays;


//マップの各ドットに対する進行可否や攻撃判定などを保有する
public class Mapdata{
	int[][] data = new int[800][640];

	public Mapdata(){
		clearData();
	}
	
	public void clearData(){
		for(int i = 0; i < 800; i++){
			Arrays.fill(data[i], 0);
		}
	}
	
}
