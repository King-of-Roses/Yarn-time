using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FmodEvents : MonoBehaviour
{
    [field: Header("Ambience")]

    [field: SerializeField] public EventReference ambience { get; private set; }

    [field: Header("Music")]

    [field: SerializeField] public EventReference music { get; private set; }

    [field: Header("Player SFX")]

    [field: SerializeField] public EventReference playerFootSteps { get; private set; }

    public static FmodEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Fmod Events in the scene.");
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
