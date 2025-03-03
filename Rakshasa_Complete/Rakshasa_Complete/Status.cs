using System;
using System.Threading;

namespace Rakshasa_Complete
{
    class Status
    {
        public static Player player; // 전역 변수로 플레이어 정보 저장
        private static bool isPlayerCreated = false; // 플레이어 생성 여부 확인

        public static void CreatePlayer()
        {
            if (!isPlayerCreated) // 🔹 이미 생성된 경우 다시 생성하지 않음
            {
                Random random = new Random();
                player = new Player();

                player.name = "칼잡이";
                player.HP = 100;
                player.MP = 50 + random.Next(-5, 5);
                player.ATK = 10 + random.Next(-5, 5);
                player.DEF = 10 + random.Next(-5, 5);
                player.GOLD = random.Next(0, 21);



                isPlayerCreated = true; // ✅ 한 번만 실행되도록 설정

                PlayerStatus();
            }
        }

        static void PlayerStatus()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("* 이름 : " + player.name);
            Console.WriteLine("* HP : " + player.HP);
            Console.WriteLine("* MP : " + player.MP);
            Console.WriteLine("* 공격력 : " + player.ATK);
            Console.WriteLine("* 방어력 : " + player.DEF);
            Console.WriteLine("* 소지금 : " + player.GOLD);
            Console.WriteLine("-----------------------------");
        }

        public static void Display()
        {
            Console.Clear();

            int rerollCount = 0;

            if (!isPlayerCreated) // 🔹 플레이어가 없으면 생성
            {
                CreatePlayer();
            }

            while (rerollCount < 3)
            {
                Console.WriteLine("당신의 발걸음은 여기서부터 시작됩니다....");
                Console.WriteLine($"아직 발을 떼고 싶지 않으신가요? (Y/N) [남은 기회: {3 - rerollCount}]");

                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Y)
                {
                    rerollCount++;
                    Console.Clear();
                    if (rerollCount < 3)
                    {
                        isPlayerCreated = false; // 다시 능력치 변경 가능하도록 설정
                        CreatePlayer(); // 새로운 능력치 부여
                    }
                    else
                    {
                        Console.WriteLine("더 이상 능력치를 다시 정할 수 없습니다.");
                        Thread.Sleep(2000);
                        break;
                    }
                }
                else if (key == ConsoleKey.N)
                {
                    Console.WriteLine("좋습니다. 이제 앞으로 나아가십시오.");
                    Thread.Sleep(2000);
                    Game.Display();
                    return;
                }
            }

            // 3번 초과하면 강제 진행
            Console.WriteLine("능력치가 확정되었습니다. 게임을 시작합니다.");
            Thread.Sleep(2000);
            CreatePlayer();
            Thread.Sleep(2000);
            Game.Display();
        }
    }
}
