using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMove : MonoBehaviour
{
    public float MissileSpeed = 350f;
    public float DestroyMissileYpos = -37f;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(0, -1, 0) * MissileSpeed * Time.deltaTime);
        /*
        if (this.transform.position.y < DestroyMissileYpos)
        {
           this.GetComponent<Collider>().enabled = false;
        }*/
        if (transform.position.y < -1000f | transform.position.y > 1000f | transform.position.x > 600f | transform.position.x < -600f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //this.GetComponent<Collider>().enabled = false;
            Destroy(gameObject);
        }
    }
}
