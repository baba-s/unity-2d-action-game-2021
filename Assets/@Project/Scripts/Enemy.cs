using PC2D;
using UnityEngine;

// �G�𐧌䂷��X�N���v�g
public class Enemy : MonoBehaviour
{
	// ����A�j���[�V�����̃v���n�u
	public GameObject m_hitPrefab;

	// ���ꂽ���ɍĐ����� SE
	public AudioClip m_hitClip;

	// �G�̈ړ��𐧌䂷��R���|�[�l���g
	private PlatformerMotor2D m_motor;

	// �G�̃X�v���C�g��\������R���|�[�l���g
	private SpriteRenderer m_renderer;

	// �G�̓����蔻����Ǘ�����R���|�[�l���g
	private BoxCollider2D m_collider;

	// �V�[�����J�n���鎞�ɌĂяo�����֐�
	private void Awake()
	{
		// �G�̈ړ��𐧌䂷��R���|�[�l���g���擾����
		m_motor = GetComponent<PlatformerMotor2D>();

		// �ŏ��͍��Ɉړ�����
		m_motor.normalizedXMovement = -1;

		// �G�̃X�v���C�g��\������R���|�[�l���g���擾����
		m_renderer = GetComponent<SpriteRenderer>();

		// �ŏ��͉摜���������ɂ���
		m_renderer.flipX = false;

		// �G�̓����蔻����Ǘ�����R���|�[�l���g���擾����
		m_collider = GetComponent<BoxCollider2D>();
	}

	// ���t���[���Ăяo�����֐�
	private void Update()
	{
		// ���݂̐i�s�������擾����
		var dir = 0 < m_motor.normalizedXMovement
			? Vector3.right
			: Vector3.left;

		// �i�s�����Ƀ^�C���}�b�v�����݂��邩�ǂ������m�F����
		var offset = m_collider.size.y * 0.5f;
		var hit = Physics2D.Raycast
		(
			transform.position - new Vector3( 0, offset, 0 ),
			dir,
			m_collider.size.x * 0.55f,
			Globals.ENV_MASK
		);

		// �i�s�����Ƀ^�C���}�b�v�����݂���ꍇ
		if ( hit.collider != null )
		{
			// �ړ������𔽓]������
			m_motor.normalizedXMovement = -m_motor.normalizedXMovement;

			// �摜�̌����𔽓]������
			m_renderer.flipX = !m_renderer.flipX;
		}
	}

	// ���̃I�u�W�F�N�g�Ɠ����������ɌĂяo�����֐�
	private void OnTriggerEnter2D( Collider2D other )
	{
		// ���O�ɁuPlayer�v���܂܂��I�u�W�F�N�g�Ɠ���������
		if ( other.name.Contains( "Player" ) )
		{
			// �v���C���[�̈ړ��𐧌䂷��R���|�[�l���g���擾����
			var motor = other.GetComponent<PlatformerMotor2D>();

			// �v���C���[���������̏ꍇ
			if ( motor.IsFalling() )
			{
				// �G���폜����
				Destroy( gameObject );

				// �v���C���[���W�����v������
				motor.ForceJump();

				// �V�[���ɑ��݂��� CameraShaker �X�N���v�g����������
				var cameraShake = FindObjectOfType<CameraShaker>();

				// CameraShaker ���g�p���ăJ������h�炷
				cameraShake.Shake();

				// ����A�j���[�V�����̃I�u�W�F�N�g�𐶐�����
				Instantiate( m_hitPrefab, transform.position, Quaternion.identity );

				// ���ꂽ���� SE ���Đ�����
				var audioSource = FindObjectOfType<AudioSource>();
				audioSource.PlayOneShot( m_hitClip );

				// �v���C���[���W�����v�������� SE �͍Đ����Ȃ��悤�ɂ���
				var player = other.GetComponent<Player>();
				player.IsSkipJumpSe = true;
			}
			// �v���C���[���������ł͂Ȃ��ꍇ
			else
			{
				// �v���C���[���� Player �X�N���v�g���擾����
				var player = other.GetComponent<Player>();

				// �v���C���[�����ꂽ���ɌĂяo���֐������s����
				player.Dead();
			}
		}
	}
}