using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Holds the basic UI calls for the game board
public class GameBoard : MonoBehaviour
{
    public PlayBoard userBoard; 
    public PlayBoard opponentBoard;
    public TMP_Text dialog;
    public int TotalShipCount = 5;

    private GameStateEnum gameState = GameStateEnum.Setup;
    private int ShipsPlacedCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(dialog != null)
            dialog.text = "Click on the tile to place a ship,\nclick on a second tile for direction.";
        
        userBoard.ClickAction += Click;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState == GameStateEnum.Setup && ShipsPlacedCount > TotalShipCount)
        {
            userBoard.ClickAction -= Click;
            gameState = GameStateEnum.Play;
            if(dialog != null)
                dialog.text = "Click on a tile on the opponent board to shot at their ships.\nSink your opponents ships before they sink yours!\nGood Luck Hunting!";
        }
    }

    private void Click(TileAction action)
    {
        //Place a ship, increment
    }
}