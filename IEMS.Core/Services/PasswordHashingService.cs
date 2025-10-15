using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace IEMS.Core.Services
{
    public class PasswordHashingService
    {
        private const int SaltSize = 16; // 128 bits
        private const int HashSize = 32; // 256 bits
        private const int Iterations = 10000; // Keep at 10000 for backward compatibility with existing password hashes

        public string HashPassword(string password)
        {
            // Generate a random salt
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Hash the password
            byte[] hash = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: Iterations,
                numBytesRequested: HashSize);

            // Combine salt and hash
            byte[] hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            // Convert to base64
            return Convert.ToBase64String(hashBytes);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"DEBUG PasswordHashingService: Verifying password (length: {password?.Length})");
                System.Diagnostics.Debug.WriteLine($"DEBUG PasswordHashingService: HashedPassword length: {hashedPassword?.Length}");

                // Get hash bytes
                byte[] hashBytes = Convert.FromBase64String(hashedPassword);
                System.Diagnostics.Debug.WriteLine($"DEBUG PasswordHashingService: Hash bytes length: {hashBytes.Length} (expected: {SaltSize + HashSize})");

                // Extract salt
                byte[] salt = new byte[SaltSize];
                Array.Copy(hashBytes, 0, salt, 0, SaltSize);

                // Hash the password with the extracted salt
                byte[] hash = KeyDerivation.Pbkdf2(
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: Iterations,
                    numBytesRequested: HashSize);

                // Compare the computed hash with the stored hash using constant-time comparison
                // to prevent timing attacks
                bool isValid = true;
                for (int i = 0; i < HashSize; i++)
                {
                    isValid &= (hashBytes[i + SaltSize] == hash[i]);
                }

                System.Diagnostics.Debug.WriteLine($"DEBUG PasswordHashingService: Verification result: {isValid}");
                return isValid;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"DEBUG PasswordHashingService: Exception during verification: {ex.Message}");
                return false;
            }
        }
    }
}