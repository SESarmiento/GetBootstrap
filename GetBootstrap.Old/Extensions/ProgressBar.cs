using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Extensions
{
    public class ProgressBar
    {
        private int _cwidth;
        private int _cheight;
        private int _csrtop;
        private int _csrleft;
        private int _progwidth;
        private int _value = 0;
        private int _maxvalue;
        private float _width = 50;
        private bool _showPercent = true;
        private bool _showSeparator = true;

        public int Value { get => _value; set => _value = value; }
        public int MaxValue { get => _maxvalue; set => _maxvalue = value; }

        public float Width
        {
            get => _width; set
            {
                if (value > 100)
                {
                    throw new ArgumentOutOfRangeException("Width must not be greater than to 100");
                }
                else if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Width must not be less than to 0");
                }
                _width = value;
            }
        }

        public ConsoleColor BackgroundColor { get; set; } = ConsoleColor.Gray;
        public ConsoleColor ProgressColor { get; set; } = ConsoleColor.Cyan;
        public ConsoleColor SeparatorColor { get; set; } = ConsoleColor.Gray;
        public bool ShowPercent { get => _showPercent; set => _showPercent = value; }
        public bool ShowSeparator { get => _showSeparator; set => _showSeparator = value; }

        public ProgressBar(int maxValue = 100)
        {
            _maxvalue = maxValue;
        }

        public void DrawProgressBar()
        {
            DrawProgressBar((int)_width);
        }

        public void DrawProgressBar(int width)
        {
            Width = width;
            _cwidth = (int)(((Console.BufferWidth - (_showPercent ? 7 : 0)) / 100f) * _width);
            _cheight = Console.BufferHeight;
            _csrtop = Console.CursorTop;
            _csrleft = Console.CursorLeft;

            _progwidth = 0;
            for (int i = 0; i < _cwidth - _csrleft; i++)
            {
                Console.BackgroundColor = BackgroundColor;
                Console.ForegroundColor = SeparatorColor;
                Console.Write(_showSeparator ? "_" : " ");
                _progwidth++;
            }
            Console.WriteLine();
        }

        public void Increment(int increment = 1)
        {
            lock (Bootstrap._threads)
            {
                _value += increment;
                if (_value <= _maxvalue)
                {
                    DrawProgress(_value);
                }
            }
        }

        private void DrawProgress(int value)
        {
            int _cursortop = Console.CursorTop;
            int _cursorleft = Console.CursorLeft;

            Console.CursorTop = _csrtop;
            Console.CursorLeft = _csrleft;
            Console.BackgroundColor = ProgressColor;

            float progress = (value / (float)_maxvalue) * 100f;
            float pbwidth = (_progwidth / 100f) * progress;
            for (int i = 0; i < pbwidth; i++)
            {
                Console.ForegroundColor = SeparatorColor;
                Console.Write(_showSeparator ? "_" : " ");
            }
            Console.ResetColor();

            if (_showPercent)
            {
                Console.CursorLeft = _cwidth;
                Console.WriteLine($" {progress.ToString("0.00")}%");
            }

            Console.CursorTop = _cursortop;
            Console.CursorLeft = _cursorleft;
        }
    }
}

