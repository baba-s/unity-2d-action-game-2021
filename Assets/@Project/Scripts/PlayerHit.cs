using UnityEngine;

// �v���C���[�̂���A�j���[�V�����𐧌䂷��X�N���v�g
public class PlayerHit : MonoBehaviour
{
	// ����A�j���[�V�����̈ړ��̑���
	public Vector3 m_velocity = new Vector3( 0, 15, 0 );

	// ����A�j���[�V�����̈ړ��ɂ�����d�͂̋���
	public float m_gravity = 30;

	// ���t���[���Ăяo�����֐�
	private void Update()
	{
		// ����A�j���[�V�������ړ����܂�
		transform.localPosition += m_velocity * Time.deltaTime;

		// �d�͂�K�p���Ă��񂾂񗎉�����悤�ɂ��܂�
		m_velocity.y -= m_gravity * Time.deltaTime;
	}
}