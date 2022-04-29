using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritterPokeScript : MonoBehaviour
{
    AudioManager audioManager;

    Scene3CritterScript critter;

    public LayerMask mask;

    public Camera cam;

    public GameObject home;

    private void Awake()
    {
        audioManager = AudioManager.instance;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Debug.Log(Screen.width);
            Debug.Log(Screen.height);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, mask))
            {
                critter = hit.collider.gameObject.GetComponent<Scene3CritterScript>();

                audioManager.Play("CritterWhine");

                critter.shooed = true;
                critter.destination = home.transform.position;
            }            
        }
    }
}
