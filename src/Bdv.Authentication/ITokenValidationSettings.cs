namespace Bdv.Authentication
{
    public interface ITokenValidationSettings
    {
        /// <summary>
        /// RSA public key (path to xml file)
        /// </summary>
        string RsaPublicKey { get; }

        /// <summary>
        /// Issuer
        /// </summary>
        string Issuer { get; }
    }
}
