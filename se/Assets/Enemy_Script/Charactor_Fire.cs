using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactor_Fire : MonoBehaviour
{
    private const float DISTANCE_RECOG = 4.8f;    // 적이 미사일을 발사하는 절대 거리

    public GameObject MissileObject;        // 적이 발사하는 미사일
    public Transform MissileLocation;       // 적의 미사일이 발사되는 위치
    public int MissileMaximumPool;          // 적의 미사일 오브젝트가 생성되는 최대 개수
    public float FireRateTime;              // 적의 미사일이 발사되는 속도
    public GameObject ParticleFXExplosion;

    private GameObject[] Missiles;          // 미사일 오브젝트를 생성하여 저장할 배열
    private MemoryPool MPool;               // 미사일 오브젝트를 관리할 메모리풀
    private GameObject Player;              // 플레이어의 카메라
    private bool FireEnabled;               // 미사일 발사 허용 여부
    private bool FireState;                 // 미사일이 발사되고 있는지에 대한 여부

    // 처음 실행 시 작동
    void Start()
    {
        MPool = new MemoryPool();
        MPool.Create(MissileObject, MissileMaximumPool);
        Missiles = new GameObject[MissileMaximumPool];
        Player = GameObject.Find("Main Camera");
        FireEnabled = false;

        // 처음에는 미사일이 발사되고 있지 않더라고 다음번 발사를 위해 true
        FireState = false;
    }

    // 종료시 작동
     void OnApplicationQuit()
    {
        // 메모리풀을 비움
        MPool.Dispose();
    }

    void OnDestroy()
    {
        // 메모리풀을 비움
        MPool.Dispose();
    }

    // 충돌 감지 메소드
    void OnTriggerEnter(Collider collider)
    {
        // 만약 플레이어의 미사일과 충돌하였다면
        if (collider.GetComponent<Collider>().CompareTag("Player Missile"))
        {
            // 메모리풀을 정리한다.
            for (int i = 0; i < MissileMaximumPool; i++)
            {
                if (Missiles[i])
                {
                    if (Missiles[i].GetComponent<Collider>().enabled == false)
                    {
                        Missiles[i].GetComponent<Collider>().enabled = true;
                        MPool.RemoveItem(Missiles[i]);
                        Missiles[i] = null;
                    }
                }
            }
            // 자기 자신을 비활성화 한다.
            gameObject.SetActive(false);
            Instantiate(ParticleFXExplosion, this.transform.position, Quaternion.identity); //폭발 이펙트를 생성합니다
            Destroy(gameObject);
        }
    }

    // 매 프레임마다 실행
    void Update()
    {
        DistanceChecker();
        MissileFire();
    }
    
    void DistanceChecker()
    {

        if ((this.transform.position.y < 1000f)& (this.transform.position.y > -1000f) & (this.transform.position.x < 600f) & (this.transform.position.x > -600f))
        {
            // 미사일 발사 허용
            FireEnabled = true;
        }
        else
        {
            // 미사일 발사 불허용
            FireEnabled = false;
        }

    }

    // 미사일 발사 메소드
    void MissileFire()
    {
        // 미사일 발사가 허용 된다면
        if (FireEnabled)
        {
            // 지금 미사일을 발사하고 있지 않다면 발사
            if (!FireState)
            {
                StartCoroutine(FireCycleControl());
                for (int i = 0; i < MissileMaximumPool; i++)
                {
                    if (Missiles[i] == null)
                    {
                        Missiles[i] = MPool.NewItem();
                        Missiles[i].transform.position = MissileLocation.transform.position;
                        break;
                    }
                }
            }

            // 발사 이후 객체 회수
            for (int i = 0; i < MissileMaximumPool; i++)
            {
                if (Missiles[i])
                {
                    if (Missiles[i].transform.position.y < -1000f | Missiles[i].transform.position.y > 1000f | Missiles[i].transform.position.x > 600f | Missiles[i].transform.position.x < -600f)
                    {
                        Missiles[i].GetComponent<Collider>().enabled = false;
                    }
                    if (Missiles[i].GetComponent<Collider>().enabled == false)
                    {
                        Missiles[i].GetComponent<Collider>().enabled = true;
                        MPool.RemoveItem(Missiles[i]);
                        Missiles[i] = null;
                    }
                }
            }
        }
    }


    // 미사일 발사 제어를 위한 코루틴 메소드
    IEnumerator FireCycleControl()
    {
        FireState = true;
        yield return new WaitForSeconds(FireRateTime);
        FireState = false;
    }
}