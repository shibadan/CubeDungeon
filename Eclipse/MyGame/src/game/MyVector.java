package game;

public class MyVector {
	double x, y;
	double mx = 100000, my = 100000; //最高速度

	public MyVector(){
		this(0, 0);
	}

	public MyVector(double in_x, double in_y){
		x = in_x;
		y = in_y;
	}

	public void turnX(){
		x *= -1;
	}

	public void turn(){
		x *= -1;
		y *= -1;
	}

	public void setMax(double x, double y){
		mx = x;
		my = y;
	}

	public  void setX(double nx){
		x = nx;
	}

	public void setY(double ny){
		y = ny;
	}

	public void addX(double v){
		x += v;
		if(x > mx) x = mx;
	}

	public void addY(double v){
		y += v;
		if(y > my) y = my;
	}

	public double getX(){
		return x;
	}

	public double getY(){
		return y;
	}

}
