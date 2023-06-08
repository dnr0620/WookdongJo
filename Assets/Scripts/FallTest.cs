using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTest : MonoBehaviour
{
    public float destroyDelay = 2f;     // 발판이 파괴되는 지연 시간
    public float respawnDelay = 5f;     // 파괴된 발판이 재생성되는 지연 시간
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
            Invoke("DestroyPlatform", destroyDelay);  // 일정 시간 후 발판 파괴
        }
    }

    private void DestroyPlatform()
    {
        gameObject.SetActive(false);  // 발판 비활성화
        Invoke("RespawnPlatform", respawnDelay);  // 일정 시간 후 발판 재생성
    }

    private void RespawnPlatform()
    {
        gameObject.SetActive(true);  // 발판 활성화
        isDestroyed = false;  // 발판 상태 재설정
    }
}