using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

//creates the game board on startup
public class PlayBoard : MonoBehaviour
{
    // Ship objects
    public Ship[] Ships;
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
    //Sets the ships
    public bool ShipsSet;

    // Start is called before the first frame update
    void Start()
    {
        SetTiles();
        for(int i = 0; i < Ships.Length; i++)
        {
            Ships[i].SetInteractable(!IsUserBoard);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!ShipsSunk && Ships.All(ship => !ship.IsNotSunk))
        {
            ShipsSunk = true;
            ShipSunkAction?.Invoke(IsUserBoard);
        }
    }

    //Sets the tiles to the board
    private void SetTiles()
    {
        for(int y = 0; y < 10; y++)
        {
            for(int x = 0; x < 10; x++)
            {
                Tiles[y*10+x] = Instantiate<Tile>(tilePrefab, tileParent);
                Tiles[y*10+x].ClickedEvent += ClickedTile;
                Tiles[y*10+x].SetInteractable(!IsUserBoard);
            }
        }
    }

    //Sets the tiles to the board
    public void SetShips(Ship[] shipPrefabs)
    {
        Ships = new Ship[shipPrefabs.Length];
    }

    //Indicates the tile has been clicked
    private void ClickedTile(Transform tileTransform)
    {
        Debug.Log($"Tile has been clicked PlayBoard {(IsUserBoard?"User":"Opponent")}");
    }
}
