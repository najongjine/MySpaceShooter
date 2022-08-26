using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuFXLifeTimer : MonoBehaviour
{
    [SerializeField]
    float timer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DeactivateGameObject),5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DeactivateGameObject()
    {
        Destroy(gameObject);
    }

}
