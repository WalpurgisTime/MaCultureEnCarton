using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class Musician
{
    public string myString;
    public string myString2;
    public string myString3;
    public string myString4;
    public string myString5;
    public string name;

    public AudioSource audioSource;

}

public class ArrayTableau : MonoBehaviour
{
    // Déclarez la liste publique
    public List<Musician> myStringListMusician = new List<Musician>();
    public Button answer1;
    public Button answer2;
    public Button answer3;
    public Button answer4;
    public Text nameText;

    public Sprite imageMusiqueActive;
    public Sprite imageMusiqueInactive;

    private bool Isplayed;

    public Button MusicButton;
    public Text answer1Text;
    public Text answer2Text;
    public Text answer3Text;
    public Text answer4Text;

    private int randomIndex;
    public int Win;
    private bool Done;


    void Start()
    {
        Win = 0;
        randomIndex = UnityEngine.Random.Range(0, myStringListMusician.Count);
        answer1Text.text = myStringListMusician[randomIndex].myString;
        answer2Text.text = myStringListMusician[randomIndex].myString2;
        answer3Text.text = myStringListMusician[randomIndex].myString3;
        answer4Text.text = myStringListMusician[randomIndex].myString4;
        nameText.text = myStringListMusician[randomIndex].name;

    }

      public void OnClickAnswer1()
    {
        if(answer1.interactable && !Done)
        {
            Done = true;
            if(myStringListMusician[randomIndex].myString == myStringListMusician[randomIndex].myString5)
            { 
                Win = 1;
                Debug.Log("Win");
            }
            else
            {
                Debug.Log("Lose");
                Win = -1;
            }
        }
    }

    public void OnClickAnswer2()
    {
        if(answer2.interactable&& !Done)
        {
            Done = true;
            if(myStringListMusician[randomIndex].myString2 == myStringListMusician[randomIndex].myString5)
            { 
                Win = 1;
                Debug.Log("Win");
            }
            else
            {
                Debug.Log("Lose");
                Win = -1;
            }
        }
    }
    public void OnClickAnswer3()
    {
        if(answer3.interactable&& !Done)
        {
            Done = true;
            if(myStringListMusician[randomIndex].myString3 == myStringListMusician[randomIndex].myString5)
            { 
                Win = 1;
                Debug.Log("Win");
            }
            else
            {
                Debug.Log("Lose");
                Win = -1;
            }
        }
    }
    public void OnClickAnswer4()
    {
        if(answer4.interactable&& !Done)
        {
            Done = true;
            if(myStringListMusician[randomIndex].myString4 == myStringListMusician[randomIndex].myString5)
            { 
                Win = 1;
                Debug.Log("Win");
            }
            else
            {
                Debug.Log("Lose");
                Win = -1;
            }
        }
    }

     public void OnClickMusic()
    {
        if(MusicButton.interactable)
        {
            if(Isplayed)
            {
                myStringListMusician[randomIndex].audioSource.Stop();
                Isplayed = false;
                MusicButton.image.sprite = imageMusiqueInactive;
            }
            else
            {
                myStringListMusician[randomIndex].audioSource.Play();
                Isplayed = true;
                MusicButton.image.sprite = imageMusiqueActive;
            }
            
        }
    }

}

