using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public GameObject bgUL;
    public GameObject bgML;
    public GameObject bgOL;

    public float bgULSpeed = 0.1f;
    public float bgMLSpeed = 0.12f;
    public float bgOLSpeed = 0.14f;

    private float bgULDirY = 0.0f;
    private float bgMLDirY = 0.0f;
    private float bgOLDirY = 0.0f;

    void Start()
    {
        
    }

    void Update()
    {
        bgULDirY += Time.deltaTime * bgULSpeed;
        bgMLDirY += Time.deltaTime * bgMLSpeed;
        bgOLDirY += Time.deltaTime * bgOLSpeed;

        bgUL.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, bgULDirY);
        bgML.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, bgMLDirY);
        bgOL.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, bgOLDirY);

    }
}
