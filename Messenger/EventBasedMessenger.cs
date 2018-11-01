using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger
{
    public delegate void TheEventHandler<T>(T value);

    public class EventBased {
        public static event TheEventHandler<string> TheHandler;
        public static void Call(string str) {
            TheHandler(str);
        }
    }
    public class EventBasedExec {
        public void Show() {
            EventBased.TheHandler += GUIMethod;
            EventBased.Call("aa");
        }
        private void GUIMethod(string str) {
            Console.WriteLine(str);
        }
    }
}
