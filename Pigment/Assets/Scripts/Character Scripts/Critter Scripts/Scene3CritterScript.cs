using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Scene3CritterScript : MonoBehaviour
{
    ObjectPoolingScript objectPooler;

    AudioManager audioManager;

    public List<GameObject> targetFruits = new List<GameObject>();

    public TableScript table;

    NavMeshAgent navAgent;

    [SerializeField]
    GameObject targetFruit;

    public Vector3 destination;

    public float wait;

    public GameObject home;

    public Animator anim;

    public Transform redSpawn;
    public Transform blueSpawn;
    public Transform yellowSpawn;

    bool eating = false;
    bool hunting = false;
    public bool shooed;

    bool targetAvailable;

    float huntTimer;

    bool makeSound;

    void Start()
    {
        audioManager = AudioManager.instance;

        makeSound = true;
        
        navAgent = GetComponent<NavMeshAgent>();

        objectPooler = ObjectPoolingScript.Instance;

        destination = navAgent.destination;

        targetAvailable = true;
    }

    void Update()
    {
        if (targetFruit != null)
        {
            huntTimer += Time.deltaTime;

            if (targetFruit.activeInHierarchy && !shooed)
            {
                destination = targetFruit.transform.position;
            }

            else
            {
                if (!eating)
                {
                    destination = home.transform.position;
                }
            }

            if (!targetFruit.activeInHierarchy)
            {
                targetFruits.Remove(targetFruit);
                targetFruit = null;
            }
            
            if(huntTimer > 6f && targetFruits.Count != 0 && targetAvailable)
            {
                huntTimer = 0;

                targetAvailable = false;

                targetFruits.Remove(targetFruit);
                targetFruit = null;

                StartCoroutine(FindTargetFruit());
            }
        }

        if(targetFruit == null)
        {
            destination = home.transform.position;
        }

        navAgent.destination = destination;
    }

    public void ActivateGetNewTarget()
    {
        GetNewTarget(GetTargetFruit());
    }

    public GameObject GetTargetFruit()
    {
        targetFruit = table.targetFruit;

        huntTimer = 0;

        return targetFruit;
    }

    public void GetNewTarget(GameObject target)
    {
        if (!targetFruits.Contains(target))
        {
            targetFruits.Add(target);
        }

        if (hunting == false)
        {
            hunting = true;

            StartCoroutine(FindTargetFruit());
        }
    }

    public IEnumerator FindTargetFruit()
    {
        navAgent.isStopped = true;
        anim.SetBool("isRunning", false);

        yield return new WaitForSeconds(.5f);

        if (targetFruits.Count != 0)
        {
            targetFruit = targetFruits[targetFruits.Count - 1];
        }

        else if(targetFruits.Count == 0)
        {
            destination = home.transform.position;
        }

        navAgent.isStopped = false;
        anim.SetBool("isRunning", true);
        targetAvailable = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CritterHome"))
        {
            shooed = false;
            huntTimer = 0;
        }

        if (other.CompareTag("YellowFruit"))
        {
            hunting = false;
            huntTimer = 0;

            if (targetFruits.Contains(other.gameObject))
            {
                targetFruits.Remove(other.gameObject);
            }

            objectPooler.SpawnFromPool(other.tag, yellowSpawn.position, Quaternion.identity);
            eating = true;

            navAgent.isStopped = true;

            if (makeSound)
            {
                makeSound = false;

                audioManager.Play("CritterEating");
            }

            StartCoroutine(EatTheFruit());

            anim.SetBool("isRunning", false);

            anim.SetBool("isEating", true);
        }

        if (other.CompareTag("BlueFruit"))
        {
            hunting = false;
            huntTimer = 0;

            if (targetFruits.Contains(other.gameObject))
            {
                targetFruits.Remove(other.gameObject);
            }

            objectPooler.SpawnFromPool(other.tag, blueSpawn.position, Quaternion.identity);
            eating = true;

            navAgent.isStopped = true;

            if (makeSound)
            {
                makeSound = false;

                audioManager.Play("CritterEating");
            }

            StartCoroutine(EatTheFruit());

            anim.SetBool("isRunning", false);

            anim.SetBool("isEating", true);
        }

        if (other.CompareTag("RedFruit"))
        {
            hunting = false;
            huntTimer = 0;

            if (targetFruits.Contains(other.gameObject))
            {
                targetFruits.Remove(other.gameObject);
            }

            objectPooler.SpawnFromPool(other.tag, redSpawn.position, Quaternion.identity);
            eating = true;

            navAgent.isStopped = true;

            if (makeSound)
            {
                makeSound = false;

                audioManager.Play("CritterEating");
            }

            StartCoroutine(EatTheFruit());

            anim.SetBool("isRunning", false);
        
            anim.SetBool("isEating", true);
        }
    }

    public IEnumerator EatTheFruit()
    {
        yield return new WaitForSeconds(2f);

        navAgent.isStopped = false;

        eating = false;

        makeSound = true;

        anim.SetBool("isRunning", true);

        anim.SetBool("isEating", false);

        if(targetFruits.Count != 0)
        {
            StartCoroutine(FindTargetFruit());
        }
    }
}
