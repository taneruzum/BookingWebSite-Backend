namespace ReminderApp.Application.Extensions
{
    public static class ByteFormatExtension
    { 
        public static byte[] HexStringToByteArray(this string hex)
        {
            hex = hex.Replace(" ", "").Replace("0x", "");

            int numberChars = hex.Length;
            byte[] bytes = new byte[numberChars / 2];

            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }

            return bytes;
        }
    }
}
