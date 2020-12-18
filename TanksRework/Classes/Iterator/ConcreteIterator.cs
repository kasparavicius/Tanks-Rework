﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TanksRework.Classes.Iterator
{
    class ConcreteIterator : Iterator
    {
        private ConcreteAgg _aggregate;
        private int _current = 0;


        public ConcreteIterator(ConcreteAgg aggregate)
        {
            this._aggregate = aggregate;
        }

        public override object First()
        {
            return _aggregate[0];
        }


        public override object Next()
        {
            object ret = null;
            if (_current < _aggregate.Count - 1)
            {
                ret = _aggregate[++_current];
            }

            return ret;
        }


        public override object CurrentItem()
        {
            return _aggregate[_current];
        }


        public override bool IsDone()
        {
            return _current >= _aggregate.Count;
        }
    }
}
