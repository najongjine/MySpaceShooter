using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    [SerializeField]
    float speed = 0.05f;
    float Y_Axis;
    Material bgMaterial;

    private void Awake()
    {
        bgMaterial = GetComponent<Renderer>().material;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Y_Axis += speed * Time.deltaTime;
        bgMaterial.SetTextureOffset("_MainTex", new Vector2(0f,Y_Axis));
    }
}
