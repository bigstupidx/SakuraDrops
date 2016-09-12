﻿using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;

public class StringUtil : MonoBehaviour {

	// 초성, 중성, 종성에 대한 코드 테이블.
	private static string m_ChoSungTbl = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";
	private static string m_JungSungTbl = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ";
	private static string m_JongSungTbl = " ㄱㄲㄳㄴㄵㄶㄷㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅄㅅㅆㅇㅈㅊㅋㅌㅍㅎ";
	
	private static ushort m_UniCodeHangulBase = 0xAC00;
	private static ushort m_UniCodeHangulLast = 0xD79F;
	
	//조사 처리
	static public string AddSuffix(string hanStr, string type1 = "을", string type2 = "를")
	{
		string str;
		
		char charStr = hanStr[hanStr.Length-1];

		char[] divided = DivideJaso (charStr);

		if( divided == null )
		{
			str = hanStr + type1;
			
			return str;
		}

		if (divided [2].GetHashCode() == 32) {
			str = hanStr + type2;
		} else {
			str = hanStr + type1;
		}
		
		return str;
	}
	
	//자소 결합
	public static string MergeJaso(string choSung, string jungSung, string jongSung)
	{
		int ChoSungPos, JungSungPos, JongSungPos;
		int nUniCode;
		
		ChoSungPos = m_ChoSungTbl.IndexOf(choSung);     // 초성 위치
		JungSungPos = m_JungSungTbl.IndexOf(jungSung);   // 중성 위치
		JongSungPos = m_JongSungTbl.IndexOf(jongSung);   // 종성 위치
		
		// 앞서 만들어 낸 계산식
		nUniCode = m_UniCodeHangulBase + (ChoSungPos * 21 + JungSungPos) * 28 + JongSungPos;
		
		// 코드값을 문자로 변환
		char temp = Convert.ToChar(nUniCode);
		return temp.ToString();
	}
	
	//자소 분리(초성+중성+종성)
	public static char[] DivideJaso(char hanChar)
	{
		int ChoSung, JungSung, JongSung;
		
		ushort temp = 0x0000;
		
		try
		{
			temp = Convert.ToUInt16(hanChar); //Char을 16비트 부호없는 정수형 형태로 변환
		}
		catch (Exception e)
		{
			Debug.Log("Error " + e);
		}
		
		if ((temp < m_UniCodeHangulBase) || (temp > m_UniCodeHangulLast)) return null;
		
		//초성자, 중성자, 종성자 Index계산
		int nUniCode = temp - m_UniCodeHangulBase;
		ChoSung = nUniCode / (21 * 28);
		nUniCode = nUniCode % (21 * 28);
		JungSung = nUniCode / 28;
		nUniCode = nUniCode % 28;
		JongSung = nUniCode;
		
		return new char[] { m_ChoSungTbl[ChoSung], m_JungSungTbl[JungSung], m_JongSungTbl[JongSung] };
	}
	
	public enum LanguageType
	{
		Unknown
		, OverBound
		, OneByteChar
		, Korean // 완성형 문자
		, KoreanJaum // 자음
		, KoreanMoum // 모음
		, Chinese // 한글 한자
		, Japanese // 일본 가나
	}
	
	/// <summary>
	/// KS-완성형 코드 기반 문자 판별 함수
	/// </summary>
	public static LanguageType GetLangageType(string sourceString)
	{
		if (sourceString.Length > 2)
			return LanguageType.OverBound;
		
		byte[] _tmp = Encoding.Default.GetBytes(sourceString);
		
		if (_tmp.Length != 2)
			return LanguageType.OneByteChar;
		
		if ((_tmp[1] > 0xFE) || (_tmp[1] < 0xA1))
			return LanguageType.Unknown;
		
		if ((_tmp[0] >= 0xB0) && (_tmp[0] <= 0xC8)) // 완성형 문자
			return LanguageType.Korean;
		else if (_tmp[0] == 0xA4) // 한글 자모
		{
			if (_tmp[1] >= 161 && _tmp[1] <= 190) // 자음
				return LanguageType.KoreanJaum;
			else // 모음
				return LanguageType.KoreanMoum;
		}
		else if ((_tmp[0] >= 0xCA) && (_tmp[0] <= 0xFD)) // 한글 한자
			return LanguageType.Chinese;
		
		if ((_tmp[0] >= 0xAA) && (_tmp[0] <= 0XAB)) // 일본 가나
			return LanguageType.Japanese;
		
		return LanguageType.Unknown;
	}

	// FormatCash
//	public static string FormatCash(ulong num)
//	{
//		if (Language.CurrentLanguage () != LanguageCode.KO) {
//			return SIPrefix.GetInfo (num, 0).AmountWithPrefix;
//		}
//
//		bool UseDecimal=false;
//		string Sign ="";
//		int i =0;
//		int Level =0;
//
//		string[] NumberChar = new string[]{ "", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
//		string[] LevelChar = new string[]{ "", "십", "백", "천" };
//		string[] DecimalChar = new string[]{ "", "만", "억", "조", "경", "해", "자" };
//
//		string strValue = string.Format("{0}", num);
//		string NumToKorea = Sign;
//		UseDecimal = false;
//
//		for( i = 0 ; i<strValue.Length; i++)
//		{
//			Level = strValue.Length - i;
//
//			if (strValue.Substring (i, 1) != "0") {
//				UseDecimal = true;
//				if (((Level - 1) % 4) == 0) {
//					NumToKorea = NumToKorea + NumberChar [int.Parse (strValue.Substring (i, 1))] + DecimalChar [(Level - 1) / 4];
//					UseDecimal = false;
//				} else {
//					if (strValue.Substring (i, 1) == "1")
//						NumToKorea = NumToKorea + LevelChar [(Level - 1) % 4];
//					else
//						NumToKorea = NumToKorea + NumberChar [int.Parse (strValue.Substring (i, 1))] + LevelChar [(Level - 1) % 4];
//				}
//			} else {
//				if (((Level - 1) % 4) == 0 && strValue.Length <= 8) {
//					NumToKorea = NumToKorea + DecimalChar [(Level - 1) / 4];
//				}
//			}
//		}
//		return NumToKorea;
//	}

	// FormatCash
	public static string FormatCash(double num)
	{
		return SIPrefix.GetInfo (num, 2).AmountWithPrefix;
	}
}