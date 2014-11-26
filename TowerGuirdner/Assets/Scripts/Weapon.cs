using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    private int damage;

    public void setDamage(int d)
    {
        damage = d;
    }

    public int getDamage()
    {
        return damage;
    }

}
