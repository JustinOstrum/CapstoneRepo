using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitTrailerScript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DisableFruit());
    }

    IEnumerator DisableFruit()
    {
        yield return new WaitForSeconds(4f);

        gameObject.SetActive(false);
    }

}
