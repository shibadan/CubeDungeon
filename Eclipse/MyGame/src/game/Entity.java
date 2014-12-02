package game;
import java.awt.Graphics;


public class Entity {
	MyVector pos; //左上の座標
	MyVector speed; //現在速度
	MyVector acceleration; //加速度

	public Entity(int cx, int cy){
		this(cx, cy, 0, 0, 0, 0);
	}

	public Entity(int cx, int cy, int sx, int sy){
		this(cx, cy, sx, sy, 0, 0);
	}

	public Entity(int cx, int cy, double sx, double sy){
		this(cx, cy, sx, sy, 0, 0);
	}

	public Entity(int cx, int cy, double sx, double sy, double ax, double ay){
		pos = new MyVector(cx,cy);
		speed = new MyVector(sx, sy);
		acceleration = new MyVector(ax, ay);
	}

	public int getPosX(){
		return (int) pos.getX();
	}

	public int getPosY(){
		return (int)pos.getY();
	}

	public void stopX(){
		speed.setX(0);
	}

	public void stopY(){
		speed.setY(0);
	}

	public void turn(){
		speed.turn();
	}

	public void accelerate(double x, double y){
		acceleration.addX(x);
		acceleration.addY(y);
	}

	public void move(){
		speed.addX(acceleration.getX());
		speed.addY(acceleration.getY());
		pos.addX(speed.getX());
		pos.addY(speed.getY());
	}

	public void draw(Graphics g){

	}
}

