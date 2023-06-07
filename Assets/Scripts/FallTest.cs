using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTest : MonoBehaviour
{
    public float destroyDelay = 2f;     // 발판이 파괴되는 지연 시간
    public float respawnDelay = 2f;     // 파괴된 발판이 재생성되는 지연 시간
    public GameObject platformPrefab;   // 재생성될 발판의 프리팹

    private bool isDestroyed = false;   // 발판이 파괴되었는지 여부
    private float destroyTime = 0f;     // 발판이 파괴된 시간
    private Vector3 initialPosition;    // 발판의 초기 위치
    private Quaternion initialRotation; // 발판의 초기 회전값

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isDestroyed)
        {
            isDestroyed = true;
            destroyTime = Time.time;
            Destroy(gameObject, destroyDelay);  // 일정 시간 후 발판 파괴
        }
    }

    private void Update()
    {
        if (isDestroyed && Time.time >= destroyTime + respawnDelay)
        {
            isDestroyed = false;
            GameObject newPlatform = Instantiate(platformPrefab, initialPosition, initialRotation);  // 발판 재생성
            newPlatform.GetComponent<FallTest>().Initialize(respawnDelay);  // 발판 컨트롤러 초기화
        }
    }

    public void Initialize(float delay)
    {
        isDestroyed = false;
        destroyTime = 0f;
        respawnDelay = delay;
    }
}