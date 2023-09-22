using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public GameManager gameManager; //Imports the gameManager
    public string winner=""; //Initiate a variable for game winner

    //
    void OnCollisionEnter(Collision collision)
    {
        Time.timeScale = 0; //Stops the game
        gameManager.ShowGameOverScreen(); //Shows game over screen
        winner = (collision.gameObject.name); //Gets the name of the player that hit the finish line
        gameManager.UpdateWinnerText(winner); //Displays the name of the winner
        gameManager.UpdateWinnerTime(gameManager.minutes + ":" + gameManager.seconds); //Displays the time it took for the winner to get to the finish line
    }
}