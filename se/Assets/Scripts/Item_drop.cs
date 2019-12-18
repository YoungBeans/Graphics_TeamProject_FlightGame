using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_drop : MonoBehaviour
{

    GameObject item_levelup;
    GameObject item_new;
    Vector3 positionValue;
    int r = 0;
    float Speed = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Player Missile")
        {
            r = Random.Range(0, 100);
            if (r<= 13)
            {
                item_drop();
            }
            if (Random.Range(0, 100) <= 5)
            {
                item_drop_bomb();
            }
        }
    }

    void item_drop()
    {
        item_levelup = Resources.Load("usingAssets/Item_levelup") as GameObject;
        positionValue = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y);
        positionValue.z = -90;
        string s = gameObject.name;
        if (s == "Enemy_down(Clone)")
        {
            item_new = (GameObject)Instantiate(item_levelup, positionValue, Quaternion.LookRotation(new Vector3(0, -1, 0)));
        }
        else if (s == "Enemy_left(Clone)")
        {
            item_new = (GameObject)Instantiate(item_levelup, positionValue, Quaternion.LookRotation(new Vector3(1, -1, 0)));
        }
        else if (s == "Enemy_right(Clone)")
        {
            item_new = (GameObject)Instantiate(item_levelup, positionValue, Quaternion.LookRotation(new Vector3(-1, -1, 0)));
        }
        else if (s == "Enemy_up(Clone)")
        {
            item_new = (GameObject)Instantiate(item_levelup, positionValue, Quaternion.LookRotation(new Vector3(0, 1, 0)));
        }
    }
    void item_drop_bomb()
    {
        item_levelup = Resources.Load("usingAssets/Item_bomb") as GameObject;
        positionValue = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y);
        positionValue.z = -90;
        string s = gameObject.name;
        if (s == "Enemy_down(Clone)")
        {
            item_new = (GameObject)Instantiate(item_levelup, positionValue, Quaternion.LookRotation(new Vector3(0, -1, 0)));
        }
        else if (s == "Enemy_left(Clone)")
        {
            item_new = (GameObject)Instantiate(item_levelup, positionValue, Quaternion.LookRotation(new Vector3(1, -1, 0)));
        }
        else if (s == "Enemy_right(Clone)")
        {
            item_new = (GameObject)Instantiate(item_levelup, positionValue, Quaternion.LookRotation(new Vector3(-1, -1, 0)));
        }
        else if (s == "Enemy_up(Clone)")
        {
            item_new = (GameObject)Instantiate(item_levelup, positionValue, Quaternion.LookRotation(new Vector3(0, 1, 0)));
        }
    }

}
