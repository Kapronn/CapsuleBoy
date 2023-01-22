using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageImageScript : MonoBehaviour
{
    private Image _damageImage;

    private void Start()
    {
        _damageImage = gameObject.GetComponent<Image>();
        _damageImage.enabled = false;
    }

    public void CallDamageVisualEffect()
    {
        StartCoroutine(DamageEffect());
    }

    IEnumerator DamageEffect()
    {
        _damageImage.enabled = true;
        for (float time = 1; time > 0; time -= Time.deltaTime )
        {
            _damageImage.color = new Color(1, 0, 0,time);
        yield return null;
        }

        _damageImage.enabled = false;
    }
}
