using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTest : MonoBehaviour
{
    public float destroyDelay = 2f;     // ������ �ı��Ǵ� ���� �ð�
    public float respawnDelay = 5f;     // �ı��� ������ ������Ǵ� ���� �ð�
    public GameObject platformPrefab;   // ������� ������ ������

    private bool isDestroyed = false;   // ������ �ı��Ǿ����� ����
    private float destroyTime = 0f;     // ������ �ı��� �ð�
    private Vector3 initialPosition;    // ������ �ʱ� ��ġ
    private Quaternion initialRotation; // ������ �ʱ� ȸ����

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
            Invoke("DestroyPlatform", destroyDelay);  // ���� �ð� �� ���� �ı�
        }
    }

    private void DestroyPlatform()
    {
        gameObject.SetActive(false);  // ���� ��Ȱ��ȭ
        Invoke("RespawnPlatform", respawnDelay);  // ���� �ð� �� ���� �����
    }

    private void RespawnPlatform()
    {
        gameObject.SetActive(true);  // ���� Ȱ��ȭ
        isDestroyed = false;  // ���� ���� �缳��
    }
}