namespace PZ_10
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите текст: ");
            string input = Console.ReadLine();

            // Разделение текста на предложения и удаление пустых строк
            string[] sentences = input.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            // Получение количества слов в каждом предложении
            var sentenceWordCount = sentences.Select(s => new { Sentence = s.Trim(), WordCount = s.Trim().Split(' ').Length });

            // Сортировка предложений по количеству слов в порядке возрастания
            var sortedSentences = sentenceWordCount.OrderBy(s => s.WordCount);

            // Вывод отсортированного текста
            Console.WriteLine("Отсортированный текст:");
            foreach (var sentence in sortedSentences)
            {
                Console.WriteLine(sentence.Sentence);
            }   
        }
    }
}