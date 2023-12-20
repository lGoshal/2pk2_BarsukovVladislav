namespace PZ_16
{
    internal class Program
    {
        static int mapSize = 25; //размер карты
        static char[,] map = new char[mapSize, mapSize + 1]; //карта
        //координаты на карте игрока
        static int playerY = mapSize / 2;
        static int playerX = mapSize / 2;
        static byte enemies = 10; //количество врагов
        static byte buffs = 3; //количество усилений
        static int health = 5;  // количество аптечек
        static int PlayerHp = 50; //здоровье персонажа
        static int EnemyHp = 30; //здоровье врага
        static int PlayerPower = 10; //урон персонажа
        static int EnemyPower = 5; //урон врага
        static int enemiesCount = enemies; //подсчёт врагов
        static int NumSteps = 0; //для подсчёта пройденных шагов
        static int playerOldX; //предыдущие координаты игрока
        static int playerOldY; //предыдущие координаты игрока
        static string path; //путь для загрузки определённых сохранений игры
        static int oldStep;

        static void Main(string[] args)
        {
            StartDisplay();
            Move();
        }
        static void GenerationMap()
        {
            Random random = new Random();
            //создание пустой карты
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    map[i, j] = '_';
                }
            }

            //чтобы при рестарте игры игрок помещался в середину карты
            playerY = mapSize / 2;
            playerX = mapSize / 2;

            map[playerX, playerY] = 'P'; // в середину карты ставится игрок

            //временные координаты для проверки занятости ячейки
            int x;
            int y;
            //добавление врагов
            while (enemies > 0)
            {
                x = random.Next(0, mapSize);
                y = random.Next(1, mapSize); //от 1 до mapSize - чтобы по правому краю (где не работает контакт с существами) не спавнились

                //если ячейка пуста  - туда добавляется враг
                if (map[x, y] == '_')
                {
                    map[x, y] = 'E';
                    enemies--; //при добавлении врагов уменьшается количество нерасставленных врагов
                }
            }
            //добавление баффов
            while (buffs > 0)
            {
                x = random.Next(0, mapSize);
                y = random.Next(1, mapSize);

                if (map[x, y] == '_')
                {
                    map[x, y] = 'B';
                    buffs--;
                }
            }
            //добавление аптечек
            while (health > 0)
            {
                x = random.Next(0, mapSize);
                y = random.Next(1, mapSize);

                if (map[x, y] == '_')
                {
                    map[x, y] = 'H';
                    health--;
                }
            }

            UpdateMap(); //отображение заполненной карты на консоли
        }
        static void Move()
        {
            while (true)
            {
                playerOldX = playerX;
                playerOldY = playerY;

                StatisticInGame(); //вывод статистики в момент игры
                CheckStepsOfGetBuff(); //проверка оставшихся шагов до окончания действия баффа, если он подобран то//смена координат в зависимости от нажатия клавиш
                switch (Console.ReadKey().Key)
                {
                    //управление стрелочками на клавиатуре
                    case ConsoleKey.UpArrow:
                        NumSteps++; //подсчёт шагов при каждом движении
                        playerX--;
                        break;
                    case ConsoleKey.DownArrow:
                        playerX++;
                        NumSteps++;
                        break;
                    case ConsoleKey.LeftArrow:
                        playerY--;
                        NumSteps++;
                        break;
                    case ConsoleKey.RightArrow:
                        playerY++;
                        NumSteps++;
                        break;
                    case ConsoleKey.Q:
                        Quit();
                        break;
                    default:
                        break;
                }
                Barrier();
                switch (map[playerX, playerY]) //считывает с чем контактирует игрок
                {
                    case 'E': //если напал на врага
                        Fight();
                        break;
                    case 'H': //если подобрал аптечку
                        PlayerHp = 50;
                        break;
                    case 'B': //если подобрал бафф
                        GetBuff();
                        break;
                }

                //предыдущее положение игрока затирается
                map[playerOldX, playerOldY] = '_';
                Console.SetCursorPosition(playerOldY, playerOldX);
                Console.Write('_');

                //обновление положения персонажа
                map[playerX, playerY] = 'P';
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(playerY, playerX);
                Console.Write('P');
                Console.ResetColor();
            }
        }
        static void Barrier()
        {
            //если координаты игрока выходят за край, то игрок остаётся на прежнем месте 
            if (playerX == -1)
            {
                playerX = 0;
                NumSteps--; // (при движении шаг увеличивается), но т.к. шага фактически не было, то мы его убавляем, чтобы его значение не изменилось
            }
            if (playerY == -1)
            {
                playerY = 0;
                NumSteps--;
            }
            if (playerX == mapSize)
            {
                playerX = mapSize - 1;
                NumSteps--;
            }
            if (playerY == mapSize + 1)
            {
                playerY = mapSize;
                NumSteps--;
            }
        }
        static void UpdateMap()
        {
            Console.Clear();
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    //раскраска сущностей и их вывод
                    switch (map[i, j])
                    {
                        case 'H':
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;
                        case 'B':
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;
                        case 'E':
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;
                        case 'P':
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;
                        default:
                            Console.Write(map[i, j]);
                            break;
                    }
                }
                Console.WriteLine(map[i, 0]);
            }
        }
        static void Fight()
        {
            EnemyHp -= PlayerPower; //отнимание хп у врага
            if (EnemyHp > 0) //если враг ещё жив
            {
                PlayerHp -= EnemyPower; //отнимание хп у игрока
                                        //смена местоположения врага (меняются местами с игроком)
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(playerOldY, playerOldX);
                map[playerOldX, playerOldY] = 'E';
                Console.Write('E');
                Console.ResetColor();


                //чтобы при повторном вызове Fight враг мог встать на место игрока
                playerOldX = playerX;
                playerOldY = playerY;
                if (PlayerHp <= 0)//если игрок погиб
                {
                    DeathDisplay();
                }
            }
            else if (EnemyHp <= 0) //если враг 'погиб'
            {
                enemiesCount--;
                EnemyHp = 30;
                if (enemiesCount == 0) //если врагов не осталось
                {
                    WinDisplay();

                }
            }
        }
        static void StatisticInGame()
        {
            if (PlayerHp <= 15)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(mapSize + 12, 10);
                Console.Write($"Здоровье игрока: {PlayerHp}    ");
                Console.ResetColor();
            }
            else
            {
                Console.SetCursorPosition(mapSize + 12, 10);
                Console.Write($"Здоровье игрока: {PlayerHp}    ");
            }

            Console.SetCursorPosition(mapSize + 12, 11);
            Console.Write($"Урон игрока: {PlayerPower}     ");
            Console.SetCursorPosition(mapSize + 12, 12);
            Console.Write($"Осталось врагов: {enemiesCount}   ");
            Console.SetCursorPosition(mapSize + 12, 13);
            Console.Write($"Пройдено шагов: {NumSteps}    ");
            Console.SetCursorPosition(mapSize + 12, 5);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("P");
            Console.ResetColor();
            Console.Write(" - ваш персонаж");
            Console.SetCursorPosition(mapSize + 12, 6);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Е");
            Console.ResetColor();
            Console.Write(" - враги");
            Console.SetCursorPosition(mapSize + 12, 7);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("H");
            Console.ResetColor();
            Console.Write(" - аптечка (восстанавливает здоровье до макс.)");
            Console.SetCursorPosition(mapSize + 12, 8);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("B");
            Console.ResetColor();
            Console.Write(" - зелье урона (умножает урон вдвое)");
            Console.SetCursorPosition(mapSize + 12, 19);
            Console.Write("Q - открыть меню настроек");
        }
        static void GetBuff()
        {
            oldStep = NumSteps;
            PlayerPower = PlayerPower * 2;
        }
        static void CheckStepsOfGetBuff()
        {
            if (PlayerPower > 10) //если урон игрока уже увеличен
            {
                if ((20 - (NumSteps - oldStep)) % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(mapSize + 12, 22);
                    Console.Write($"⏳ До окончания действия зелья силы осталось шагов: {20 - (NumSteps - oldStep)} ");
                    Console.ResetColor();
                }
                else if (20 - (NumSteps - oldStep) % 2 != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(mapSize + 12, 22);
                    Console.Write($"⌛️ До окончания действия зелья силы осталось шагов: {20 - (NumSteps - oldStep)} ");
                    Console.ResetColor();
                }

                if (NumSteps - oldStep == 20) //если время действия баффа закончилось
                {
                    PlayerPower = 10; //дефолтное значение дамага игрока
                    Console.SetCursorPosition(mapSize + 12, 22);
                    //заполнение строки, где была информации о времени действия баффа пустотой
                    Console.Write("                                                              ");
                }
            }
        }
        static void StartDisplay()
        {
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8; //для того, чтобы программа видела юникод символы
            Console.CursorVisible = false; //скрытный курсов
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(40, 10);
            Console.Write("═════════════════════════════════");
            Console.ResetColor();
            Console.SetCursorPosition(40, 11);
            Console.Write("N - начать новую игру");
            Console.SetCursorPosition(40, 12);
            Console.Write("L - загрузить сохраненную игру");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(40, 13);
            Console.Write("═════════════════════════════════");
            Console.ResetColor();
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.L: //запуск последнего сохранения
                    Console.Clear();
                    LoadGame();
                    break;
                case ConsoleKey.N: //запуск новой игры
                    GenerationMap();
                    break;
                default: //если игрок нажимает на другие кнопки то ничего не происходит, метод просто вызывается заново
                    StartDisplay();
                    break;
            }
        }
        static void WinDisplay()
        {
            Console.Clear();
            Console.SetCursorPosition(40, 9);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("═══════════════════════════════════════════");
            Console.ResetColor();
            Console.SetCursorPosition(40, 10);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" Вы победили :) ");
            Console.ResetColor();
            Console.SetCursorPosition(40, 11);
            Console.Write($"Количество пройденных шагов: {NumSteps}");
            Console.SetCursorPosition(40, 12);
            Console.Write($"Вернуться на стартовый экран - клавиша B");
            Console.SetCursorPosition(40, 13);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("═══════════════════════════════════════════");
            Console.ResetColor();
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.B: //если игрок нажал на B(back)
                    StartDisplay();
                    break;
                default:
                    WinDisplay();
                    break;
            }
        }
        static void DeathDisplay()
        {
            Console.Clear();
            Console.SetCursorPosition(40, 9);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("═══════════════════════════════════════════");
            Console.ResetColor();
            Console.SetCursorPosition(40, 10);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(" Вы проиграли :( ");
            Console.ResetColor();
            Console.SetCursorPosition(40, 11);
            Console.Write($"Количество пройденных шагов: {NumSteps}");
            Console.SetCursorPosition(40, 12); Console.Write($"Вернуться на стартовый экран - клавиша B");
            Console.SetCursorPosition(40, 13);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("═══════════════════════════════════════════");
            Console.ResetColor();
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.B: //если игрок нажал на B(back)
                    StartDisplay();
                    break;
                default:
                    DeathDisplay();
                    break;
            }
        }
        static void Quit()
        {
            Console.Clear();
            Console.SetCursorPosition(40, 9);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("═══════════════════════════════════");
            Console.ResetColor();
            Console.SetCursorPosition(40, 10);
            Console.Write("▶️ R - продолжить игру");
            Console.SetCursorPosition(40, 11);
            Console.Write("💾 F - сохранить игру");
            Console.SetCursorPosition(40, 12);
            Console.Write("↩️ B - вернуться на стартовый экран");
            Console.SetCursorPosition(40, 13);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("═══════════════════════════════════");
            Console.ResetColor();
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.R: //если игрок продолжил игру
                    //вывод карты
                    UpdateMap();
                    break;
                case ConsoleKey.F: //если игрок сохранил игру
                    Console.Clear();
                    SaveGame();
                    DisplayAfterSave();
                    break;
                case ConsoleKey.B: //если игрок решил вернуться на стартовый экран
                    StartDisplay();
                    break;
                default:
                    Quit();
                    break;
            }
        }
        static void SaveGame()
        {
            Console.CursorVisible = true;
            Console.SetCursorPosition(40, 10);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("═════════════════════════════════════");
            Console.ResetColor();
            Console.SetCursorPosition(40, 11);
            Console.Write("Введите название сохранения: ");
            Console.SetCursorPosition(40, 12);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("═════════════════════════════════════");
            Console.ResetColor();
            Console.SetCursorPosition(69, 11);
            path = Console.ReadLine(); //файл с символами сущностей, координатами и параметрами
            Console.CursorVisible = false;
            try
            {
                using (FileStream file = new FileStream(path + ".txt", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(file))
                    {
                        for (int i = 0; i < mapSize; i++) //цикл для записи в файл координат сущностей и параметров игры
                        {
                            for (int j = 0; j < mapSize; j++)
                            {
                                if (map[i, j] != '_' && map[i, j] != 'P')
                                {
                                    writer.Write(map[i, j] + " ");
                                    writer.Write(i + " ");
                                    writer.Write(j + " ");
                                }
                            }
                        }
                        //запись всех параметров в момент сохранения игры
                        writer.Write("* "); //стоп-символ (применяется в LoadGame()
                        writer.Write(playerX + " ");
                        writer.Write(playerY + " ");
                        writer.Write(enemiesCount + " ");
                        writer.Write(buffs + " "); writer.Write(health + " ");
                        writer.Write(PlayerHp + " ");
                        writer.Write(EnemyHp + " ");
                        writer.Write(PlayerPower + " ");
                        writer.Write(NumSteps + " ");
                        writer.Write(oldStep + " ");
                    }
                }
            }
            catch
            {
                Console.Clear();
                Console.SetCursorPosition(38, 14);
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Write(" Ошибка: запрещённые символы в названии, повторите попытку ");
                Console.ResetColor();
                SaveGame();
            }
        }
        static void DisplayAfterSave()
        {
            Console.Clear();
            Console.SetCursorPosition(40, 9);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("═══════════════════════════════════════════");
            Console.ResetColor();
            Console.SetCursorPosition(40, 10);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Игра успешно сохранена! ");
            Console.ResetColor();
            Console.SetCursorPosition(40, 11);
            Console.Write($"Название сохранения: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{path}  ");
            Console.ResetColor();
            Console.SetCursorPosition(40, 12);
            Console.Write("Вернуться назад - клавиша G");
            Console.SetCursorPosition(40, 13);
            Console.Write("Вернуться на стартовый экран - клавиша B");
            Console.SetCursorPosition(40, 14);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("═══════════════════════════════════════════");
            Console.ResetColor();
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.B:
                    StartDisplay();
                    break;
                case ConsoleKey.G:
                    Quit();
                    break;
                default:
                    DisplayAfterSave();
                    break;
            }
        }
        static void LoadGame()
        {
            Console.CursorVisible = true;
            Console.SetCursorPosition(38, 10);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("══════════════════════════════════════════════════════");
            Console.ResetColor();
            Console.SetCursorPosition(38, 11);
            Console.Write("Введите название сохранения для загрузки игры: ");
            Console.SetCursorPosition(38, 12);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("══════════════════════════════════════════════════════");
            Console.ResetColor();
            Console.SetCursorPosition(85, 11);
            path = Console.ReadLine(); //файл с символами сущностей, координатами и параметрами
            Console.CursorVisible = false;
            try
            {
                using (FileStream file = new FileStream(path + ".txt", FileMode.OpenOrCreate, FileAccess.Read))
                {
                    using (StreamReader reader = new StreamReader(file))
                    {
                        Console.Clear();
                        string[] lines = reader.ReadToEnd().Split(); //заполнение массива данными из файла
                        int count = 0; //для подсчёта данных с линий
                        int X = 0; int Y = 0; //для считывания координат сущностей

                        //создание пустой карты
                        for (int i = 0; i < mapSize; i++)
                        {
                            for (int j = 0; j < mapSize; j++)
                            {
                                map[i, j] = '_';
                                Console.Write(map[i, j]);
                            }
                            Console.WriteLine(map[i, 0]);
                        }//запись в массив map сущностей, согласно их координатам
                        while (true)
                        {
                            if (Convert.ToChar(lines[count]) == 'E')
                            {
                                Y = Convert.ToInt32(lines[count + 1]);
                                X = Convert.ToInt32(lines[count + 2]);
                                map[Y, X] = Convert.ToChar(lines[count]);
                                count += 3;
                            }
                            else if (Convert.ToChar(lines[count]) == 'B')
                            {
                                Y = Convert.ToInt32(lines[count + 1]);
                                X = Convert.ToInt32(lines[count + 2]);
                                map[Y, X] = Convert.ToChar(lines[count]);
                                count += 3;
                            }
                            else if (Convert.ToChar(lines[count]) == 'H')
                            {
                                Y = Convert.ToInt32(lines[count + 1]);
                                X = Convert.ToInt32(lines[count + 2]);
                                map[Y, X] = Convert.ToChar(lines[count]);
                                count += 3;
                            }
                            else if (Convert.ToChar(lines[count]) == '*')
                            {
                                //переход к записи параметров
                                break;
                            }
                        }

                        //запись параметров
                        playerX = Convert.ToInt32(lines[count + 1]);
                        playerY = Convert.ToInt32(lines[count + 2]);
                        enemiesCount = Convert.ToInt32(lines[count + 3]);
                        buffs = Convert.ToByte(lines[count + 4]);
                        health = Convert.ToInt32(lines[count + 5]);
                        PlayerHp = Convert.ToInt32(lines[count + 6]);
                        EnemyHp = Convert.ToInt32(lines[count + 7]);
                        PlayerPower = Convert.ToInt32(lines[count + 8]);
                        NumSteps = Convert.ToInt32(lines[count + 9]);
                        oldStep = Convert.ToInt32(lines[count + 10]);

                        //запись в массив игрока
                        map[playerX, playerY] = 'P';

                        UpdateMap(); //вывод карты по получившимся параметрам
                    }
                }
            }
            catch
            {
                Console.Clear();
                Console.SetCursorPosition(38, 14);
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Write(" Ошибка: такого сохранения не найдено, повторите попытку ");
                Console.ResetColor();
                LoadGame();
            }
        }
    }
}