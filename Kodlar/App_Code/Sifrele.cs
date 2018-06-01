using System;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using System.Text;


public class Sifrele : IDisposable
{
    // Change these keys
    // KEY ve Vector dizileri için tanımlanan sayı adetini değiştirmeyin. Sayıları değiştirin lakin toplam sayı adeti aynı kalsın.. aksi halde çalışmaz..

    private byte[] Key = { 123, 217, 17, 11, 24, 26, 85, 25, 114, 164, 27, 162, 37, 112, 222, 209, 241, 24, 175, 144, 173, 33, 196, 29, 24, 26, 17, 218, 131, 236, 53,209 };
    private byte[] Vector = { 146, 64, 191, 111, 23, 3, 133, 119, 231, 121, 25, 112, 79, 32, 114, 156,101};
    private ICryptoTransform EncryptorTransform, DecryptorTransform;
    private System.Text.UTF8Encoding UTFEncoder;
    public Sifrele()
    {
        //This is our encryption method
        RijndaelManaged rm = new RijndaelManaged();

        //Create an encryptor and a decryptor using our encryption method, key, and vector.
        EncryptorTransform = rm.CreateEncryptor(this.Key, this.Vector);
        DecryptorTransform = rm.CreateDecryptor(this.Key, this.Vector);

        //Used to translate bytes to text and vice versa
        UTFEncoder = new System.Text.UTF8Encoding();
    }
    static public byte[] GenerateEncryptionKey()
    {
        //Generate a Key.
        RijndaelManaged rm = new RijndaelManaged();
        rm.GenerateKey();
        return rm.Key;
    }
    static public byte[] GenerateEncryptionVector()
    {
        //Generate a Vector
        RijndaelManaged rm = new RijndaelManaged();
        rm.GenerateIV();
        return rm.IV;
    }
    public string EncryptToString(string TextValue)
    {
        return ByteArrToString(Encrypt(TextValue));
    }
    public byte[] Encrypt(string TextValue)
    {
        //Translates our text value into a byte array.
        Byte[] bytes = UTFEncoder.GetBytes(TextValue);

        //Used to stream the data in and out of the CryptoStream.
        MemoryStream memoryStream = new MemoryStream();

        /*
         * We will have to write the unencrypted bytes to the stream,
         * then read the encrypted result back from the stream.
         */
        #region Write the decrypted value to the encryption stream
        CryptoStream cs = new CryptoStream(memoryStream, EncryptorTransform, CryptoStreamMode.Write);
        cs.Write(bytes, 0, bytes.Length);
        cs.FlushFinalBlock();
        #endregion
        #region Read encrypted value back out of the stream
        memoryStream.Position = 0;
        byte[] encrypted = new byte[memoryStream.Length];
        memoryStream.Read(encrypted, 0, encrypted.Length);
        #endregion
        //Clean up.
        cs.Close();
        memoryStream.Close();
        return encrypted;
    }
    public string DecryptString(string EncryptedString)
    {
        return Decrypt(StrToByteArray(EncryptedString));
    }
    public string Decrypt(byte[] EncryptedValue)
    {
        #region Write the encrypted value to the decryption stream
        MemoryStream encryptedStream = new MemoryStream();
        CryptoStream decryptStream = new CryptoStream(encryptedStream, DecryptorTransform, CryptoStreamMode.Write);
        decryptStream.Write(EncryptedValue, 0, EncryptedValue.Length);
        decryptStream.FlushFinalBlock();
        #endregion
        #region Read the decrypted value from the stream.
        encryptedStream.Position = 0;
        Byte[] decryptedBytes = new Byte[encryptedStream.Length];
        encryptedStream.Read(decryptedBytes, 0, decryptedBytes.Length);
        encryptedStream.Close();
        #endregion
        return UTFEncoder.GetString(decryptedBytes);
    }
    public byte[] StrToByteArray(string str)
    {
        if (str.Length == 0)
            throw new Exception("Invalid string value in StrToByteArray");

        byte val;
        byte[] byteArr = new byte[str.Length / 3];
        int i = 0;
        int j = 0;
        do
        {
            val = byte.Parse(str.Substring(i, 3));
            byteArr[j++] = val;
            i += 3;
        }
        while (i < str.Length);
        return byteArr;
    }
    public string ByteArrToString(byte[] byteArr)
    {
        byte val;
        string tempStr = "";
        for (int i = 0; i <= byteArr.GetUpperBound(0); i++)
        {
            val = byteArr[i];
            if (val < (byte)10)
                tempStr += "00" + val.ToString();
            else if (val < (byte)100)
                tempStr += "0" + val.ToString();
            else
                tempStr += val.ToString();
        }
        return tempStr;
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}