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
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
