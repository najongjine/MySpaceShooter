using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == TagManager.PROJECTILE_TAG)
        {
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == TagManager.METEOR_TAG || collision.gameObject.tag == TagManager.COLLECTABLE_TAG)
        {
            Destroy(collision.gameObject);
        }
    }
}
