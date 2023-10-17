using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class parallax : MonoBehaviour
{
   private MeshRenderer m_Renderer;
    public float animationspeed = 1f;

    private void Awake()
    {
        m_Renderer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        m_Renderer.material.mainTextureOffset += new Vector2(animationspeed * Time.deltaTime, 0);
    }
}
