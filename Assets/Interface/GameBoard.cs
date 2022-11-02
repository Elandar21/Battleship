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
    //Array of ships to be played
    public Ship[] ShipsToBePlayed;
    //Current state of the game
    private GameStateEnum gameState = GameStateEnum.Setup;
    //Indicates if it is the players turn
    private bool IsPlayerTurn = true;

    // Start is called before the first frame update
    void Start()
    {
        if(dialog != null)
        {
            dialog.text = "Click on the tile to place a ship,\nclick on a second tile for direction.";
        }
        opponentBoard.ShipSunkAction += BoardCleared;
        //opponentBoard.SetShips(ShipsToBePlayed);

        userBoard.ShipSunkAction += BoardCleared;
        //userBoard.SetShips(ShipsToBePlayed);
        userBoard.ClickAction += RegisterClickEvent;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState == GameStateEnum.Setup &&  userBoard.ShipsSet && opponentBoard.ShipsSet)
        {
            gameState = GameStateEnum.Play;
            if(dialog != null)
            {
                dialog.text = "Click on a tile on the opponent board to shot at their ships.\nSink your opponents ships before they sink yours!\nGood Luck Hunting!";
            }
        }

        if(gameState == GameStateEnum.Play)
        {
            if(!IsPlayerTurn)
            {
                //Execute AI
                int x = (int)Random.value * 10;
                int y = (int)Random.value * 10;
                userBoard.CastUIHit(x*40, y*40);
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
                dialog.text = "We have met the enemy and they are ours...  -Oliver Hazard Perry";
            }
            else
            {
                dialog.text = "I have not yet begun to fight! -John Paul Jones";
            }
        }
    }

    //User click event
    private void RegisterClickEvent()
    {
        IsPlayerTurn = false;
    }
}