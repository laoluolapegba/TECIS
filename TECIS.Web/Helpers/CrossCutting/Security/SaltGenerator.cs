﻿using System;
using System.Security.Cryptography;
namespace TECIS.Web.Helpers.CrossCutting.Security
{
    public static class SaltGenerator
    {
        private static RNGCryptoServiceProvider m_cryptoServiceProvider = null;
        private const int SALT_SIZE = 24;

        static SaltGenerator()
        {
            m_cryptoServiceProvider = new RNGCryptoServiceProvider();
        }

        public static string GetSaltString()
        {
            // Lets create a byte array to store the salt bytes
            byte[] saltBytes = new byte[SALT_SIZE];


            m_cryptoServiceProvider.GetBytes(saltBytes);
            // Return a Base64 string representation of the random number
            return Convert.ToBase64String(saltBytes);

            //// lets generate the salt in the byte array
            //m_cryptoServiceProvider.GetNonZeroBytes(saltBytes);

            //// Let us get some string representation for this salt
            //string saltString = Utility.GetString(saltBytes);

            //// Now we have our salt string ready lets return it to the caller
            //return saltString;
        }
    }
}