using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cubi : MonoBehaviour
{
    public GameObject inputFieldGO;
    public AudioClip cubiSound;
    private AudioSource cubiAS;
    public float speed;
    private Color color;
    public static Toy cubi;
    private void Start()
    {
        cubiAS = gameObject.GetComponent<AudioSource>();
        color = GetComponent<Renderer>().material.color;
        cubi = new Toy(color, "");
        CheckCubiName();

    }

    public void SetCubiName()
    {
        if (cubi.toyName != "")
        {
            cubi.toyName = inputFieldGO.GetComponentInChildren<TMP_InputField>().text;           
            Debug.Log("You named your toy: " + cubi.toyName);
            inputFieldGO.gameObject.SetActive(false);
        }
    }

    private void CheckCubiName()
    {
        if (cubi.toyName == "")
        {
            
            inputFieldGO.gameObject.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        if(!cubiAS.isPlaying)
        {
            cubi.MakeSound(cubiAS, cubiSound);
        }
       
    }
}
