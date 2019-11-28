using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_drop : MonoBehaviour
{

    GameObject item_levelup;
    GameObject item_new;
    Vector3 positionValue;

    float Speed = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            item_drop();
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * 5f * Time.deltaTime);
    }

    void item_drop()
    {
        item_levelup = Resources.Load("usingAssets/Item_levelup") as GameObject;
        positionValue = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y);
        item_new = (GameObject)Instantiate(item_levelup, positionValue, Quaternion.LookRotation(gameObject.transform.forward));
    }

}
