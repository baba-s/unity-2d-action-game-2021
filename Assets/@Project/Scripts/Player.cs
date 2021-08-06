using UnityEngine;
using UnityEngine.SceneManagement;

// �v���C���[�𐧌䂷��X�N���v�g
public class Player : MonoBehaviour
{
	// �v���C���[�̂���A�j���[�V�����̃v���n�u
	public GameObject m_playerHitPrefab;

	// �W�����v�������ɍĐ����� SE
	public AudioClip m_jumpClip;

	// ���ꂽ���ɍĐ����� SE
	public AudioClip m_hitClip;

	// �W�����v�������� SE ���X�L�b�v���邩�ǂ���
	public bool IsSkipJumpSe;

	// �v���C���[�����ꂽ���ɌĂяo���֐�
	public void Dead()
	{
		// �v���C���[���\���ɂ���
		// Destroy �֐��Ńv���C���[���폜���Ă��܂���
		// OnRetry �֐����Ăяo����Ȃ��Ȃ邽��
		// SetActive �֐��Ŕ�\���ɂ���
		gameObject.SetActive( false );

		// �V�[���ɑ��݂��� CameraShaker �X�N���v�g����������
		var cameraShake = FindObjectOfType<CameraShaker>();

		// CameraShaker ���g�p���ăJ������h�炷
		cameraShake.Shake();

		// 2 �b��Ƀ��g���C����
		Invoke( "OnRetry", 2 );

		// �v���C���[�̂���A�j���[�V�����̃I�u�W�F�N�g�𐶐�����
		Instantiate
		(
			m_playerHitPrefab,
			transform.position,
			Quaternion.identity
		);

		// ���ꂽ���� SE ���Đ�����
		var audioSource = FindObjectOfType<AudioSource>();
		audioSource.PlayOneShot( m_hitClip );
	}

	// ���g���C���鎞�ɌĂяo�����֐�
	private void OnRetry()
	{
		// ���݂̃V�[����ǂݍ��ݒ����ă��g���C����
		SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
	}

	// �V�[�����J�n���鎞�ɌĂяo�����֐�
	private void Awake()
	{
		// �v���C���[�̈ړ��𐧌䂷��R���|�[�l���g���擾����
		var motor = GetComponent<PlatformerMotor2D>();

		// �W�����v�������ɌĂяo�����C�x���g�Ɋ֐���o�^����
		motor.onJump += OnJump;
	}
	
	// �W�����v�������ɌĂяo�����֐�
	private void OnJump()
	{
		// �W�����v�������� SE ���X�L�b�v����ꍇ
		if ( IsSkipJumpSe )
		{
			// �W�����v�������� SE �͍Đ����܂���
			IsSkipJumpSe = false;
		}
		// �X�L�b�v���Ȃ��ꍇ
		else
		{
			// �W�����v�������� SE ���Đ�����
			var audioSource = FindObjectOfType<AudioSource>();
			audioSource.PlayOneShot( m_jumpClip );
		}
	}
}