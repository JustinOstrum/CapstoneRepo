using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerScript : MonoBehaviour
{
    public GameManager gm;

    public FruitSpawnScript fruitSpawner;

    public CritterMoveScript critterMove;

    public GameObject redBasket;
    public GameObject yellowBasket;
    public GameObject blueBasket;

    PlayerNavigationScript playerMoveScript;

    public Animator anim;

    public Transform carryTransform;

    float originalSpeed;

    public bool iscarryingFruit = false;

    private void Start()
    {
        playerMoveScript = GetComponent<PlayerNavigationScript>();

        originalSpeed = playerMoveScript.playerNavMeshAgent.speed;        
    }

    public void StartSayHi()
    {
        StartCoroutine(SayHi());
    }

    IEnumerator SayHi()
    {
        anim.SetBool("isWaving", true);        

        yield return new WaitForSeconds(2f);

        anim.SetBool("isWaving", false);
    }

    private void Update()
    {
        if (!iscarryingFruit)
        {
            anim.SetBool("isRunning", playerMoveScript.isRunning);
        }
    }

    public void CarryingFruit()
    {
        iscarryingFruit = true;

        anim.SetBool("isRunning", false);
        anim.SetBool("isCarrying", true);

        playerMoveScript.playerNavMeshAgent.speed *= .75f;
    }

    public void DeliverFruit()
    {
        iscarryingFruit = false;

        anim.SetBool("isRunning", true);
        anim.SetBool("isCarrying", false);

        playerMoveScript.playerNavMeshAgent.speed = originalSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedFruit") || other.CompareTag("YellowFruit") || other.CompareTag("BlueFruit"))
        {
            FruitScript fruit = other.gameObject.GetComponent<FruitScript>();

            if (!iscarryingFruit)
            {
                fruitSpawner.RemoveFruitFromList(other.gameObject);

                if (fruit.fullyGrown)
                {
                    CarryingFruit();
                }

                if (other.gameObject == critterMove.targetFruit)
                {
                    critterMove.MissedFruit();
                }
            }
        }
    }
}