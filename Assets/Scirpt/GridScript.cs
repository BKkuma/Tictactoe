using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridScript : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Text butttontext;
    [SerializeField] private string playerSide;

    public void SetSpace()
    {
        butttontext.text = playerSide;
        button.interactable = false;
    }

}
