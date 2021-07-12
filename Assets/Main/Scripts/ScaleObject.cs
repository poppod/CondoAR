using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ScaleObject : MonoBehaviour
{
    [SerializeField] bool canScale;
    [SerializeField] DefaultTrackableEventHandler trackEvent;


    Vector3 defaultScale = Vector3.one;
    float distance;
    Vector3 scale;

    // Start is called before the first frame update
    void Start() => transform.localScale = defaultScale;

    void OnDisable() => ResetScale();

    void ResetScale() => transform.localScale = defaultScale;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 2 && canScale)
        {
            var touchZero = Input.GetTouch(0);
            var touchOne = Input.GetTouch(1);

            if (touchZero.phase == TouchPhase.Ended || touchZero.phase == TouchPhase.Canceled ||
                touchOne.phase == TouchPhase.Ended || touchOne.phase == TouchPhase.Canceled)
                return;

            if (touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
            {
                distance = Vector2.Distance(touchZero.position, touchOne.position);
                scale = transform.localScale;
            }
            else
            {
                var currentDistance = Vector2.Distance(touchZero.position, touchOne.position);

                if (Mathf.Approximately(distance, 0))
                    return;

                var factor = currentDistance / distance;
                transform.localScale = scale * factor;
            }
        }

        //trackEvent.StatusFilter = transform.localScale.x > defaultScale.x ? DefaultTrackableEventHandler.TrackingStatusFilter.Tracked_ExtendedTracked : DefaultTrackableEventHandler.TrackingStatusFilter.Tracked;
        
        //if (Input.touchCount == 0)
        //{
        //    var touch = Input.GetTouch(0);
        //    if (touch.phase == TouchPhase.Moved)
        //    {
        //        transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * Time.deltaTime, transform.position.y,
        //            transform.position.z + touch.deltaPosition.y * Time.deltaTime);
        //    }
        //}
    }
}
