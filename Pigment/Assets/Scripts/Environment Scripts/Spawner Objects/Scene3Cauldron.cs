using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States { Empty, Blue, Yellow, Red, GreenBlueYellow, GreenYellowBlue, PurpleRedBlue, PurpleBlueRed, OrangeYellowRed, OrangeRedYellow, Brewing }

public class Scene3Cauldron : MonoBehaviour
{
    AudioManager audioManager;

    public States state;

    public Transform sourSpawn;
    public Transform spicySpawn;
    public Transform sweetSpawn;

    //references the object pooler
    ObjectPoolingScript objectPooler;

    public GameManager gm;

    //the transform of the spawn object
    public Transform potionSpawn;

    public Material bubbleMat;

    public List<GameObject> checkmarks= new List<GameObject>();
    
    public List<bool> ColourChecks = new List<bool>();

    string PotionToSpawn = "";

    public GameObject cauldronFiller;

    private Material fillerMat;

    private int checkIndex;

    Color currentColor;

    public ParticleSystem bubbles;

    public bool stage1 = false;
    public bool stage2 = false;

    private void Awake()
    {
        audioManager = AudioManager.instance;
    }

    private void Start()
    {
        objectPooler = ObjectPoolingScript.Instance; //grabs reference to the Object Pooler Instance
        state = States.Empty;
        fillerMat = cauldronFiller.GetComponent<Renderer>().sharedMaterial;

        fillerMat.color = new Color32(192, 254, 255, 128);

        bubbleMat.color = fillerMat.color;
    }

    public void ResetCauldron()
    {
        state = States.Empty;

        StartCoroutine(LerpColours(fillerMat, fillerMat.color, new Color32(192, 254, 255, 128)));

        stage1 = false;
        stage2 = false;

    }

    public void ActivateBubbles()
    {
        bubbles.Play();

        audioManager.Play("PotionGet");
    }

    public void DisableBubbles()
    {
        bubbles.Stop();
    }

    private void CallStateSwitch()
    {
        switch (state)
        {
            case States.Empty:

                PotionToSpawn = "";

                StartCoroutine(LerpColours(fillerMat, fillerMat.color, new Color32(192, 254, 255, 128)));

                break;

            case States.Blue:

                PotionToSpawn = "BluePotion";

                checkIndex = 2;

                StartCoroutine(LerpColours(fillerMat, fillerMat.color, new Color32(0, 0, 255, 170)));
                
                break;

            case States.Yellow:

                PotionToSpawn = "YellowPotion";

                checkIndex = 0;

                StartCoroutine(LerpColours(fillerMat, fillerMat.color, new Color32(255, 255, 0, 170)));
                
                break;

            case States.Red:

                PotionToSpawn = "RedPotion";

                checkIndex = 1;

                StartCoroutine(LerpColours(fillerMat, fillerMat.color, new Color32(255, 0, 0, 170)));
                
                break;

            case States.GreenYellowBlue:

                PotionToSpawn = "GreenPotion";

                checkIndex = 3;

                StartCoroutine(LerpColours(fillerMat, fillerMat.color, new Color32(0, 255, 0, 170)));
                
                break;

            case States.GreenBlueYellow:

                PotionToSpawn = "GreenPotion";

                checkIndex = 3;

                StartCoroutine(LerpColours(fillerMat, fillerMat.color, new Color32(0, 255, 0, 170)));
                
                break;

            case States.PurpleRedBlue:

                PotionToSpawn = "PurplePotion";

                checkIndex = 5;

                StartCoroutine(LerpColours(fillerMat, fillerMat.color, new Color32(128, 0, 255, 170)));
                
                break;

            case States.PurpleBlueRed:

                PotionToSpawn = "PurplePotion";

                checkIndex = 5;

                StartCoroutine(LerpColours(fillerMat, fillerMat.color, new Color32(128, 0, 255, 170)));
                
                break;

            case States.OrangeRedYellow:

                PotionToSpawn = "OrangePotion";

                checkIndex = 4;

                StartCoroutine(LerpColours(fillerMat, fillerMat.color, new Color32(255, 128, 0, 170)));
                
                break;

            case States.OrangeYellowRed:

                PotionToSpawn = "OrangePotion";

                checkIndex = 4;

                StartCoroutine(LerpColours(fillerMat, fillerMat.color, new Color32(255, 128, 0, 170)));
                
                break;

        }

        Debug.Log(state);
        Debug.Log(PotionToSpawn);
    }

    private void OnTriggerEnter(Collider other) //checks to see if the Fruit and Fuel have been added. The objects handle setting themselves inactive.
    {        
        if (other.CompareTag("YellowFruit"))
        {
            objectPooler.SpawnFromPool("YellowFruit", sourSpawn.position, Quaternion.identity);

            if (state == States.Empty)
            {
                state = States.Yellow;

                audioManager.Play("Bloop");
            }

            else if (state == States.Red && stage2)
            {
                state = States.OrangeRedYellow;

                audioManager.Play("Bloop");
            }

            else if (state == States.Blue && stage2)
            {
                state = States.GreenBlueYellow;

                audioManager.Play("Bloop");
            }

            CallStateSwitch();
        }

        if (other.CompareTag("RedFruit"))
        {
            objectPooler.SpawnFromPool("RedFruit", spicySpawn.position, Quaternion.identity);

            if (state == States.Empty)
            {
                state = States.Red;

                audioManager.Play("Bloop");
            }

            else if (state == States.Blue && stage2)
            {
                state = States.PurpleBlueRed;

                audioManager.Play("Bloop");
            }

            else if (state == States.Yellow && stage2)
            {
                state = States.OrangeYellowRed;

                audioManager.Play("Bloop");
            }

            CallStateSwitch();
        }

        if (other.CompareTag("BlueFruit"))
        {
            objectPooler.SpawnFromPool("BlueFruit", sweetSpawn.position, Quaternion.identity);

            if (state == States.Empty)
            {
                state = States.Blue;

                audioManager.Play("Bloop");
            }

            else if (state == States.Red && stage2)
            {
                state = States.PurpleRedBlue;

                audioManager.Play("Bloop");
            }

            else if (state == States.Yellow && stage2)
            {
                state = States.GreenYellowBlue;

                audioManager.Play("Bloop");
            }

            CallStateSwitch();
        }
    }

    public void BrewPotion() //this calls the objectPooler to spawn the object from the pool, triggering that object's unique "OnObjectSpawn()" function through an interface
    {
        if (state != States.Empty)
        {
            audioManager.Play("PotionGet");

            for (int i = 0; i < checkmarks.Count - 1; i++)
            {
                checkmarks[checkIndex].SetActive(true);
                ColourChecks[checkIndex] = true;
            }

            if (!ColourChecks.Contains(false))
            {
                StartCoroutine(FinishGame());
            }
        }

        DisableBubbles();

        state = States.Empty;

        objectPooler.SpawnFromPool(PotionToSpawn, potionSpawn.position, Quaternion.identity);

        PotionToSpawn = "";
        
        CallStateSwitch();
    }

    IEnumerator FinishGame()
    {
        yield return new WaitForSeconds(2f);

        audioManager.Play("LevelComplete");

        gm.LoadNextScene();
    }

    IEnumerator LerpColours(Material mat, Color curColour,Color newColour)
    {
        var i = 0f;
        
        while (i < 2.0f)
        {
            i += Time.deltaTime;

            mat.color = Color.Lerp(curColour, newColour, i/1.5f);

            bubbleMat.color = mat.color;

            yield return null;
        }
    }
}