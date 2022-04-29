using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSpoonScript : MonoBehaviour
{
    public Scene3Cauldron cauldronScript;

    private Vector3 screenPoint;
    private Vector3 offset;    

    bool stirring = false;
    
    float stirringCounter;
    float stage1StirringTime = 4f;
    float stage2StirringTime = 9f;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();        
    }

    private void Update()
    {
        if (stirring == true)
        {
            stirringCounter += Time.deltaTime;            
        }

        if (stirringCounter >= stage1StirringTime && stirringCounter < stage2StirringTime && cauldronScript.stage1 == false)
        {
            cauldronScript.stage1 = true;

            cauldronScript.ActivateBubbles();

            cauldronScript.stage2 = true;
        }

        if(stirringCounter >= stage2StirringTime)
        {
            stirringCounter = 0;

            cauldronScript.stage1 = false;
            cauldronScript.stage2 = false;

            cauldronScript.BrewPotion();
        }
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        curPosition.x = Mathf.Clamp(curPosition.x, -4.8f, -3.1f);
        curPosition.y = Mathf.Clamp(curPosition.y, 2.3f, 2.3f);
        curPosition.z = Mathf.Clamp(curPosition.z, -2.85f, -2.3f);
        transform.position = curPosition;
        
        stirring = true;
    }

    private void OnMouseUp()
    {
        stirring = false;
    }
}
