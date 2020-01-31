using System;
using System.Linq;

namespace PalindromeApp
{
    internal class Program
    {
        #region  Static Fields

        private const int MIN_NUMBER = 10000;
        private const int MAX_NUMBER = 99999;

        private static readonly string POSITIVE_ANSWER = @"Yes :)";
        private static readonly string NEGATIVE_ANSWER = @"No :(";

        #endregion

        #region  Public Methods

        public static bool IsPrimeNumber( int number )
        {
            if ( number <= 1 ) return false;

            if ( number == 2 ) return true;

            if ( number % 2 == 0 ) return false;

            var boundary = (int) Math.Floor( Math.Sqrt( number ) );
            for ( var i = 3; i <= boundary; i += 2 )
                if ( number % i == 0 )
                    return false;

            return true;
        }

        public static bool IsPalindrome( string text )
        {
            if ( string.IsNullOrWhiteSpace( text ) ) return false;

            var reversed = new string( text.Reverse().ToArray() );

            return string.Equals( text, reversed, StringComparison.OrdinalIgnoreCase );
        }

        public static long GetLargestPalindrome( out int firstNumber, out int secondNumber )
        {
            long largestPalindrome = 0;
            firstNumber = 0;
            secondNumber = 0;

            for ( var i = MAX_NUMBER; i > MIN_NUMBER; i-- )
                if ( IsPrimeNumber( i ) )
                    for ( var j = i; j > MIN_NUMBER; j-- )
                        if ( IsPrimeNumber( j ) )
                        {
                            var product = (long) i * j;
                            if ( product < largestPalindrome ) break;

                            if ( IsPalindrome( product.ToString() ) && product > largestPalindrome )
                            {
                                largestPalindrome = product;
                                firstNumber = i;
                                secondNumber = j;
                            }
                        }

            return largestPalindrome;
        }

        public static void Main()
        {
            Console.WriteLine( "Starting..." );

            var palindrome = GetLargestPalindrome( out var firstNumber, out var secondNumber );

            Console.WriteLine( $"Palindrome: {palindrome} | Really Palindrome? {( IsPalindrome( palindrome.ToString() ) ? POSITIVE_ANSWER : NEGATIVE_ANSWER )}" );
            Console.WriteLine( $"First Number: {firstNumber} | Is Prime Number? {( IsPrimeNumber( firstNumber ) ? POSITIVE_ANSWER : NEGATIVE_ANSWER )}" );
            Console.WriteLine( $"Second Number: {secondNumber} | Is Prime Number? {( IsPrimeNumber( secondNumber ) ? POSITIVE_ANSWER : NEGATIVE_ANSWER )}" );
            Console.WriteLine( $"Product of first number * second number ({firstNumber} * {secondNumber}) =  {firstNumber * secondNumber}" );
            Console.WriteLine( $"Checking ({firstNumber} * {secondNumber} = {palindrome}) {palindrome == firstNumber * secondNumber}" );
        }

        #endregion
    }
}