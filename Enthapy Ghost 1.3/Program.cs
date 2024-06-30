using System;
using System.Drawing.Text;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Enthapy;
using System.Security.Cryptography;

internal static class Program
{
    [STAThread]
    private static async Task Main()
    {
        InstallEmbeddedFont();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(defaultValue: true);
        Application.Run(new Start());
    }

    [DllImport("gdi32.dll")]
    private static extern IntPtr AddFontResourceEx(string lpszFilename, uint fl, IntPtr res);

    [DllImport("gdi32.dll")]
    private static extern bool RemoveFontResourceEx(string lpFileName, uint fl, IntPtr pdv);

    private static string tempFontPath;
    private static PrivateFontCollection privateFontCollection;


    public static void InstallEmbeddedFont()
    {
        privateFontCollection = new PrivateFontCollection();

        // Load the font data from embedded resources
        byte[] fontData;
        string resourceName = "Resources.Poppins-Regular.ttf"; // Replace with your font file name
        Assembly assembly = Assembly.GetExecutingAssembly();
        using (Stream stream = assembly.GetManifestResourceStream(resourceName))
        {
            if (stream == null)
            {
                throw new ArgumentException($"Font resource '{resourceName}' not found.");
            }

            fontData = new byte[stream.Length];
            stream.Read(fontData, 0, (int)stream.Length);
        }

        int length = 17; // Specify the desired length of the random string
        string randomString = GenerateRandomString(length);

        // Save the font to a temporary location
        tempFontPath = Path.Combine(Path.GetTempPath(), randomString); // Replace with your desired temporary file name
        File.WriteAllBytes(tempFontPath, fontData);

        // Install the font from the temporary location
        AddFontResourceEx(tempFontPath, 0, IntPtr.Zero);
        privateFontCollection.AddFontFile(tempFontPath);
    }

    private static readonly Random random = new Random();
    private const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    public static string GenerateRandomString(int length)
    {
        char[] result = new char[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = characters[random.Next(characters.Length)];
        }
        return new string(result);
    }
}
