using UnityEngine;
using System;

//Represents the tile object
public class Tile : MonoBehaviour
{
    //Allows devices to subscribe to click event
    public Action<Transform> ClickedEvent;

    //Sends the message up that the tile has been clicked
    public void Clicked()
    {
        ClickedEvent?.Invoke(transform);
    }
}