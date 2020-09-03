using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LoadBar : MonoBehaviour
{
    private UnityEvent onProgressComplete;
    public Slider slider;
    public string scene;
    private float currentValue = 0f;
    public float CurrentValue  
    {
        get {
            return currentValue;
        }
        set {
            if (value >= slider.maxValue)
                onProgressComplete.Invoke();
            currentValue = value;
            slider.value = currentValue;
        }
    }
    void Start () 
    {
    CurrentValue = 0f;
    if (onProgressComplete == null)
            onProgressComplete = new UnityEvent();
        onProgressComplete.AddListener(OnProgressComplete);
    }

    void Update () {
        CurrentValue += 0.0153f;
    }

    // The method to call when the progress bar fills up
    void OnProgressComplete() {
        SceneManager.LoadScene(scene);
    }
}
