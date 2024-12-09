using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public Slider volumeSlider; // Tham chiếu đến slider
    public const string VolumeKey = "GameVolume"; // Key lưu trong PlayerPrefs

    public void Start()
    {
        // Lấy giá trị âm lượng đã lưu, nếu chưa có thì đặt mặc định là 1 (100%)
        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 1f);
        AudioListener.volume = savedVolume; // Đặt âm lượng tổng
        volumeSlider.value = savedVolume;  // Đặt giá trị cho slider

        // Lắng nghe sự kiện thay đổi slider
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value; // Đặt âm lượng tổng của game
        PlayerPrefs.SetFloat(VolumeKey, value); // Lưu giá trị âm lượng
        PlayerPrefs.Save();
    }

    public void OnDestroy()
    {
        // Bỏ lắng nghe khi script bị hủy để tránh lỗi
        volumeSlider.onValueChanged.RemoveListener(SetVolume);
    }
}
