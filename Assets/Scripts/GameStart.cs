
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{

    public string[] characterList;
    public Sprite[] avatarList;
    int p1Selection;
    int p2Selection;
    bool p1Selected;
    bool p2Selected;

    bool gameReady;

    private void Start()
    {
        GameObject.Find("Player1Avatar").GetComponent<Image>().sprite = avatarList[0];
        GameObject.Find("Player2Avatar").GetComponent<Image>().sprite = avatarList[1];
    }

    private void Update()
    {
        if (Input.GetButtonDown("p1Horizontal") && !p1Selected)
        {
            p1NextAvatar();
        }

        if (Input.GetButtonDown("p2Horizontal") && !p2Selected)
        {
            p2NextAvatar();
        }

        if (Input.GetButtonDown("p1Punch1") && !p1Selected)
        {
            p1Select();
        }

        if (Input.GetButtonDown("p2Punch1") && !p2Selected)
        {
            p2Select();
        }

        if (p1Selected && p2Selected)
        {
            StartCoroutine(SetGameReady(1));
        }

        if (Input.GetButtonDown("p1Punch1") && gameReady)
        {
            StartGame();
        }

        if (Input.GetButtonDown("p2Punch1") && gameReady)
        {
            StartGame();
        }
    }


    private void StartGame()
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

    private void p1Select()
    {
        GameObject.Find("Player1Text").GetComponent<Text>().text = characterList[p1Selection];
        p1Selected = true;
    }

    private void p2Select()
    {
        GameObject.Find("Player2Text").GetComponent<Text>().text = characterList[p2Selection];
        p2Selected = true;
    }

    private IEnumerator SetGameReady(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameObject.Find("StartGameText").GetComponent<Text>().text = "PRESS (A) TO START";
        gameReady = true;
    }
}