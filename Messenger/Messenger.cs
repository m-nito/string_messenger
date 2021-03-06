﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger
{
    // in case typing is needed, use Messenger<T>
    public static class Messenger
    {
        private static Dictionary<Enum, Action<string>> _listenerDict;

        /// <summary>
        /// Registeres new event with given user-defined key enum.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="act">Event to register in form of Method(string).</param>
        public static void Register(Enum key, Action<string> act)
        {
            if (_listenerDict == null)
                _listenerDict = new Dictionary<Enum, Action<string>>();
            if (!_listenerDict.ContainsKey(key))
                _listenerDict[key] = act;
            else
                _listenerDict[key] += act;
        }

        /// <summary>
        /// Calls registered event. Nothing happens if given key doesn't exist.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="message"></param>
        public static void Call(Enum key, string message) {
            if (_listenerDict != null && _listenerDict.ContainsKey(key))
                _listenerDict[key](message);
        }
    }
}
