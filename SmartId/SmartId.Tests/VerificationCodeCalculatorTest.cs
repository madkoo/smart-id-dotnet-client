using System.Security.Cryptography;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using SmartId.Helper;

namespace SmartId.Tests
{
    [TestClass]
    public class VerificationCodeCalculatorTest
    {
        private byte[] hash;
        private string expectedVc;

        [TestInitialize]
        public void Setup()
        {
            expectedVc = "0000";
            hash = VerificationCodeCalculator.GenerateRandomSHA512();
        }

        [TestMethod]
        public void should_return_7712_verificationcode_result()
        {
            //Assign
            var bytes = Encoding.UTF8.GetBytes($"Hello World!");
            using (SHA256 sha256 = SHA256.Create())
            {
                var sha256Result = sha256.ComputeHash(bytes);
                expectedVc = "7712";
                //Act
                var verificationCode = VerificationCodeCalculator.CalculateVerificationCode(sha256Result);
                //Assert            
                Assert.AreEqual(expectedVc, verificationCode);
            }
        }

        [TestMethod]
        public void should_return_1464_verificationcode_result()
        {
            var bytes = Encoding.UTF8.GetBytes($"You're gonna need a bigger boat.");
            using (SHA256 sha256 = SHA256.Create())
            {
                var sha256Result = sha256.ComputeHash(bytes);
                expectedVc = "1464";
                //Act
                var verificationCode = VerificationCodeCalculator.CalculateVerificationCode(sha256Result);
                //Assert            
                Assert.AreEqual(expectedVc, verificationCode);

            }
        }

        [TestMethod]
        public void should_return_7782_verificationcode_result()
        {
            var bytes = Encoding.UTF8.GetBytes($"Go ahead, make my day.");
            using (SHA256 sha256 = SHA256.Create())
            {
                //where we take SHA256 result
                var sha256Result = sha256.ComputeHash(bytes);
                expectedVc = "7782";
                //Act
                var verificationCode = VerificationCodeCalculator.CalculateVerificationCode(sha256Result);
                //Assert            
                Assert.AreEqual(expectedVc, verificationCode);

            }
        }


        [TestMethod]
        public void should_return_4612_verificationcode_result()
        {
            var text = $"Hedgehogs – why can't they just share the hedge?";
            var bytes = Encoding.UTF8.GetBytes(text);
            using (SHA256 sha256 = SHA256.Create())
            {
                //where we take SHA256 result
                var sha256Result = sha256.ComputeHash(bytes);
                expectedVc = "4612";
                //Act
                var verificationCode = VerificationCodeCalculator.CalculateVerificationCode(sha256Result);
                //Assert            
                Assert.AreEqual(expectedVc, verificationCode);

            }

        }

        [TestMethod]
        public void should_return_4240_valid_result_verificationcode()
        {
            var bytes = Encoding.UTF8.GetBytes($"Say 'hello' to my little friend!");
            using (SHA256 sha256 = SHA256.Create())
            {
                //where we take SHA256 result
                var sha256Result = sha256.ComputeHash(bytes);
                expectedVc = "4240";
                //Act
                var verificationCode = VerificationCodeCalculator.CalculateVerificationCode(sha256Result);
                //Assert            
                Assert.AreEqual(expectedVc, verificationCode);

            }

        }
    }
}
