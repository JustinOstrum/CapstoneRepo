using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour
{
    Renderer meshRend;

    Animator anim;

    private void Start()
    {
        meshRend = GetComponent<MeshRenderer>();

        anim = GetComponent<Animator>();

        meshRend.enabled = false;
    }

    public IEnumerator SwingAxe(bool logCanSpawn)
    {
        if (!logCanSpawn)
        {
            meshRend.enabled = true;

            yield return new WaitForSeconds(1f);

            anim.SetTrigger("Chop");

            yield return new WaitForSeconds(2f);


            anim.ResetTrigger("Chop");

            meshRend.enabled = false;
            
            logCanSpawn = true;
        }
    }
}