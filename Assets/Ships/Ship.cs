using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Details about the ship
public class Ship : MonoBehaviour
{
    //Ship image background
    public GameObject background;
    //Contains the hit buttons for the ship
    public Tile[] HitTiles;
    //Indicates if the ship has been sunk
    public bool IsNotSunk = true;
    //How many hits can the ship take
    public int HitsForShip = 2;
    //Hits taken by the ship
    private int hitsTaken = 0;

    //Updates if the ship has been hit
    public void TakesHit(Transform tile)
    {
        hitsTaken++;
        Debug.Log("Hit");
        if(IsNotSunk && HitsForShip <= hitsTaken)
        {
            IsNotSunk = false;
        }
    }

    //Places the ship on the gameboard
    public void PlaceShip(Vector2 ShipLocation, bool IsVisible)
    {
        if(transform is RectTransform rect)
        {
            bool odd = HitsForShip%2 != 0;
            rect.anchoredPosition = ShipLocation - new Vector2(-20, odd ? 20 : 0);
        }

        if(background != null)
        {
            background.SetActive(IsVisible);
        }
    }

    //Sets the tile to be interactable
    public void SetInteractable(bool isInteractable, bool isDisplayed)
    {
        if(HitTiles == null)
        {
            Debug.Log("No tiles set on ship");
            return;
        }

        for(int i = 0; i < HitTiles.Length; i++)
        {
            HitTiles[i].SetInteractable(isInteractable);
            if(isInteractable)
                HitTiles[i].ClickedEvent += TakesHit;
            else
                HitTiles[i].ClickedEvent -= TakesHit;
            HitTiles[i].SetDisplay(isDisplayed);
        }
    }
}
