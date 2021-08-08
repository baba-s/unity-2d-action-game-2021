#if !UNITY_EDITOR // .exe でのみこのスクリプトを有効化します

using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

// スプラッシュスクリーンを監視するスクリプト
public class SplashScreenChecker : MonoBehaviour
{
    // スプラッシュスクリーンの表示前に呼び出される関数
    [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSplashScreen )]
    private static void RuntimeInitializeBeforeSplashScreen()
    {
        // スプラッシュスクリーンの表示中は
        // ゲームが進行しないようにするために時間を止めておく
        Time.timeScale = 0;
    }

    // 最初のシーンの読み込み前に呼び出される関数
    [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSceneLoad )]
    private static void RuntimeInitializeBeforeSceneLoad()
    {
        // スプラッシュスクリーンの表示が終了したかどうかを監視する
        // ゲームオブジェクトを最初のシーンに生成する
        var go = new GameObject();
        go.AddComponent<SplashScreenChecker>();
    }

    // スプラッシュスクリーンの表示が終了したかどうかを監視する関数
    private IEnumerator Start()
    {
        // スプラッシュスクリーンの表示が終了するまで待機する
        while ( !SplashScreen.isFinished )
        {
            yield return null;
        }

        // スプラッシュスクリーンの表示が終了したら
        // ゲームを進行するために時間の停止を解除する
        Time.timeScale = 1;
    }
}

#endif