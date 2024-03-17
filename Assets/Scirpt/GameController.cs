using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Text[] buttonlist;

    private string playerSide;

    private void Awake()
    {
        SetGameControllerOnButton();
        playerSide = "X";
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
        if (buttonlist[0].text == playerSide && buttonlist[1].text == playerSide && buttonlist[2].text == playerSide)
        {
            GameOver();
        }
        if (buttonlist[3].text == playerSide && buttonlist[4].text == playerSide && buttonlist[5].text == playerSide)
        {
            GameOver();
        }
        if (buttonlist[6].text == playerSide && buttonlist[7].text == playerSide && buttonlist[8].text == playerSide)
        {
            GameOver();
        }
        if (buttonlist[0].text == playerSide && buttonlist[3].text == playerSide && buttonlist[6].text == playerSide)
        {
            GameOver();
        }
        if (buttonlist[1].text == playerSide && buttonlist[4].text == playerSide && buttonlist[7].text == playerSide)
        {
            GameOver();
        }
        if (buttonlist[2].text == playerSide && buttonlist[5].text == playerSide && buttonlist[8].text == playerSide)
        {
            GameOver();
        }
        if (buttonlist[0].text == playerSide && buttonlist[4].text == playerSide && buttonlist[8].text == playerSide)
        {
            GameOver();
        }
        if (buttonlist[2].text == playerSide && buttonlist[4].text == playerSide && buttonlist[6].text == playerSide)
        {
            GameOver();
        }

        ChangeSide();
    }

    public void GameOver()
    {
        for (int i = 0;i < buttonlist.Length;i++)
        {
            buttonlist[i].GetComponentInParent<Button>().interactable = false;
        }
    }

    public void ChangeSide()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }
}
