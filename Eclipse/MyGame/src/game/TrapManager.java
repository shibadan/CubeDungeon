package game;

import java.util.ArrayList;

public class TrapManager {

	ArrayList<TrapBlock> traps = new ArrayList<TrapBlock>();
	private int size = 0;

	public void add(TrapBlock t){
		traps.add(t);
		size++;
	}

	public int size(){
		return size;
	}

	public void check(Kid kid){
		for(TrapBlock t: traps){
			t.check(kid);
		}
	}

	public Block getBlock(int n){
		return traps.get(n).getBlock();
	}

}
