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
    //Image that is displayed for the tile
    public Image TileImage;
    //Material to display when the tile is clicked
    public Material ClickedMaterial;
    //Indicates if the tile display
    private bool displayClickedMaterial = false;

    //Sends the message up that the tile has been clicked
    public void Clicked()
    {
        ClickedEvent?.Invoke(transform);
        if(displayClickedMaterial)
            TileImage.material = ClickedMaterial;
    }

    //Sets the tile to be interactable
    public void SetInteractable(bool isInteractable)
    {
        if(button != null)
            button.interactable = isInteractable;
        displayClickedMaterial = isInteractable;
    }
}