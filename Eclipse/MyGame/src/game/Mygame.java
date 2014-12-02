package game;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

import javax.swing.JFrame;
import javax.swing.JPanel;


public class Mygame{

	private static Thread game;
	private static JFrame frame;

	public static void main(String[] args){
		frame = new JFrame();
		frame.setTitle("MyGame");
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setBounds(400, 150, 820, 650);
		frame.getContentPane().setPreferredSize(new Dimension(780, 620));
		frame.pack();
		frame.setResizable(false);
		Game panel = new Game();
		panel.setBackground(Color.cyan);
		game = new Thread(panel); //ゲーム用スレッド作成
		game.start();
		frame.getContentPane().add(panel);
		frame.setVisible(true);
	}
}

class Game extends JPanel implements Runnable, KeyListener{
	Gamebody body;
	//コンストラクタ
	public Game(){
		setBackground(Color.white);
		addKeyListener(this);//キーリスナー
		body = new Gamebody();
	}

	//ペイントのメイン
	public void paintComponent(Graphics g){
		requestFocusInWindow();//キー入力で必要（押されたキーをどのウィンドウで処理するかをこのウィンドウに決定）
		super.paintComponent(g);
		body.draw(g);
	}

	//使わない
	public void keyTyped(KeyEvent e) {

	}

	//キーが押されたときに動く
	public void keyPressed(KeyEvent e) {
		int k;
		k = e.getKeyCode();
		body.key_func(k);
	}

	//キーが離されたときに動く
	public void keyReleased(KeyEvent e) {
		int k;
		k = e.getKeyCode();
		body.keyReleased(k);
	}

	//ループのメイン
	public void run() {
		while(true){
			body.update();
			repaint();
			try {
				Thread.sleep(6);
			} catch (InterruptedException e) {
			}
		}
	}

}

