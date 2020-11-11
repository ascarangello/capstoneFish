using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public string talking;
    [SerializeField]
    public string[] sentences;
    public Queue<string> sentenceQueue;
    private void Start()
    {
        sentenceQueue = new Queue<string>();
        foreach(string sentence in sentences)
        {

            sentenceQueue.Enqueue(sentence);
        }
        
    }

    public void resetInfo()
    {
        sentenceQueue.Clear();
        foreach (string sentence in sentences)
        {

            sentenceQueue.Enqueue(sentence);
        }
    }
}
