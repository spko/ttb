using System;
using System.Text;

namespace Spo.ToolsTestsBenchmarks.Common.Common.Helpers
{
    public static class EncodingHelper
    {
        public static string BytesToAscii(byte[] byteToDecode, int length)
        {
            if (byteToDecode == null || byteToDecode.Length == 0)
            {
                return string.Empty;
            }

            string message;
            try
            {
                message = Encoding.ASCII.GetString(byteToDecode, 0, length);
            }
            catch (DecoderFallbackException)
            {
                message = string.Empty;
            }
            catch (ArgumentException)
            {
                message = string.Empty;
            }

            return message;
        }

        public static byte[] ToBytes(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            byte[] bytes = Encoding.Default.GetBytes(value);

            return bytes;
        }
    }
}
