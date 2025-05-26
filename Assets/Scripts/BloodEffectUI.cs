using UnityEngine;
using UnityEngine.UI;

public class BloodEffectUI : MonoBehaviour
{
    public Image bloodImage;
    public Image[] bloodDrops; // 추가 피방울 스프라이트

    public int maxHP = 30;
    public int currentHP = 30;

    private float targetAlpha = 0f;
    public float fadeSpeed = 2f;

    void Update()
    {
        // 투명도 조절
        Color c = bloodImage.color;
        c.a = Mathf.Lerp(c.a, targetAlpha, Time.deltaTime * fadeSpeed);
        bloodImage.color = c;

        // 피 방울 투명도
        foreach (var drop in bloodDrops)
        {
            if (drop.enabled)
            {
                Color dropColor = drop.color;
                dropColor.a = c.a;
                drop.color = dropColor;
            }
        }

        // 테스트용 데미지
        if (Input.GetButtonDown("Jump"))
        {
            ApplyDamage(10);
        }
    }

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

    void UpdateBloodDrops(int count)
    {
        for (int i = 0; i < bloodDrops.Length; i++)
        {
            bloodDrops[i].enabled = i < count;
        }
    }
}