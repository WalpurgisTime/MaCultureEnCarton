using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;

[Serializable]
public class Paintings
{
    public string myString;
    public string myString2;
    public string myString3;
    public string myString4;
    public string myString5;
    public string name;

}

public class MovePieces : MonoBehaviour
{
    public List<Paintings> myStringListPainting = new List<Paintings>();
    public Button answer1;
    public Button answer2;
    public Button answer3;
    public Button answer4;

    public Text answer1Text;
    public Text answer2Text;
    public Text answer3Text;
    public Text answer4Text;

    public Text nameText;
    public int Win;
    private bool Done;



    public GameObject[] Pieces;
    public Sprite[] Paintings;
    public Vector3[] StoredPosition;
    public Quaternion[] StoredRotation;
    private float randomRotation ;
    public int[] IndexPieces2; 
    public int IndexPieces;
    public string[] Name;
    private int Index;

    // Start is called before the first frame update
    void Start()
    {
        Index =  UnityEngine.Random.Range(0, Paintings.Length);
        IndexPieces2 = new int[Pieces.Length];
        StoredPosition = new Vector3[Pieces.Length];
        StoredRotation = new Quaternion[Pieces.Length];
        Name = new string[Pieces.Length];
        CreatePieces(0,90);
        CreatePieces(1,0);
        CreatePieces(2,180);
        CreatePieces(3,270);
        CreatePieces(4,360);

        GameObject[] tousLesObjets = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject objet in tousLesObjets)
        {
            if (objet.name == "Puzzle")
            {
                SpriteRenderer spriteRenderer = objet.GetComponent<SpriteRenderer>();
                Vector2 ancienneTaille = spriteRenderer.sprite.bounds.size;

                // Change le sprite du SpriteRenderer avec la nouvelle image
                spriteRenderer.sprite = Paintings[Index];

                // Ajuste la taille du SpriteRenderer pour correspondre à la taille de la nouvelle image
                Vector2 nouvelleTaille = Paintings[Index].bounds.size;
                spriteRenderer.size = nouvelleTaille;
            }
        }

        Win = 0;
        answer1Text.text = myStringListPainting[Index].myString;
        answer2Text.text = myStringListPainting[Index].myString2;
        answer3Text.text = myStringListPainting[Index].myString3;
        answer4Text.text = myStringListPainting[Index].myString4;
        nameText.text = myStringListPainting[Index].name;     
    }

     public void OnClickAnswer1()
    {
        if(answer1.interactable && !Done)
        {
            Done = true;
            if(myStringListPainting[Index].myString == myStringListPainting[Index].myString5)
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
            if(myStringListPainting[Index].myString2 == myStringListPainting[Index].myString5)
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
            if(myStringListPainting[Index].myString3 == myStringListPainting[Index].myString5)
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
            if(myStringListPainting[Index].myString4 == myStringListPainting[Index].myString5)
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

    void CreatePieces(int index, float xd)
    {
        IndexPieces = UnityEngine.Random.Range(0, Pieces.Length);
        
        IndexPieces2[index] = IndexPieces; 
        
        StoredPosition[IndexPieces] = Pieces[IndexPieces].transform.position;
        StoredRotation[IndexPieces] = Pieces[IndexPieces].transform.rotation;
        Name[index] = Pieces[IndexPieces].name;
       

        Pieces[IndexPieces].transform.position = new Vector3(300f,xd+90f, 0f);
        randomRotation = UnityEngine.Random.Range(0, 4) * 90f;
        Pieces[IndexPieces].transform.rotation = Quaternion.Euler(0f, 0f, randomRotation);
        Pieces[IndexPieces].AddComponent<GrabSecond>();
    }
}
