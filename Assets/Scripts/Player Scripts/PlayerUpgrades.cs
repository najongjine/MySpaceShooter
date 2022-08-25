using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    [SerializeField]
    WeaponUpgrade weaponUpgrade;

    Collectable collectable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyCollectable( Collectable coll)
    {
        if (coll?.type != CollectableType.Health)
        {
            Destroy(coll.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag==TagManager.COLLECTABLE_TAG)
        {
            collectable=collision?.gameObject?.GetComponent<Collectable>();
            if (collectable?.type==CollectableType.Blaster1)
            {
                weaponUpgrade.ActivateWeapon(0);
            }
            if (collectable?.type == CollectableType.Blaster2)
            {
                weaponUpgrade.ActivateWeapon(1);
            }
            if (collectable?.type == CollectableType.Rocket)
            {
                weaponUpgrade.ActivateWeapon(2);
            }
            if (collectable?.type == CollectableType.Missle)
            {
                weaponUpgrade.ActivateWeapon(3);
            }
            DestroyCollectable(collectable);
        }
       
    }

}
