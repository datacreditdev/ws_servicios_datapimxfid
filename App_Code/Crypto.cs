//==================================================
//David Santos 20-Junio-2006
//==================================================
using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;

public class Crypto
{
    private string stringKey;
    private string stringIV;

    private CryptoProvider algorithm;

    public enum CryptoProvider
    {
        DES,
        TripleDES,
        RC2,
            Rijndael
    }

    public enum CryptoAction
    {
        Encrypt,
        Desencrypt
    }

    public Crypto(CryptoProvider alg)
    {
        this.algorithm = alg;
    }

    public string Key
    {
        get
        {
            return stringKey;
        }
        set
        {
            stringKey = value;
        }
    }

    public string IV
    {
        get
        {
            return stringIV;
        }
        set
        {
            stringIV = value;
        }
    }

    public string CifrarCadena(string CadenaOriginal)
    {
        // creamos el flujo tomando la memoria como respaldo.
        MemoryStream memStream = null;
        try
        {
            // verificamos que la llave y el VI han sido proporcionados.
            if (stringKey != null && stringIV != null)
            {
                // obtenemos el arreglo de bytes correspondiente a la llave
                // y al vector de inicialización.
                byte[] key = MakeKeyByteArray();
                byte[] IV = MakeIVByteArray();
                // convertimos el mensaje original en sus correspondiente
                // arreglo de bytes.
                byte[] textoPlano = Encoding.UTF8.GetBytes(CadenaOriginal);

                // creamos el flujo 
                memStream = new MemoryStream(CadenaOriginal.Length * 2);
                // obtenemos nuestro objeto cifrador, usando la clase 
                // CryptoServiceProvider codificada anteriormente.
                CryptoServiceProvider cryptoProvider =
                    new CryptoServiceProvider((CryptoServiceProvider.CryptoProvider)this.algorithm,
                    CryptoServiceProvider.CryptoAction.Encrypt);
                ICryptoTransform transform = cryptoProvider.GetServiceProvider(key, IV);
                // creamos el flujo de cifrado, usando el objeto cifrador creado y almancenando
                // el resultado en el flujo MemoryStream.
                CryptoStream cs = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
                // ciframos el mensaje.
                cs.Write(textoPlano, 0, textoPlano.Length);
                // cerramos el flujo de cifrado.
                cs.Close();
            }
            else
                // si los valores dela llave y/o del VI no se han establecido
                // informamos mendiante una excepción.
                throw new Exception("Error al inicializar la clave y el vector");
        }
        catch
        {
            throw;
        }
        // la conversión se ha realizado con éxito,
        // convertimos el arreglo de bytes en cadena de caracteres, 
        // usando la clase Convert, debido al formato usando para
        // crear el arreglo de bytes.
        return Convert.ToBase64String(memStream.ToArray());
    }

    public string DescifrarCadena(string CadenaCifrada)
    {
        // creamos el flujo tomando la memoria como respaldo.
        MemoryStream memStream = null;
        try
        {
            // verificamos que la llave y el VI han sido proporcionados.
            if (stringKey != null && stringIV != null)
            {
                // obtenemos el arreglo de bytes correspondiente a la llave
                // y al vector de inicialización.
                byte[] key = MakeKeyByteArray();
                byte[] IV = MakeIVByteArray();
                // obtenemos el arreglo de bytes de la cadena cifrada.
                byte[] textoCifrado = Convert.FromBase64String(CadenaCifrada);

                // creamos el flujo
                memStream = new MemoryStream(CadenaCifrada.Length);
                // obtenemos nuestro objeto cifrador, usando la clase 
                // CryptoServiceProvider codificada anteriormente.
                CryptoServiceProvider cryptoProvider =
                    new CryptoServiceProvider((CryptoServiceProvider.CryptoProvider)this.algorithm,
                    CryptoServiceProvider.CryptoAction.Desencrypt);
                ICryptoTransform transform = cryptoProvider.GetServiceProvider(key, IV);
                // creamos el flujo de cifrado, usando el objeto cifrador creado y almancenando
                // el resultado en el flujo MemoryStream.
                CryptoStream cs = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
                cs.Write(textoCifrado, 0, textoCifrado.Length); // ciframos
                cs.Close(); // cerramos el flujo.
            }
            else
                // si los valores dela llave y/o del VI no se han establecido
                // informamos mendiante una excepción.
                throw new Exception("Error al inicializar la clave y el vector.");

        }
        catch
        {
            throw;
        }

        // utilizamos el mismo sistema de codificación para obtener 
        // la cadena a partir del byte array.
        return Encoding.UTF8.GetString(memStream.ToArray());
    }

    private byte[] MakeKeyByteArray()
    {
        switch (this.algorithm)
        {
            case CryptoProvider.DES:
            case CryptoProvider.RC2:
                if (stringKey.Length < 8)
                    stringKey = stringKey.PadRight(8);
                else if (stringKey.Length > 8) // si la cadena supera los 8 bytes,
                    // truncamos la cadena dejándola en 8 bytes.
                    stringKey = stringKey.Substring(0, 8);
                break;
            case CryptoProvider.TripleDES:
            case CryptoProvider.Rijndael:
                // verificamos que la longitud de la cadena no sea menor a 16 bytes
                if (stringKey.Length < 16)
                    stringKey = stringKey.PadRight(16);
                else if (stringKey.Length > 16)// si la longitud es mayor a 16 bytes,
                    // truncamos la cadena dejándola en 8 bytes.
                    stringKey = stringKey.Substring(0, 16);
                break;
        }

        return Encoding.UTF8.GetBytes(stringKey);
    }

    private byte[] MakeIVByteArray()
    {
        switch (this.algorithm)
        {
            case CryptoProvider.DES:
            case CryptoProvider.RC2:
            case CryptoProvider.TripleDES:

                if (stringIV.Length < 8)
                    stringIV = stringIV.PadRight(8);
                else if (stringIV.Length > 8) // si la cadena supera los 8 bytes,
                    stringIV = stringIV.Substring(0, 8);
                break;
            case CryptoProvider.Rijndael:
                if (stringIV.Length < 16)
                    stringIV = stringIV.PadRight(16);
                else if (stringIV.Length > 16)// si la cadena supera los 16 bytes,
                    stringIV = stringIV.Substring(0, 16);
                break;
        }

        return Encoding.UTF8.GetBytes(stringIV);
    }
}
