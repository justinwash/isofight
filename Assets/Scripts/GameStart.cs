
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{

    public string[] characterList;
    public Sprite[] avatarList;
    int p1Selection;
    int p2Selection;

    private void Start()
    {
        GameObject.Find("Player1Avatar").GetComponent<Image>().sprite = avatarList[0];
        GameObject.Find("Player2Avatar").GetComponent<Image>().sprite = avatarList[1];
    }

    // Our Startscreen GUI
    void OnGUI()
	{

		if (GUI.Button(new Rect(30, 30, 150, 30), "Start Game"))
		{
            if (GameState.Instance.GetP1Character() == null || GameState.Instance.GetP2Character() == null)
            {
                GameObject.Find("Canvas").GetComponentInChildren<Text>().text = "No really, pick a character!";
            }
            else startGame();
		}

    }

    private void Update()
    {
        if (Input.GetButtonDown("p1Horizontal"))
        {
            p1NextAvatar();
        }

        if (Input.GetButtonDown("p2Horizontal"))
        {
            p2NextAvatar();
        }
    }


    private void startGame()
	{
		print("Starting The Thing!");

		DontDestroyOnLoad(GameState.Instance);
		GameState.Instance.StartState();
	}

    private void p1NextAvatar()
    {
        if (p1Selection >= avatarList.Length - 1)
        {
            p1Selection = 0;
        }
        else
        {
            p1Selection += 1;
        }

        GameObject.Find("Player1Avatar").GetComponent<Image>().sprite = avatarList[p1Selection];
        GameState.Instance.SetCharacter(1, characterList[p1Selection]);
    }

    private void p2NextAvatar()
    {
        if (p2Selection >= avatarList.Length - 1)
        {
            p2Selection = 0;
        }
        else
        {
            p2Selection += 1;
        }

        GameObject.Find("Player2Avatar").GetComponent<Image>().sprite = avatarList[p2Selection];
        GameState.Instance.SetCharacter(2, characterList[p2Selection]);
    }
}