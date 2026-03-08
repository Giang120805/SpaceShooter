using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 0.5f;

    private Renderer bgRenderer;

    void Start()
    {
        bgRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;

        bgRenderer.material.mainTextureOffset = new Vector2(0, offset);
    }
}