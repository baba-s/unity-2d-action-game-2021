using UnityEngine;

// �g�����|�����𐧌䂷��X�N���v�g
public class Trampoline : MonoBehaviour
{
	// �v���C���[���W�����v�����鍂��
	public float m_jumpHeight = 10;

	// ���̃I�u�W�F�N�g�Ɠ����������ɌĂяo�����֐�
	private void OnTriggerEnter2D( Collider2D other )
	{
		// ���O�ɁuPlayer�v���܂܂��I�u�W�F�N�g�Ɠ���������
		if ( other.name.Contains( "Player" ) )
		{
			// �v���C���[�̑���𐧌䂷��X�N���v�g���擾����
			var motor = other.GetComponent<PlatformerMotor2D>();

			// �v���C���[���W�����v������
			motor.ForceJump( m_jumpHeight );

			// -- ��������ǉ� -- //

			// �g�����|�����̃A�j���[�^�[���擾����
			var animator = GetComponent<Animator>();

			// �W�����v���鎞�̃A�j���[�V�������Đ�����
			animator.Play( "Jump" );

			// -- �����܂Œǉ� -- //
		}
	}
}