using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorPattern
{
    class SeasonIterator
    {
        private Season _current;

        public bool HasNext()
        {
            /* E' minore di 4? Quindi non è l'ultimo della lista (che parte da 1) di stagioni. -> true */
            return (int)_current < 4;
        }

        public void MoveToNext()
        {
            if (_current == Season.Summer)
                _current = Season.Autumn;
            else if (_current == Season.Autumn)
                _current = Season.Winter;
            else if (_current == Season.Winter)
                _current = Season.Spring;

            else if (_current == Season.Spring) //ultimo, volendo inutile
                _current = Season.Summer;

            else //default
                _current = Season.Summer;
        }

        public Season GetCurrent()
        {
            return _current;
        }

        #region Alternative
        private void MoveToNext_b()
        {
            switch (_current)
            {
                case Season.Summer:
                    {
                        _current = Season.Autumn;
                        break;
                    }
                case Season.Autumn:
                    {
                        _current = Season.Winter;
                        break;
                    }
                case Season.Winter:
                    {
                        _current = Season.Spring;
                        break;
                    }
                case Season.Spring:
                    {
                        _current = Season.Summer;
                        break;
                    }

                default:
                    {
                        _current = Season.Summer;
                        break;
                    }
            }
        }

        private void MoveToNext_c()
        {
            switch (_current)
            {
                case Season.Summer:
                        _current = Season.Autumn;
                        break;
                case Season.Autumn:
                        _current = Season.Winter;
                        break;
                case Season.Winter:
                        _current = Season.Spring;
                        break;
                case Season.Spring:
                        _current = Season.Summer;
                        break;

                default:
                        _current = Season.Summer;
                        break;
            }
        }

        private Season GetCurrent_b() => _current;
        #endregion
    }
}