using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFruitScript : MonoBehaviour, IPooledObject
{
    public void OnObjectSpawn()
    {
        StartCoroutine(DeactivateFruit());
    }

    public IEnumerator DeactivateFruit()
    {
        yield return new WaitForSeconds(4f);

        gameObject.SetActive(false);
    }
}
