using UnityEngine;
using UnityEngine.UI;
using System;

//creates the game board on startup
public class PlayBoard : MonoBehaviour
{
    // Ship objects
    public Ship[] Ships = new Ship[5];
    // Tiles objects
    public GameObject[] Tiles = new GameObject[100];
    // tile prefab
    public GameObject tilePrefab;
    // tile parent
    public Transform tileParent;
    // ship parent
    public Transform shipParent;
    //IsUser
    public bool IsUserBoard;

    public Action<TileAction> ClickAction;

    // Start is called before the first frame update
    void Start()
    {
        SetTiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Sets the tiles to the board
    private void SetTiles()
    {
        for(int y = 0; y < 10; y++)
        {
            for(int x = 0; x < 10; x++)
            {
                Tiles[y*10+x] = Instantiate(tilePrefab, tileParent);
                (Tiles[y*10+x].transform as RectTransform).anchoredPosition = new Vector2(40*x,40*y);
                Button button = Tiles[y*10+x].GetComponent<Button>();
                if(button != null)
                {
                    button.OnClick.AddListener();
                }
            }
        }
    }
}
