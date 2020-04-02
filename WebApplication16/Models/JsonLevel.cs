
namespace WebApplication16.Models
{
    /// <summary>
    /// Class to calculate a depth level of file.
    /// </summary>
    public class JsonLevel
    {
        private int max(int a, int b)
        {
            return (a > b) ? a : b;
        }
        public int checkLevel(string json)
        {
            int count = 0;
            int curLvl = 0;
            for (int i = 0; i < json.Length; i++)
            {
                if (json[i] == '{' || json[i] == '[')
                {
                    curLvl++;
                    continue;
                }
                if (json[i] == '}' || json[i] == ']')
                {
                    count = max(count, curLvl);
                    curLvl--;
                }
            }
            return count;
        }
    }
}