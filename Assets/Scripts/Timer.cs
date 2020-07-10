using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public bool allowUnscaledDeltaTime = false;

    /// <summary>
    /// The duration this timer should run for.
    /// </summary>
    private float duration;

    /// <summary>
    /// Status of this timer, which can be IDLE, RUNNING, or FINISHED.
    /// </summary>
    private Status status;

    private float countingTime;
    private bool counting;

    /// <summary>
    /// Psuedo-Constructor for this Timer. Sets the duration and the status of the timer to idle, but doesn't begin the timer.
    /// </summary>
    /// <param name="duration">Duration of the timer.</param>
    public void SetTimer(float duration)
    {
        SetTimer(duration, Timer.Status.IDLE);
    }

    /// <summary>
    /// Psuedo-Constructor for this Timer. Sets the duration and the status of the timer, but doesn't begin the timer.
    /// </summary>
    /// <param name="duration">Duration of the timer.</param>
    /// <param name="startingStatus">Starting status, can be RUNNING, FINISHED, IDLE.</param>
    public void SetTimer(float duration, Timer.Status startingStatus)
    {
        this.duration = duration;
        this.status = startingStatus;
    }

    /// <summary>
    /// Get the current status of the timer, which is defined in Status enum.
    /// </summary>
    /// <returns>IDLE, RUNNING, or FINISHED Status enum.</returns>
    public Status GetStatus()
    {
        return this.status;
    }

    /// <summary>
    /// Start this timer using Unity's Invoke().
    /// </summary>
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

    /// <summary>
    /// Helper function that is called when the timer is finished counting to its duration.
    /// </summary>
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


    /// <summary>
    /// Used to keep track of the stage/status of this timer.
    /// </summary>
    public enum Status
    {
        IDLE,
        RUNNING,
        FINISHED
    }

}
