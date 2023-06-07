using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTest : MonoBehaviour
{
    public float destroyDelay = 2f;     // ������ �ı��Ǵ� ���� �ð�
    public float respawnDelay = 2f;     // �ı��� ������ ������Ǵ� ���� �ð�
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
            Destroy(gameObject, destroyDelay);  // ���� �ð� �� ���� �ı�
        }
    }

    private void Update()
    {
        if (isDestroyed && Time.time >= destroyTime + respawnDelay)
        {
            isDestroyed = false;
            GameObject newPlatform = Instantiate(platformPrefab, initialPosition, initialRotation);  // ���� �����
            newPlatform.GetComponent<FallTest>().Initialize(respawnDelay);  // ���� ��Ʈ�ѷ� �ʱ�ȭ
        }
    }

    public void Initialize(float delay)
    {
        isDestroyed = false;
        destroyTime = 0f;
        respawnDelay = delay;
    }
}