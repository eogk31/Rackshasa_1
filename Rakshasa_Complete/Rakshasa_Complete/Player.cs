using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rakshasa_Complete
{
    public struct Player
    {
        public string name; // 이름
        public int HP;      // 체력
        public int MP;      // 기력
        public int ATK;     // 공격력
        public int DEF;     // 방어력
        public int GOLD;    // 소지금

        // 생성자 추가 (능력치 랜덤 조정)
        public Player(string name, int hp, int mp, int atk, int def, int gold)
        {
            this.name = name;
            this.HP = hp;
            this.MP = mp;
            this.ATK = atk;
            this.DEF = def;
            this.GOLD = gold;
        }
    }
}
