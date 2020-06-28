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
    private float eatTimer = 3.0f;

    private Animator petAnim;
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
            petAnim.SetBool("is_eating", true);
            eatTimer -= Time.deltaTime;
            if (eatTimer <= 0) {
                petAnim.SetBool("is_eating", false);
            }
        }
        
    }

    public void StartMove(Vector3 endPos)
    {
        petAnim.SetBool("is_walking", true);
        startMarker = this.transform;
        endMarker = endPos;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker);
        Debug.Log("journeyLength is " + journeyLength);
    }
}
