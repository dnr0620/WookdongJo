using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerMove playerMove;
    public int totalPoint;
    public int stagePoint;
    public int stageIndex;
    // public int health;
    public int deadCount;
    public PlayerMove player;

    public Image[] UIhealth;
    public Text UIPoint;
    public Text UIStage;
    public GameObject RestartBtn;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
  


    public void HealthDown()
    {
        /*if (health > 0)
        {*/
            //health--;
            deadCount++;
            // Result UI
           /* Debug.Log("�׾����ϴ�! 3�� �� ��Ȱ�մϴ�!");
            Debug.Log("������� "+deadCount+"�� �׾����ϴ�!");
*/

            //UIhealth[health].color = new Color(1, 1, 1, 0.2);

            /* }
             else
             {

                 // Player Die Effect
                 player.OnDie();



                 // Retry Button UI
                 // UIRestartBtn.SetActive(true);*/

        
    }

 /*   void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           // playerMove = collision.GetComponent<PlayerMove>();

            // ���� �� ��� ó��
            playerMove.OnDie();

        *//*collision.attachedRigidbody.velocity = Vector2.zero;
        collision.transform.position = new Vector3(0, 0, -1);*//*

        }
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
