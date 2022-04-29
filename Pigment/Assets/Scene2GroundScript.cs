using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2GroundScript : MonoBehaviour
{
    [SerializeField]
    private GameEvent fruitHit;

    public List<GameObject> fruits = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedFruit") || other.CompareTag("YellowFruit") || other.CompareTag("BlueFruit"))
        {
            IdentifyFruit(other.gameObject);
        }
    }

    public void IdentifyFruit(GameObject fruit)
    {
        if (!fruits.Contains(fruit))
        {
            fruits.Add(fruit);
            fruitHit.Invoke();
        }
    }

    public void ClearFruitList(GameObject fruit)
    {
        fruits.Remove(fruit);        
    }
}
