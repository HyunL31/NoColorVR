using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Blood Vignette
/// </summary>

public class BloodEffectUI : MonoBehaviour
{
    public Image bloodImage;
    public Image[] bloodDrops; // Additional Blood Drops

    public int maxHP = 30;
    public int currentHP = 30;

    private float targetAlpha = 0f;
    public float fadeSpeed = 2f;

    void Update()
    {
        // Alpha Control
        Color c = bloodImage.color;
        c.a = Mathf.Lerp(c.a, targetAlpha, Time.deltaTime * fadeSpeed);
        bloodImage.color = c;

        // Blood Drop Alpha
        foreach (var drop in bloodDrops)
        {
            if (drop.enabled)
            {
                Color dropColor = drop.color;
                dropColor.a = c.a;
                drop.color = dropColor;
            }
        }

        // for test
        if (Input.GetButtonDown("Jump"))
        {
            ApplyDamage(10);
        }
    }

    // Calculate Player's Damage with 3 stages
    public void ApplyDamage(int amount)
    {
        currentHP -= amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        float healthRatio = (float)currentHP / maxHP;
        targetAlpha = 1f - healthRatio;

        int dropCount = Mathf.Clamp((int)((1f - healthRatio) * bloodDrops.Length), 0, bloodDrops.Length);

        UpdateBloodDrops(dropCount);

        Debug.Log($"HP: {currentHP}, Alpha: {targetAlpha}, Blood count: {dropCount}");
    }

    // Adding Blood Drop
    void UpdateBloodDrops(int count)
    {
        for (int i = 0; i < bloodDrops.Length; i++)
        {
            bloodDrops[i].enabled = i < count;
        }
    }
}