using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyManager : MonoBehaviour
{

    public GameObject[] toy;
    private int toyIndex;
    void Start()
    {
        //making the "fake" object that was picked in creation visible and giving it its color
        toyIndex = ToyCreationManager.toyIndex;
        toy[toyIndex].GetComponent<Renderer>().sharedMaterial.color = ToyCreationManager.currentToyColor;
        toy[toyIndex].gameObject.SetActive(true);  
    }

}
