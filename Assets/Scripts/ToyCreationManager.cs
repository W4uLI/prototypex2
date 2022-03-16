using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ToyCreationManager : MonoBehaviour
{
    public TextMeshProUGUI toyName;
    public bool isCreated = true;
    public List<GameObject> toysList;
    private int toyIndex;


    void Start()
    {
        if(!isCreated)
        {
            toyIndex = 0;
            toysList[toyIndex].gameObject.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
       
    }
 

    public void NextToy() // cycles forward through the indexes of list
    {
        toyIndex++;
        if (toyIndex < toysList.Count)
        {
            
            toysList[toyIndex].gameObject.SetActive(true);
            toysList[toyIndex - 1].gameObject.SetActive(false);
        }
        else if(toyIndex == toysList.Count)
        {        
            toysList[toyIndex - 1].gameObject.SetActive(false);
            toyIndex = 0;
            toysList[toyIndex].gameObject.SetActive(true);
        }
        UpdateToyName();
    }

    public void PreviousToy() // cycles backwards trough the indexes
    {    
        if (toyIndex > 0)
        {
            toyIndex--;
            toysList[toyIndex].gameObject.SetActive(true);
            toysList[toyIndex + 1].gameObject.SetActive(false);
        }
        else if (toyIndex == 0)
        {
            toysList[toyIndex].gameObject.SetActive(false);
            toyIndex = toysList.Count -1;  
            toysList[toyIndex].gameObject.SetActive(true);  
            
        }
        UpdateToyName();
    }

    void UpdateToyName()
    {
        toyName.text = toysList[toyIndex].gameObject.name;
    }
}
