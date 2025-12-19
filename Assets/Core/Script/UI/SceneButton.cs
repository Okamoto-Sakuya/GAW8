using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    [Header("移動先のシーン名")]
    [Tooltip("ここに飛びたいシーン名を入力（例：Main、TitleSceneなど）")]
    public string targetSceneName;

    //  ボタンで呼ぶ関数
    public void OnButtonClick()
    {
        if (!string.IsNullOrEmpty(targetSceneName))
        {
            // 状態リセットしたい場合はここに記述
            PlayerPrefs.DeleteAll();  // スコアなど保存してたらクリア
            Time.timeScale = 1f;      // 念のため一時停止解除
            SceneManager.LoadScene(targetSceneName);
        }
        else
        {
            Debug.LogWarning("シーン名が設定されていません。");
        }
    }
}