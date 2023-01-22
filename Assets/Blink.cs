using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] private Renderer[] _renderers;

    public void StartBlink()
    {
        StartCoroutine(BlinkEffect());
    }

    IEnumerator BlinkEffect()
    {
        for (float time = 0; time < 0.3; time += Time.deltaTime)
        {
            for (int i = 0; i < _renderers.Length; i++)
            {
                _renderers[i].material.SetColor("_EmissionColor",
                    new Color(Mathf.Sin((time * 30) * 0.5f + 0.5f), 0, 0, 0));
                yield return null;
            }
        }
    }
}
