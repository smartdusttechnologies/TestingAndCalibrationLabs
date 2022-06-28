using System;
using System.Collections.Generic;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Common
{
    public static class Helpers
    {

        public static long ToUnixEpochDate(DateTime date) => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        public static bool ValidateMinimumSmallChars(string password, int expectedCount)
        {
            int smallCharCount = 0;
            foreach (char c in password)
            {
                if (c >= 'a' && c <= 'z')
                {
                    smallCharCount++;
                    if (expectedCount == smallCharCount)
                        return true;
                }
            }
            return false;
        }

        public static bool ValidateMinimumCapsChars(string password, int expectedCount)
        {
            int capsCharCount = 0;
            foreach (char c in password)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    capsCharCount++;
                    if (expectedCount == capsCharCount)
                        return true;
                }
            }
            return false;
        }

        public static bool ValidateMinimumDigits(string password, int expectedCount)
        {
            int minDigitCount = 0;
            foreach (char c in password)
            {
                if (c >= '0' && c <= '9')
                {
                    minDigitCount++;
                    if (expectedCount == minDigitCount)
                        return true;
                }
            }
            return false;
        }

        public static bool ValidateMinimumSpecialChars(string password, int expectedCount)
        {
            int minSpecialCharCount = 0;
            char[] special = { '@', '#', '$', '%', '^', '&', '+', '=' };
            foreach (char c in special)
            {
                if (password.IndexOf(c) != -1)
                {
                    minSpecialCharCount++;
                    if (expectedCount == minSpecialCharCount)
                        return true;
                }
            }
            return false;
        }

        public static bool ValidateDisallowedChars(string password, string disallowedChars)
        {
            if (string.IsNullOrEmpty(disallowedChars))
                return true;

            foreach (char c in disallowedChars)
            {
                if (password.IndexOf(c) != -1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
