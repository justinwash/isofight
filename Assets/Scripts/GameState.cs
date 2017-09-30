
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    private string p1CharacterName;
    private string p2CharacterName;
    private int p1StockSelection;
    private int p2StockSelection;
    public string activeStage;
    private static GameState instance;
    private int p1RoundCount;
    private int p2RoundCount;
    private int winner;
    private bool gameOver;

    

    void Update()
    {
        if (gameOver)
        {
            if (Input.GetButtonDown("p1Punch1") || Input.GetButtonDown("p2Punch1"))
            {
                ReturnToCharSelect();
            }
        }
           
    }
    
    // Creates an instance of gamestate as a gameobject if an instance does not exist
    public static GameState Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameState").AddComponent<GameState>();
            }

            return instance;
        }
    }

    // Sets the instance to null when the application quits
    public void OnApplicationQuit()
    {
        instance = null;
    }

    // Creates a new game state
    public void StartState()
    {
        print("Creating a new game state");
        SceneManager.LoadScene("DefaultStage");
    }

    public void ReturnToCharSelect()
    {
        print("Returning to Character Select");
        gameOver = false;
        Destroy(gameObject);
        SceneManager.LoadScene("CharacterSelect");
    }

    // Returns the active Stage
    public string GetStage()
    {
        return activeStage;
    }

    public void SetStage(string newStage)
    {
        activeStage = newStage;
    }

    public void SetCharacter(int player, string chracter)
    {
        if (player == 1)
        {
            p1CharacterName = chracter;
        }

        if (player == 2)
        {
            p2CharacterName = chracter;
        }
    }

    public string GetP1Character()
    {
        return p1CharacterName;
    }

    public string GetP2Character()
    {
        return p2CharacterName;
    }

    public void TallyRound(int player)
    {
        if (player == 1)
        {
            p1RoundCount += 1;
        }

        if (player == 2)
        {
            p2RoundCount += 1;
        }

        if (p1RoundCount >= 2)
        {
            ActivateWinScreen(1);
        }

        if (p2RoundCount >= 2)
        {
            ActivateWinScreen(2);
        }
    }

    public void ActivateWinScreen(int player)
    {
        if (player == 1)
        {
            winner = 2;
        }

        if (player == 2)
        {
            winner = 1;
        }

        Time.timeScale = 0;
        GameObject.Find("Game_End").GetComponent<Text>().text = "PLAYER " + winner + " WINS!";
        GameObject.Find("Return_To_Char_Select").GetComponent<Text>().text = "Press (A) to return to character select";
        gameOver = true;
    }
}