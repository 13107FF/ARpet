using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMoveTo : MonoBehaviour
{
    public Transform startMarker;
    public Vector3 endMarker;
    private float speed = 0.1f;
    private float startTime;
    private float journeyLength;

    public string petAnimStatus;

    private Animator petAnim;
    private float eatTimer = 3.0f;
    private float playTimer = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        journeyLength = 0;
        petAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (journeyLength > 0)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startMarker.position, endMarker, fracJourney);

            if (fracJourney < 0.1f)
            {
                var lookPos = endMarker - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);
            }
            
        }

        if (Vector3.Distance(startMarker.position, endMarker) < 0.1)
        {
            petAnim.SetBool("is_walking", false);
            if (petAnimStatus == "is_eating")
            {
                petAnim.SetBool("is_eating", true);
                petAnim.SetBool("is_playing", false);
                eatTimer -= Time.deltaTime;
                if (eatTimer <= 0)
                {
                    petAnim.SetBool("is_eating", false);
                    petAnimStatus = "";
                    eatTimer = 3.0f;
                }
            }
            else if (petAnimStatus == "is_playing")
            {
                petAnim.SetBool("is_playing", true);
                petAnim.SetBool("is_eating", false);
                playTimer -= Time.deltaTime;
                if (playTimer <= 0)
                {
                    petAnim.SetBool("is_playing", false);
                    petAnimStatus = "";
                    playTimer = 5.0f;
                }
            }

        }

    }

    public void StartMove(Vector3 endPos, string petstatus)
    {
        petAnimStatus = petstatus;
        petAnim.SetBool("is_walking", true);
        startMarker = this.transform;
        endMarker = endPos;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker);
        Debug.Log("journeyLength is " + journeyLength);
    }
}
