using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP;
    private Enemy_Data enemyData;
    GameObject item_levelup;
    GameObject item_new;
    Vector3 positionValue;
    // Use this for initialization
    void Start()
    {
        enemyData = new Enemy_Data(HP);
        Debug.Log(gameObject.name + "의 체력 : " + enemyData.getHP());
    }

    void Update()
    {
        if (enemyData.getHP() <= 0)
        {
            Debug.Log("파괴!!!!!");
            item_drop();
            Destroy(gameObject);
            // 현재 적의 오브젝트를 메모리풀링으로 만들지 않았기 때문에
            // Destroy로 처리합니다.
        }
    }
    void item_drop()
    {
        item_levelup = Resources.Load("usingAssets/Item_levelup") as GameObject;
        positionValue = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y);
        positionValue.z = -90;
        item_new = (GameObject)Instantiate(item_levelup, positionValue, Quaternion.LookRotation(gameObject.transform.forward));
    }
    private void OnTriggerEnter(Collider collision)
    {
        // 부딛히는 collision을 가진 객체의 태그가 "Player Missile"일 경우
        if (collision.CompareTag("Player Missile"))
        {
            Debug.Log("미사일과 충돌");
            enemyData.decreaseHP(10);   // 체력을 10 감소
            Debug.Log(gameObject.name + "의 현재 체력 : " + enemyData.getHP());
        }

        // 부딛히는 collision을 가진 객체의 태그가 "Player Bomb"일 경우
        if (collision.CompareTag("Player Bomb"))
        {
            Debug.Log("폭탄과 충돌");
            enemyData.decreaseHP(100);   // 체력을 100 감소
            Debug.Log(gameObject.name + "의 현재 체력 : " + enemyData.getHP());
        }
    }
}