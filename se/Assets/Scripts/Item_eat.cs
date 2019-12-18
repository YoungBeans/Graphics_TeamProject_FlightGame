using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_eat : MonoBehaviour
{
    public GameObject party;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item_level")
        {
            Instantiate(party, transform.position, transform.rotation);
            scoreManager.score += 500;
        }
    }
}
