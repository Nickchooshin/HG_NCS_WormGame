using UnityEngine;
using System.Collections;

public class BossHealth : MonoBehaviour {

    public GUITexture health;
    private Boss boss;
    private Rect pixelInset;
    private float texWidth;

    void Start()
    {
        boss = gameObject.GetComponent<Boss>();

        pixelInset = health.pixelInset;
        texWidth = pixelInset.width;
    }

    void Update()
    {
        float fPercent = (float)(boss.Life) / 100.0f;
        float fR = (fPercent * 0.5f) + 0.5f;
        float fG = ((1.0f - fPercent) * 0.75f);

        health.color = new Color(fR, fG, 0.0f);

        pixelInset.width = texWidth * fPercent;
        health.pixelInset = pixelInset;
    }
}
