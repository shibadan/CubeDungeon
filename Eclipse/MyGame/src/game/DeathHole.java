package game;

//落とし穴クラス
public class DeathHole extends Block {

	public DeathHole(int cx, int cy) {
		super(cx, cy);
		fillData(0);
		setData();
	}

	public void setData(){
		for(int i = 0; i < 32; i++){
			for(int j = 20; j < 32; j++){
				data[i][j] = 2;
			}
		}
	}
}
