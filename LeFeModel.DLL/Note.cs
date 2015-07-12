using System;
using System.Collections.Generic;
using System.Text;

namespace LeFe.Model
{
    public class Note
    {
        public Note()
        {
            word = up = down = foot = "";
            usingTimes = 0;
        }
        public string word;
        public string up;
        public string down;
        public string foot;
        public int usingTimes;
    }
}
