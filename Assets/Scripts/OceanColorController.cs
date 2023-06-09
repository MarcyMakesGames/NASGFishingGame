using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanColorController : MonoBehaviour
{
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private int numPoints = 4;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float transitionDuration = 1f;

    private Color[] distributedColors;
    private int pointIndex = 0;
    private float elapsedTime;
    private bool isTransitioning;

    private void Start()
    {
        distributedColors = GetDistributedColors(startColor, endColor, numPoints);

        GameManager.OnFishPoolDepleted += StartColorTransition;
    }

    private void Update()
    {
        if (pointIndex == distributedColors.Length - 1)
            return;

        if (isTransitioning)
        {
            float t = elapsedTime / transitionDuration;

            Color currentColor = Color.Lerp(distributedColors[pointIndex], distributedColors[pointIndex + 1], t);
            spriteRenderer.color = currentColor;

            elapsedTime += Time.deltaTime;

            if (elapsedTime >= transitionDuration)
            {
                spriteRenderer.color = distributedColors[pointIndex + 1];
                pointIndex++;
                isTransitioning = false;
            }
        }
    }

    private void OnDestroy()
    {
        GameManager.OnFishPoolDepleted -= StartColorTransition;
    }

    private Color[] GetDistributedColors(Color start, Color end, int numPoints)
    {
        Color[] colors = new Color[numPoints];

        for (int i = 0; i < numPoints; i++)
        {
            float t = (float)i / (numPoints - 1);

            // Interpolate between the start and end colors
            colors[i] = Color.Lerp(start, end, t);
        }

        return colors;
    }

    private void StartColorTransition()
    {
        // Reset the elapsed time and flag
        elapsedTime = 0f;
        isTransitioning = true;
    }
}

