using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform desPos;
    public Transform startPos; // 시작 지점
    public Transform endPos; // 끝 지점
    public float flatformSpeed;// 발판 속도

    private void Start()
    {
        transform.position = startPos.position;
        desPos = endPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player")) 
        {
            collision.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, desPos.position, Time.deltaTime* flatformSpeed);

        if (Vector2.Distance(transform.position, desPos.position) <= 0.01f) // 트랜스폼 포지션과 데스포지션 사이의 거리가 0.05일때 목적지 변경
        {
            if (desPos == endPos)
            { desPos = startPos; }
            else
            { desPos = endPos; }
        }
    }
}
