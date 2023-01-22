using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject healthIcon;

    private List<GameObject> _healthIcons = new List<GameObject>();

    public void Setup(int maxHealth)
    {
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject newIcon = Instantiate(healthIcon, transform);
            _healthIcons.Add(newIcon);
        }
    }

    public void HealthDisplay(int health)
    {
        for (int i = 0; i < _healthIcons.Count; i++)
        {
            _healthIcons[i].SetActive(i < health ? true : false);
        }
    }
}