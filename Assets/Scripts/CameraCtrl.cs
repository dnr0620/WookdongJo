using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    GameObject player;

    public float offsetX = 10;
    public float offsetY = 10;
    public float offsetZ = 10;
    private void LateUpdate()
    {
        transform.position = new Vector3(
        Mathf.Clamp(Camera.main.transform.position.x, -offsetX, offsetX),
        Mathf.Clamp(Camera.main.transform.position.y, -offsetY, offsetY),
        Mathf.Clamp(Camera.main.transform.position.z, -offsetZ, offsetZ));
    }

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = this.player.transform.position;
        
        
        

        transform.position = new Vector3(transform.position.x, playerPos.y, -10);

    }

    
}
