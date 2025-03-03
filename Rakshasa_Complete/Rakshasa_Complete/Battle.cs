using System;
using System.Threading;

namespace Rakshasa_Complete
{
    internal class Battle
    {
        enum Enemy
        {
            Enemy1 = 0,
            Enemy2 = 1,
            Enemy3 = 2,
            Enemy4 = 3
        }

        struct Monster
        {
            public string name;
            public int HP;
            public int MP;
            public int ATK;
            public int DEF;
        }

        static void DisplayUI(Player player, Monster monster, string log)
        {
            Console.Clear();
            Console.WriteLine("============================================");

            // 🔹 적 정보 출력
            Console.WriteLine("  [ 적의 정보 ]");
            Console.WriteLine($"  이름: {monster.name}");
            Console.WriteLine($"  체력: {monster.HP} / 기력: {monster.MP}");
            Console.WriteLine($"  공격력: {monster.ATK} / 방어력: {monster.DEF}");
            Console.WriteLine("============================================");

            // 🔹 플레이어 정보 출력
            Console.WriteLine("  [ 플레이어 정보 ]");
            Console.WriteLine($"  이름: {player.name}");
            Console.WriteLine($"  체력: {player.HP} / 기력: {player.MP}");
            Console.WriteLine($"  공격력: {player.ATK} / 방어력: {player.DEF}");
            Console.WriteLine($"  소지금: {player.GOLD} G");
            Console.WriteLine("============================================");

            // 🔹 전투 로그 출력
            Console.WriteLine("  [ 전투 로그 ]");
            Console.WriteLine($"  {log}");
            Console.WriteLine("============================================");

            // 🔹 플레이어 행동 선택
            Console.WriteLine("  [ 행동 선택 ]");
            Console.WriteLine("  1) 공격   2) 방어   3) 기술   4) 도구");
            Console.WriteLine("============================================");
        }

        static Monster CreateMonster()
        {
            Random random = new Random();
            int spawn = random.Next(0, 4);
            Monster enemy;

            switch ((Enemy)spawn)
            {
                case Enemy.Enemy1:
                    enemy.name = "한량";
                    enemy.HP = random.Next(1, 10);
                    enemy.MP = random.Next(5, 21);
                    enemy.ATK = random.Next(5, 21);
                    enemy.DEF = random.Next(1, 10);
                    break;
                case Enemy.Enemy2:
                    enemy.name = "도적";
                    enemy.HP = random.Next(1, 10);
                    enemy.MP = random.Next(5, 21);
                    enemy.ATK = random.Next(10, 25);
                    enemy.DEF = random.Next(5, 15);
                    break;
                case Enemy.Enemy3:
                    enemy.name = "무인";
                    enemy.HP = random.Next(1, 10);
                    enemy.MP = random.Next(5, 21);
                    enemy.ATK = random.Next(8, 22);
                    enemy.DEF = random.Next(3, 12);
                    break;
                default:
                    enemy.name = "살수";
                    enemy.HP = random.Next(1, 10);
                    enemy.MP = random.Next(10, 30);
                    enemy.ATK = random.Next(20, 40);
                    enemy.DEF = random.Next(10, 20);
                    break;
            }
            return enemy;
        }

        static Monster CreateFinalBoss()
        {
            Monster boss;
            boss.name = "???";
            boss.HP = 20;
            boss.MP = 50;
            boss.ATK = 30;
            boss.DEF = 20;

            return boss;
        }

