Гра в дартс дуже популярна у Великій Британії та Голландії. У грі беруть участь кілька гравців. Вони по черзі кидають у ціль по три дротики.
На початку гри кожен гравець має кілька очок, зазвичай 501. За кожне попадання дротика в ціль сума гравця зменшується на деяке число, залежно від того, в яку частину мішені він потрапив. Перший, хто сягає нуля очок, вважається переможцем.
Зовнішній вигляд мішені показаний малюнку праворуч. Вона поділена на 20 секторів, що розташовані навколо невеликого центрального кола. Це коло, своєю чергою, ділиться на внутрішню і зовнішню частину (іноді внутрішня частина називається «яблучко»). Попадання у зовнішню частину центрального кола оцінюється 25 очок, а в «яблучко» – удвічі більше, тобто у 50 очок. Вартість сектора дорівнює числу, що на ньому написано. Крім того на мішені виділено два кільця - зовнішнє та внутрішнє. Потраплення в них оцінюється відповідно в два і втричі більше, ніж у частину відповідного сектора, що залишилася.
Існують додаткові правила для останньої серії кидків, у якій гравець має досягти нуля очок. У цій серії гравцеві доведеться кинути в ціль від одного до трьох дротиків. Гравець повинен досягти точності нуля очок, отримання негативної суми вважається помилкою. Останній дротик має бути «подвійним», тобто потрапити у зовнішнє кільце будь-якого сектора або в «яблучко» - (воно вважається подвоєнням зовнішньої частини центрального кола).
Наприклад, один із правильних способів закінчити гру, маючи 50 очок – кинути дротики у «18» та «D16».
Способи D20, 10, або 20, T10 не підходять: останній кидок не є подвоєним. Ще один можливий спосіб перемогти в цьому випадку – просто потрапити до «яблучка» («Bull»). За кількістю очок, що залишилися, знайдіть всі способи правильно закінчити гру.
Вхідні дані
Вхідний файл INPUT.TXT містить число n - кількість очок, що залишилися (1 ≤ n ≤ 200).
Вихідні дані
У першому рядку вихідного файлу OUTPUT.TXT виведіть k – кількість способів правильно завершити партію. Кожен із наступних k рядків повинен містити опис одного правильного способу. При цьому число від 1 до 20 відповідає влученню у відповідний сектор. Літера «D» перед числом позначає попадання у зовнішнє (подвоює) кільце, а «T» - у внутрішнє (потроює). Зовнішня частина центрального кола позначається як "25", а "яблучко" (bull eye) - словом "Bull".
приклад
INPUT.TXT	
5
OUTPUT.TXT
7
1 D1 D1
1 2 D1
1 D2
D1 1 D1
T1 D1
2 1 D1
3 D1
