using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Extensions
{
    public class ProgressBar
    {
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                if (!_isProgressBarExist)
                {
                    DrawProgressBar(_width);
                }
                else
                {
                    DrawProgress(_value);
                }
            }
        }
        public int MaxValue
        {
            get => _maxValue;
            set
            {
                if (value < _value)
                {
                    throw new ArgumentOutOfRangeException("MaxValue", "should not be less than Value.");
                }

                _maxValue = value;
            }
        }         
        /// <summary>
        /// Set the width of progress bar.
        /// </summary>
        public float Width { get => _width; set => _width = value; }
        public bool DisplayPercentage { get; set; }
        public bool DisplaySeparator { get; set; }
        public ConsoleColor BackgroundColor { get; set; } = ConsoleColor.Gray;
        public ConsoleColor ProgressColor { get; set; } = ConsoleColor.DarkCyan;

        private bool _isProgressBarExist;
        private int _progressBarWidth;
        private int _cursorTop;
        private int _cursorLeft;
        private int _bufferHeight;
        private int _bufferWidth;
        private int _value = 0;
        private float _width = 50;
        private int _maxValue = 100;
        private string _percentageText;

        public void DrawProgressBar() => DrawProgressBar(_width);
        
        public void DrawProgressBar(float width)
        {
            lock (Bootstrap.Threads)
            {
                _width = width;
                _isProgressBarExist = true;
                _bufferWidth = (int)(((Console.BufferWidth - (DisplayPercentage ? 7 : 0)) / 100f) * _width);
                _bufferHeight = Console.BufferHeight;
                _cursorTop = Console.CursorTop;
                _cursorLeft = Console.CursorLeft;

                Console.BackgroundColor = BackgroundColor;
                Console.ForegroundColor = BackgroundColor;

                _progressBarWidth = 0;
                StringBuilder progressBarBuilder = new StringBuilder();
                for (int i = 0; i < _bufferWidth - _cursorLeft; i++)
                {
                    progressBarBuilder.Append(DisplaySeparator ? "_" : " ");
                    _progressBarWidth++;
                }
                Console.WriteLine(progressBarBuilder);
            }

            DrawProgress(_value);
        }

        private void DrawProgress(int value)
        {
            lock (Bootstrap.Threads)
            {
                if (value < 0)
                {
                    return;
                }

                int cursorTop = Console.CursorTop;
                int cursorLeft = Console.CursorLeft;

                Console.CursorTop = _cursorTop;
                Console.CursorLeft = _cursorLeft;
                Console.BackgroundColor = ProgressColor;

                float progress = ((value) / ((float)MaxValue)) * 100f;
                float progressWidth = (_progressBarWidth / 100f) * progress;


                Console.ForegroundColor = BackgroundColor;
                StringBuilder progressBuilder = new StringBuilder();

                for (int i = 0; i < progressWidth; i++)
                {
                    if (progressWidth <= _progressBarWidth)
                    {
                        progressBuilder.Append(DisplaySeparator ? "_" : " ");
                    }
                }

                Console.Write(progressBuilder);

                Console.ResetColor();

                if (DisplayPercentage)
                {
                    Console.CursorLeft = _bufferWidth;

                    if (progressWidth <= _progressBarWidth)
                    {
                        _percentageText = progress.ToString("0.00");
                    }
                    Console.WriteLine($" {_percentageText}%");
                }

                Console.CursorTop = cursorTop;
                Console.CursorLeft = cursorLeft;
            }
        }
    }
}
