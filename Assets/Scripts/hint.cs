using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class hint : MonoBehaviour
{
    public CinemachineVirtualCamera vcCamera;
    public GameObject player, spike;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            vcCamera.Follow = player.transform;

        }
        if (Input.GetKeyDown(KeyCode.O))
        {

            vcCamera.Follow = spike.transform;

        }
    }
}
