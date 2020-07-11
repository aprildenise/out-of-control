using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public bool allowUnscaledDeltaTime = false;
    private float duration;
    private Status status;

    private float countingTime;
    private bool counting;

    public void SetTimer(float duration)
    {
        SetTimer(duration, Timer.Status.IDLE);
    }

    public void SetTimer(float duration, Timer.Status startingStatus)
    {
        this.duration = duration;
        this.status = startingStatus;
    }

    public Status GetStatus()
    {
        return this.status;
    }

    public void StartTimer()
    {
        status = Status.RUNNING;
        counting = true;
        //StartCoroutine(Count());
    }

    public void ResetTimer()
    {
        //StopCoroutine(Count());

        counting = false;
        countingTime = 0;
        status = Status.IDLE;
    }

    private IEnumerator Count()
    {
        if (allowUnscaledDeltaTime) yield return new WaitForSecondsRealtime(duration);
        else yield return new WaitForSeconds(duration);

        status = Status.FINISHED;

        yield return 0;

    }

    private void Update()
    {
        if (!counting) return;
        if (allowUnscaledDeltaTime) countingTime += Time.unscaledDeltaTime;
        else countingTime += Time.deltaTime;

        if (countingTime >= duration)
        {
            ResetTimer();
            status = Status.FINISHED;
        }
    }


    public enum Status
    {
        IDLE,
        RUNNING,
        FINISHED
    }

}
