using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider NitroSlider;
    public Slider MagnetSlider;
    public Slider MusicSlider, SfxSlider;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    public GameObject PausePanel;

    private void Start()
    {
        LoadSliderValues();
        MusicSlider.onValueChanged.AddListener(delegate { MusicVolume(); });
        SfxSlider.onValueChanged.AddListener(delegate { SFXVolume(); });
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateBestScore(int score)
    {
        bestScoreText.text = score.ToString();
    }

    public void LoadBestScore(int bestScore)
    {
        bestScoreText.text = bestScore.ToString();
    }

    public void MusicVolume()
    {
        AudioController.Instance.MusicVolume(MusicSlider.value);
        PlayerPrefs.SetFloat(GlobalConstant.MUSIC_SLIDER, MusicSlider.value);
    }

    public void SFXVolume()
    {
        AudioController.Instance.SFXVolume(SfxSlider.value);
        PlayerPrefs.SetFloat(GlobalConstant.SFX_SLIDER, SfxSlider.value);
    }

    private void LoadSliderValues()
    {
        if (PlayerPrefs.HasKey(GlobalConstant.MUSIC_SLIDER))
        {
            MusicSlider.value = PlayerPrefs.GetFloat(GlobalConstant.MUSIC_SLIDER);
        }
        else
        {
            MusicSlider.value = 1.0f;
        }

        if (PlayerPrefs.HasKey(GlobalConstant.SFX_SLIDER))
        {
            SfxSlider.value = PlayerPrefs.GetFloat(GlobalConstant.SFX_SLIDER);
        }
        else
        {
            SfxSlider.value = 1.0f;
        }
    }
}
