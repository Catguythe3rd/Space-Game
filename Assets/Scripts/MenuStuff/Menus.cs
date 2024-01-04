using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menus : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public static bool PlayerIsDead = false;
    public GameObject DeathMenuUI;
    private bool DeathSoundIsMade = false;
    private int BarInUse = 1;
    public GameObject EnergyBar;
    public GameObject EnergyNumber;
    public int ControllesInUse = 1;
    public TextMeshProUGUI InputUsedText;

    private void Start()
    {
        BarInUse = PlayerPrefs.GetInt("BarInUse");
        ControllesInUse = PlayerPrefs.GetInt("ControllesInUse");
    }

    void Update()
    {
        if (PlayerIsDead == false)
        {
            //this allows one button to pause and unpause.
            if (Input.GetButtonDown("Pause"))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        //this tells the game the player has died.
        if (SaveManager.Energy <= 0 && SaveManager.Energy <= 0)
        {
            PlayerIsDead = true;
            DeathMenuUI.SetActive(true);
            if (DeathSoundIsMade == false)
            {
                FindObjectOfType<AudioManager>().PlayZ("PlayerDeath");
                DeathSoundIsMade = true;
            }
        }

        //this tells the game what energy display to use.
        if (BarInUse == 1)
        {
            EnergyBar.SetActive(true);
            EnergyNumber.SetActive(false);
        }

        if (BarInUse == -1)
        {
            EnergyBar.SetActive(false);
            EnergyNumber.SetActive(true);
        }

        //this tells the game what text to use for the input setting.
        if (ControllesInUse == 1)
        {
            InputUsedText.text = "Input: -Key Board and Mouse-";
        }
        if (ControllesInUse == -1)
        {
            InputUsedText.text = "Input: -Controller-";
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void respawn()
    {
        PlayerIsDead = false;
        SaveManager.Energy = 500;
        DeathMenuUI.SetActive(false);
        SaveManager.Score -= 1000;
        if (SaveManager.Score < 0)
        {
            SaveManager.Score = 0;
        }
        SceneManager.LoadScene(1);
        DeathSoundIsMade = false;
        FindObjectOfType<AudioManager>().StopZ("PlayerDeath");
    }

    public void ChangeEnergy()
    {
        BarInUse *= -1;
        PlayerPrefs.SetInt("BarInUse", BarInUse);
    }

    public void ChangeControlles()
    {
        ControllesInUse *= -1;
        PlayerPrefs.SetInt("ControllesInUse", ControllesInUse);
    }
}
