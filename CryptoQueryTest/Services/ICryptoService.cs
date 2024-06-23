using CryptoQueryTest.Model;

namespace CryptoQueryTest.Services
{
    public interface ICryptoService
    {
        Task<CryptoCurrencyResponse> GetAllCrypto();

        Task<CryptoCurerency?> GetCryptoById(string Id);
    }
}
