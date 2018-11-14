using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

using SmartId.Helper;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetVC());
            Console.Read();
        }


        static string GetVC()
        {
            var data = Encoding.ASCII.GetBytes("text");
            var str = "";
            var result = string.Empty;
            using (SHA512 shaM = new SHA512Managed())
            {
                var hash = shaM.ComputeHash(data);
                str = Convert.ToBase64String(hash);
            }

            data = Encoding.ASCII.GetBytes(str);
            //var twoRightmostBytes = new byte[];
            using (var sha256 = SHA256.Create())
            {
                var hash = sha256.ComputeHash(data);
                //Array.Reverse(hash);
                var twoRightmostBytesArray = hash.Take(2).Reverse().ToArray();

                //var shortBytes = sizeof(short) / sizeof(byte);

                using (var ms = new MemoryStream(twoRightmostBytesArray))
                {
                    using (var reader = new BinaryReader(ms))
                    {
                        var twoRightmostBytes = reader.ReadUInt16();
                        ulong positiveInteger = (Convert.ToUInt16(twoRightmostBytes));
                        return positiveInteger.ToString().GetLast(4);
                    }
                }
            }



            //byte[] digest = DigestCalculator.calculateDigest(documentHash, HashType.SHA256);
            //ByteBuffer byteBuffer = ByteBuffer.wrap(digest);
            //int shortBytes = Short.SIZE / Byte.SIZE; // Short.BYTES in java 8
            //int rightMostBytesIndex = byteBuffer.limit() - shortBytes;
            //short twoRightmostBytes = byteBuffer.getShort(rightMostBytesIndex);
            //int positiveInteger = ((int) twoRightmostBytes) & 0xffff;
            //String code = String.valueOf(positiveInteger);
            //String paddedCode = "0000" + code;
            //return paddedCode.substring(code.length());
        }


    }
}
