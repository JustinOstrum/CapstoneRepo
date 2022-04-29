using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CritterJumpScript : MonoBehaviour
{
    AudioManager audioManager;

    public Scene2GroundScript ground;

    NavMeshAgent navAgent;

    public GameObject targetFruit;

    Vector3 destination;

    public GameObject home;

    public Animator anim;

    bool makeSound = true;

    public Transform redSpawn;
    public Transform blueSpawn;
    public Transform yellowSpawn;

    private void Awake()
    {
        audioManager = AudioManager.instance;
    }

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();

        destination = navAgent.destination;

        targetFruit = home;

        anim.SetBool("isRunning", true);
    }

    void Update()
    {
        destination = targetFruit.transform.position;
        navAgent.destination = destination;

        if (!targetFruit.activeInHierarchy)
        {
            targetFruit = home;
        }
    }

    public GameObject GetTargetFruit()
    {
        if (ground.fruits.Count != 0)
        {
            targetFruit = ground.fruits[Random.Range(0, ground.fruits.Count - 1)];
        }

        else
        {
            targetFruit = home;
        }

        return targetFruit;
    }

    public void ActivateGetNewTarget()
    {
        GetNewTarget(GetTargetFruit());
    }

    public void GetNewTarget(GameObject target)
    {
        anim.SetBool("isEating", false);
        anim.SetBool("isRunning", true);
        targetFruit = target;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("YellowFruit"))
        {
            ground.ClearFruitList(other.gameObject);            
            StartCoroutine(EatTheFruit());
        }

        if (other.CompareTag("BlueFruit"))
        {
            ground.ClearFruitList(other.gameObject);
            StartCoroutine(EatTheFruit());
        }

        if (other.CompareTag("RedFruit"))
        {
            ground.ClearFruitList(other.gameObject);
            StartCoroutine(EatTheFruit());
        }
    }

    public IEnumerator EatTheFruit()
    {
        anim.SetBool("isRunning", false);

        anim.SetBool("isEating", true);

        navAgent.isStopped = true;

        if (makeSound)
        {
            makeSound = false;
            audioManager.Play("CritterEating");            
        }

        yield return new WaitForSeconds(2f);

        navAgent.isStopped = false;
        makeSound = true;

        ActivateGetNewTarget();
    }
}