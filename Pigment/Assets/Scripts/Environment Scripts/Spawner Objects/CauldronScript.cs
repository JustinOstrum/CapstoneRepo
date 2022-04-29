using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//These states allow the cauldron to discern what fruit has been put in and what colours to show
//public enum States { Empty, Blue, Yellow, Red, GreenBlueYellow, GreenYellowBlue, PurpleRedBlue, PurpleBlueRed, OrangeYellowRed, OrangeRedYellow, Brewing }

//ensures that the object has a collider
[RequireComponent(typeof(Collider))]

public class CauldronScript : MonoBehaviour
{
    public States state;

    public List<GameObject> fruitTokens = new List<GameObject>();

    public List<GameObject> colourPanels = new List<GameObject>();

    //references the object pooler
    ObjectPoolingScript objectPooler;

    //the transform of the spawn object
    public Transform potionSpawn;

    //vaiables for how long it takes to make a potion
    public float brewTime;
    public float brewTimeCounter;

    //checks for if the cauldron has a fruit and fuel
    public bool hasFuel = false;
    bool hasFruit = false;

    RedFruitScript redFruitScript;
    YellowFruitScript yellowFruitScript;
    BlueFruitScript blueFruitScript;

    FuelScript fuel;

    string PotionToSpawn;

    public GameObject cauldronFiller;

    private Material fillerMat;
    
    private void Start()
    {        
        objectPooler = ObjectPoolingScript.Instance; //grabs reference to the Object Pooler Instance
        brewTimeCounter = 0; //assures the brew timer is always 0 to start
        state = States.Empty;
        fillerMat = cauldronFiller.GetComponent<Renderer>().sharedMaterial;
    }

    private void Update()
    {
        if (hasFuel && hasFruit)
        {
            brewTimeCounter += Time.deltaTime; //the brewtimer only starts when there is fruit and fuel 
        }

        if (brewTimeCounter >= brewTime)
        {
            hasFruit = false;
            hasFuel = false;
            brewTimeCounter = 0;
            BrewPotion();
        }

        Debug.Log(state);
    }

    private void CallStateSwitch()
    {
        switch (state)
        {
            case States.Empty:

                foreach (GameObject _token in fruitTokens)
                {
                    _token.gameObject.SetActive(false);
                }

                fillerMat.color = new Color32(192, 254, 255, 128);

                break;

            case States.Blue:

                fruitTokens[0].SetActive(true);

                PotionToSpawn = "BluePotion";

                fillerMat.color = new Color32(0, 0, 255, 170);

                break;

            case States.Yellow:

                fruitTokens[2].SetActive(true);

                PotionToSpawn = "YellowPotion";

                fillerMat.color = new Color32(255, 255, 0, 170);

                break;

            case States.Red:

                fruitTokens[4].SetActive(true);

                PotionToSpawn = "RedPotion";

                fillerMat.color = new Color32(255, 0, 0, 170);

                break;

            case States.GreenYellowBlue:

                fruitTokens[2].SetActive(true);
                fruitTokens[1].SetActive(true);

                PotionToSpawn = "GreenPotion";

                fillerMat.color = new Color32(0, 255, 0, 170);

                break;

            case States.GreenBlueYellow:

                fruitTokens[0].SetActive(true);
                fruitTokens[3].SetActive(true);

                PotionToSpawn = "GreenPotion";

                fillerMat.color = new Color32(0, 255, 0, 170);

                break;

            case States.PurpleRedBlue:

                fruitTokens[4].SetActive(true);
                fruitTokens[1].SetActive(true);

                PotionToSpawn = "PurplePotion";

                fillerMat.color = new Color32(128, 0, 255, 170);

                break;

            case States.PurpleBlueRed:

                fruitTokens[0].SetActive(true);
                fruitTokens[5].SetActive(true);

                PotionToSpawn = "PurplePotion";

                fillerMat.color = new Color32(128, 0, 255, 170);

                break;

            case States.OrangeRedYellow:

                fruitTokens[4].SetActive(true);
                fruitTokens[3].SetActive(true);

                PotionToSpawn = "OrangePotion";

                fillerMat.color = new Color32(255, 128, 0, 170);

                break;

            case States.OrangeYellowRed:

                fruitTokens[2].SetActive(true);
                fruitTokens[5].SetActive(true);

                PotionToSpawn = "OrangePotion";

                fillerMat.color = new Color32(255, 128, 0, 170);

                break;

        }
    }

    private void OnTriggerEnter(Collider other) //checks to see if the Fruit and Fuel have been added. The objects handle setting themselves inactive.
    {
        yellowFruitScript = other.gameObject.GetComponent<YellowFruitScript>();
        redFruitScript = other.gameObject.GetComponent<RedFruitScript>();
        blueFruitScript = other.gameObject.GetComponent<BlueFruitScript>();
        fuel = other.gameObject.GetComponent<FuelScript>();

        if (yellowFruitScript && yellowFruitScript.isCarried == false)
        {

            hasFruit = true;

            if(state == States.Empty)
            {
                state = States.Yellow;
            }

            else if(state == States.Red)
            {
                state = States.OrangeRedYellow;
            }

            else if (state == States.Blue)
            {
                state = States.GreenBlueYellow;
            }

            CallStateSwitch();
        }

        if (redFruitScript && redFruitScript.isCarried == false)
        {
            hasFruit = true;
           

            if (state == States.Empty)
            {
                state = States.Red;
            }

            else if (state == States.Blue)
            {
                state = States.PurpleBlueRed;
            }

            else if (state == States.Yellow)
            {
                state = States.OrangeYellowRed;
            }

            CallStateSwitch();
        }

        if (blueFruitScript && blueFruitScript.isCarried == false)
        {
            hasFruit = true;

            if (state == States.Empty)
            {
                state = States.Blue;
            }

            else if (state == States.Red)
            {
                state = States.PurpleRedBlue;
            }

            else if (state == States.Yellow)
            {
                state = States.GreenYellowBlue;
            }

            CallStateSwitch();
        }
                    
        if (fuel && !fuel.isCarried)
        {            
            hasFuel = true;
            Debug.Log("hasFuel");
        }
    }   

    public void BrewPotion() //this calls the objectPooler to spawn the object from the pool, triggering that object's unique "OnObjectSpawn()" function through an interface
    {
        state = States.Empty;

        objectPooler.SpawnFromPool(PotionToSpawn, potionSpawn.position, Quaternion.identity);

        CallStateSwitch();
    }
}