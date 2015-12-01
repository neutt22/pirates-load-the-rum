using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

	void Awake () {
		// Explosion particle only lasts 1 second then destroy
		Destroy(gameObject, 1f);
	}
}
