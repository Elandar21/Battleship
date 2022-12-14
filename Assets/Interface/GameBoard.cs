using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

// Holds the basic UI calls for the game board
public class GameBoard : MonoBehaviour
{
    //Casts a ray to the canvas 
    public GraphicRaycaster Raycaster;
    //EventSystem used with game
    public EventSystem GameEventSystem;
    //Board containing the logic for the user
    public PlayBoard userBoard; 
    //Board containing the logic for the opponent
    public PlayBoard opponentBoard;
    //AI class
    public AI opponent = new AI();
    //Dialog box to give guidance to the user
    public TMP_Text dialog;
    //Array of ships to be played
    public Ship[] ShipsToBePlayed = new Ship[5];
    //Current state of the game
    private GameStateEnum gameState = GameStateEnum.Setup;
    //Ship Place index
    private int shipPlaceIndex = 0;
    private Vector2 UserBoardLocation = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        if(dialog != null)
        {
            dialog.text = "Click on the tile to place a ship,\nclick on a second tile for direction.";
        }
        userBoard.SetGameState(gameState);
        opponentBoard.SetGameState(gameState);
        userBoard.ClickAction += RegisterClickEvent;
        UserBoardLocation = new Vector2(userBoard.shipParent.position.x, userBoard.shipParent.position.y);
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
    private void RegisterClickEvent(Vector2 position)
    {
        if(gameState == GameStateEnum.Setup)
        {
            if(userBoard.SetShips(ShipsToBePlayed[shipPlaceIndex], position))
            {
                opponentBoard.SetShips(ShipsToBePlayed[shipPlaceIndex], opponent.GetPosition());
                shipPlaceIndex++;
            }

            if(shipPlaceIndex >= ShipsToBePlayed.Length)
            {
                StartGame();
            }
        }
        else if(gameState == GameStateEnum.Play)
        {
            //Opponent click
            CastOpponentHit();
        }
    }

    //Sets the conditions to start the game
    private void StartGame()
    {
        gameState = GameStateEnum.Play;
        opponent.Reset();
        userBoard.SetGameState(gameState);
        opponentBoard.SetGameState(gameState);
        userBoard.Interact(true);
        opponentBoard.Interact(true);
        if(dialog != null)
        {
            dialog.text = "Click on a tile on the opponent board to shot at their ships.\nSink your opponents ships before they sink yours!\nGood Luck Hunting!";
        }
        userBoard.ShipSunkAction += BoardCleared;
        opponentBoard.ShipSunkAction += BoardCleared;
        userBoard.ClickAction -= RegisterClickEvent;
        opponentBoard.ClickAction += RegisterClickEvent;
    }

    //Imitates a button click, but from the UI on the user board
    private void CastOpponentHit()
    {
        if(Raycaster == null)
        {
            Debug.Log("GraphicRaycaster is not set on GameBoard");
            return;
        } 
        
        if(GameEventSystem == null)
        {
            Debug.Log("EventSystem has not been set on GameBoard");
            return;
        }
        
        PointerEventData pointData = new PointerEventData(GameEventSystem);
        
        Vector2 clickPos = UserBoardLocation + opponent.GetPosition();
        pointData.position = clickPos;

        Debug.Log($"Click Position: {clickPos}");

        List<RaycastResult> results = new List<RaycastResult>();
        Raycaster.Raycast(pointData, results);

        foreach(RaycastResult result in results)
        {   
            Button tile = result.gameObject.GetComponent<Button>();
            if(tile != null)
            {
                tile.onClick.Invoke();
                return;
            }
        }
    }
}