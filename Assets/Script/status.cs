using UnityEngine;
using System.Collections;

public class status : MonoBehaviour {

/*    쉴드의 처리는 어떻게 할것인가?
 *    1.오브젝트는 쉴드에 2번 부딪히지는 않는다.
 *    2.쉴드는 단번에 깨지지 않는다.
 *    3.쉴드는 자동으로 천천히 회복한다
 *    4.쉴드가 완전히 없어 졌을 때에는, 몇초간 회복하지 않는다.
 *    5.쉴드는 유저가 강제로 회복 시킬수 있다. 돈을 써서.
 *    6.쉴드에 부딪히면, 물체의 공격력을 쉴드가 받는다.
 *    쉴드는 물체에 한번의 hp 또는 공격력을 감소시키는 효과를 준다.
 *    쉴드는 물체의 방어력을 무시한 데미지를 줄수 있다.
 *    쉴드 hp
 * 공격체 hp - 쉴드 atk
 * 
*/

    // For Global
    public int hp;
    public int atk;
    public int def;

    // For Enemy
    public bool isHitShield = false;

    // For Shield

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

	}
}
