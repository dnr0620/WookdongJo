using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform desPos;
    public Transform startPos; // ���� ����
    public Transform endPos; // �� ����
    public float flatformSpeed;// ���� �ӵ�

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

        if (Vector2.Distance(transform.position, desPos.position) <= 0.01f) // Ʈ������ �����ǰ� ���������� ������ �Ÿ��� 0.05�϶� ������ ����
        {
            if (desPos == endPos)
            { desPos = startPos; }
            else
            { desPos = endPos; }
        }
    }
}
