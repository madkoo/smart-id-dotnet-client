﻿using System;
using System.Linq;
using System.Security.Cryptography;

namespace SmartId.Helper
{
    public static class VerificationCodeCalculator
    {
        /// <summary>
        /// Generates randomly generated hash in Base64 fromat
        /// </summary>
        /// <returns>randomly generated hash in Base64 fromat</returns>
        public static byte[] GenerateRandomSHA512()
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] bytes = GetRandomBytes();
                return sha512.ComputeHash(bytes);

            }
        }

        /// <summary>
        /// Converts byte array to base64 string
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static string ToBase64String(byte[] hash)
        {
            return Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Generate random bytes
        /// </summary>
        /// <returns></returns>
        private static byte[] GetRandomBytes()
        {
            RNGCryptoServiceProvider rnd = new RNGCryptoServiceProvider();
            var randomBytes = new byte[64];
            rnd.GetBytes(randomBytes);
            return randomBytes;
        }

        /// <summary>
        /// The Verification Code(VC) is computed as:
        /// integer(SHA256(hash)[−2:−1]) mod 10000
        /// where we take SHA256 result, extract 2 rightmost bytes from it,
        /// interpret them as a big-endian unsigned integer and take the last 4 digits in decimal for display.
        /// SHA256 is always used here, no matter what was the algorithm used to calculate hash.
        /// </summary>
        /// <param name="hash"></param>
        /// <returns>Verification code</returns>
        public static string CalculateVerificationCode(byte[] hash)
        {
            //integer(SHA256(hash)[−2:−1]) mod 10000
            using (SHA256 sha256 = SHA256.Create())
            {
                //where we take SHA256 result
                var sha256Result = sha256.ComputeHash(hash);
                //extract 2 rightmost bytes from it,
                var twoRightmostBytes = sha256Result.Reverse().Take(2).ToArray();

                //interpret them as a big - endian unsigned integer
                ushort positiveInteger = BitConverter.ToUInt16(twoRightmostBytes, 0);

                //Take 4 last digits
                return positiveInteger.ToString().GetLast(4);
            }
        }
    }
}
