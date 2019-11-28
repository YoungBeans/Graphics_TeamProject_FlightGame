using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileUp : MonoBehaviour
{
    public float MissileSpeed = 30f;
    public float DestroyMissileYpos = -37f;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(0, 1, 0) * MissileSpeed * Time.deltaTime);
        /*
        if (this.transform.position.y < DestroyMissileYpos)
        {
           this.GetComponent<Collider>().enabled = false;
        }*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("기체충돌");
            this.GetComponent<Collider>().enabled = false;
        }
    }
}
