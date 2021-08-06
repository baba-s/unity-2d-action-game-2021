using UnityEngine;

// �������𐧌䂷��X�N���v�g
public class MovePlatform : MonoBehaviour
{
	// �������̈ړ�����
	public Vector3 m_distance = new Vector3( 5, 0, 0 );

	// �������̈ړ����x
	public float m_speed = 0.5f;

	// �J�n�ʒu
	private Vector3 m_startPosition;

	// �I���ʒu
	private Vector3 m_endPosition;

	// �V�[�����J�n���鎞�ɌĂяo�����֐�
	private void Awake()
	{
		// ���݈ʒu���J�n�ʒu�Ƃ��ċL������
		m_startPosition = transform.localPosition;

		// �J�n�ʒu�ƈړ���������I���ʒu��ݒ肷��
		m_endPosition = m_startPosition + m_distance;
	}

	// ���t���[���Ăяo�����֐�
	private void Update()
	{
		// ���݂̈ʒu���v�Z����
		var t           = Mathf.PingPong( Time.time * m_speed, 1 );
		var newPosition = Vector3.Lerp( m_startPosition, m_endPosition, t );

		// ���݂̈ʒu�𔽉f����
		transform.localPosition = newPosition;
	}
}