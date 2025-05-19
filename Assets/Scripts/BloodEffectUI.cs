using UnityEngine;
using UnityEngine.UI;

public class BloodEffectUI : MonoBehaviour
{
    public Image bloodImage;
    public int maxHP = 30;
    public int currentHP = 30;

    private float targetAlpha = 0f;
    public float fadeSpeed = 2f;

    void Update()
    {
        // 현재 알파에서 목표 알파로 부드럽게
        Color c = bloodImage.color;
        c.a = Mathf.Lerp(c.a, targetAlpha, Time.deltaTime * fadeSpeed);
        bloodImage.color = c;

        // 테스트용: Space 눌러서 데미지 적용
        if (Input.GetButtonDown("Jump")) // 기본 키보드 스페이스바
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

        Debug.Log($"HP: {currentHP}, 알파: {targetAlpha}");
    }
}
