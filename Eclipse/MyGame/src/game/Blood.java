package game;
import java.awt.Color;
import java.awt.Graphics;

public class Blood extends Entity {

	Map map;
	
	public Blood(int cx, int cy, double sx, double sy, Map m) {
		super(cx, cy, sx, sy);
		accelerate(0,0.02);
		speed.setMax(4,4);
		map = m;
	}

	private void moveCheck(){
		int x1 = (int)(getPosX() + speed.getX()), y1 = (int)getPosY();
		int x2 = (int)getPosX(), y2 = (int)(getPosY() + speed.getY());

		if(map.getMapData(x1, y1) > 0 || map.getMapData(x1, y1) > 0 ||map.getMapData(x2, y2) > 0 || map.getMapData(x2, y2) > 0){
			speed.setX(0);
			speed.setY(0);
			acceleration.setY(0);
		}
	}

	public void move(){
		speed.addX(acceleration.getX());
		speed.addY(acceleration.getY());

		moveCheck();
		pos.addX(speed.getX());
		pos.addY(speed.getY());
	}
	
	public void draw(Graphics g){
		g.setColor(Color.red);
		g.drawRect((int)pos.getX(), (int)pos.getY(), 1, 1);
	}

}
