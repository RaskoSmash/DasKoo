using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScriptTest : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource musicObj;
    public bool justSpawned = false;
    public AudioListener target;
    public AnimationCurve disVolume;
    // Use this for initialization
    void Start()
    {
        musicObj = GetComponent<AudioSource>();
        justSpawned = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (justSpawned)
        {
            if (clip != null)
                musicObj.clip = clip;

            musicObj.timeSamples = 0;
            musicObj.Play();
            musicObj.loop = true;
            justSpawned = false;
        }
        if (target != null)
        {
            Vector3 dis = (target.transform.position - transform.position);
            float mag = Mathf.Clamp(dis.magnitude, disVolume.keys[0].time, disVolume.keys[disVolume.keys.Length - 1].time);
            musicObj.volume = disVolume.Evaluate(mag);
        }
    }
}
