using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedGuide : MonoBehaviour
{
    public float delayBeforeShow = 1f;
    // ��ʾ�����������
    public float displayDuration = 7f;

    private CanvasGroup canvasGroup;

    void Awake()
    {
        // ���Ի�ȡ CanvasGroup�����û�������һ��
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
        // ��ʼʱ���أ�͸����Ϊ0��
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
