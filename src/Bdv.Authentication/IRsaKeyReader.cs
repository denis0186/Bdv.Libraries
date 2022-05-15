using Microsoft.IdentityModel.Tokens;

namespace Bdv.Authentication
{
    public interface IRsaKeyReader
    {
        /// <summary>
        /// Get RSA public key from xml file. This method uses cache when calls second or more times.
        /// </summary>
        /// <param name="keyFile">XML key file</param>
        /// <returns></returns>
        ValueTask<RsaSecurityKey> GetPublicKeyAsync(string keyFile);

        /// <summary>
        /// Get RSA private key from xml file. This method uses cache when calls second or more times.
        /// </summary>
        /// <param name="keyFile">XML key file</param>
        /// <returns></returns>
        ValueTask<RsaSecurityKey> GetPrivateKeyAsync(string keyFile);
    }
}
