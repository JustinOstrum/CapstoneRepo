using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SetPoke()
    {
        anim.SetTrigger("Poked");           
    }

    public void SetWin()
    {
        anim.SetBool("Completed", true);
    }
}
