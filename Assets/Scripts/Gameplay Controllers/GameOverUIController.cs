using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{
    public static GameOverUIController instance { get; private set; }

    [SerializeField]
    Canvas playerInfoCanvas, ShipsAndMeteorInfoCanvas, gameOverCanvas;

    [SerializeField]
    Text shipsDestroyedFinalInfoTxt, meteorDestroyedFinalInfoTxt, waveFinalInfoTxt;

    [SerializeField]
    Text shipsDestroyedHighscoreTxt, meteorDestroyedHighscoreTxt, waveHighscoreTxt;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenGameOverPanel()
    {
        playerInfoCanvas.enabled = false;
        ShipsAndMeteorInfoCanvas.enabled = false;
        gameOverCanvas.enabled = true;

        var shipsDestroyedFinal = GameplayUIController.instance.GetShipsDestroyedCount();
        var meteorDestroyedFinal = GameplayUIController.instance.GetMeteorsDestroyedCount();
        var waveCountFinal = GameplayUIController.instance.GetWaveCount() -1;

        shipsDestroyedFinalInfoTxt.text = $" x {shipsDestroyedFinal}";
        meteorDestroyedFinalInfoTxt.text = $" x {meteorDestroyedFinal}";
        waveFinalInfoTxt.text = $"Wave : {waveCountFinal}";


        CalculateHighscore(shipsDestroyedFinal, meteorDestroyedFinal, waveCountFinal);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    void CalculateHighscore(int shipsDestroyedCurrent, int meteorsDestroyedCurrent, int waveCurrent)
    {

        int shipsDestroyed_Highscore = DataManager.GetData(TagManager.SHIPS_DESTROYED_DATA);
        int meteorsDestroyed_Highscore = DataManager.GetData(TagManager.METEORS_DESTROYED_DATA);
        int waveHighscore = DataManager.GetData(TagManager.WAVE_NUMBER_DATA);

        if (shipsDestroyedCurrent > shipsDestroyed_Highscore)
            DataManager.SaveData(TagManager.SHIPS_DESTROYED_DATA, shipsDestroyedCurrent);

        if (meteorsDestroyedCurrent > meteorsDestroyed_Highscore)
            DataManager.SaveData(TagManager.METEORS_DESTROYED_DATA, meteorsDestroyedCurrent);

        if (waveCurrent > waveHighscore)
            DataManager.SaveData(TagManager.WAVE_NUMBER_DATA, waveCurrent);

        shipsDestroyedHighscoreTxt.text = "x" + DataManager.GetData(TagManager.SHIPS_DESTROYED_DATA);
        meteorDestroyedHighscoreTxt.text = "x" + DataManager.GetData(TagManager.METEORS_DESTROYED_DATA);
        waveHighscoreTxt.text = "Wave: " + DataManager.GetData(TagManager.WAVE_NUMBER_DATA);

    }
}
