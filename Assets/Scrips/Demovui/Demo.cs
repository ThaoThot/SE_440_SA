using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //demo lambda
        MoveGameObject(() => { Debug.Log("callback"); });
        //demo multi thread
        Debug.Log("Start call Count Down");
        StartCoroutine(CountDown());
        Debug.Log("End Call Count Down");
        //demo multi thread 2
        MultiThread02();
    }

    private async void MultiThread02()
    {
        Debug.Log("Start multi tasks");
        List<UniTask> tasks = new List<UniTask>();
        tasks.Add(TaskA("Move GameObject", 2000));
        tasks.Add(TaskA("Scale GameObject", 4000));
        await UniTask.WhenAll(tasks);
        Debug.Log("Completed tasks");
    }

    private async UniTask TaskA(string log, int delay)
    {
        Debug.Log($"Task Start{log}");
        await UniTask.Delay( delay );
        Debug.Log($"Task Done{log}");
    }

    private IEnumerator CountDown()
    {
        Debug.Log("Start Count Down");
        int countTime = 3;
        for(int i = 0; i < countTime; i++)
        {
            yield return new WaitForSeconds(1);
        }
        Debug.Log("End Count Down");
    }
    private void MoveGameObject(Action callback)
    {
        Debug.Log("Move Game Object completed");
        callback?.Invoke();

    }
}
