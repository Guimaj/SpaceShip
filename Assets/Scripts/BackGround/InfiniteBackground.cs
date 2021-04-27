using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{

    public float scrollSpeed;
    private Vector2 position;
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        this.meshRenderer = GetComponent<MeshRenderer>();
        this.position = new Vector2(0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        scrollBackground();
    }

    void scrollBackground()
    {
        float positionX = Time.time * scrollSpeed;
        this.position.x = positionX;
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", this.position);
    }

    public float GetScrollSpeed()
    {
        return this.scrollSpeed;
    }

    public void SetScrollSpeed(float speed)
    {
        this.scrollSpeed = speed;
    }
}
