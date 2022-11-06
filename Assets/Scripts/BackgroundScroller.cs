using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float backgroundScrollSpeed = 0.5f;
    Material background;
    Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<Renderer>().material;
        offset = new Vector2(0f, backgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        background.mainTextureOffset += offset * Time.deltaTime;
    }
}
