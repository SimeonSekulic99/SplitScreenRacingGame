using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Script for changing the image on the track selection screen
public class ImageChanger : MonoBehaviour
{
    public Image imageToChange; //Sets the image that needs to change
    public Sprite[] sprites; //Array of sprites that are used to represent each of the taracks
    public int currentSpriteIndex = 0; //The index of the current sprite being desplayed in the image component
    public GameObject[] tracks; //Used for instantiating the barricades on the track based on the trackIndex

    //Changes to the next image when pressing the right arrow in the GUI on the track select screen
    public void ChangeImageNext()
    {
        currentSpriteIndex++;
        if (currentSpriteIndex >= sprites.Length)
        {
            currentSpriteIndex = 0;
        }
        imageToChange.sprite = sprites[currentSpriteIndex];
    }

    //Changes to the previous image when pressing the right arrow in the GUI on the track select screen
    public void ChangeImagePrevious()
    {
        if (currentSpriteIndex <= 0)
        {
            currentSpriteIndex = sprites.Length - 1;
        }
        else
        {
            currentSpriteIndex -= 1;
        }
        imageToChange.sprite = sprites[currentSpriteIndex];
    }

    //Instantiates the track based on the current track selected
    public void PickTrack()
    {
        var trackPicked = Instantiate(tracks[currentSpriteIndex]);
    }
}