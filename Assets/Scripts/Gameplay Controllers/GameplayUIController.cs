using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIController : MonoBehaviour
{
    public static GameplayUIController instance { get; private set; }

    [SerializeField]
    Text waveInfoTxt, shipsDestroyedInfoTxt, meteorsDestroyedInfoTxt;

    int waveCount, shipsDestroyedCount, meteorDestroyedCount;

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
    public void SetWave()
    {
        waveCount++;
        waveInfoTxt.text = $"Wave : {waveCount}";
    }
    public void ShipsDestroyed()
    {
        shipsDestroyedCount++;
        shipsDestroyedInfoTxt.text = $"{shipsDestroyedCount} x ";
    }
    public void SetMeteorsDestroyed()
    {
        meteorDestroyedCount++;
        meteorsDestroyedInfoTxt.text = $"{meteorDestroyedCount} x ";
    }
    public int GetShipsDestroyedCount()
    {
        return shipsDestroyedCount;
    }
    public int GetMeteorsDestroyedCount()
    {
        return meteorDestroyedCount;
    }
    public int GetWaveCount()
    {
        return waveCount;
    }
    public void SetInfo(int infoType)
    {
        switch (infoType)
        {
            case 1:
                waveCount++;
                waveInfoTxt.text = $"Wave : {waveCount}";
                break;
            case 2:
                shipsDestroyedCount++;
                shipsDestroyedInfoTxt.text = $"{shipsDestroyedCount} x ";
                break;
            case 3:
                meteorDestroyedCount++;
                meteorsDestroyedInfoTxt.text = $"{meteorDestroyedCount} x ";
                break;
        }
    }

}
