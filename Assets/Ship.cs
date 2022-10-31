﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Details about the ship
public class Ship : MonoBehaviour
{
    //Ship image
    public GameObject background;
    //Indicates if the ship has been sunk
    public bool IsSunk = false;
    //Indicates if the ship is visible
    public bool IsVisible = false;
    //How many hits can the ship take
    public int HitsForShip = 2;
    //Indicates the bottom left corner of the ship on the grid
    public Vector2 ShipLocation;
    //Indicates if the ship is across
    public bool IsAcross;
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
        if(!IsSunk && HitsForShip >= hitsTaken)
        {
            IsSunk = true;
        }
    }

    //Updates if the ship has been hit
    public void TakesHit()
    {
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
}
