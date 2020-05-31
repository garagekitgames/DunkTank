using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using DamageEffect;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class EffectsController : UnitySingletonPersistent<EffectsController>
{
    public AudioMixerGroup mixerGroup;

    public int currentSlowPriority = 0;
    public int previousSlowPriority = 0;

    private IEnumerator coroutine;

    [Range(1.0f, 10f)]
    public float slowFactor = 1.8f;

    public bool timeSlowing;

    public bool bigHit = false;
    public float pitch = 1;

    private DamageEffectScript damageEffectScript;
    public float minVolume = 0.2f;
    public float maxVolume = 0.3f;
    //
    public float minVelocity = 1;
    public float maxVelocity = 10;
    //
    protected float lastImpactTime = 0.5f;
    public float minImpactDelay = 0.15f;
    //
    public AudioClip[] ballHitClips;

    public AudioClip[] hurtClips;
    public AudioClip[] voiceClips;

    public AudioClip[] screamClips;


    public GameObject lightHitFXPrefab;
    public GameObject heavyHitFXPrefab;

    public GameObject explosionFXPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        base.Awake();
    }

    public void CreateHitEffect(Vector3 position, int hitType, Vector3 normal)
    {

        Quaternion rot = Quaternion.FromToRotation(Vector3.forward, normal);
        //camRippler.RippleEffect(position);
        if (hitType == 0)
        {
            GameObject hitFX = Instantiate(Instance.lightHitFXPrefab, position, rot);
        }
        else
        {
            GameObject hitFX = Instantiate(Instance.heavyHitFXPrefab, position, rot);
        }

    }

    public void CreateExplosionEffect(Vector3 position)
    {

        //Quaternion rot = Quaternion.FromToRotation(Vector3.forward, normal);
        //camRippler.RippleEffect(position);
        
            GameObject hitFX = Instantiate(Instance.explosionFXPrefab, position, Quaternion.identity);
        //}

    }

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("Level Loaded");
        //Debug.Log(scene.name);
        //Debug.Log(mode);

        //reset the values  
        Time.timeScale = 1.0f;
        //Time.fixedDeltaTime = Time.fixedDeltaTime * slowFactorValue;
        Time.fixedDeltaTime = 0.01f;
        //Time.maximumDeltaTime = Time.maximumDeltaTime * slowFactorValue;
        Time.maximumDeltaTime = 0.3333333f;

        Instance.pitch = Time.timeScale;
        bigHit = false;
        previousSlowPriority = 0;

        if (scene.name.Contains("Level"))
        {
            //if (camTransform == null)
            //{
            //    camTransform = Camera.main;
            //}

            //mfCam = camTransform.transform.root.GetComponent<MultiFighterCamera>();
            //f3dCam = camTransform.transform.root.GetComponent<Fighter3DCamera>();
            //cashObjectPool = EZObjectPool.CreateObjectPool(Instance.cashPrefab, cashPrefab.name, 10, true, true, true);
            //alertObjectPool = EZObjectPool.CreateObjectPool(Instance.alertPrefab, alertPrefab.name, 10, true, true, true);
            //// scoreObjectPool = EZObjectPool.CreateObjectPool(Instance.scoreFloatingTextPrefab, scoreFloatingTextPrefab.name, 10, true, true, true);
            //camRippler = camTransform.transform.GetComponent<RipplePostProcessor>();
            ////reset the values  
            Time.timeScale = 1.0f;
            //Time.fixedDeltaTime = Time.fixedDeltaTime * slowFactorValue;
            Time.fixedDeltaTime = 0.01f;
            //Time.maximumDeltaTime = Time.maximumDeltaTime * slowFactorValue;
            Time.maximumDeltaTime = 0.3333333f;
            Instance.pitch = Time.timeScale;
            bigHit = false;
            previousSlowPriority = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBallHitSound(Vector3 collisionPoint, float relativeVolocityMagnitude, string tag)
    {
        if (relativeVolocityMagnitude > Instance.minVelocity)
        {
            //
            float m = Mathf.Clamp01((relativeVolocityMagnitude - Instance.minVelocity) / (Instance.maxVelocity - Instance.minVelocity));
            float volumeM = Instance.minVolume + (Instance.maxVolume - Instance.minVolume) * m;
            //
            GameObject gO = new GameObject("OneShotAudio");
            gO.transform.position = collisionPoint;
            AudioSource source = gO.AddComponent<AudioSource>();
            source.loop = false;
            source.dopplerLevel = 0.1f;
            source.volume = volumeM;
            source.pitch = Random.Range(Instance.pitch - 0.1f, Instance.pitch + 0.1f); //Instance.pitch;
            source.rolloffMode = AudioRolloffMode.Linear;
            source.minDistance = 2000;
            source.maxDistance = 2010;
            source.spatialBlend = 0.5f;
            source.outputAudioMixerGroup = Instance.mixerGroup;
            /*int clipIndex = Mathf.FloorToInt(m * 0.999f * Instance.clips.Length);
            if (clipIndex < Instance.clips.Length && clipIndex >= 0)
            {
                source.clip = Instance.clips[Mathf.FloorToInt(m * 0.999f * Instance.clips.Length)]; // **** INDEX 0 to 1 less than number of clips ***
               // Debug.Log("clipIndex " + clipIndex + "  clips.Length " + Instance.clips.Length);
            }
            else
            {
               // Debug.LogError("clipIndex " + clipIndex + "  clips.Length " + Instance.clips.Length);
            }*/

            //if (tag.Contains("Wep"))
            //{
            //    int clipIndex = Random.Range(0, Instance.weaponclips.Length);  //Mathf.FloorToInt(m * 0.999f * Instance.windupclips.Length);
            //    if (clipIndex < Instance.weaponclips.Length && clipIndex >= 0)
            //    {
            //        source.clip = Instance.weaponclips[clipIndex]; // **** INDEX 0 to 1 less than number of clips ***
            //                                                       //  Debug.Log("windupclips " + clipIndex + "  windupclips.Length " + Instance.windupclips.Length);
            //    }
            //    else
            //    {
            //        //  Debug.LogError("windupclips " + clipIndex + "  windupclips.Length " + Instance.windupclips.Length);
            //    }
            //}
            //else
            //{
            int clipIndex = Random.Range(0, Instance.ballHitClips.Length);  //Mathf.FloorToInt(m * 0.999f * Instance.windupclips.Length);
                                                                           //    
            //int clipIndex = Mathf.FloorToInt(m * 0.999f * Instance.ballHitClips.Length);  //Mathf.FloorToInt(m * 0.999f * Instance.windupclips.Length);
                if (clipIndex < Instance.ballHitClips.Length && clipIndex >= 0)
                {
                    source.clip = Instance.ballHitClips[clipIndex]; // **** INDEX 0 to 1 less than number of clips ***
                                                             //  Debug.Log("windupclips " + clipIndex + "  windupclips.Length " + Instance.windupclips.Length);
                }
                else
                {   
                    //  Debug.LogError("windupclips " + clipIndex + "  windupclips.Length " + Instance.windupclips.Length);
                }
            //}

            source.Play();
            //
            Destroy(gO, source.clip.length + 0.1f);
        //
    }
}


    public void PlayHurtSound(Vector3 collisionPoint, float relativeVolocityMagnitude, string tag)
    {
        if (relativeVolocityMagnitude > Instance.minVelocity)
        {
            //
            float m = Mathf.Clamp01((relativeVolocityMagnitude - Instance.minVelocity) / (Instance.maxVelocity - Instance.minVelocity));
            float volumeM = Instance.minVolume + (Instance.maxVolume - Instance.minVolume) * m;
            //
            GameObject gO = new GameObject("OneShotAudio");
            gO.transform.position = collisionPoint;
            AudioSource source = gO.AddComponent<AudioSource>();
            source.loop = false;
            source.dopplerLevel = 0.1f;
            source.volume = volumeM;
            source.pitch = Random.Range(Instance.pitch - 0.1f, Instance.pitch + 0.1f); //Instance.pitch;
            source.rolloffMode = AudioRolloffMode.Linear;
            source.minDistance = 2000;
            source.maxDistance = 2010;
            source.spatialBlend = 0.5f;
            source.outputAudioMixerGroup = Instance.mixerGroup;
            /*int clipIndex = Mathf.FloorToInt(m * 0.999f * Instance.clips.Length);
            if (clipIndex < Instance.clips.Length && clipIndex >= 0)
            {
                source.clip = Instance.clips[Mathf.FloorToInt(m * 0.999f * Instance.clips.Length)]; // **** INDEX 0 to 1 less than number of clips ***
               // Debug.Log("clipIndex " + clipIndex + "  clips.Length " + Instance.clips.Length);
            }
            else
            {
               // Debug.LogError("clipIndex " + clipIndex + "  clips.Length " + Instance.clips.Length);
            }*/

            //if (tag.Contains("Wep"))
            //{
            //    int clipIndex = Random.Range(0, Instance.weaponclips.Length);  //Mathf.FloorToInt(m * 0.999f * Instance.windupclips.Length);
            //    if (clipIndex < Instance.weaponclips.Length && clipIndex >= 0)
            //    {
            //        source.clip = Instance.weaponclips[clipIndex]; // **** INDEX 0 to 1 less than number of clips ***
            //                                                       //  Debug.Log("windupclips " + clipIndex + "  windupclips.Length " + Instance.windupclips.Length);
            //    }
            //    else
            //    {
            //        //  Debug.LogError("windupclips " + clipIndex + "  windupclips.Length " + Instance.windupclips.Length);
            //    }
            //}
            //else
            //{
            int clipIndex = Random.Range(0, Instance.hurtClips.Length);  //Mathf.FloorToInt(m * 0.999f * Instance.windupclips.Length);
                                                                            //    
                                                                            //int clipIndex = Mathf.FloorToInt(m * 0.999f * Instance.ballHitClips.Length);  //Mathf.FloorToInt(m * 0.999f * Instance.windupclips.Length);
            if (clipIndex < Instance.hurtClips.Length && clipIndex >= 0)
            {
                source.clip = Instance.hurtClips[clipIndex]; // **** INDEX 0 to 1 less than number of clips ***
                                                                //  Debug.Log("windupclips " + clipIndex + "  windupclips.Length " + Instance.windupclips.Length);
            }
            else
            {
                //  Debug.LogError("windupclips " + clipIndex + "  windupclips.Length " + Instance.windupclips.Length);
            }
            //}

            source.Play();
            //
            Destroy(gO, source.clip.length + 0.1f);
            //
        }
    }


    public void PlayRandomLaughSound(Vector3 collisionPoint, float relativeVolocityMagnitude, string tag)
    {
        if (relativeVolocityMagnitude > Instance.minVelocity)
        {
            //
            float m = Mathf.Clamp01((relativeVolocityMagnitude - Instance.minVelocity) / (Instance.maxVelocity - Instance.minVelocity));
            float volumeM = Instance.minVolume + (Instance.maxVolume - Instance.minVolume) * m;
            //
            GameObject gO = new GameObject("OneShotAudio");
            gO.transform.position = collisionPoint;
            AudioSource source = gO.AddComponent<AudioSource>();
            source.loop = false;
            source.dopplerLevel = 0.1f;
            source.volume = volumeM / 10f;
            source.pitch = Random.Range(Instance.pitch - 0.1f, Instance.pitch + 0.1f); //Instance.pitch;
            source.rolloffMode = AudioRolloffMode.Linear;
            source.minDistance = 2000;
            source.maxDistance = 2010;
            source.spatialBlend = 0.5f;
            source.outputAudioMixerGroup = Instance.mixerGroup;
            /*int clipIndex = Mathf.FloorToInt(m * 0.999f * Instance.clips.Length);
            if (clipIndex < Instance.clips.Length && clipIndex >= 0)
            {
                source.clip = Instance.clips[Mathf.FloorToInt(m * 0.999f * Instance.clips.Length)]; // **** INDEX 0 to 1 less than number of clips ***
               // Debug.Log("clipIndex " + clipIndex + "  clips.Length " + Instance.clips.Length);
            }
            else
            {
               // Debug.LogError("clipIndex " + clipIndex + "  clips.Length " + Instance.clips.Length);
            }*/

            //if (tag.Contains("Wep"))
            //{
            //    int clipIndex = Random.Range(0, Instance.weaponclips.Length);  //Mathf.FloorToInt(m * 0.999f * Instance.windupclips.Length);
            //    if (clipIndex < Instance.weaponclips.Length && clipIndex >= 0)
            //    {
            //        source.clip = Instance.weaponclips[clipIndex]; // **** INDEX 0 to 1 less than number of clips ***
            //                                                       //  Debug.Log("windupclips " + clipIndex + "  windupclips.Length " + Instance.windupclips.Length);
            //    }
            //    else
            //    {
            //        //  Debug.LogError("windupclips " + clipIndex + "  windupclips.Length " + Instance.windupclips.Length);
            //    }
            //}
            //else
            //{
            int clipIndex = Random.Range(0, Instance.voiceClips.Length);  //Mathf.FloorToInt(m * 0.999f * Instance.windupclips.Length);
                                                                         //    
                                                                         //int clipIndex = Mathf.FloorToInt(m * 0.999f * Instance.ballHitClips.Length);  //Mathf.FloorToInt(m * 0.999f * Instance.windupclips.Length);
            if (clipIndex < Instance.voiceClips.Length && clipIndex >= 0)
            {
                source.clip = Instance.voiceClips[clipIndex]; // **** INDEX 0 to 1 less than number of clips ***
                                                             //  Debug.Log("windupclips " + clipIndex + "  windupclips.Length " + Instance.windupclips.Length);
            }
            else
            {
                //  Debug.LogError("windupclips " + clipIndex + "  windupclips.Length " + Instance.windupclips.Length);
            }
            //}

            source.Play();
            //
            Destroy(gO, source.clip.length + 0.1f);
            //
        }
    }



    public void PlayRandomScreamSound(Vector3 collisionPoint, float relativeVolocityMagnitude, string tag)
    {
        if (relativeVolocityMagnitude > Instance.minVelocity)
        {
            //
            float m = Mathf.Clamp01((relativeVolocityMagnitude - Instance.minVelocity) / (Instance.maxVelocity - Instance.minVelocity));
            float volumeM = Instance.minVolume + (Instance.maxVolume - Instance.minVolume) * m;
            //
            GameObject gO = new GameObject("OneShotAudio");
            gO.transform.position = collisionPoint;
            AudioSource source = gO.AddComponent<AudioSource>();
            source.loop = false;
            source.dopplerLevel = 0.1f;
            source.volume = volumeM / 7f;
            source.pitch = Random.Range(Instance.pitch - 0.1f, Instance.pitch + 0.1f); //Instance.pitch;
            source.rolloffMode = AudioRolloffMode.Linear;
            source.minDistance = 2000;
            source.maxDistance = 2010;
            source.spatialBlend = 0.5f;
            source.outputAudioMixerGroup = Instance.mixerGroup;
            /*int clipIndex = Mathf.FloorToInt(m * 0.999f * Instance.clips.Length);
            if (clipIndex < Instance.clips.Length && clipIndex >= 0)
            {
                source.clip = Instance.clips[Mathf.FloorToInt(m * 0.999f * Instance.clips.Length)]; // **** INDEX 0 to 1 less than number of clips ***
               // Debug.Log("clipIndex " + clipIndex + "  clips.Length " + Instance.clips.Length);
            }
            else
            {
               // Debug.LogError("clipIndex " + clipIndex + "  clips.Length " + Instance.clips.Length);
            }*/

            //if (tag.Contains("Wep"))
            //{
            //    int clipIndex = Random.Range(0, Instance.weaponclips.Length);  //Mathf.FloorToInt(m * 0.999f * Instance.windupclips.Length);
            //    if (clipIndex < Instance.weaponclips.Length && clipIndex >= 0)
            //    {
            //        source.clip = Instance.weaponclips[clipIndex]; // **** INDEX 0 to 1 less than number of clips ***
            //                                                       //  Debug.Log("windupclips " + clipIndex + "  windupclips.Length " + Instance.windupclips.Length);
            //    }
            //    else
            //    {
            //        //  Debug.LogError("windupclips " + clipIndex + "  windupclips.Length " + Instance.windupclips.Length);
            //    }
            //}
            //else
            //{
            int clipIndex = Random.Range(0, Instance.screamClips.Length);  //Mathf.FloorToInt(m * 0.999f * Instance.windupclips.Length);
                                                                          //    
                                                                          //int clipIndex = Mathf.FloorToInt(m * 0.999f * Instance.ballHitClips.Length);  //Mathf.FloorToInt(m * 0.999f * Instance.windupclips.Length);
            if (clipIndex < Instance.screamClips.Length && clipIndex >= 0)
            {
                source.clip = Instance.screamClips[clipIndex]; // **** INDEX 0 to 1 less than number of clips ***
                                                              //  Debug.Log("windupclips " + clipIndex + "  windupclips.Length " + Instance.windupclips.Length);
            }
            else
            {
                //  Debug.LogError("windupclips " + clipIndex + "  windupclips.Length " + Instance.windupclips.Length);
            }
            //}

            source.Play();
            //
            Destroy(gO, source.clip.length + 0.1f);
            //
        }
    }


    public void CameraShake(float impact, float roughness, float fadeInTime, float fadeOutTime)
    {
        if (CameraShaker.Instance != null)
        {
            //CameraShaker.Instance.ShakeOnce(Mathf.Clamp(impact, 1, 5), 10, 0.05f, 0.4f);
            CameraShaker.Instance.ShakeOnce(Mathf.Clamp(impact, 1, 5), roughness, fadeInTime, fadeOutTime);

        }
    }

    public void LevelClear()
    {
        EffectsController.Instance.slowDownTime(4, 1f, 1);
    }

    public void LevelFail()
    {
        EffectsController.Instance.slowDownTime(4, 1f, 1);
    }

    public void slowDownTime(float slowFactorValue, float waitTime, int m)
    {

        /*else if(m == 1)
        {
            bigHit = false;
        }*/
        currentSlowPriority = m;
        if (currentSlowPriority >= previousSlowPriority && !timeSlowing)
        {
            coroutine = TimeSlow(slowFactorValue, waitTime, m);
            StartCoroutine(coroutine);
        }
        /* if(!bigHit)
         {
             coroutine = TimeSlow(slowFactorValue, waitTime, m);
             StartCoroutine(coroutine);
         }*/

    }
    private IEnumerator TimeSlow(float slowFactorValue, float waitTime, int m)
    {


        // Debug.Log("Actual Value: " + Time.maximumDeltaTime);
        SlowTime(slowFactorValue, m);
        timeSlowing = true;

        // Debug.Log("Changed Value: " + Time.maximumDeltaTime);
        //Debug.Log("Supposed Value: " + timeScaleAmount * timePerFrame);
        yield return new WaitForSeconds(waitTime);

        ResetTime(slowFactorValue);
        timeSlowing = false;
        // Debug.Log("After Reset Value: " + Time.maximumDeltaTime);
        //print("Coroutine ended: " + Time.time + " seconds");
    }

    public void SlowTime(float slowFactorValue, int m)
    {

        previousSlowPriority = currentSlowPriority;

        if (Time.timeScale == 1.0f)
        {
            if (m == 0)
            {
                bigHit = true;
            }
            float newTimeScale = Time.timeScale / slowFactorValue;
            //assign the 'newTimeScale' to the current 'timeScale'  
            Time.timeScale = newTimeScale;
            //proportionally reduce the 'fixedDeltaTime', so that the Rigidbody simulation can react correctly  
            Time.fixedDeltaTime = Time.fixedDeltaTime / slowFactorValue;
            //The maximum amount of time of a single frame  
            Time.maximumDeltaTime = Time.maximumDeltaTime / slowFactorValue;

            Instance.pitch = 0.8f;
        }

    }

    public void ResetTime(float slowFactorValue)
    {
        if ((Time.timeScale != 1.0f) && (Time.fixedDeltaTime != 0.01f)) //the game is running in slow motion  
        {
            //reset the values  
            Time.timeScale = 1.0f;
            //Time.fixedDeltaTime = Time.fixedDeltaTime * slowFactorValue;
            Time.fixedDeltaTime = 0.01f;
            //Time.maximumDeltaTime = Time.maximumDeltaTime * slowFactorValue;
            Time.maximumDeltaTime = 0.3333333f;
            Instance.pitch = Time.timeScale;
            bigHit = false;
            previousSlowPriority = 0;
        }
    }

}
