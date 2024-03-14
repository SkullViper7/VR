using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Framerate : MonoBehaviour
{
    //private void Start()
    //{
    //    Application.targetFrameRate = 20;
    //}

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Camera cam = GetComponent<Camera>();

        RenderTexture m_SavedTexture = cam.targetTexture;

        if (m_SavedTexture == null)
            m_SavedTexture = Instantiate(source) as RenderTexture;

        if (Time.frameCount % 20 == 0)
            Graphics.Blit(source, m_SavedTexture);

        Graphics.Blit(m_SavedTexture, destination);
    }
}
