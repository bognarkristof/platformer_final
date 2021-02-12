using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace platformer_final
{
    class Class1
    {
        public bool goleft, goright, jumping, GameOver;

        public int jumpSpeed;
        public int force;
        public int score = 0;
        public int player_speed = 7;

        public int horizontalSpeed = 5;
        public int verticalSpeed = 3;

        public int enemyOneSpeed = 5;
        public int enemyTwoSpeed = 3;
    }
}
