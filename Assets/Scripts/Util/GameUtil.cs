using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System;

public class GameUtil : Singleton<GameUtil> {
	// 암호화에 쓰일 키 32자
	private string _key = "31391459313914593139145956789012";

	/*
	// 암호화
	Debug.Log(GameUtil.Encrypt("test", GameUtil.key));

	// 복호화
	Debug.Log(GameUtil.Decrypt("yitRA0hGWef6oXuLjYy9Rg==", GameUtil.key));
	*/

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/* 객체의 이름을 통하여 자식 요소를 찾아서 리턴하는 함수
	 * ex : ITexture texture = GetChildObj (obj, "ItemThumb").GetComponent<UITexture>(); 
	 */
	public GameObject GetChildObj( GameObject source, string itemName  ) { 
		Transform[] AllData = source.GetComponentsInChildren< Transform >(); 
		GameObject target = null;
		
		foreach( Transform Obj in AllData ) { 
			if( Obj.name == itemName ) { 
				target = Obj.gameObject;
				break;
			} 
		}
		
		return target;
	}

	/* AES 암호화
	 * Debug.Log(GameUtil.it.Encrypt("value",));
	 */
	public string Encrypt(string toEncrypt)
	{
		byte[] keyArray = UTF8Encoding.UTF8.GetBytes(_key);
		byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
		RijndaelManaged rDel = new RijndaelManaged();
		rDel.Key = keyArray;
		rDel.Mode = CipherMode.ECB;
		rDel.Padding = PaddingMode.PKCS7;
		ICryptoTransform cTransform = rDel.CreateEncryptor();
		byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
		return Convert.ToBase64String(resultArray, 0, resultArray.Length);
	}

	/* AES 복호화
	 * Debug.Log(GameUtil.it.Decrypt("yitRA0hGWef6oXuLjYy9Rg=="));
	 */
	public string Decrypt(string toDecrypt)
	{
		byte[] keyArray = UTF8Encoding.UTF8.GetBytes(_key);
		byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);
		RijndaelManaged rDel = new RijndaelManaged();
		rDel.Key = keyArray;
		rDel.Mode = CipherMode.ECB;
		rDel.Padding = PaddingMode.PKCS7;
		ICryptoTransform cTransform = rDel.CreateDecryptor();
		byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
		return UTF8Encoding.UTF8.GetString(resultArray);
	}

	/*
	 * Choose - 카드 뽑기 같은거 할때 사용
	 * 0 ~ 최대
	 */
	public int Choose(float[] probs){
		float total = 0f;
		foreach(float elem in probs){
			total += elem;
		}
		
		float randomPoint = UnityEngine.Random.value * total;
		
		for(int i=0; i<probs.Length; i++){
			if(randomPoint<probs[i])
				return i;
			
			else
				randomPoint -= probs[i];
		}
		return probs.Length-1;
	}
	
	/*
	 * RandomValue - 값중에 랜덤으로 하나 뽑아옴
	 */
	public int RandomValue(int prob){
		float randomPoint = UnityEngine.Random.value * prob;

		return (int)randomPoint;
	}
}
