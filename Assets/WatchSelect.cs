using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WatchSelect : MonoBehaviour
{
    [SerializeField] private List<GameObject> watchModels = new List<GameObject>();
    [SerializeField] private GameObject w1Window;
    [SerializeField] private GameObject w2Window;
    [SerializeField] private GameObject w3Window;

    Animation w1WindowAnimation;
    Animation w2WindowAnimation;
    Animation w3WindowAnimation;

    //string _string;
    //string _buttonName;
    private void Start()
    {
        w1WindowAnimation = w1Window.GetComponent<Animation>();
        w2WindowAnimation = w2Window.GetComponent<Animation>();
        w3WindowAnimation = w3Window.GetComponent<Animation>();
    }


    public void OnWatchButtonClick(GameObject selectedModel)
    {
        string _string = selectedModel.name;

        // 1) show selected watch model on user's wrist
        foreach (var model in watchModels)
        {
            model.SetActive(model == selectedModel);
        }

        // 2) Animate watch window
        PlayAnimation(_string, 1);

    }

    public void PlayAnimation(string _string, int _speed)
    {
        if (_string == "Watch 1" || _string == "w1close")
        {
            w1WindowAnimation["w1animation"].speed = _speed;
            //if speed is -1 ,play reverse animation through its entire length/duration. Don't abruptly switch to initial state.
            if (_speed == -1) w1WindowAnimation["w1animation"].time = w1WindowAnimation["w1animation"].length;
            w1WindowAnimation.Play();
        }
        if (_string == "Watch 2" || _string == "w2close")
        {
            w2WindowAnimation["w2animation"].speed = _speed;
            if (_speed == -1) w2WindowAnimation["w2animation"].time = w2WindowAnimation["w2animation"].length;
            w2WindowAnimation.Play();
        }
        if (_string == "Watch 3" || _string == "w3close")
        {
            w3WindowAnimation["w3animation"].speed = _speed;
            if (_speed == -1) w3WindowAnimation["w3animation"].time = w3WindowAnimation["w3animation"].length;
            w3WindowAnimation.Play();
        }
    }

    public void OnCloseButtonClick()
    {
        string _buttonName = EventSystem.current.currentSelectedGameObject.name;

        //play animation to close window
        PlayAnimation(_buttonName, -1);
    }
}
