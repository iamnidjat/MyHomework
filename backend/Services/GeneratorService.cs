using System.Text;

namespace backend.Services
{
    public static class GeneratorService
    {
        private const string CharSet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string GenerateCode(int length) // for all: code for entering a group, random password, random username
        {
            Random random = new();
            StringBuilder codeBuilder = new();

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(CharSet.Length);
                codeBuilder.Append(CharSet[index]);
            }

            return codeBuilder.ToString();
        }
    }
}
