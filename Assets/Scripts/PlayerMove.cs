using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] public float maxSpeed, runSpeed; // 걷기, 달리기 속도
    public float jumpPower;
    public float speed; // 게임 적용 속도
    public float moveX; // 달릴때 x좌표 움직임 적용

    public bool inputEnabled = true;



    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    //Animator animator;

    public void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (inputEnabled)
        {
            // Input handling code goes here
            // Jump
            if (Input.GetButtonDown("Jump") && !anim.GetBool("IsJumping"))
            {
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                anim.SetBool("IsJumping", true);
            }

            // Stop Speed
            //if (Input.GetButtonUp("Horizontal"))
            // {
            //     rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.normalized.y);
            //  }

            // Direction Sprite
            if (Input.GetButton("Horizontal"))
                spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

            // Animation 
            if (Mathf.Abs(rigid.velocity.x) < 0.3)
                anim.SetBool("IsWalking", false);
            else
                anim.SetBool("IsWalking", true);
            // this.animator.speed = speedx / 2.0f;
            Movement();
        }

    }

    public void FixedUpdate()
    {
        if (inputEnabled) { 
            // Move Speed
            float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        // Max Speed
        if (rigid.velocity.x > maxSpeed) // Right Max Speed
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1)) // Left Max Speed
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

        // Landing Platform
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));

            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f)
                    anim.SetBool("IsJumping", false);
            }
        }
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            // Attack
            if (rigid.velocity.y < 0 && transform.position.y > collision.transform.position.y)
                OnDamaged(collision.transform.position);
            else // Damaged
                OnDamaged(collision.transform.position);
        }
    }

 




    public void OnDamaged(Vector2 targetPos)
    {

        // Health Down
        gameManager.HealthDown();


        // View Alpha
        spriteRenderer.color = new Color(1, 1, 1, 1f);

        // Reaction Force
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 1) * 10, ForceMode2D.Impulse);

        // Animation
        anim.SetTrigger("doDamaged");

        // OnDie함수 호출
        Invoke("OnDie", 0.01f);
    }



    void Movement()
    {
        if (Input.GetKey(KeyCode.X))
        { 
            speed = runSpeed;
            runSpeed = maxSpeed * 1.5f;
            moveX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

            transform.Translate(moveX, 0, 0);
        }
        
        else
        {
            speed = maxSpeed;

        }
    }


    public void OnDie()
    {
        // Change Layer - PlayerDamaged (Immortal Active)
        gameObject.layer = 11;

        // 모든 키 비활성화
        inputEnabled = false;

        // Sprite Alpha
        // spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        // Sprite Flip Y
        //spriteRenderer.flipY = true;


        // Collider.Disable
        // BoxCollider2D.enabled = false;

        // Die Effect Jump
        rigid.AddForce(Vector2.up * 1, ForceMode2D.Impulse);

        Invoke("OffDamaged",3);


    }

    void OffDamaged()
    {
        // Player의 태그 Player로 변경
        gameObject.layer = 10;

        // 투명도 
        spriteRenderer.color = new Color(1, 1, 1, 1);

        // 부활 좌표
        transform.position = new Vector3(1, 0, 0);

        // 모든 키 활성화
        inputEnabled = true;

    }



}
