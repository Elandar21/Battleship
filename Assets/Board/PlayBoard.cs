using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections.Generic;

//creates the game board on startup
public class PlayBoard : MonoBehaviour
{
    // Ship objects
    public List<Ship> Ships;
    // Tiles objects
    public Tile[] Tiles = new Tile[100];
    // tile prefab
    public Tile tilePrefab;
    // tile parent
    public Transform tileParent;
    // ship parent
    public Transform shipParent;
    //IsUser
    public bool IsUserBoard = false;
    //All Ships have been sunk
    private bool ShipsSunk = false;
    //Action on ships sunk
    public Action<bool> ShipSunkAction;
    //Action on user click on board
    public Action<Vector2> ClickAction;
    //current game state
    private GameStateEnum currentState;

    // Start is called before the first frame update
    void Start()
    {
        SetTiles();
        Ships = new List<Ship>();
    }

    //Sets the tiles to the board
    private void SetTiles()
    {
        for(int y = 0; y < 100; y++)
        {
            Tiles[y] = Instantiate<Tile>(tilePrefab, tileParent);
            Tiles[y].ClickedEvent += ClickedTile;
            //Tiles[y].SetInteractable(!IsUserBoard);
        }
    }

    //Sets the current game state to the board
    public void SetGameState(GameStateEnum state)
    {
        currentState = state;
    }

    //Sets the tiles to the board
    public bool SetShips(Ship shipPrefab, Vector2 position)
    {
        Debug.Log("Setting Ship");
        //check that ship can be set in bounds
        //Can not place ships on other ships
        Ships.Add(Instantiate(shipPrefab, shipParent));
        int LastIndex = Ships.Count() - 1;
        Ships[LastIndex].PlaceShip(position, IsUserBoard);
        Ships[LastIndex].SetInteractable(!IsUserBoard, false);

        return true;
    }

    //Indicates the tile has been clicked
    private void ClickedTile(Transform transform)
    {
        ClickAction?.Invoke((transform as RectTransform).anchoredPosition);
        
        if(currentState == GameStateEnum.Play)
        {
            if(!ShipsSunk && Ships.All(ship => !ship.IsNotSunk))
            {
                Debug.Log("Ships Sunk");
                ShipsSunk = true;
                ShipSunkAction?.Invoke(IsUserBoard);
            }
        }
    }

    //Sets the ships and board to be interactable
    public void Interact(bool isInteractable)
    {
        for(int y = 0; y < Tiles.Length; y++)
        {
            Tiles[y].SetInteractable(!IsUserBoard);
            Tiles[y].SetDisplay(isInteractable);
            if(y < Ships.Count)
                Ships[y].SetInteractable(!IsUserBoard, isInteractable);
        }
    }
}
