using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class P1AngryFishLogic : MonoBehaviour
{
    public string onLoseText;
    private Transform player;
    private NavMeshAgent agent;
    private PopupManager popupText;

    [Header("Fish Sound")]
    public AudioSource source;


    // Start is called before the first frame update
    void Start()
    {
        popupText = GameObject.FindGameObjectWithTag("Popup").GetComponent<PopupManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
    }

    public IEnumerator PlaySound()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        source.Play();

        StartCoroutine(PlaySound());

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform == player)
        {
            popupText.setText(onLoseText);
            player.GetComponent<CharController>().killed();
        }

    }
}
