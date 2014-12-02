package game;

import java.awt.Graphics;

 public interface Trap {

	public abstract void move();
	public abstract boolean check(Kid kid);
	public abstract void draw(Graphics g);

}
