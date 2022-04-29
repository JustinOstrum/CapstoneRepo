using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReticleScript : MonoBehaviour
{
    List<LayerMask> masks = new List<LayerMask>();

    public List<bool> interactions = new List<bool>();

    public LayerMask pickupMask;
    public LayerMask woodChoppingMask;
    public LayerMask fruitPickingMask;
    public LayerMask fruitCuttingMask;
    public LayerMask waterCollectingMask;
    public LayerMask cauldronStirringMask;

    bool canPickUp = false;
    bool canChopWood = false;
    bool canPickFruit = false;
    bool canCutFruit = false;
    bool canCollectWater = false;
    bool canStirCauldron = false;

    private void Start()
    {
        masks.Add(pickupMask);
        masks.Add(woodChoppingMask);
        masks.Add(fruitPickingMask);
        masks.Add(fruitCuttingMask);
        masks.Add(waterCollectingMask);
        masks.Add(cauldronStirringMask);

        interactions.Add(canPickUp);
        interactions.Add(canChopWood);
        interactions.Add(canPickFruit);
        interactions.Add(canCutFruit);
        interactions.Add(canCollectWater);
        interactions.Add(canStirCauldron);        
    }

    private void Update()
    {
        ReticleChangeOnRayHit();
    }

    private void ReticleChangeOnRayHit()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3f, masks[0]))
        {
            interactions[0] = true;
            
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
        }

        else if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3f, masks[1]))
        {
            interactions[1] = true;
            
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.cyan);
        }

        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3f, masks[2]))
        {
            interactions[2] = true;
            
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.cyan);
        }

        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3f, masks[3]))
        {
            interactions[3] = true;
            
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.cyan);
        }

        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3f, masks[4]))
        {
            interactions[4] = true;
            
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.cyan);
        }

        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3f, masks[5]))
        {
            interactions[5] = true;
            
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.cyan);
        }

        else
        {
            interactions[0] = false;
            interactions[1] = false;
            interactions[2] = false;
            interactions[3] = false;
            interactions[4] = false;
            interactions[5] = false;
                        
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1f, Color.white);            
        }
    }
}
