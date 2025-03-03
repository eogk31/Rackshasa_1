using System;

namespace Rakshasa_Complete
{
    class Game
    {
        public static int progress = 0; // 진행도

        public static void Display()
        {
            Console.Clear();

            Player play = Status.player; // 🔹 기존 플레이어 데이터 가져오기

            Console.WriteLine("=====================================");
            Console.WriteLine("            게임 화면                 ");
            Console.WriteLine("=====================================");
            Console.WriteLine($" 진행도: {progress}  |  소지금: {play.GOLD} G");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine(" [ 상태 ]");
            Console.WriteLine($" 체력: {play.HP}  |  기력: {play.MP}");
            Console.WriteLine($" 공격력: {play.ATK}  |  방어력: {play.DEF}");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine(" 1) 전투 시작");
            Console.WriteLine(" 2) 상점 (추후 추가 가능)");
            Console.WriteLine(" [Backspace] 타이틀 화면으로 돌아가기");
            Console.WriteLine("=====================================");

            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.D1)
                {
                    Console.WriteLine($"DEBUG: 진행도가 증가함! 현재 진행도: {progress}"); // 디버깅 출력
                    play.ATK += 1;
                    Battle.Display();
                    break;
                }
                else if (key == ConsoleKey.Backspace)
                {
                    Title.Display();
                    break;
                }
            }
        }

    }
}
