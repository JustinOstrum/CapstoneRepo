using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FruitScript : MonoBehaviour, IPooledObject
{
    AudioManager audioManager;

    public List<Collider> colliders = new List<Collider>();

    [SerializeField]
    private GameEvent SpawnRedFruit;

    [SerializeField]
    private GameEvent SpawnBlueFruit;

    [SerializeField]
    private GameEvent SpawnYellowFruit;

    [SerializeField]
    private GameEvent SpawnRedFruitBasket;

    [SerializeField]
    private GameEvent SpawnBlueFruitBasket;

    [SerializeField]
    private GameEvent SpawnYellowFruitBasket;

    [SerializeField]
    private GameEvent IncreaseBlue;

    [SerializeField]
    private GameEvent IncreaseRed;

    [SerializeField]
    private GameEvent IncreaseYellow;

    [SerializeField]
    private GameEvent TriggerHunt;

    Rigidbody rb;

    Vector3 spawnPOS;

    public PlayerControllerScript playerScript;

    Transform thisTransform;

    public bool fullyGrown;

    public bool beingCarried;

    [SerializeField]
    int identifier = -1;

    private void Awake()
    {
        audioManager = AudioManager.instance;

        rb = GetComponent<Rigidbody>();
        thisTransform = GetComponent<Transform>();
        spawnPOS = transform.position;
    }

    private void Start()
    {
        fullyGrown = false;
    }

    public void PlayGrowSound()
    {
        audioManager.Play("FruitGrow");

        fullyGrown = true;
    }

    public void OnObjectSpawn()
    {
        fullyGrown = false;

        rb.isKinematic = false;

        if (identifier != -1)
        {
            if (identifier == 0)
            {
                gameObject.tag = "RedFruit";
            }

            if (identifier == 1)
            {
                gameObject.tag = "YellowFruit";
            }

            if (identifier == 2)
            {
                gameObject.tag = "BlueFruit";
            }
        }
    }

    private void Update()
    {
        if (beingCarried)
        {
            thisTransform.position = playerScript.carryTransform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !gameObject.CompareTag("Untagged"))
        {
            playerScript = other.gameObject.GetComponent<PlayerControllerScript>();

            if (playerScript.iscarryingFruit == false && fullyGrown)
            {
                rb.isKinematic = true;

                beingCarried = true;
            }
        }

        if (other.CompareTag("Critter") && gameObject.CompareTag("RedFruit") && beingCarried == false && fullyGrown)
        {
            CritterMoveScript critterscript = other.gameObject.GetComponent<CritterMoveScript>();

            SpawnRedFruit.Invoke();

            gameObject.tag = "Untagged";

            identifier = 0;

            rb.isKinematic = true;

            StartCoroutine(FruitEaten());
        }

        if (other.CompareTag("Critter") && gameObject.CompareTag("BlueFruit") && beingCarried == false && fullyGrown)
        {
            CritterMoveScript critterscript = other.gameObject.GetComponent<CritterMoveScript>();

            SpawnBlueFruit.Invoke();

            gameObject.tag = "Untagged";

            identifier = 2;

            rb.isKinematic = true;

            StartCoroutine(FruitEaten());

        }

        if (other.CompareTag("Critter") && gameObject.CompareTag("YellowFruit") && beingCarried == false && fullyGrown)
        {
            CritterMoveScript critterscript = other.gameObject.GetComponent<CritterMoveScript>();

            SpawnYellowFruit.Invoke();

            gameObject.tag = "Untagged";

            identifier = 1;

            rb.isKinematic = true;

            StartCoroutine(FruitEaten());

        }

        if (other.CompareTag("RedBasket") && gameObject.CompareTag("RedFruit"))
        {
            SpawnRedFruit.Invoke();
            SpawnRedFruitBasket.Invoke();
            IncreaseRed.Invoke();

            if (beingCarried)
            {
                gameObject.tag = "Untagged";
                identifier = 0;
                beingCarried = false;
                playerScript.DeliverFruit();
            }

            gameObject.SetActive(false);
        }

        if (other.CompareTag("YellowBasket") && gameObject.CompareTag("YellowFruit"))
        {
            SpawnYellowFruit.Invoke();
            SpawnYellowFruitBasket.Invoke();
            IncreaseYellow.Invoke();

            if (beingCarried)
            {
                gameObject.tag = "Untagged";
                identifier = 1;
                beingCarried = false;
                playerScript.DeliverFruit();
            }

            gameObject.SetActive(false);
        }

        if (other.CompareTag("BlueBasket") && gameObject.CompareTag("BlueFruit"))
        {
            SpawnBlueFruit.Invoke();
            SpawnBlueFruitBasket.Invoke();
            IncreaseBlue.Invoke();

            if (beingCarried)
            {
                gameObject.tag = "Untagged";
                identifier = 2;
                beingCarried = false;
                playerScript.DeliverFruit();
            }

            gameObject.SetActive(false);
        }

        if (other.CompareTag("ResetPOS"))
        {
            transform.position = spawnPOS;
        }
    }

    public void TriggerHuntEvent()
    {
        TriggerHunt.Invoke();
    }

    public IEnumerator FruitEaten()
    {
        yield return new WaitForSeconds(2f);

        gameObject.SetActive(false);
    }
}