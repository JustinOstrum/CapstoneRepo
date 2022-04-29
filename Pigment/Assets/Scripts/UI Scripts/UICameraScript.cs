using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICameraScript : MonoBehaviour
{
    public GameManager gameManager;

    public WaveScript wave;

    public Camera cam;

    public LayerMask mask;

    public LayerMask mask2;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            //RaycastHit is a variable to store collision information
            RaycastHit hit;

            //Physics.Raycast figures out if there are any colliders that have the same
            // mask and are within the distance defined, if so, that data is returned
            // via the hit variable
            if (Physics.Raycast(ray, out hit, 100f, mask))
            {
                wave.SetWin();

                StartCoroutine(WaitForCheer());
            }

            if (Physics.Raycast(ray, out hit, 100f, mask2))
            {
                wave.SetPoke();             
            }
        }
    }

    public IEnumerator WaitForCheer()
    {
        yield return new WaitForSeconds(3f);
        
        gameManager.LoadNextScene();

    }
}
