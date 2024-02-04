// Gamemanager.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public int Score;
    public Text ScoreText;
    public bool IsWin;

    public string sceneToLoad1 = "Paintings";
    public string sceneToLoad2 = "Music";
    public string sceneToLoad3 = "Quotes";

    private bool Done;

    void Update()
    {
        CheckIfAllGrabsSecondWon();
        CheckIfAllGrabs2Won();
        CheckIfAllGrabs1Won();
        ScoreText.text = Score.ToString();

    }

    void CheckIfAllGrabsSecondWon()
    {

        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == sceneToLoad1)
        {
            GrabSecond[] grabsSecondScripts = FindObjectsOfType<GrabSecond>();
            MovePieces[] MovePiecesScritps = FindObjectsOfType<MovePieces>();
            bool allWon = true;

            
            foreach (GrabSecond grabsSecond in grabsSecondScripts)
            {
                if (!grabsSecond.Won) // Utiliser le bon nom de variable
                {
                    allWon = false;
                    break;
                }
            }

            if (allWon && !Done && MovePiecesScritps[0].Win == 1)
            {
                Score += 10;
                ScoreText.text = Score.ToString();
                IsWin = true;
                Done = true;
                
                
                SwitchScene();
                Debug.Log("Tous les GrabsSecond ont gagné. Score mis à 10.");
            }
            if(MovePiecesScritps[0].Win < 0)
            {
                Score -= 10;
                ScoreText.text = Score.ToString();
                SwitchScene();
            }
            else
            {
                ScoreText.text = "Pas encore";
            }
        }
    }

    void CheckIfAllGrabs1Won()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == sceneToLoad3)
        {
            ArrayContainer[] arrayContainerScripts = FindObjectsOfType<ArrayContainer>();

            // Vérifiez d'abord si l'array n'est pas vide avant d'accéder à ses éléments
            if(arrayContainerScripts != null && arrayContainerScripts.Length > 0)
            {
                if(arrayContainerScripts[0].Win == 2)
                {
                    Score += 10;
                    ScoreText.text = Score.ToString();
                    SwitchScene();
                }
                else if(arrayContainerScripts[0].Win < 0)
                {
                    Score -= 10;
                    ScoreText.text = Score.ToString();
                    SwitchScene();
                }
            }
        }
    }


    
    void CheckIfAllGrabs2Won()
    {
        ArrayTableau[] arrayTableauScripts = FindObjectsOfType<ArrayTableau>();
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == sceneToLoad2)
        {


            if(arrayTableauScripts!= null)
            {
                if(arrayTableauScripts[0].Win == 1)
                {
                    Score += 10;
                    ScoreText.text = Score.ToString();
                    Debug.Log("Win");
                    SwitchScene();
                }
                if(arrayTableauScripts[0].Win < 0)
                {
                    Score -= 10;
                    ScoreText.text = Score.ToString();
                    Debug.Log("PasWin");
                    
                    SwitchScene();
                }
                
            }
        }

    }


    public void SwitchScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        string sceneToLoad;
        if (currentScene == sceneToLoad1)
        {
            sceneToLoad = sceneToLoad2;
            Done = false;
        }
        else if (currentScene == sceneToLoad2)
        {
            sceneToLoad = sceneToLoad3;
        }
        else
        {
            sceneToLoad = sceneToLoad1;
        }

        SceneManager.LoadScene(sceneToLoad);
    }
}
