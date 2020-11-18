using System.Collections;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public bool isPingpong;
    public Vector3 begin, end;
    public float time;
    public AnimationCurve curve;

    public void OnMoveBtnClick()
    {
        Move(begin, end, time, isPingpong);
    }

    private void Move(Vector3 begin, Vector3 end, float time, bool pingpong)
    {
        StopAllCoroutines();
        StartCoroutine(MoveForward(begin, end, time, pingpong));
    }

    IEnumerator MoveForward(Vector3 begin, Vector3 end, float time, bool pingpong)
    {
        float t = 0;
        Vector3 dir = end - begin;
        while (t < time)
        {
            t = Mathf.Clamp(t + Time.deltaTime, 0, time);
            ((RectTransform)transform).anchoredPosition = dir * curve.Evaluate(t / time) + begin;
            yield return 1;
        }
        if (pingpong)
        {
            StartCoroutine(MoveBack(begin, end, time, pingpong));
        }
    }

    IEnumerator MoveBack(Vector3 begin, Vector3 end, float time, bool pingpong)
    {
        float t = time;
        Vector3 dir = end - begin;
        while (t > 0)
        {
            t = Mathf.Clamp(t - Time.deltaTime, 0, time);
            ((RectTransform)transform).anchoredPosition = dir * curve.Evaluate(t / time) + begin;
            yield return 1;
        }
        if (pingpong)
        {
            StartCoroutine(MoveForward(begin, end, time, pingpong));
        }
    }
}
