using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFade : MonoBehaviour
{

    void Start()
    {
        Scenemanager.Instance.FadeIn();
    }
}
