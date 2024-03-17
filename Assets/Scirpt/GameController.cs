using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player
{
    public Image panel;
    public Text text;
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
    [SerializeField] private bool playerMove;
    [SerializeField] float delay;
    [SerializeField] private Player playerX;
    [SerializeField] private Player playerO;
    [SerializeField] private PlayerColor activePlayerColor;
    [SerializeField] private PlayerColor inactivePlayerColor;

    private string playerSide;
    private string aiSide;
    private int value;
    private int moveCount;

    private void Awake()
    {
        gameOverPanal.SetActive(false);
        SetGameControllerOnButton();
        playerSide = "X";
        moveCount = 0;
        reStartGame.SetActive(false);
        playerMove = true;
        SetPlayerColor(playerX,playerO);
    }
    private void SetGameControllerOnButton()
    {
        for (int i = 0; i < buttonlist.Length; i++)
        {
            buttonlist[i].GetComponentInParent<GridScript>().SetGameContorller(this);
        }
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
        if (buttonlist[3].text == playerSide && buttonlist[4].text == playerSide && buttonlist[5].text == playerSide)
        {
            GameOver(playerSide);
        }
        if (buttonlist[6].text == playerSide && buttonlist[7].text == playerSide && buttonlist[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        if (buttonlist[0].text == playerSide && buttonlist[3].text == playerSide && buttonlist[6].text == playerSide)
        {
            GameOver(playerSide);
        }
        if (buttonlist[1].text == playerSide && buttonlist[4].text == playerSide && buttonlist[7].text == playerSide)
        {
            GameOver(playerSide);
        }
        if (buttonlist[2].text == playerSide && buttonlist[5].text == playerSide && buttonlist[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        if (buttonlist[0].text == playerSide && buttonlist[4].text == playerSide && buttonlist[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        if (buttonlist[2].text == playerSide && buttonlist[4].text == playerSide && buttonlist[6].text == playerSide)
        {
            GameOver(playerSide);
        }

        if (moveCount >= 9)
        {
            GameOver("draw");
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
        }
        else
        {
            SetGameOverText(playerSide + " You are very strong!");
        }
        reStartGame.SetActive(true);

    }

    public void ChangeSide()
    {
        playerSide = (playerSide == "X") ? "O" : "X";

        if (playerSide == "X")
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
        playerSide = "X";
        moveCount = 0;
        gameOverPanal.SetActive(false);


        SetBoardInteractable(true);

        for (int i = 0; i < buttonlist.Length; i++)
        {
            buttonlist[i].text = "";
        }

        SetPlayerColor(playerX, playerO);
        reStartGame.SetActive(false);
    }
    public void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonlist.Length; i++)
        {
            buttonlist[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }
}
