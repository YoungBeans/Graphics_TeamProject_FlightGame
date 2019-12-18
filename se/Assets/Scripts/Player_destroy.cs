using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_destroy : MonoBehaviour
{
    public GameObject ParticleFXExplosion;
    public int maxHealth = 3;
    public int nowHealth;

    // Start is called before the first frame update


    void Start()
    {
        nowHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (nowHealth == 0)
            Die();
    }

    void Die()
    {
        Debug.Log("주인공 파괴");
        Instantiate(ParticleFXExplosion, this.transform.position, Quaternion.identity); //폭발 이펙트를 생성합니다
        Destroy(gameObject);

    }

    IEnumerator UnBeatTime()
    {
        int countTime = 0;

        Renderer renderer = transform.Find("Body").gameObject.GetComponent<Renderer>();

        while (countTime < 15)
        {
            if (countTime % 2 == 0)
                renderer.enabled = true;
            else
                renderer.enabled = false;
            yield return new WaitForSeconds(0.2f);
            countTime++;
        }
        renderer.enabled = true;
        GetComponent<Collider>().enabled = true;
        yield return null;
    }

    private void OnGUI()
    {
        //스타일

        GUIStyle style = new GUIStyle();

        //폰트크기

        style.fontSize = 100;
        style.normal.textColor = Color.white;

        GUILayout.BeginArea(new Rect(30, 30 , Screen.width, Screen.height));
        GUILayout.BeginVertical();
        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        GUILayout.Space(15);

        string heart = "";
        for (int i = 0; i < nowHealth; i++)
            heart += "♥";
        GUILayout.Label(heart,style);
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Enemy Missile"))
        {
            nowHealth--;
            if (nowHealth >= 1)
            {
                GetComponent<Collider>().enabled = false;
                StartCoroutine("UnBeatTime");
            }
            /*
            Debug.Log("주인공 파괴");
            Instantiate(ParticleFXExplosion, this.transform.position, Quaternion.identity); //폭발 이펙트를 생성합니다
            Destroy(gameObject);
            */
        }
    }
}
