using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class DungeonFactory
{
    public static Dungeon BuildNewDungeon(int dungeonDone)
    {
        return new Dungeon(dungeonDone);
    }
}

