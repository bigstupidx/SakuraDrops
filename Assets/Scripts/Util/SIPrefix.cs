using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;

public class SIPrefix : MonoBehaviour {
	private static List<SIPrefixInfo> _SIPrefixInfoList = new
		List<SIPrefixInfo>();

	static SIPrefix()
	{
		_SIPrefixInfoList = new List<SIPrefixInfo>();
		LoadSIPrefix();
	}

	public static List<SIPrefixInfo> SIPrefixInfoList
	{ 
		get 
		{ 
			SIPrefixInfo[] siPrefixInfoList = new SIPrefixInfo[6];
			_SIPrefixInfoList.CopyTo(siPrefixInfoList);
			return siPrefixInfoList.ToList();
		}
	}

	private static void LoadSIPrefix()
	{
		_SIPrefixInfoList.AddRange (new SIPrefixInfo[] {
			new SIPrefixInfo () {
				Symbol = "Y",
				Prefix = "yotta",
				Example = 1.0e24,
				ZeroLength = 24,
				ShortScaleName = "Septillion",
				LongScaleName = "Quadrillion"
			},
			new SIPrefixInfo () {
				Symbol = "Z",
				Prefix = "zetta",
				Example = 1.0e21,
				ZeroLength = 21,
				ShortScaleName = "Sextillion",
				LongScaleName = "Trilliard"
			},
			new SIPrefixInfo () {
				Symbol = "E",
				Prefix = "exa",
				Example = 1.0e18,
				ZeroLength = 18,
				ShortScaleName = "Quintillion",
				LongScaleName = "Trillion"
			},
			new SIPrefixInfo () {
				Symbol = "P",
				Prefix = "peta",
				Example = 1.0e15,
				ZeroLength = 15,
				ShortScaleName = "Quadrillion",
				LongScaleName = "Billiard"
			},
			new SIPrefixInfo () {
				Symbol = "T",
				Prefix = "tera",
				Example = 1.0e12,
				ZeroLength = 12,
				ShortScaleName = "Trillion",
				LongScaleName = "Billion"
			},
			new SIPrefixInfo () {
				Symbol = "G",
				Prefix = "giga",
				Example = 1.0e9,
				ZeroLength = 9,
				ShortScaleName = "Billion",
				LongScaleName = "Milliard"
			},
			new SIPrefixInfo () {
				Symbol = "M",
				Prefix = "mega",
				Example = 1.0e6,
				ZeroLength = 6,
				ShortScaleName = "Million",
				LongScaleName = "Million"
			},
			new SIPrefixInfo () {
				Symbol = "K",
				Prefix = "kilo",
				Example = 1.0e3,
				ZeroLength = 3,
				ShortScaleName = "Thousand",
				LongScaleName = "Thousand"
			},
			new SIPrefixInfo () {
				Symbol = "h",
				Prefix = "hecto",
				Example = 1.0e2,
				ZeroLength = 2,
				ShortScaleName = "Hundred",
				LongScaleName = "Hundred"
			},
			new SIPrefixInfo () {
				Symbol = "da",
				Prefix = "deca",
				Example = 1.0e1,
				ZeroLength = 1,
				ShortScaleName = "Ten",
				LongScaleName = "Ten"
			},
			new SIPrefixInfo () {
				Symbol = "",
				Prefix = "",
				Example = 1,
				ZeroLength = 0,
				ShortScaleName = "One",
				LongScaleName = "One"
			},
		});
	}

	public static SIPrefixInfo GetInfo(ulong amount, int decimals = 2)
	{
		if (amount >= ulong.MaxValue) {
			amount = ulong.MaxValue;
		}

		return GetInfo(Convert.ToDouble(amount), decimals);
	}

	public static SIPrefixInfo GetInfo(double amount, int decimals = 2)
	{
		SIPrefixInfo siPrefixInfo = null;
		double amountToTest = Math.Abs(amount);

		var amountLength = amountToTest.ToString("0").Length;
		if(amountLength < 3)
		{
			siPrefixInfo = _SIPrefixInfoList.Find(i => i.ZeroLength == amountLength).Clone() as SIPrefixInfo;
			siPrefixInfo.AmountWithPrefix =  Math.Round(amount, decimals).ToString();

			return siPrefixInfo;
		}

		siPrefixInfo = _SIPrefixInfoList.Find(i => amountToTest > i.Example).Clone() as SIPrefixInfo;

		siPrefixInfo.AmountWithPrefix = Math.Round(
			amountToTest / Convert.ToDouble(siPrefixInfo.Example), decimals).ToString()
			+ siPrefixInfo.Symbol;

		return siPrefixInfo;
	}
}

public class SIPrefixInfo : ICloneable
{
	public string Symbol { get; set; }
	public double Example { get; set; }
	public string Prefix { get; set; }
	public int ZeroLength { get; set; }
	public string ShortScaleName { get; set; }
	public string LongScaleName { get; set; }
	public string AmountWithPrefix { get; set; }

	public object Clone()
	{
		return new SIPrefixInfo()
		{
			Example = this.Example,
			LongScaleName = this.LongScaleName,
			ShortScaleName = this.ShortScaleName,
			Symbol = this.Symbol,
			Prefix = this.Prefix,
			ZeroLength = this.ZeroLength
		};

	}
}