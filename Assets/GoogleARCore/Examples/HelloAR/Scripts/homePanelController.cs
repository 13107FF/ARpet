using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homePanelController : MonoBehaviour
{
    private GameObject controller;
    private GameObject home_panel;
    private int hungry_value;
    private int mode_value;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Panel");
        home_panel = GameObject.Find("homePanel");
    }

    // Update is called once per frame
    void Update()
    {
        hungry_value = controller.GetComponent<PanelController>().strengthValue;
        mode_value = controller.GetComponent<PanelController>().moodValue;

        if(hungry_value <= PanelController.threshold)
        {
            hungryStatus();
        }
        else
        {
            if (mode_value <= PanelController.threshold)
            {
                badMoodStatus();
            }
            else
            {
                goodStatus();
            }
        }

    }
    private void fullStatus()
    {
        home_panel.transform.Find("cautionImage").gameObject.SetActive(false);
    }
   
    private void hungryStatus()
    {
        home_panel.transform.Find("moodButton").gameObject.SetActive(false);
        home_panel.transform.Find("walkButton").gameObject.SetActive(false);
        home_panel.transform.Find("badMoodButton").gameObject.SetActive(false);
        home_panel.transform.Find("badHungryMoodButton").gameObject.SetActive(true);
        home_panel.transform.Find("badHungryWalkButton").gameObject.SetActive(true);
        home_panel.transform.Find("cautionImage").gameObject.SetActive(true);
        home_panel.transform.Find("cautionImage1").gameObject.SetActive(false);
        home_panel.transform.Find("cautionImage2").gameObject.SetActive(false);

    }
    private void badMoodStatus()
    {
        home_panel.transform.Find("moodButton").gameObject.SetActive(false);
        home_panel.transform.Find("walkButton").gameObject.SetActive(true);
        home_panel.transform.Find("badMoodButton").gameObject.SetActive(true);
        home_panel.transform.Find("badHungryMoodButton").gameObject.SetActive(false);
        home_panel.transform.Find("badHungryWalkButton").gameObject.SetActive(false);
        home_panel.transform.Find("cautionImage").gameObject.SetActive(false);
        home_panel.transform.Find("cautionImage1").gameObject.SetActive(true);
        home_panel.transform.Find("cautionImage2").gameObject.SetActive(true);
    }

    private void goodStatus()
    {
        home_panel.transform.Find("moodButton").gameObject.SetActive(true);
        home_panel.transform.Find("walkButton").gameObject.SetActive(true);
        home_panel.transform.Find("badMoodButton").gameObject.SetActive(false);
        home_panel.transform.Find("badHungryMoodButton").gameObject.SetActive(false);
        home_panel.transform.Find("badHungryWalkButton").gameObject.SetActive(false);
        home_panel.transform.Find("cautionImage").gameObject.SetActive(false);
        home_panel.transform.Find("cautionImage1").gameObject.SetActive(false);
        home_panel.transform.Find("cautionImage2").gameObject.SetActive(false);
    }
}
