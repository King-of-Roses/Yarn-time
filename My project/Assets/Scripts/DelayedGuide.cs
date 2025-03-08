using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedGuide : MonoBehaviour
{
    public float delayBeforeShow = 1f;
    // 显示多少秒后隐藏
    public float displayDuration = 7f;

    private CanvasGroup canvasGroup;

    void Awake()
    {
        // 尝试获取 CanvasGroup，如果没有则添加一个
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
        // 初始时隐藏（透明度为0）
        canvasGroup.alpha = 0f;
    }

    void Start()
    {
        Invoke("ShowGuide", delayBeforeShow);
    }

    void ShowGuide()
    {
        canvasGroup.alpha = 1f;
        Invoke("HideGuide", displayDuration);
    }

    void HideGuide()
    {
        canvasGroup.alpha = 0f;
    }
}
