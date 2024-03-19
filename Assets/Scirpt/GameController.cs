using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player
{
    public Image panel;
    public Text text;
    public Button button;
}

[System.Serializable]

public class PlayerColor
{
    public Color panelColor;
    public Color textColor;
}


public class GameController : MonoBehaviour
{
    [SerializeField] private Text[] buttonlist;
    [SerializeField] private GameObject gameOverPanal;
    [SerializeField] private Text gameOverText;
    [SerializeField] private GameObject reStartGame;
    [SerializeField] private Player playerX;
    [SerializeField] private Player playerO;
    [SerializeField] private PlayerColor activePlayerColor;
    [SerializeField] private PlayerColor inactivePlayerColor;

    private string playerSide;
    private string aiSide;
    private int value;
    private int moveCount;
    public bool playerMove;
    public float delay;



    private void Awake()
    {
        gameOverPanal.SetActive(false);
        SetGameControllerOnButton();
        moveCount = 0;
        reStartGame.SetActive(false);
        playerMove = true;
    }

    public void Update()
    {
        if (playerMove == false)
        {
            delay += delay * Time.deltaTime;
            if(delay >= 100 )
            {
                value = Random.Range(0, 8);
                if (buttonlist[value].GetComponentInParent<Button>().interactable == true)
                {
                    buttonlist[value].text = AiSide();
                    buttonlist[value].GetComponentInParent<Button>().interactable = false;
                    EndTurn();
                }
            }
        }
    }
    private void SetGameControllerOnButton()
    {
        for (int i = 0; i < buttonlist.Length; i++)
        {
            buttonlist[i].GetComponentInParent<GridScript>().SetGameContorller(this);
        }
    }

    public void SetStartingSide(string startingSide)
    {
        playerSide = startingSide;
        if (playerSide == "X")
        {
            aiSide = "O";
            SetPlayerColor(playerX, playerO);
        }
        else
        {
            aiSide = "X";
            SetPlayerColor(playerO, playerX);
        }
        StartGame();
    }

    public void StartGame()
    {
        SetBoardInteractable(true);
        SetPlayerButton(false);

    }

    public string AiSide()
    {
        return aiSide;
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }
    public void EndTurn()
    {
        moveCount++;

        if (buttonlist[0].text == playerSide && buttonlist[1].text == playerSide && buttonlist[2].text == playerSide)
        {
            GameOver(playerSide);
        }
         else if (buttonlist[3].text == playerSide && buttonlist[4].text == playerSide && buttonlist[5].text == playerSide)
        {
            GameOver(playerSide);
        }

        else if (buttonlist[6].text == playerSide && buttonlist[7].text == playerSide && buttonlist[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonlist[0].text == playerSide && buttonlist[3].text == playerSide && buttonlist[6].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonlist[1].text == playerSide && buttonlist[4].text == playerSide && buttonlist[7].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonlist[2].text == playerSide && buttonlist[5].text == playerSide && buttonlist[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonlist[0].text == playerSide && buttonlist[4].text == playerSide && buttonlist[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonlist[2].text == playerSide && buttonlist[4].text == playerSide && buttonlist[6].text == playerSide)
        {
            GameOver(playerSide);
        }


        else if (buttonlist[0].text == aiSide && buttonlist[1].text == aiSide && buttonlist[2].text == aiSide)
        {
            GameOver(aiSide);
        }
        else if (buttonlist[3].text == aiSide && buttonlist[4].text == aiSide && buttonlist[5].text == aiSide)
        {
            GameOver(aiSide);
        }
        else if (buttonlist[6].text == aiSide && buttonlist[7].text == aiSide && buttonlist[8].text == aiSide)
        {
            GameOver(aiSide);
        }
        else if (buttonlist[0].text == aiSide && buttonlist[3].text == aiSide && buttonlist[6].text == aiSide)
        {
            GameOver(aiSide);
        }
        else if (buttonlist[1].text == aiSide && buttonlist[4].text == aiSide && buttonlist[7].text == aiSide)
        {
            GameOver(aiSide);
        }
        else if (buttonlist[2].text == aiSide && buttonlist[5].text == aiSide && buttonlist[8].text == aiSide)
        {   
            GameOver(aiSide);
        }
        else if (buttonlist[0].text == aiSide && buttonlist[4].text == aiSide && buttonlist[8].text == aiSide)
        {
            GameOver(aiSide);
        }
        else if (buttonlist[2].text == aiSide && buttonlist[4].text == aiSide && buttonlist[6].text == aiSide)
        {
            GameOver(aiSide);
        }


        else if (moveCount >= 9)
        {
            GameOver("draw");
        }
        else
        {
            ChangeSide();
            delay = 10;
        }

        ChangeSide();
    }

    public void SetPlayerColor(Player newPlayer , Player oldPlayer)
    {
        newPlayer.panel.color = activePlayerColor.panelColor;
        newPlayer.text.color = activePlayerColor.textColor;
        oldPlayer.panel.color = inactivePlayerColor.panelColor;
        oldPlayer.text.color = inactivePlayerColor.textColor;
    }

    public void GameOver(string winningPlayer)
    {
        SetBoardInteractable(false);

        if(winningPlayer == "draw")
        {
            SetGameOverText("Draw! Try to enter ");
            SetPlayerColorInactive();
        }
        else
        {
            SetGameOverText(winningPlayer + " You are very strong!");
        }
        reStartGame.SetActive(true);

    }

    public void ChangeSide()
    {
        playerMove = (playerMove == true) ? false : true;

        if (playerMove == true) 
        {
            SetPlayerColor(playerX, playerO);
        }
        else
        {
            SetPlayerColor(playerO, playerX);

        }
    }

    public void SetGameOverText(string value)
    {
        gameOverPanal.SetActive(true);
        gameOverText.text = value;
    }

    public void RestartGame()
    {
        moveCount = 0;
        gameOverPanal.SetActive(false);
        SetPlayerButton(true);
        SetPlayerColorInactive();
        playerMove = true;
        delay = 10;



        for (int i = 0; i < buttonlist.Length; i++)
        {
            buttonlist[i].text = "";
        }

        reStartGame.SetActive(false);
    }
    public void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonlist.Length; i++)
        {
            buttonlist[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }

    public void SetPlayerButton(bool toggle)
    {
        playerX.button.interactable = toggle;
        playerO.button.interactable = toggle;
    }

    public void SetPlayerColorInactive()
    {
        playerX.panel.color = inactivePlayerColor.panelColor;
        playerX.text.color = inactivePlayerColor.textColor;
        playerO.panel.color = inactivePlayerColor.panelColor;
        playerO.text.color = inactivePlayerColor.textColor;

    }
}
