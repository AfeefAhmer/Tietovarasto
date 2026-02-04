using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Se : MonoBehaviour
{
    [SerializeField] TMP_Dropdown jumpKeyInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider sensitivitySlider;
    public TMP_Dropdown graphicsDropdown;
    void Start()
    {
        jumpKeyInput.value=PlayerPrefs.GetInt("JumpKey",0);
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.5f);
        sensitivitySlider.value = PlayerPrefs.GetFloat("Sensitivity", 1.0f);
        graphicsDropdown.value = PlayerPrefs.GetInt("Graphics", 1);
    }
    public void SaveSettings()
    {
        PlayerPrefs.SetInt("JumpKey", jumpKeyInput.value);
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        PlayerPrefs.SetFloat("Sensitivity", sensitivitySlider.value);
        PlayerPrefs.SetInt("Graphics", graphicsDropdown.value);
        PlayerPrefs.Save();
    }
    public void ResetSettings()
    {
        PlayerPrefs.DeleteAll();
        jumpKeyInput.value = 0;
        volumeSlider.value = 0.5f;
        sensitivitySlider.value = 1.0f;
        graphicsDropdown.value = 1;
    }
}
