using System;

namespace kobo
{
	/// <summary>
	/// ISBNUtils has a set of public methods to work on ISBN codes.
	/// </summary>
	public class ISBNUtils
	{
		/// <summary>
		/// Convert a 12-digits ProductID number to standard ISBN-10 number.
		/// </summary>
		/// <returns>The ISBN-10 number.</returns>
		/// <param name="product_id">12-digits ProductID.</param>
		public static string ProductID_2_ISBN10(string product_id)
		{
			if (product_id.Length != 12) {
				throw new FormatException ("The string is not a 12 digits product id.");
			}

			string isbn;
			int ctrl = 0, c;

			// remove the first three characters as they're the prefix
			isbn = product_id.Substring (3,9);

			// calculate the weighted sum of the difits
			for (int i = 0; i < isbn.Length; i++){
				c = (int)Char.GetNumericValue(isbn[i]);
				if (c < 0 || c > 9) {
					// this is not a digit
					throw new FormatException ("All the characters of the string should be digits.");
				} else {
					ctrl += (10 - i) * c;
				}
			}

			// how much is missing to make the weighted sum a multiple of 11?
			ctrl = 11 - (ctrl % 11);

			if (ctrl == 11) {
				// then the weighted sum was already a multiple oof 11, set the control character to 0
				isbn += "0";
			} else if (ctrl == 10) {
				// cannot put "10" as the controlo character
				isbn += "x";
			} else {
				// add the number as controlo character
				isbn += Math.Abs(ctrl).ToString ();
			}

			return isbn;
		}
	}


	/// <summary>
	/// Main class: written just to test the ProductID_2_ISBN10 from command line.
	/// </summary>
	/// Call the program with the 12-digits ProductID as a parameter.
	class MainClass
	{
		public static void Main (string[] args)
		{

			if (args.Length < 1) {
				Console.WriteLine ("This program converts a product id (12 digits) to an ISBN-10 number");
				Console.WriteLine ("Call the program with the 12-digits ProductID as a parameter.");
				System.Environment.Exit (1);
			}
			Console.WriteLine ( ISBNUtils.ProductID_2_ISBN10(args[0]) );

		}
	}

}
