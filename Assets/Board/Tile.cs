using UnityEngine;
using UnityEngine.UI;
using System;

//Represents the tile object
public class Tile : MonoBehaviour
{
    //Allows devices to subscribe to click event
    public Action<Transform> ClickedEvent;
    //Sets the button interaction
    public Button button;

    //Sends the message up that the tile has been clicked
    public void Clicked()
    {
        ClickedEvent?.Invoke(transform);
    }

    //Sets the tile to be interactable
    public void SetInteractable(bool isInteractable)
    {
        if(button != null)
            button.interactable = isInteractable;
    }
}