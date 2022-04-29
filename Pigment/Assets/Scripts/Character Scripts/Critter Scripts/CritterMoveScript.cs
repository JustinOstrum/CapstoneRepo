using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CritterMoveScript : MonoBehaviour
{
    NavMeshAgent navAgent;

    AudioManager audioManager;

    public FruitSpawnScript fruitSpawnScript;

    public GameObject targetFruit;

    Transform targetTransform;

    Vector3 destination;

    public List<GameObject> targets = new List<GameObject>();

    public Animator anim;

    public bool hasTarget;
    public bool isShooed;
    bool eating;
    bool makeSound = true;

    public Transform home;

    float distanceToHome;

    private void Start()
    {
        audioManager = AudioManager.instance;

        hasTarget = false;
        isShooed = false;

        navAgent = GetComponent<NavMeshAgent>();

        destination = navAgent.destination;

        anim.SetBool("isRunning", true);        
    }

    private void Update()
    {
        distanceToHome = Vector3.Distance(transform.position, home.position);
        
        if (navAgent.remainingDistance < navAgent.stoppingDistance)
        {
            anim.SetBool("isRunning", false);
        }

        else if(navAgent.remainingDistance > navAgent.stoppingDistance && !eating)
        {
            anim.SetBool("isRunning", true);
        }

        if (hasTarget && !isShooed)
        {
            if (targetFruit.activeInHierarchy)
            {
                targetTransform = targetFruit.transform;
            }

            else
            {
                hasTarget = false;
                targetTransform = gameObject.transform;
            }
        }

        else if (isShooed)
        {
            targetTransform = home;
        }
        
        if(targetFruit == null)
        {
            targetTransform = home;
        }
        
        destination = targetTransform.position;
        navAgent.destination = destination;
    }

    public IEnumerator GetNewTarget()
    {
        if (!hasTarget && !eating && !isShooed)
        {            
            navAgent.isStopped = true;

            foreach (GameObject _fruit in fruitSpawnScript.fruitsSpawned)
            {
                if (_fruit.activeInHierarchy && _fruit.GetComponent<FruitScript>().fullyGrown)
                {
                    targets.Add(_fruit);
                }
            }

            if (targets.Count != 0)
            {
                targetFruit = targets[Random.Range(0, targets.Count - 1)];
            }

            yield return new WaitForSeconds(.5f);

            navAgent.isStopped = false;
            
            hasTarget = true;            

            targets.Clear();
        }

        Debug.Log("GettingTarget");
    }

    private void OnTriggerEnter(Collider other)
    {
        var fruitScript = other.GetComponent<FruitScript>();

        if (fruitScript && fruitScript.beingCarried == false && fruitScript.fullyGrown)
        {
            StartCoroutine(EatFruit());

            hasTarget = false;

            if (fruitSpawnScript.fruitsSpawned.Contains(other.gameObject))
            {
                fruitSpawnScript.fruitsSpawned.Remove(other.gameObject);
            }

            if (targets.Contains(other.gameObject))
            {
                targets.Remove(other.gameObject);
            }
        }

        if (other.CompareTag("Player"))
        {
            StartCoroutine(RunAway());
        }
    }

    public IEnumerator EatFruit()
    {
        eating = true;
        anim.SetBool("isRunning", false);
        anim.SetBool("isEating", true);

        if (makeSound)
        {
            makeSound = false;
            audioManager.Play("CritterEating");
        }

        yield return new WaitForSeconds(.1f);

        navAgent.isStopped = true;

        yield return new WaitForSeconds(2f);

        eating = false;
        anim.SetBool("isRunning", true);
        anim.SetBool("isEating", false);
        navAgent.isStopped = false;
        makeSound = true;

        StartCoroutine(GetNewTarget());
    }

    public IEnumerator RunAway()
    {
        isShooed = true;
        hasTarget = false;

        audioManager.Play("CritterWhine");        

        yield return new WaitUntil(() => distanceToHome <= 1f);

        audioManager.Play("CritterCry");

        isShooed = false;
    }

    public void MissedFruit()
    {
        hasTarget = false;

        StartCoroutine(GetNewTarget());
    }

    public void LeaveHome()
    {
        StartCoroutine(GetNewTarget());             
    }

    public void LevelComplete()
    {
        navAgent.isStopped = true;
    }
}
