using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    public ParticleSystem ps;    

    public void ActivateParticleSystem()
    {
        ps.Play();
    }
}
