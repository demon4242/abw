using System.Linq;

namespace abw.Common
{
	public static class StringExtenstions
	{
		public static string UpperFirstLetter(this string input)
		{
			var result = input.First().ToString().ToUpper() + string.Join(string.Empty, input.Skip(1));
			return result;
		}

		public static string LowerFirstLetter(this string input)
		{
			var result = input.First().ToString().ToLower() + string.Join(string.Empty, input.Skip(1));
			return result;
		}
	}
}
