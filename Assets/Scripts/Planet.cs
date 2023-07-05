using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour, IDamageable
{
    private float health;

    private int score;
    



    public void IncreaseScore(int add)
    {
        score += add;
    }

    

    bool IDamageable.OnDamage(int damage)
    {
        health -= damage;




        return true;
    }
}