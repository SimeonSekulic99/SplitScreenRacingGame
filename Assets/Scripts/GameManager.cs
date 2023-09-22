using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Setting up all the GUI elements 
    public GameObject menuScreen;
    public GameObject characterSelectScreen;
    public GameObject levelSelectScreen;
    public GameObject gameOverScreen;
    public GameObject gameStart;
    public GameObject pauseScreen;
    public GameObject optionsScreen;
    public GameObject optionspauseScreen;
    public GameObject player1Check;
    public GameObject player2Check;

    //Setting the light
    public Light myLight;

    //Setting the particle systems for rain and rain toggles
    public ParticleSystem rainP1;
    public ParticleSystem rainP2;
    public Toggle toggleRain1;
    public Toggle toggleRain2;

    //Setting the input fields for the players in the GUI
    public TMP_InputField inputPlayer1;
    public TMP_InputField inputPlayer2;
    public GameObject Player1Name;
    public GameObject Player2Name;

    public Slider volumeSlider; //Setting volume slider for the options menu

    public AudioSource audioSource; //Setting the source of sound

    //Game state and player ready
    bool gamestartedcheck = false;
    bool player1Ready = false;
    bool player2Ready = false;

    //Setting the gui components for winner name and time
    public TextMeshProUGUI winnerlabel;
    public TextMeshProUGUI winnertime;

    //Time display label and variabes for keeping track of time
    public TextMeshProUGUI timerText;
    private float timePassed = 0f;
    public string minutes;
    public string seconds;

    void Start()
    {
        Time.timeScale = 0; //Freezing the game time at the start

        //Setting all of the GUI components to false and opening the main menu GUI
        player1Check.SetActive(false);
        player2Check.SetActive(false);
        characterSelectScreen.SetActive(false);
        levelSelectScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        gameStart.SetActive(false);
        pauseScreen.SetActive(false);
        optionsScreen.SetActive(false);
        optionspauseScreen.SetActive(false);
        menuScreen.SetActive(true);

        //Setting the default names for players
        Player1Name.name = "Player1";
        Player2Name.name = "Player2";

        volumeSlider.value = 0.3f; //Default Volume at the start of the game
    }
    void Update()
    {
        //Opens the pause menu if the player presses the pause button(esc) and if the game is being played
        if ((Input.GetKey(KeyCode.Escape)) && gamestartedcheck) ShowPauseScreen();

        timePassed += Time.deltaTime; //Uses delta time of the game to keep track of real life time pass
        minutes = ((int)timePassed / 60).ToString();  // Convert the elapsed time to minutes
        seconds = (timePassed % 60).ToString("f2");  // Convert the remaining time to seconds

        timerText.text = "Time: " + minutes + ":" + seconds;  // update the GUI Text element
    }
    
    //Opens the options menu
    public void openOptions()
    {
        menuScreen.SetActive(false);
        optionsScreen.SetActive(true);
        pauseScreen.SetActive(false);
    }

    //Opens the options menu when the game has been paused
    public void openOptionsPause()
    {
        menuScreen.SetActive(false);
        optionspauseScreen.SetActive(true);
        pauseScreen.SetActive(false);
    }

    //Opens the main menu
    public void ShowMenuScreen()
    {
        characterSelectScreen.SetActive(false);
        optionsScreen.SetActive(false);
        optionspauseScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        menuScreen.SetActive(true);
    }

    //Opens the pause menu
    public void ShowPauseScreen()
    {
        Time.timeScale = 0;
        gamestartedcheck = false;
        menuScreen.SetActive(false);
        characterSelectScreen.SetActive(false);
        levelSelectScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        gameStart.SetActive(false);
        pauseScreen.SetActive(true);
        optionspauseScreen.SetActive(false);
    }

    //Resumes the game after leaving pause menu
    public void resume()
    {
        optionspauseScreen.SetActive(false);
        Time.timeScale = 1;
        gamestartedcheck = true;
        levelSelectScreen.SetActive(false);
        gameStart.SetActive(true);
        pauseScreen.SetActive(false);
    }

    //Opens the car select screen
    public void ShowCharacterSelectScreen()
    {
        player1Ready = false;
        player1Ready = false;
        optionspauseScreen.SetActive(false);
        levelSelectScreen.SetActive(false);
        player1Check.SetActive(false);
        player2Check.SetActive(false);
        menuScreen.SetActive(false);
        characterSelectScreen.SetActive(true);
    }

    //Checks if player 1 is ready
    public void p1Ready()
    {
        if (player1Ready == false)
        {
            player1Ready = true;
            player1Check.SetActive(true);
        }
        else {
            player1Ready = false;
            player1Check.SetActive(false);
        }

    }

    //Checks if player 2 is ready
    public void p2Ready()
    {
        if (player2Ready == false)
        {
            player2Ready = true;
            player2Check.SetActive(true);
        }
        else
        {
            player2Ready = false;
            player2Check.SetActive(false);
        }

    }

    //Opens the level select screen
    public void ShowLevelSelectScreen()
    {
        gameOverScreen.SetActive(false);
        if (player1Ready && player2Ready)
        {
            characterSelectScreen.SetActive(false);
            levelSelectScreen.SetActive(true);
        } else {
            ShowCharacterSelectScreen();
            player1Ready = false;
            player2Ready = false;
        }
    }

    //Starts the game
    public void StartGame()
    {
        Time.timeScale = 1;
        gamestartedcheck = true;
        levelSelectScreen.SetActive(false);
        gameStart.SetActive(true);
    }

    //Opens the game over screen
    public void ShowGameOverScreen()
    {
        gameStart.SetActive(false);
        levelSelectScreen.SetActive(false);
        gameOverScreen.SetActive(true);
        gamestartedcheck = false;
    }

    //Restarts the game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateWinnerText(string input) { winnerlabel.text = input; } //Sets the name of the winner

    public void UpdateWinnerTime(string input) { winnertime.text = input; } //Sets the time it took for the winner to get to the finish line

    //Closes the game
    public void Quit()
    {
        Application.Quit();
    }

    //Updates the default player names to the names that the players have input
    public void UpdateName()
    {
        if (inputPlayer1.text != "") Player1Name.name = inputPlayer1.text; else Player1Name.name = "Player1";
        if (inputPlayer2.text != "") Player2Name.name = inputPlayer2.text; else Player2Name.name = "Player2";
    }

    public void SetVolume()
    {
        audioSource.volume = volumeSlider.value; //Sets the volume of the music
    }

    //Toggles rain for player 1
    public void ToggleRain1()
    {
        if (toggleRain1.isOn) {
            rainP1.Play(); rainP2.Play(); toggleRain2.isOn = true; myLight.color = HexToColor("747474"); 
        } else { 
            rainP1.Stop(); rainP2.Stop(); toggleRain2.isOn = false;  myLight.color = HexToColor("B4AA8C"); }
    }

    //Toggles rain for player 2
    public void ToggleRain2()
    {
        if (toggleRain2.isOn)
        {
            rainP1.Play(); rainP2.Play(); toggleRain1.isOn = true; myLight.color = HexToColor("747474");
        } else {
            rainP1.Stop(); rainP2.Stop(); toggleRain1.isOn = false; myLight.color = HexToColor("B4AA8C");
        }

    }

    //Hex to color converter for rain particles
    Color HexToColor(string hex)
    {
        hex = hex.Replace("0x", "");
        hex = hex.Replace("#", "");
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        return new Color32(r, g, b, 255);
    }
}
