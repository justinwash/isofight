
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{

    // Declare properties
    private string p1CharacterName;
    private string p2CharacterName;

    private int p1StockSelection;
    private int p2StockSelection;

    public string activeStage;

    private static GameState instance;





    // gamestate()
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


 
    // startState()
    // Creates a new game state
    public void StartState()
    {
        print("Creating a new game state");
        SceneManager.LoadScene("DefaultStage");
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
}