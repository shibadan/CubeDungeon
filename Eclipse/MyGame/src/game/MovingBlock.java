package game;


public class MovingBlock extends Block {

	static final String pass = "halfblock.png";

	int direction; //移動する方向kidの移動方向と同じ
	int passed = 0, maxSquare; //移動したマス数と最大移動マス数(ブロックの数)


	public MovingBlock(int cx, int cy, int dir, int max) {
		super(cx, cy, pass);
		direction = dir;
		maxSquare = max;
		initialize();
	}

	private void initialize(){
		switch(direction){
		case 0:
			speed.setY(-0.5);
			break;
		case 1:
			speed.setX(0.5);
			break;
		case 2:
			speed.setY(0.5);
			break;
		case 3:
			speed.setX(-0.5);
			break;
		}

		fillData(0);
		for(int i = 0; i < 32; i++){
			data[i][12] = 10 + direction;
			data[i][13] = 10 + direction;
			data[i][14] = 10 + direction;
			data[i][15] = 10 + direction;
			for(int j = 16; j < 32; j++){
				data[i][j] = 1;
			}
		}
	}

	public void move(){
		speed.addX(acceleration.getX());
		speed.addY(acceleration.getY());
		pos.addX(speed.getX());
		pos.addY(speed.getY());
		passed++;
		if(passed >= maxSquare * 64){
			turn();
			direction = (direction + 2) % 4;
			for(int i = 0; i < 32; i++){
				data[i][12] = 10 + direction;
				data[i][13] = 10 + direction;
				data[i][14] = 10 + direction;
				data[i][15] = 10 + direction;
			}
			passed = 0;
		}
	}

	public void turn(){
		speed.turn();
	}

}
