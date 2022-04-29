using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractionScript : MonoBehaviour
{
    #region Singleton

    public static PlayerInteractionScript Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    void Start()
    {
                
    }    
}
