using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLifeTimer : MonoBehaviour
{
    [SerializeField]
    float timer = 5f;
    // Start is called before the first frame update

    /*
    void Start()
    {
        Destroy(gameObject,timer);
    }
    */
    private void OnEnable()
    {
        Invoke(nameof(DeactivateProjectile), timer);
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(DeactivateProjectile));
    }
    void DeactivateProjectile()
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }

}