        public static void Display()
        {
            Player player = Status.player; // 플레이어 정보 가져오기
            Monster enemy;

            Console.WriteLine($"DEBUG: 현재 진행도 (Game.progress) = {Game.progress}"); // 디버깅 출력

            string finalBossArt = @"





*****************===*=***
$===*=******=:*********=*
========$=!=$;***********
=======*$   $=!!!!!!*!**!
========#. ::*;:;;;;;;;;;
==**====-~,.!*;::::;;;;;!
=****===*~  !*;~:::~~::;;
=****=:,!..:~,: ;:~:~~~:;
*****!. :     $-!;!=-~~~~
*****~ !$--..-;,.;!*-~~~~
******,,=#$!!##-~~:-,-~*#
*******-@@@.-@@-~:=,,--=@
******-$@@#:*#@*;---.,.$#
******=$@@~.,#@$;:~~~,.-:
====**=#*=*,~@@$;~~--..-:
====;~=!==*;;;#=,.:~:-,~~
*!!!~-!:$!#=;##,!.~-:.~~:
!!!*,.;;###;:@*!$.-:$--~~
!!!!,;;;##;;!=*@$*;~$~~--
!!!****~@-;!!*$,#!;:$:~:;
!!***;=!#~!=!;=***!-#;~~;
!!!!*!**=;==*!;:!=;-$--::
!*!!**!*=!!*=!*#$$*=#=:!:
!***!***$*!*===*$$!*$;;!;
*******=.=**=$ $=@!*$!;!;
**===$$@.$$#$=$#=#!=*;;!!
$$######$@##=$@=$~;=*;;!!
########@#$$$$@$$!*$*;;!!
$$$$$$$@$$$$=#@=$$===!*==
$$$$$$$@@$$$$*#=$$===**==
$$$$$$$*:*$$!-::$$$$$==$$
$$$$$$$*~$$$#*:$#$$$$$$$$
$$$$$$$!.$$$#$;~$#$$$==$$
$$#$$$$~:#$$#@#=$$$$$$$$$
$$#$$##$#########$#$$$$$$
##$####@@#####$##$$$=*$$$
####$########$$$$$$$$$$$=


";

            // 🔹 최종 보스 조우 조건
            if (Game.progress == 8)
            {
                Console.Clear();
                Console.WriteLine(finalBossArt); // 🔹 최종 보스 아스키 아트 출력
                Console.WriteLine("\n[ ??? ]");
                Console.WriteLine("......간다.");
                Thread.Sleep(3000);

                enemy = CreateFinalBoss();
            }
            else
            {
                enemy = CreateMonster();
            }

            // 🔹 진행도 증가 및 플레이어 공격력 증가 적용
            Game.progress++;
            Console.WriteLine($"DEBUG: 전투 시작! 진행도 증가 후 Game.progress = {Game.progress}"); // 디버깅 출력
            player.ATK += 1;  // 🔹 매 전투마다 공격력 증가
            string log = $"{enemy.name}이(가) 나타났다!\n(전투 경험이 쌓이며 공격력이 증가했다! 현재 공격력: {player.ATK})";

            // 🔹 전투 시작
            int result = Fight(ref player, ref enemy);

            if (result == 1)  // 🔹 승리 시
            {
                if (Game.progress == 9) // 🔹 최종 보스 승리 후 타이틀 이동
                {
                    Console.Clear();
                    Console.WriteLine("[ 당신은 모든 적을 쓰러뜨렸다... ]");
                    Console.WriteLine("긴 전투가 끝났다. 이제 모든 것이 조용해졌다.");
                    Console.WriteLine("락샤사의 힘에서 벗어날 수 있을까?");
                    Thread.Sleep(5000);
                    Title.Display();
                }
                else
                {
                    Console.WriteLine("전투에서 승리했습니다!");
                    Thread.Sleep(2000);
                    Game.Display();
                }
            }
            else  // 🔹 패배 시
            {
                Console.WriteLine("게임 오버...");
                Thread.Sleep(2000);
                Title.Display();
            }
        }


        static int Fight(ref Player player, ref Monster monster)
        {
            string log = $"{monster.name}이(가) 나타났다!";

            while (true)
            {
                DisplayUI(player, monster, log);
                ConsoleKey key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.D1) // 🔹 일반 공격
                {
                    monster.HP = Math.Max(0, monster.HP - player.ATK);
                    log = $"{player.name}가 {monster.name}을(를) 공격하여 {player.ATK}의 데미지를 입혔다!";
                }
                else if (key == ConsoleKey.D2) // 🔹 스킬 공격
                {
                    if (player.MP >= 10)
                    {
                        monster.HP = Math.Max(0, monster.HP - (player.ATK * 2));
                        player.MP = Math.Max(0, player.MP - 10);
                        log = $"{player.name}가 스킬 공격으로 {monster.name}에게 {player.ATK * 2}의 데미지를 입혔다! (MP -10)";
                    }
                    else
                    {
                        log = "MP가 부족하여 스킬을 사용할 수 없다!";
                        continue;
                    }
                }
                else if (key == ConsoleKey.D3) // 🔹 방어
                {
                    log = $"{player.name}가 방어 자세를 취하여 피해를 줄였다!";
                }
                else if (key == ConsoleKey.D4) // 🔹 도구 사용 (추후 기능 확장 가능)
                {
                    log = "아직 사용할 도구가 없다!";
                }
                else if (key == ConsoleKey.Backspace) // 🔹 도망가기
                {
                    log = $"{player.name}가 도망쳤다!";
                    Game.Display();
                    return 0;
                }

                // 🔹 적이 쓰러졌을 경우
                if (monster.HP <= 0)
                {
                    log = $"{monster.name}을(를) 쓰러뜨렸다!";
                    return 1;
                }

                // 🔹 적의 반격
                player.HP = Math.Max(0, player.HP - monster.ATK);
                log = $"{monster.name}이(가) {player.name}을(를) 공격하여 {monster.ATK}의 데미지를 입혔다!";

                if (player.HP <= 0)
                {
                    log = "패배했습니다. 게임 오버.";
                    return 0;
                }
            }
        }
    }
}
