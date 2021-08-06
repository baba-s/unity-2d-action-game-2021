using System.Collections;
using UnityEngine;

// �J������h�炷�X�N���v�g
public class CameraShaker : MonoBehaviour
{
	// �J������h�炷���ԁi�b�j
	public float m_duration = 0.25f;

	// �J������h�炷����
	public float m_magnitude = 0.1f;

	// �J������h�炷
	public void Shake()
	{
		StartCoroutine( DoShake() );
	}

	// �J������h�炷�������R���[�`���Ŏ�������֐�
	private IEnumerator DoShake()
	{
		// �J�����̈ʒu���L�����Ă���
		var pos = transform.localPosition;

		// �J������h�炵�n�߂Ă���̌o�ߎ���
		var elapsed = 0f;

		// �܂��J������h�炷���ԓ��̏ꍇ
		while ( elapsed < m_duration )
		{
			// �J������h�炷���߂Ɉʒu�������_���ɓ�����
			var x = pos.x + Random.Range( -1f, 1f ) * m_magnitude;
			var y = pos.y + Random.Range( -1f, 1f ) * m_magnitude;

			transform.localPosition = new Vector3( x, y, pos.z );

			// �J������h�炵�n�߂Ă���̌o�ߎ��Ԃ�i�߂�
			elapsed += Time.deltaTime;

			// ���̃t���[���ł̏�������U���f����
			yield return null;
		}

		// �J������h�炵�I������珉���ʒu�ɖ߂�
		transform.localPosition = pos;
	}
}