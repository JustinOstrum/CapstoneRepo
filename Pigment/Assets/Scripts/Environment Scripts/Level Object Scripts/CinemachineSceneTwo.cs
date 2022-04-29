using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineSceneTwo : MonoBehaviour
{
    CinemachineVirtualCamera cmCam;

    public Animator pigmentAnim;

    CinemachineTrackedDolly cmDolly;

    DoorScript door;

    public CinemachineTargetGroup cmGroup;

    public float speed;

    bool canOpen = true;

    void Start()
    {
        door = FindObjectOfType<DoorScript>();

        cmCam = GetComponent<CinemachineVirtualCamera>();

        cmDolly = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTrackedDolly>();

        cmDolly.m_PathPosition = 0f;
    }

    void Update()
    {
        cmDolly.m_PathPosition += speed * Time.deltaTime; 
        
        if(cmDolly.m_PathPosition >= 25f && canOpen)
        {
            canOpen = false;

            StartCoroutine(door.DoorSwing());

            StartCoroutine(Startle());
        }
    }

    IEnumerator Startle()
    {
        yield return new WaitForSeconds(1.5f);
            pigmentAnim.SetTrigger("Shock");
    }
}
