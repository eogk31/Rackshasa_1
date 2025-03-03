using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 타이틀 화면에서 게임 설명 선택 시 이동하는 화면
namespace Rakshasa_Complete
{
    class Explanation
    {
        public static void Display()
        {
            // 기존 화면 지우기
            Console.Clear();

            // 게임 설명 출력
            string explan = @"
『목 표』

1. 전투를 진행하며 마지막 적인 최종보스를 쓰러트리는 것이 목표인 게임입니다.
2. 전투를 진행할 때마다 진행도가 1씩 더해지며, 진행도가 8 이 되면 보스와 조우합니다.
3. 진행도 / 남은 체력 / 선택지에 따라 결말이 달라집니다.

──────────────────────────────────────────────────────────────────────────────────────────────────

『전 투』

1. 기본적으로 전투는 플레이어가 항상 먼저 행동하며, 적은 언제나 그 다음으로 행동합니다.
2. 플레이어는 1번 공격 / 2번 방어 / 3번 기술 / 4번 도구 중 하나를 선택합니다.
3. 적은 플레이어의 공격에 대하여 공격 / 방어 / 반격 중 하나를 실행합니다.

──────────────────────────────────────────────────────────────────────────────────────────────────

『백스페이스 바를 입력해 타이틀 화면으로 <-』






";

            Console.WriteLine(explan);

            // Backspace 입력 감지 후 타이틀 화면으로 복귀
            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Backspace)
                {
                    Title.Display();
                    break;
                }
            }
        }
    }
}
