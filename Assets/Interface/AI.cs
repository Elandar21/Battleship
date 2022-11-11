using UnityEngine;
using System.Collections.Generic;

//Basic AI class
public class AI
{
    //contains a list of all the index the AI has pressed
    public List<Vector2> availablePositions;

    //generic constructor
    public AI()
    {
        Reset();
    }

    //Resets the list of available indexes
    public void Reset()
    {
        availablePositions = new List<Vector2>();
        for(int i = 0; i < 100; i++)
        {
            availablePositions.Add(new Vector2((i%10)*40, -(i/10)*40));
        }        
    }

    //Gets an available position from the AI
    public Vector2 GetPosition()
    {
        int index = (int)(Random.value * availablePositions.Count);
        if(index > 0)
        {
            Vector2 tmpPos = availablePositions[index];
            availablePositions.RemoveAt(index);
            return tmpPos;
        }
        return new Vector2();
    } 
}