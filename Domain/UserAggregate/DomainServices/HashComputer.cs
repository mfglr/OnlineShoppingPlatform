using System.Security.Cryptography;
using System.Text;

namespace Domain.UserAggregate.DomainServices
{
    internal static class HashComputer
    {
        private static readonly int _iterationCount = 10000;
        private static readonly byte[] _iterationCountBytes = BitConverter.GetBytes(_iterationCount);

        private static readonly int _iterationCountLength = 4;
        private static readonly int _saltLength = 16;
        private static readonly int _hashLength = 32;
        private static readonly int _resultLength = _iterationCountLength + _saltLength + _hashLength;

        private static readonly int _iterationCountLocation = 0;
        private static readonly int _saltLocation = _iterationCountLocation + _iterationCountLength;
        private static readonly int _hashLocation = _saltLocation + _saltLength;


        private static byte[] InternalCompute(string value, byte[] salt, int iterationCount)
            => Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(value), salt, iterationCount, HashAlgorithmName.SHA256, _hashLength);

        private static bool CompareBytes(byte[] a, byte[] b)
        {
            if (a.Length != b.Length) return false;

            for (int i = 0, j = 0; i < a.Length; i++, j++)
                if (a[i] != b[j]) return false;

            return true;
        }

        public static byte[] Compute(string value)
        {
            var salt = new byte[_saltLength];
            RandomNumberGenerator.Fill(salt);

            var hash = InternalCompute(value, salt, _iterationCount);

            var result = new byte[_resultLength];
            Array.Copy(_iterationCountBytes, 0, result, _iterationCountLocation, _iterationCountLength);
            Array.Copy(salt, 0, result, _saltLocation, _saltLength);
            Array.Copy(hash, 0, result, _hashLocation, _hashLength);

            return result;
        }

        public static bool Check(string value, byte[] result)
        {
            var iterationCountBytes = new byte[_iterationCountLength];
            Array.Copy(result, _iterationCountLocation, iterationCountBytes, 0, _iterationCountLength);
            var iterationCount = BitConverter.ToInt32(iterationCountBytes);

            var salt = new byte[_saltLength];
            Array.Copy(result, _saltLocation, salt, 0, _saltLength);

            var hash = new byte[_hashLength];
            Array.Copy(result, _hashLocation, hash, 0, _hashLength);

            var computedHash = InternalCompute(value, salt, iterationCount);

            return CompareBytes(computedHash, hash);
        }
    }
}
