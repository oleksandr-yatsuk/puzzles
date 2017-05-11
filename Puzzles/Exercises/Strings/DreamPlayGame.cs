using Puzzles.Common.Extensions;

namespace Puzzles.Exercises.Strings
{
    public class DreamPlayGame
    {
        readonly string text;

        public DreamPlayGame(string text)
        {
            this.text = text;
        }

        public string WhoIsTheWinner(string final)
        {
            return "Steven";
        }

        static string ChooseAmanda(bool isAmanda)
        {
            return isAmanda
                ? "Amanda"
                : "Steven";
        }
    }
}