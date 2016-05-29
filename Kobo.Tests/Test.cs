using NUnit.Framework;
using System;
using kobo;

namespace kobo.Tests
{
	[TestFixture ()]
	public class ConvertProductIDToISBN10Test
	{
		/// <summary>
		/// Tests some known ProductID expecting the correct ISBN-10
		/// </summary>
		[Test ()]
		/// <summary>
		/// Determines whether this instance can convert.
		/// </summary>
		/// <returns><c>true</c> if this instance can convert; otherwise, <c>false</c>.</returns>
		public void CanConvert ()
		{
			Assert.AreEqual ("1400079179", kobo.ISBNUtils.ProductID_2_ISBN10 ("978140007917"));
			Assert.AreEqual ("0375414576", kobo.ISBNUtils.ProductID_2_ISBN10 ("978037541457"));
			Assert.AreEqual ("0374281580", kobo.ISBNUtils.ProductID_2_ISBN10 ("978037428158"));
			Assert.AreEqual ("155192370x", kobo.ISBNUtils.ProductID_2_ISBN10 ("978155192370"));
		}

		/// <summary>
		/// Tests the returning of an Exception when the input ProductID is longer or shorter than 12 digits.
		/// </summary>
		[Test ()]
		/// <summary>
		/// Checks the product identifier length12.
		/// </summary>
		public void CheckProductIdLength12 ()
		{
			Assert.Throws<FormatException>(() => kobo.ISBNUtils.ProductID_2_ISBN10 ("1234567890123"));
			Assert.Throws<FormatException>(() => kobo.ISBNUtils.ProductID_2_ISBN10 ("12345678901"));
		}

		/// <summary>
		/// Tests the returning of an Exception when the input ProductID has a character that's not a digit.
		/// </summary>
		[Test ()]
		/// <summary>
		/// Checks the that product identifier has not invalid characters.
		/// </summary>
		public void CheckThatProductIdHasNotInvalidCharacters ()
		{
			Assert.Throws<FormatException>(() => kobo.ISBNUtils.ProductID_2_ISBN10 ("123a56789012"));
			Assert.Throws<FormatException>(() => kobo.ISBNUtils.ProductID_2_ISBN10 ("12345678901x"));
		}
	}
}

