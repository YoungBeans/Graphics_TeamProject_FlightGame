using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Fire2 : MonoBehaviour
{
    public GameObject PlayerBomb;    // 복제할 폭탄 오브젝트
    public Transform BombLocation;   // 폭탄이 발사될 위치
    public float FireDelay;             // 폭탄 발사 속도(미사일이 날라가는 속도x)
    private bool FireState;             // 폭탄 발사 속도를 제어할 변수
    public int count;
    public int BombMaxPool;          // 메모리 풀에 저장할 미사일 개수
    private MemoryPool MPool;           // 메모리 풀
    private GameObject[] BombArray;  // 메모리 풀과 연동하여 사용할 미사일 배열


    // 게임이 종료되면 자동으로 호출되는 함수
    private void OnApplicationQuit()
    {
        // 메모리 풀을 비웁니다.
        MPool.Dispose();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "item_bomb")
        {
            MPool.Create(PlayerBomb, ++count);
        }
    }
    void Start()
    {
        // 처음에 폭탄을 발사할 수 있도록 제어변수를 true로 설정
        FireState = true;

        // 메모리 풀을 초기화합니다.
        MPool = new MemoryPool();
        // PlayerMissile을 MissileMaxPool만큼 생성합니다.
        MPool.Create(PlayerBomb, BombMaxPool);
        // 배열도 초기화 합니다.(이때 모든 값은 null이 됩니다.)
        BombArray = new GameObject[BombMaxPool];

    }

    void Update()
    {
        // 매 프레임마다 미사일발사 함수를 체크한다.
        playerFire2();
    }


    private void OnGUI()
    {
        //스타일

        GUIStyle style = new GUIStyle();

        //폰트크기

        style.fontSize = 60;
        style.normal.textColor = Color.white;

        GUILayout.BeginArea(new Rect(30, 1800, Screen.width, Screen.height));
        GUILayout.BeginVertical();
        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        GUILayout.Space(15);

        string bomb = "Bomb : ";
        bomb += count.ToString();
        GUILayout.Label(bomb, style);
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }


    // 미사일을 발사하는 함수
    private void playerFire2()
    {
        // 제어변수가 true일때만 발동
        if (FireState)
        {
            // 키보드의 "S"를 누르면
            if (Input.GetKey(KeyCode.S))
            {
                if (count > 0)
                {
                    count--;
                }
                // 코루틴 "FireCycleControl"이 실행되며
                StartCoroutine(FireCycleControl());

                // 폭탄 풀에서 발사되지 않은 미사일을 찾아서 발사합니다.
                for (int i = 0; i < BombMaxPool; i++)
                {
                    // 만약 폭탄배열[i]가 비어있다면
                    if (BombArray[i] == null)
                    {
                        // 메모리풀에서 폭탄을 가져온다.
                        BombArray[i] = MPool.NewItem();
                        // 해당 폭탄의 위치를 미사일 발사지점으로 맞춘다.
                        BombArray[i].transform.position = BombLocation.transform.position;
                        // 발사 후에 for문을 바로 빠져나간다.

                        break;
                    }
                }
            }
        }

        // 폭탄이 발사될때마다 미사일을 메모리풀로 돌려보내는 것을 체크한다.
        for (int i = 0; i < BombMaxPool; i++)
        {
            // 만약 폭탄[i]가 활성화 되어있다면
            if (BombArray[i])
            {
                // 폭탄[i]의 Collider가 비활성 되었다면
                if (BombArray[i].GetComponent<Collider>().enabled == false)
                {
                    // 다시 Collider를 활성화 시키고
                    BombArray[i].GetComponent<Collider>().enabled = true;
                    // 폭탄을 메모리로 돌려보내고
                    MPool.RemoveItem(BombArray[i]);
                    // 가리키는 배열의 해당 항목도 null(값 없음)로 만든다.
                    BombArray[i] = null;
                }
            }
        }
    }

    // 코루틴 함수
    IEnumerator FireCycleControl()
    {
        // 처음에 FireState를 false로 만들고
        FireState = false;
        // FireDelay초 후에
        yield return new WaitForSeconds(FireDelay);
        // FireState를 true로 만든다.
        FireState = true;
    }
}