using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineController : MonoBehaviour
{
    private PlayableDirector playableDirector;
    [SerializeField][Range(0,1)] private float speed;
    private bool isAlive = true;

    public bool IsAlive
    {
        get { return isAlive; }
        set { isAlive = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
        ChangeTimeLineSpeed(speed);
        playableDirector.Play();
    }

    // Update is called once per frame
    void Update()
    {
        TimeLineTrigger();
    }

    //Controlling the timeline speed
    private void ChangeTimeLineSpeed(float _speed)
    {
        if (playableDirector != null)
        {
            playableDirector.playableGraph.GetRootPlayable(0).SetSpeed(_speed);
        }
    }

    //Controlling the timeline action
    private void TimeLineTrigger()
    {
        if (isAlive)
        {
            playableDirector.Play();
        }
        else
        {
            playableDirector.Pause();
        }
    }
}
