using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Data
{
    private int HP; // 적 기체의 체력

    public Enemy_Data(int _HP)  // 생성자
    {
        HP = _HP;
    }
    // Enemy_Data enemy = new Enemy_Data(50); -> 체력이 50인 적의 데이터

    public void decreaseHP(int damage)  // damage만큼 체력을 깎는다.
    {
        HP -= damage;
    }
    // Enemy_Data enemy = new Enemy_Data(50); -> 체력이 50인 적의 데이터
    // enemy.decreaseHP(20); -> 체력을 20만큼 깎는다.

    public int getHP()
    {
        return HP;
    }
    // Enemy_Data enemy = new Enemy_Data(50); -> 체력이 50인 적의 데이터
    // enemy.getHP(); -> 현재 체력을 반환
}