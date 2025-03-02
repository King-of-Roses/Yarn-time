using UnityEngine;
using UnityEngine.UI;

public class UIButtonSound : MonoBehaviour
{
    public void PlayClickSound()
    {
        AudioManager.instance.PlayOneShotUI(FmodEvents.instance.buttonClick);
    }

}
