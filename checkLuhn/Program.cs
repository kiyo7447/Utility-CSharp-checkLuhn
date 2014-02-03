using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkLuhn
{
	class Program
	{
		static void Main(string[] args)
        {

			bool f = IsCreditCardValid(args[0]);

			if (f == true)
				Console.WriteLine("ok!");
			else
				Console.WriteLine("ng!");
        }

		public static bool IsCreditCardValid(string cardNumber)
		{
			const string allowed = "0123456789";
			int i;

			StringBuilder cleanNumber = new StringBuilder();
			for (i = 0; i < cardNumber.Length; i++)
			{
				if (allowed.IndexOf(cardNumber.Substring(i, 1)) >= 0)
					cleanNumber.Append(cardNumber.Substring(i, 1));
			}
			if (cleanNumber.Length < 13 || cleanNumber.Length > 16)
				return false;

			for (i = cleanNumber.Length + 1; i <= 16; i++)
				cleanNumber.Insert(0, "0");

			int multiplier, digit, sum, total = 0;
			string number = cleanNumber.ToString();

			for (i = 1; i <= 16; i++)
			{
				multiplier = 1 + (i % 2);
				digit = int.Parse(number.Substring(i - 1, 1));
				sum = digit * multiplier;
				if (sum > 9)
					sum -= 9;
				total += sum;
			}
			return (total % 10 == 0);
		}
	}
}
