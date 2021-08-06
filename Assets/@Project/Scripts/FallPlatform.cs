using UnityEngine;

// �����鏰�𐧌䂷��X�N���v�g
public class FallPlatform : MonoBehaviour
{
	// �����鑬��
	public float m_speed = 0.3f;

	// �v���C���[����ɏ�������ǂ���
	private bool m_isHit;

	// �V�[�����J�n���鎞�ɌĂяo�����֐�
	private void Awake()
	{
		// �������g�� MovingPlatformMotor2D ���擾����
		var motor = GetComponent<MovingPlatformMotor2D>();

		// �v���C���[�������������ɌĂяo�����C�x���g�Ɋ֐���o�^����
		motor.onPlatformerMotorContact += OnContact;
	}

	// �v���C���[�������������ɌĂяo�����֐�
	private void OnContact( PlatformerMotor2D player )
	{
		// �v���C���[���������̏ꍇ
		if ( player.IsFalling() )
		{
			// �v���C���[����ɏ�������Ƃɂ���
			m_isHit = true;
		}
	}

	// ���t���[���Ăяo�����֐�
	private void Update()
	{
		// �v���C���[����ɏ�����ꍇ
		if ( m_isHit )
		{
			// �������g�� MovingPlatformMotor2D ���擾����
			var motor = GetComponent<MovingPlatformMotor2D>();

			// ����������
			motor.velocity = Physics2D.gravity * m_speed;
		}
	}
}