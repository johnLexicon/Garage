using System;
using System.IO;

namespace Garage.Cmd
{
    public static class CmdUtils
    {
        /// <summary>
        /// Asks for string.
        /// </summary>
        /// <returns>The user answer</returns>
        /// <param name="prompt">Prompt for the user</param>
        public static string AskForString(string prompt)
        {

            string answer = string.Empty;
            while (string.IsNullOrWhiteSpace(answer))
            {
                Console.Write(prompt);
                answer = Console.ReadLine();
            }

            return answer;
        }

        /// <summary>
        /// Control method for asking after an integer.
        /// </summary>
        /// <returns>The integer given from the user</returns>
        /// <param name="prompt">Prompt for the user</param>
        public static int AskForInteger(string prompt)
        {
            bool success = false;
            int result;

            do
            {
                string answer = AskForString(prompt);
                success = int.TryParse(answer, out result);
                if (!success)
                {
                    Console.WriteLine("An integer please!!");
                }

            } while (!success);

            return result;
        }

        public static string ReadTextFile(string path)
        {
            Console.WriteLine(path);
            string content = string.Empty;
            try
            {
                content = File.ReadAllText(path);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Unable to read from {path}. {e.Message}");
            }

            return content;
        }
    }
}
