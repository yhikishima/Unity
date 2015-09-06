﻿
using UnityEngine;
using System.Collections;

public class AttackArea : MonoBehaviour {
	CharacterStatus status;

	void Start()
	{
		status = transform.root.GetComponent<CharacterStatus>();
	}


	public class AttackInfo
	{
		public int attackPower; // この攻撃の攻撃力.
		public Transform attacker; // 攻撃者.
	}


	// 攻撃情報を取得する.
	AttackInfo GetAttackInfo()
	{			
		AttackInfo attackInfo = new AttackInfo();
		// 攻撃力の計算.
		attackInfo.attackPower = status.Power;
		if (status.attackPowerBoost)
			attackInfo.attackPower += attackInfo.attackPower / 2;

		attackInfo.attacker = transform.root;
		
		return attackInfo;
	}

	// 当たった.
	void OnTriggerEnter(Collider other)
	{
		// 攻撃が当たった相手のDamageメッセージをおくる.
		other.SendMessage("Damage",GetAttackInfo());
	}


	// 攻撃判定を有効にする.
	void OnAttack()
	{
		collider.enabled = true;
	}


	// 攻撃判定を無効にする.
	void OnAttackTermination()
	{
			collider.enabled = false;
	}
}
