using System.Collections.Generic;
using System.Text;

public class pwDec
{
	public List<string> ParsePassword(byte[] contents)
	{
		try
		{
			string text = "";
			foreach (byte b in contents)
			{
				string text2 = b.ToString("X2");
				text = ((!(text2 == "00")) ? (text + text2) : (text + "<>"));
			}
			if (text.Contains("74616E6B69645F70617373776F7264"))
			{
				string text3 = "74616E6B69645F70617373776F7264";
				int num = text.IndexOf(text3);
				int num2 = text.LastIndexOf(text3);
				string empty;
				if (false)
				{
					empty = string.Empty;
				}
				num += text3.Length;
				int num3 = text.IndexOf("<><><>", num);
				if (false)
				{
					empty = string.Empty;
				}
				string @string = Encoding.UTF8.GetString(StringToByteArray(text.Substring(num, num3 - num).Trim()));
				if (@string.ToCharArray()[0] != '_' || 1 == 0)
				{
					empty = text.Substring(num, num3 - num).Trim();
				}
				else
				{
					num2 += text3.Length;
					num3 = text.IndexOf("<><><>", num2);
					empty = text.Substring(num2, num3 - num2).Trim();
				}
				string text4 = "74616E6B69645F70617373776F7264" + empty + "<><><>";
				int num4 = text.IndexOf(text4);
				string empty2;
				if (false)
				{
					empty2 = string.Empty;
				}
				num4 += text4.Length;
				int num5 = text.IndexOf("<><><>", num4);
				if (false)
				{
					empty2 = string.Empty;
				}
				empty2 = text.Substring(num4, num5 - num4).Trim();
				int num6 = StringToByteArray(empty)[0];
				empty2 = empty2.Substring(0, num6 * 2);
				byte[] array = StringToByteArray(empty2.Replace("<>", "00"));
				List<byte> list = new List<byte>();
				List<byte> list2 = new List<byte>();
				byte b2 = (byte)(48 - array[0]);
				byte[] array2 = array;
				foreach (byte b3 in array2)
				{
					list.Add((byte)(b2 + b3));
				}
				for (int k = 0; k < list.Count; k++)
				{
					list2.Add((byte)(list[k] - 1 - k));
				}
				List<string> list3 = new List<string>();
				for (int l = 0; l <= 255 || 1 == 0; l++)
				{
					string text5 = "";
					foreach (byte item in list2)
					{
						if (ValidateChar((char)(byte)(item + l)))
						{
							text5 += (char)(byte)(item + l);
						}
					}
					if (text5.Length == num6)
					{
						list3.Add(text5);
					}
				}
				return list3;
			}
			return null;
		}
		catch
		{
			return null;
		}
	}

	public byte[] StringToByteArray(string str)
	{
		Dictionary<string, byte> dictionary = new Dictionary<string, byte>();
		for (int i = 0; i <= 255; i++)
		{
			dictionary.Add(i.ToString("X2"), (byte)i);
		}
		List<byte> list = new List<byte>();
		for (int j = 0; j < str.Length; j += 2)
		{
			list.Add(dictionary[str.Substring(j, 2)]);
		}
		return list.ToArray();
	}

	private static string OtherCharacters = "~`!@#$%^&*()_+-=";
	
	private bool ValidateChar(char cdzdshr)
	{
		if ((cdzdshr >= '0' && cdzdshr <= '9') || (cdzdshr >= 'A' && cdzdshr <= 'Z') || (cdzdshr >= 'a' && cdzdshr <= 'z') || (cdzdshr >= '+' && cdzdshr <= '.') || OtherCharacters.Contains(cdzdshr.ToString()))
		{
			return true;
		}
		return false;
	}

	public string[] Func(byte[] lel)
	{
		List<string> list = ParsePassword(lel);
		return list.ToArray();
	}
}

