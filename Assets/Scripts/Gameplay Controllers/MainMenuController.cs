using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private Canvas mainMenuCanvas, highscoreCanvas;

    [SerializeField]
    private Text shipsDestroyedHighscore, meteorsDestroyedHighscore, wavesSurvivedHighscore;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenCloseHighscoreCanvas(bool open)
    {
        mainMenuCanvas.enabled = !open;
        highscoreCanvas.enabled = open;

        if (open)
            DisplayHighscore();

    }

    void DisplayHighscore()
    {
        shipsDestroyedHighscore.text = "x" + DataManager.GetData(TagManager.SHIPS_DESTROYED_DATA);
        meteorsDestroyedHighscore.text = "x" + DataManager.GetData(TagManager.METEORS_DESTROYED_DATA);
        wavesSurvivedHighscore.text = "Waves Survived: " + DataManager.GetData(TagManager.WAVE_NUMBER_DATA);
    }
}
