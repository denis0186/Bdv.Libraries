using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace Bdv.Common.Impl
{
    public class RsaKeyReader : IRsaKeyReader
    {
        private readonly Dictionary<string, string> _keys = new();

        public ValueTask<RsaSecurityKey> GetPrivateKeyAsync(string keyFile)
        {
            return GetRsaSecurityKeyCoreAsync(keyFile, true);
        }

        public ValueTask<RsaSecurityKey> GetPublicKeyAsync(string keyFile)
        {
            return GetRsaSecurityKeyCoreAsync(keyFile, false);
        }

        private ValueTask<RsaSecurityKey> GetRsaSecurityKeyCoreAsync(string keyFile, bool includePrivateParameters)
        {
            ArgumentNullException.ThrowIfNull(keyFile);
            if (_keys.ContainsKey(keyFile))
            {
                return ValueTask.FromResult(GetRsaSecurityKey(_keys[keyFile], includePrivateParameters));
            }

            return new ValueTask<RsaSecurityKey>(GetRsaSecurityKeyAsync(keyFile, includePrivateParameters));
        }

        private async Task<RsaSecurityKey> GetRsaSecurityKeyAsync(string keyFile, bool includePrivateParameters)
        {
            if (string.IsNullOrWhiteSpace(keyFile) || !File.Exists(keyFile))
            {
                throw new ArgumentException("RSA key file wasn't provided");
            }

            var key = await File.ReadAllTextAsync(keyFile);
            _keys[keyFile] = key;
            return GetRsaSecurityKey(key, includePrivateParameters);
        }

        private RsaSecurityKey GetRsaSecurityKey(string key, bool includePrivateParameters)
        {
            using var rsa = RSA.Create();
            rsa.FromXmlString(key);
            return new RsaSecurityKey(rsa.ExportParameters(includePrivateParameters));
        }
    }
}
