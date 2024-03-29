﻿using System.Security.Cryptography;
using VHS.System.HashingProvider.Converters;

namespace VHS.System.HashingProvider.HashImplementations
{
    public class Sha1HashImplementation : IHashImplementation
    {
        private SHA1 _sha1;
        private ByteToStringConverter _btsc;

        public Sha1HashImplementation()
        {
            _sha1 = SHA1.Create();
            _btsc = new ByteToStringConverter();
        }

        public string HashBytes(byte[] input)
        {
            var hash = _sha1.ComputeHash(input);
            return _btsc.Convert(hash);
        }
    }
}