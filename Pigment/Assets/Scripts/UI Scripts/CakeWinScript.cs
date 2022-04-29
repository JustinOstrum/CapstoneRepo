using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeWinScript : MonoBehaviour
{    
    void Update()
    {
        this.transform.Rotate(0, transform.position.y * 4f * Time.deltaTime , 0);
        
    }
}
