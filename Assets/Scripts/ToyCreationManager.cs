using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ToyCreationManager : MonoBehaviour
{
    public TextMeshProUGUI toyName;
    public static bool isCreated = false;
    public List<GameObject> toysList;
    public static int toyIndex;
    private int colorIndex;
    public List<Color> colorList;
    public static Color currentToyColor;

    void Start()
    {

        DataManager.LoadGameData();
        if (!isCreated)
        {
            toyIndex = 0;
            colorIndex = 0;
            toysList[toyIndex].gameObject.SetActive(true);          
            SetColor();
            //toysList[toyIndex].GetComponent<Renderer>().material.color = colorList[toyIndex];
        }
        else
        {
            CreationComplete();
        }
       
    }
 
    public void NextToy() 
    {
        toyIndex++; // when the player clicks the button add 1 to the index     
        if (toyIndex < toysList.Count) 
        {
            toysList[toyIndex - 1].gameObject.SetActive(false); //  set the previous object in the list to inactive
            toysList[toyIndex].gameObject.SetActive(true); // set next object in list to active
           
        }
        else if(toyIndex == toysList.Count) // if the index has reached the end of the list
        {        
            toysList[toyIndex - 1].gameObject.SetActive(false); // since the index will get +1 everytime you click. the last actual object in the list will be set inactive
            toyIndex = 0; // reset the index to 0 to match the very first object in the list
            toysList[toyIndex].gameObject.SetActive(true); // and set the first item active again
        }
        UpdateToyName();
    }

    public void PreviousToy() // same as next toy but opposite, making sure we cycle backwards.
    {    
        if (toyIndex > 0)
        {
            toyIndex--;
            toysList[toyIndex + 1].gameObject.SetActive(false);
            toysList[toyIndex].gameObject.SetActive(true);           
        }
        else if (toyIndex == 0)
        {
            toysList[toyIndex].gameObject.SetActive(false);
            toyIndex = toysList.Count -1;
            toysList[toyIndex].gameObject.SetActive(true);  
            
        }
        UpdateToyName();
    }      

    public void ChangeColor()
    {
        colorIndex++; // add 1 to index everytime you press    
            
        if (colorIndex == colorList.Count)
        {
            colorIndex = 0;
            toysList[toyIndex].GetComponent<Renderer>().material.color = colorList[colorIndex]; 
        }
        SetColor();
    }

    void UpdateToyColor()
    {
        currentToyColor = toysList[toyIndex].GetComponent<Renderer>().material.color;
    }

    void SetColor()
    {
        foreach (GameObject toys in toysList)
        {
            toys.GetComponent<Renderer>().material.color = colorList[colorIndex];
        }
    }

    void UpdateToyName()
    {
        //simply to match the shown name of the object to the UI;
        toyName.text = toysList[toyIndex].gameObject.name;
    }

    public void CreationComplete()
    {
        UpdateToyColor();
        isCreated = true;
        DataManager.SaveGameData();       
        SceneManager.LoadScene(1);
    }
}
