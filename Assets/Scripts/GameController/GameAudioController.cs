using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAudioController : MonoBehaviour
{
    public static GameAudioController instance;

    [SerializeField] private AudioSource gameIntroAudioSource;
    [SerializeField] private AudioSource gamePlayAudioSource;
    [SerializeField] private AudioSource gameSoundsEffectAudioSource;

    [SerializeField] private AudioClip gameIntroSound;
    [SerializeField][Range(0, 1)] private float gameIntroSoundVolume;

    [SerializeField] private AudioClip gamePlaySound;
    [SerializeField][Range(0, 1)] private float gamePlaySoundVolume;

    [SerializeField] private AudioClip bananaSound;
    [SerializeField][Range(0, 1)] private float bananaSoundVolume;

    [SerializeField] private AudioClip letterSound;
    [SerializeField][Range(0, 1)] private float letterSoundVolume;

    [SerializeField] private AudioClip buttonSound;
    [SerializeField][Range(0, 1)] private float buttonSoundVolume;

    [SerializeField] private AudioClip playerHitSound;
    [SerializeField][Range(0, 1)] private float playerHitSoundVolume;

    [SerializeField] private AudioClip gameOverWinSound;
    [SerializeField][Range(0, 1)] private float gameOverWinSoundVolume;

    [SerializeField] private AudioClip gameOverLoseSound;
    [SerializeField][Range(0, 1)] private float gameOverLoseSoundVolume;

    private bool isPlaying;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0 && !isPlaying)
        {
            MainMenuSound();

            if(gamePlayAudioSource.isPlaying)
            {
                gamePlayAudioSource.Stop();
            }

            isPlaying = true;
        }
        else if(SceneManager.GetActiveScene().buildIndex == 2 && isPlaying)
        {

            GamePlaySound();

            if(gameIntroAudioSource.isPlaying)
            {
                gameIntroAudioSource.Stop();
            }
            

            isPlaying = false;
        }
    }


    public void MainMenuSound()
    {
        AudioController(gameIntroAudioSource, gameIntroSound, gameIntroSoundVolume, true);
    }

    public void GamePlaySound()
    {
        AudioController(gamePlayAudioSource, gamePlaySound, gamePlaySoundVolume, true);
    }

    public void Collectebles1Sounds()
    {
        AudioController(gameSoundsEffectAudioSource, bananaSound, bananaSoundVolume, false);
    }

    public void Collectebles2Sounds()
    {
        AudioController(gameSoundsEffectAudioSource, letterSound, letterSoundVolume, false);
    }

    public void ButtonsSounds()
    {
        AudioController(gameSoundsEffectAudioSource, buttonSound, buttonSoundVolume, false);
    }

    public void PlayerHitSound()
    {
        AudioController(gameSoundsEffectAudioSource, playerHitSound, playerHitSoundVolume, false);
    }

    public void GameOverWinSound()
    {
        AudioController(gameSoundsEffectAudioSource, gameOverWinSound, gameOverWinSoundVolume, false);
    }

    public void GameOverLoseSound()
    {
        AudioController(gameSoundsEffectAudioSource, gameOverLoseSound, gameOverLoseSoundVolume, false);
    }

    private void AudioController(AudioSource _audioSource, AudioClip _audioClip, float _volume, bool _loop)
    {
        _audioSource.clip = _audioClip;
        _audioSource.volume = _volume;
        _audioSource.loop = _loop;
        _audioSource.Play();
    }
}
