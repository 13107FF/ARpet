using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class walkPanelController : MonoBehaviour
{
    private GameObject controller;
    private GameObject ring_process;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Panel");
        ring_process = GameObject.Find("walkPanel/mood/moodRing");
    }

    // Update is called once per frame
    void Update()
    {
        ring_process.GetComponent<Image>().fillAmount = controller.GetComponent<PanelController>().moodValue / 100.0f;
    }
}
