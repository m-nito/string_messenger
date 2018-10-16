using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MessengerTest
{
    public class MessengerTest
    {
        // user defined event keys.
        enum MESSAGE_KEY
        {
            test,
            test1,
            test2,
            test3
        }

        [Test]
        public void Test() {
            Action<string> print = (x) => {
                System.Diagnostics.Debug.WriteLine(x);
            };

            // Second action to make sure our messenger can be registered with multiple actions.
            Action<string> print2 = (x) => {
                System.Diagnostics.Debug.WriteLine($"this is print 2 : {x}");
            };

            print($"test started");

            Messenger.Messenger.Register(MESSAGE_KEY.test, print);
            Messenger.Messenger.Register(MESSAGE_KEY.test2, print);
            Messenger.Messenger.Register(MESSAGE_KEY.test2, print2);
            Messenger.Messenger.Register(MESSAGE_KEY.test3, print);

            // testing simple usage.
            print($"calling test 0");
            Messenger.Messenger.Call(MESSAGE_KEY.test, "test0");

            // trying to fire unregistered value.
            print($"calling test 1");
            Messenger.Messenger.Call(MESSAGE_KEY.test1, "test1");

            // trying to call multiple subscriber.
            print($"calling test 2");
            Messenger.Messenger.Call(MESSAGE_KEY.test2, "test2");

            // making sure previous tests not messing up with simple usage.
            print($"calling test 3");
            Messenger.Messenger.Call(MESSAGE_KEY.test3, "test3");
            
            Assert.True(print != null);

        }
    }
}
