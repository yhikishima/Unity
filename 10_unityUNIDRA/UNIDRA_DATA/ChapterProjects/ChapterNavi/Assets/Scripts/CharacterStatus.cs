using UnityEngine;
using System.Collections;

public class CharacterStatus : MonoBehaviour {
	public int level = 1;
	public int HP = 100;
	public int MaxHP = 100;

	public int Power = 10;
	public int EXP = 0;
	
	//-------- プレイヤー情報 --------.
	public string playerName;
	
	//-------- ステータス ---------.
	
	public bool attacking = false;
	public bool died = false;
	public bool allowMovieng = true;
	public bool attackPowerBoost = false;
	public bool speedBoost = false;

	// ---------- 以下のコードはAIの章で説明されます.　----------
	float attackPowerTime = 0.0f;
	float speedTime = 0.0f;

	public void GetItem( DropItem.ItemKind itemKind ){
		switch( itemKind )
		{
		case DropItem.ItemKind.Attack:
			attackPowerTime = 5.0f;
			break;
		case DropItem.ItemKind.Speed:
			speedTime = 5.0f;
			break;
		};
	}

	void update()
	{
		attackPowerBoost = false;
		speedBoost = false;

		if( attackPowerTime > 0.0f ){
			attackPowerBoost = true;
			attackPowerTime = Mathf.Max( attackPowerTime - Time.deltaTime, 0.0f );
		}
		if( speedTime > 0.0f ){
			speedBoost = true;
			speedTime = Mathf.Max( speedTime - Time.deltaTime, 0.0f );
		}
	}
}
