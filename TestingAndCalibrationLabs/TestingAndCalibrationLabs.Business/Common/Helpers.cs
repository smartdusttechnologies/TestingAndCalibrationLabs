using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace TestingAndCalibrationLabs.Business.Common
{

    public static class Helpers
    {
        private static char[] charSet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        #region Public Methods.

        public static DateTime? ConverddmmyyyyTommddyyyy(string dateString)
        {
            DateTime dt;
            if (DateTime.TryParseExact(dateString,
                                        "d/M/yyyy",
                                        CultureInfo.InvariantCulture,
                                        DateTimeStyles.None,
                out dt))
            {
                return dt;
            }
            return null;
        }
        
        public static bool IsEmail(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        }
        public static string Base64Encode(string strOriginal)
        {
            string strModified = null;
            if (!string.IsNullOrEmpty(strOriginal))
            {
                byte[] byt = Encoding.UTF8.GetBytes(strOriginal);
                strModified = Convert.ToBase64String(byt);
            }
            return strModified;
        }
        public static string Base64Decode(string strModified)
        {
            string strOriginal = null;
            if (!string.IsNullOrEmpty(strModified))
            {
                byte[] b = Convert.FromBase64String(strModified);
                strOriginal = Encoding.UTF8.GetString(b, 0, b.Length);
            }
            return strOriginal;
        }
        public static string DecimalToBinary(int decimalNumber)
        {
            string binaryNumber = Convert.ToString(decimalNumber, 2);
            return binaryNumber;
        }
        public static int BinaryToDecimal(string binaryNumber)
        {
            int decimalNumber = Convert.ToInt32(binaryNumber, 2);
            return decimalNumber;
        }
        public static string Base62Encode(long value)
        {
            string sixtyNum = string.Empty;
            if (value < 62)
            {
                sixtyNum = charSet[value].ToString();
            }
            else
            {
                long result = value;
                while (result > 0)
                {
                    long val = result % 62;
                    sixtyNum = charSet[val] + sixtyNum;
                    result = result / 62;
                }
            }
            return sixtyNum;
        }
        public static string MD5Hash(string input)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
                var strResult = BitConverter.ToString(result);
                return strResult.Replace("-", "");
            }
        }
        public static long[] GetPermissionsByPermissionCode(int permissionCode)
        {
            string bPermissionCode = Helpers.DecimalToBinary(permissionCode);
            long[] permissions = new long[bPermissionCode.Length];
            for (int i = 0; i < bPermissionCode.Length; i++)
            {
                long currentBinaryPermission = Convert.ToInt32(bPermissionCode.Substring(bPermissionCode.Length - i - 1));
                for (int j = 0; j < i; j++)
                {
                    currentBinaryPermission = currentBinaryPermission - permissions[j];
                }
                permissions[i] = currentBinaryPermission;
            }
            for (int k = 0; k < bPermissionCode.Length; k++)
            {
                permissions[k] = Helpers.BinaryToDecimal(permissions[k].ToString());
            }

            return permissions;
        }
        public static string GetFixedDigitNumber(long number, int digit)
        {
            string result = null;
            if (number > 0)
            {
                result = number.ToString().PadLeft(digit, '0');
            }
            return result;
        }
        public static string GetDataTimeString(DateTime date)
        {
            return date.ToString("yyyyMMddHHmmss");
        }
        public static string GetDataTimeString(DateTimeOffset date)
        {
            return date.ToString("yyyyMMddHHmmss");
        }
        public static DateTime UnixTimestampToDateTime(double unixTime)
        {
            DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            long unixTimeStampInTicks = (long)(unixTime * TimeSpan.TicksPerSecond);
            return new DateTime(unixStart.Ticks + unixTimeStampInTicks);
        }
        public static double DateTimeToUnixTimestamp(DateTime dateTime)
        {
            DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            long unixTimeStampInTicks = (dateTime.ToUniversalTime() - unixStart).Ticks;
            return (double)unixTimeStampInTicks / TimeSpan.TicksPerSecond;
        }
        public static DateTimeOffset UnixTimestampToDateTimeOffset(double unixTime)
        {
            DateTimeOffset unixStart = new DateTimeOffset(1970, 1, 1, 0, 0, 0, 0, new TimeSpan(0, 0, 0));
            long unixTimeStampInTicks = (long)(unixTime * TimeSpan.TicksPerSecond);
            return new DateTimeOffset(unixStart.Ticks + unixTimeStampInTicks, new TimeSpan(0, 0, 0));
        }
        public static double DateTimeOffsetToUnixTimestamp(DateTimeOffset dateTime)
        {
            DateTimeOffset unixStart = new DateTimeOffset(1970, 1, 1, 0, 0, 0, 0, new TimeSpan(0, 0, 0));
            long unixTimeStampInTicks = (dateTime.ToUniversalTime() - unixStart).Ticks;
            return (double)unixTimeStampInTicks / TimeSpan.TicksPerSecond;
        }
       public static long ToUnixEpochDate(DateTime date) => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        /// <summary>
        /// Method to Validate Minimum Small char based on password Policy Set
        /// </summary>
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
        /// <summary>
        /// Method to Validate the Minimum Caps Chars in Passoord Based on password Policy Set
        /// </summary>
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
        /// <summary>
        /// Method to Validate Minimum Digits for password
        /// </summary>
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
        /// <summary>
        /// Method to validate Special charcs in password
        /// </summary>
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
        /// <summary>
        /// Method to Validate Disallowed Chars
        /// </summary>
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

        #endregion

        #region Private Methods.

        private static int GetCurrentGreenwichHourIn24()
        {
            int thisHour = Convert.ToInt32((DateTimeOffset.Now + DateTimeOffset.Now.Offset).ToString("yyyy-MM-dd HH:mm:ss").Substring(11, 2));
            return thisHour;
        }

     


        public static string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        public static Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
    #endregion
}   
