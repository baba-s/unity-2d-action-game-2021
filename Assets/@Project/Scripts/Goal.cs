using UnityEngine;

// �S�[���𐧌䂷��X�N���v�g
public class Goal : MonoBehaviour
{
	// �S�[���������ɍĐ����� SE
	public AudioClip m_goalClip;

	// �S�[���������ǂ���
	private bool m_isGoal;

	// ���̃I�u�W�F�N�g�Ɠ����������ɌĂяo�����֐�
	private void OnTriggerEnter2D( Collider2D other )
	{
		// �܂��S�[�����Ă��炸
		if ( !m_isGoal )
		{
			// ���O�ɁuPlayer�v���܂܂��I�u�W�F�N�g�Ɠ���������
			if ( other.name.Contains( "Player" ) )
			{
				// �V�[���ɑ��݂��� CameraShaker �X�N���v�g����������
				var cameraShake = FindObjectOfType<CameraShaker>();

				// CameraShaker ���g�p���ăJ������h�炷
				cameraShake.Shake();

				// ������S�[�����Ȃ��悤�ɁA�S�[���������Ƃ��L�����Ă���
				m_isGoal = true;

				// �S�[���̃A�j���[�^�[���擾����
				var animator = GetComponent<Animator>();

				// �S�[���������̃A�j���[�V�������Đ�����
				animator.Play( "Pressed" );

				// �S�[���������� SE ���Đ�����
				var audioSource = FindObjectOfType<AudioSource>();
				audioSource.PlayOneShot( m_goalClip );
			}
		}
	}
}