using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public TextMeshProUGUI CoordinateText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI Energy_Text;
    public static int CoordinateX = 0;
    public static int CoordinateY = 0;
    public static int Score = 0;
    public static float Energy = 500;
    public static float EnergyLimit = 500;
    public GameObject[] CoordinateObjects;

    void Start()
    {
        CoordinateX = PlayerPrefs.GetInt("SavedCoordinateX");
        CoordinateY = PlayerPrefs.GetInt("SavedCoordinateY");
        
        Score = PlayerPrefs.GetInt("SavedScore");
        
        Energy = PlayerPrefs.GetFloat("SavedEnergy");
        EnergyLimit = PlayerPrefs.GetFloat("SavedEnergyLimit");
    }

    void Update()
    {
        //Energy Number calculating
        if (Energy < 0)
        {
            Energy_Text.text = "0";
        }
        else
        {
            Energy_Text.text = "" + Energy;
        }

        PlayerPrefs.SetFloat("SavedEnergy", Energy);
        PlayerPrefs.SetFloat("SavedEnergyLimit", EnergyLimit);

        //cordinates
        if (CoordinateX == 0 && CoordinateY == 0)
        {
            DisableAll();
            CoordinateObjects[0].SetActive(true);
        }
        else
        {
            DisableAll();
        }

        CoordinateText.text = "(" + CoordinateX + "," + CoordinateY + ")";
        PlayerPrefs.SetInt("SavedCoordinateX", CoordinateX);
        PlayerPrefs.SetInt("SavedCoordinateY", CoordinateY);

        //score
        if (Score <= 0)
        {
            ScoreText.text = "0";
        }
        else
        {
            ScoreText.text = Score.ToString("#,#");
        }
        PlayerPrefs.SetInt("SavedScore", Score);
    }

    void DisableAll()
    {
        foreach (GameObject ObjectInArray in CoordinateObjects)
        {
            ObjectInArray.SetActive(false);
        }
    }
}
