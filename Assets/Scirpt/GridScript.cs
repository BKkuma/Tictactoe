using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridScript : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Text butttontext;
    [SerializeField] private string playerSide;

    private GameController gameController;

    public void SetSpace()
    {
        butttontext.text = gameController.GetPlayerSide();
        button.interactable = false;
        gameController.EndTurn();
    }

    public void SetGameContorller(GameController controller)
    {
        gameController = controller;
    }

}
