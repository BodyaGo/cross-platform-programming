using System;
using NUnit.Framework;
using System.IO;

namespace ConsoleApp.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        /// <summary>
        /// Тестує метод GetBasePath, коли файл існує за вказаним шляхом.
        /// </summary>
        [Test]
        public void GetBasePath_ShouldReturnValidPath_WhenFileExists()
        {
            // Створимо тимчасовий файл для тестування
            string testFilePath = Path.Combine(Path.GetTempPath(), "testFile.txt");
            File.WriteAllText(testFilePath, "Test content");

            // Перевіряємо, що метод повертає правильний шлях
            string result = Program.GetBasePath(testFilePath);

            Assert.AreEqual(testFilePath, result);

            // Видаляємо файл після тесту
            File.Delete(testFilePath);
        }

        /// <summary>
        /// Тестує метод GetBasePath, коли файл не існує.
        /// </summary>
        [Test]
        public void GetBasePath_ShouldReturnNull_WhenFileDoesNotExist()
        {
            // Вказуємо неіснуючий файл
            string nonExistentFilePath = Path.Combine(Path.GetTempPath(), "nonExistentFile.txt");

            // Перевіряємо, що метод повертає null
            string result = Program.GetBasePath(nonExistentFilePath);

            Assert.IsNull(result);
        }

        /// <summary>
        /// Тестує метод SetPath, коли шлях існує.
        /// </summary>
        [Test]
        public void SetPath_ShouldSetEnvironmentVariable_WhenDirectoryExists()
        {
            // Створимо тимчасову директорію
            string testDir = Path.Combine(Path.GetTempPath(), "testDir");
            Directory.CreateDirectory(testDir);

            // Викликаємо метод для встановлення змінної середовища
            Program.SetPath(testDir);

            // Перевіряємо, чи змінна LAB_PATH була встановлена
            string result = Environment.GetEnvironmentVariable("LAB_PATH");

            Assert.AreEqual(testDir, result);

            // Видаляємо директорію після тесту
            Directory.Delete(testDir);
        }

        /// <summary>
        /// Тестує метод SetPath, коли шлях не існує.
        /// </summary>
        [Test]
        public void SetPath_ShouldNotSetEnvironmentVariable_WhenDirectoryDoesNotExist()
        {
            // Вказуємо неіснуючий шлях
            string nonExistentDir = Path.Combine(Path.GetTempPath(), "nonExistentDir");

            // Спочатку перевіряємо, що змінна середовища не задана
            string initialPath = Environment.GetEnvironmentVariable("LAB_PATH");

            // Викликаємо метод для встановлення змінної середовища
            Program.SetPath(nonExistentDir);

            // Перевіряємо, чи змінна LAB_PATH не була змінена
            string result = Environment.GetEnvironmentVariable("LAB_PATH");

            Assert.AreEqual(initialPath, result);
        }

        /// <summary>
        /// Тестує метод ShowHelp (перевірка консольного виведення).
        /// </summary>
        [Test]
        public void ShowHelp_ShouldDisplayHelpInformation()
        {
            // Перехоплюємо виведення на консоль
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.ShowHelp();
                var result = sw.ToString();

                // Перевіряємо, що виведено допомогу
                Assert.IsTrue(result.Contains("Usage:"));
                Assert.IsTrue(result.Contains("version"));
                Assert.IsTrue(result.Contains("run"));
            }
        }

        /// <summary>
        /// Тестує метод ShowVersionInfo (перевірка консольного виведення).
        /// </summary>
        [Test]
        public void ShowVersionInfo_ShouldDisplayVersionInfo()
        {
            // Перехоплюємо виведення на консоль
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Program.ShowVersionInfo();
                var result = sw.ToString();

                // Перевіряємо, що виведено версію та автора
                Assert.IsTrue(result.Contains("Автор:"));
                Assert.IsTrue(result.Contains("Версія:"));
            }
        }
    }
}
