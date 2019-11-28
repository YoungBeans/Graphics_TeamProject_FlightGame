using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{

    float speed = 1.5f;
    int rand;
    public GameObject player;
    public Texture[] item = new Texture[3];

    void Start()
    {

        player = GameObject.Find("Player");
        item[0] = Resources.Load("Texture/itemS") as Texture;
        item[1] = Resources.Load("Texture/itemM") as Texture;
        rand = Random.Range(1, 3);
        itemChoice(rand);
    }

    void Update()
    {
        float moveAmount = speed * Time.deltaTime;
        transform.Translate(0, 0, moveAmount * 1);

        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }
    }

    void itemChoice(int choice)
    {

        switch (choice)
        {
            case 1:
                
                GetComponent<Renderer>().material.mainTexture = item[0];
                break;

            case 2:
                GetComponent<Renderer>().material.mainTexture = item[1];
                break;

            case 3:
                GetComponent<Renderer>().material.mainTexture = item[1];
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (rand == 1)
            {
                player.SendMessage("itemS");
            }
            if (rand == 2)
            {
                player.SendMessage("itemM");
            }
            Destroy(this.gameObject);
        }

    }
}
