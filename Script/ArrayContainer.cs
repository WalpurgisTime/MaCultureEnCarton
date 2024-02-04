using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class MyTuple
{
    public string myBool;
    public string myString1;
    public string myString2;

    public string Philosophe1;
    public string Philosophe2;
    public string Philosophe3;
    public string Philosophe4;

    public string Philosophe5;

}

public class ArrayContainer : MonoBehaviour
{
    public List<MyTuple> myStringList = new List<MyTuple>();
    private int randomIndex;
    public Text mystring1Text;
    public Text mystring1Text2;
    public InputField myInputField;  
    public Button answer1;
    public Button answer2;
    public Button answer3;
    public Button answer4;
    public Text answer1Text;
    public Text answer2Text;
    public Text answer3Text;
    public Text answer4Text;

    public int Win;
    private bool Done;
    private bool Done2;

    

    void Start()
    {
        Win = 0;
        randomIndex = UnityEngine.Random.Range(0, myStringList.Count);
        mystring1Text.text = myStringList[randomIndex].myString1;
        mystring1Text2.text = myStringList[randomIndex].myString2;
        answer1Text.text = myStringList[randomIndex].Philosophe1;
        answer2Text.text = myStringList[randomIndex].Philosophe2;
        answer3Text.text = myStringList[randomIndex].Philosophe3;
        answer4Text.text = myStringList[randomIndex].Philosophe4;
    }

    public void OnInputField()
    {
        string userInput = myInputField.text;  // Get the value from the InputField
        if(!Done)
        {
            Done= true;
            if (myStringList[randomIndex].myBool == userInput)
            {
                // Your logic here if the input matches myBool
                Debug.Log("Input matches myBool!");
                Win += 1;
            }
            else
            {
                // Your logic here if the input does not match myBool
                Debug.Log("Input does not match myBool!");
                Win = -2;
            }
        }
    }

    public void OnClickAnswer1()
    {
        if(answer1.interactable && !Done2)
        {
            Done2 = true;
            if(myStringList[randomIndex].Philosophe1 == myStringList[randomIndex].Philosophe5)
            { 
                Debug.Log("Win");
                Win += 1;
            }
            else
            {
                Debug.Log("Lose");
                Win = -2;
            }
        }
    }

    public void OnClickAnswer2()
    {
        if(answer2.interactable&& !Done2)
        {
            Done2 = true;
            if(myStringList[randomIndex].Philosophe2 == myStringList[randomIndex].Philosophe5)
            { 
                Debug.Log("Win");
                Win += 1;
            }
            else
            {
                Debug.Log("Lose");
                Win = -2;
            }
        }
    }
    public void OnClickAnswer3()
    {
        if(answer3.interactable&& !Done2)
        {
            Done2 = true;
            if(myStringList[randomIndex].Philosophe3 == myStringList[randomIndex].Philosophe5)
            { 
                Debug.Log("Win");
                Win += 1;
            }
            else
            {
                Debug.Log("Lose");
                Win = -2;
            }
        }
    }
    public void OnClickAnswer4()
    {
        if(answer4.interactable&& !Done2)
        {
            Done2 = true;
            if(myStringList[randomIndex].Philosophe4 == myStringList[randomIndex].Philosophe5)
            { 
                Debug.Log("Win");
                Win += 1;
            }
            else
            {
                Debug.Log("Lose");
                Win = -2;
            }
        }
    }

}
