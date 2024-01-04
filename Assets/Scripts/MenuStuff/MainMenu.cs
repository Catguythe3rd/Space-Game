using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Menus.GameIsPaused = false;
        SceneManager.LoadScene(1);
    }

    public void QuiteGame()
    {
        Debug.Log("When not in the editor, this would shut-down the game.");
        Application.Quit();
    }

    public void ResetGame()
    {
        PlayerPrefs.SetFloat("LastRotation", 0);
        PlayerPrefs.SetInt("SavedScore", 0);
        PlayerPrefs.SetFloat("SavedEnergy", 500);
        PlayerPrefs.SetFloat("SavedEnergyLimit", 500);
        PlayerPrefs.SetInt("SavedCoordinateX", 0);
        PlayerPrefs.SetInt("SavedCoordinateY", 0);
        PlayerPrefs.SetInt("BarInUse", 1);
        PlayerPrefs.SetInt("ControllesInUse", 1);
    }
}
