#if !UNITY_EDITOR // .exe �ł݂̂��̃X�N���v�g��L�������܂�

using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

// �X�v���b�V���X�N���[�����Ď�����X�N���v�g
public class SplashScreenChecker : MonoBehaviour
{
    // �X�v���b�V���X�N���[���̕\���O�ɌĂяo�����֐�
    [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSplashScreen )]
    private static void RuntimeInitializeBeforeSplashScreen()
    {
        // �X�v���b�V���X�N���[���̕\������
        // �Q�[�����i�s���Ȃ��悤�ɂ��邽�߂Ɏ��Ԃ��~�߂Ă���
        Time.timeScale = 0;
    }

    // �ŏ��̃V�[���̓ǂݍ��ݑO�ɌĂяo�����֐�
    [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSceneLoad )]
    private static void RuntimeInitializeBeforeSceneLoad()
    {
        // �X�v���b�V���X�N���[���̕\�����I���������ǂ������Ď�����
        // �Q�[���I�u�W�F�N�g���ŏ��̃V�[���ɐ�������
        var go = new GameObject();
        go.AddComponent<SplashScreenChecker>();
    }

    // �X�v���b�V���X�N���[���̕\�����I���������ǂ������Ď�����֐�
    private IEnumerator Start()
    {
        // �X�v���b�V���X�N���[���̕\�����I������܂őҋ@����
        while ( !SplashScreen.isFinished )
        {
            yield return null;
        }

        // �X�v���b�V���X�N���[���̕\�����I��������
        // �Q�[����i�s���邽�߂Ɏ��Ԃ̒�~����������
        Time.timeScale = 1;
    }
}

#endif