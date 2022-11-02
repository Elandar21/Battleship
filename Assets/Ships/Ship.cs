using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Details about the ship
public class Ship : MonoBehaviour
{
    //Ship image
    public GameObject background;
    //Indicates if the ship has been sunk
    public bool IsNotSunk = true;
    //Indicates if the ship is visible
    public bool IsVisible = false;
    //How many hits can the ship take
    public int HitsForShip = 2;
    //Hits taken by the ship
    private int hitsTaken = 0;

    //Sets the visibilty of ship
    void Start()
    {
        if(background != null)
        {
            background.SetActive(IsVisible);
        }
    }

    //Update is called once per frame
    void Update()
    {
        if(IsNotSunk && HitsForShip >= hitsTaken)
        {
            IsNotSunk = false;
        }
    }

    //Updates if the ship has been hit
    public void TakesHit()
    {
        //Need to get hit index
        hitsTaken++;
        Debug.Log("Hit");
    }

    //Places the ship on the gameboard
    public void PlaceShip(Vector2 ShipLocation, bool IsAcross)
    {
        if(transform is RectTransform rect)
        {
            if(IsAcross)
            {
                rect.rotation = Quaternion.AngleAxis(90, Vector3.forward);
                ShipLocation.x -= 40;
            }
            rect.anchoredPosition = ShipLocation;
        }
    }

    //Indicates that the ship has been hit
    public void Hit()
    {
        Debug.Log("Ship Click");
    }
}
