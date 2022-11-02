using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

//creates the game board on startup
public class PlayBoard : MonoBehaviour
{
    // Ship objects
    public Ship[] Ships = new Ship[5];
    // Tiles objects
    public Tile[] Tiles = new Tile[100];
    // tile prefab
    public Tile tilePrefab;
    // tile parent
    public Transform tileParent;
    // ship parent
    public Transform shipParent;
    //IsUser
    public bool IsUserBoard;
    //Action on tile action
    public Action<TileAction> ClickAction;
    //Ships sunk
    private bool ShipsSunk = false;
    //Action on ships sunk
    public Action<bool> ShipSunkAction;

    // Start is called before the first frame update
    void Start()
    {
        SetTiles();
    }

    // Update is called once per frame
    void Update()
    {
        if(!ShipsSunk && !Ships.Any(ship => ship != null && ship.IsNotSunk))
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
            }
        }
    }

    private void ClickedTile(Transform tileTransform)
    {

    }
}
