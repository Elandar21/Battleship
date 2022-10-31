using UnityEngine;
using UnityEngine.UI;

//creates the game board on startup
public class PlayBoard : MonoBehaviour
{
    // Ship objects
    public Ship[] Ships = new Ship[5];
    // tiles objects
    public GameObject[] tiles = new GameObject[100];
    // tile prefab
    public GameObject tilePrefab;
    // tile parent
    public Transform tileParent;

    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < 10; x++)
        {
            for(int y = 0; y < 10; y++)
            {
                tiles[x*y] = Instantiate(tilePrefab, tileParent);
                (tiles[x*y].transform as RectTransform).anchoredPosition = new Vector2(40*x,40*y);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // shot miss
    private void Miss()
    {
        Debug.Log("Miss");
    }
}
