using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Holds the basic UI calls for the game board
public class GameBoard : MonoBehaviour
{
    //Board containing the logic for the user
    public PlayBoard userBoard; 
    //Board containing the logic for the opponent
    public PlayBoard opponentBoard;
    //Dialog box to give guidance to the user
    public TMP_Text dialog;
    //Total ship count of the game
    public int TotalShipCount = 5;
    //Current state of the game
    private GameStateEnum gameState = GameStateEnum.Setup;

    // Start is called before the first frame update
    void Start()
    {
        if(dialog != null)
        {
            dialog.text = "Click on the tile to place a ship,\nclick on a second tile for direction.";
        }
        
        opponentBoard.ShipsSunk += BoardCleared;
        userBoard.ShipsSunk += BoardCleared;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState == GameStateEnum.Setup && ShipsPlacedCount > TotalShipCount)
        {
            gameState = GameStateEnum.Play;
            if(dialog != null)
            {
                dialog.text = "Click on a tile on the opponent board to shot at their ships.\nSink your opponents ships before they sink yours!\nGood Luck Hunting!";
            }
        }
    }

    //Indicates if the user won or lost
    private void BoardCleared(bool IsUser)
    {
        if(dialog != null)
        {
            if(!IsUser)
            {
                dialog.text = "You Won!";
            }
            else
            {
                dialog.text = "Next time...";
            }
        }
    }
}