using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearPlatform : MonoBehaviour
{
    float fallTime = 0.5f;
    float destroyTime = 2f;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            PlatformManager.Instance.StartCoroutine("spawnPlatform", new Vector2(transform.position.x, transform.position.y));
            Invoke("FallPlatform", fallTime);
            Destroy(gameObject, destroyTime);
        }
    }

    void FallPlatform()
    {
        rb.isKinematic = false;
    }
}
