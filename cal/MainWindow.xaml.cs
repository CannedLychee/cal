using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cal
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        #region 声明
        double numnow = 0, numpre = 0, result = 0; 
        //当前运算数，前一运算数，运算结果
        string opt = null; 
        //运算符，"+"加，“-”减，“*”乘，“/”除，null无当前运算符
        bool flag_ans = false;
        //保留上一次结果标志，在输入等号后如继续输入运算符进行运算则保留，重新输入数字/按下AC则抛弃
        bool flag_opt = false;
        //上一输入是运算符标志
        bool flag_dot = false;
        //输入小数点标志
        bool flag_neg = false;
        //负数标志
        int dec_count = 0;
        //小数位数
        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        #region IO
        /// <summary>
        /// 显示函数
        /// </summary>
        /// <param 此刻按键="input"></param>
        public void Display(string input)
        {
            if (input == "=")
            {
                lineout.Text = Convert.ToString(result);
            }
            else
            {
                if (lineout.Text != "0")
                {
                    lineout.Text += input;
                }
                else
                {
                    lineout.Text = input;
                }
            }
        }
        /// <summary>
        /// 输入函数
        /// </summary>
        public void inp(int n)
        {
            if (flag_ans)
            {
                flag_ans = false;
                opt = null;
                result = 0;
                numnow = 0;
            }

            if (flag_opt)
            {
                flag_opt = false;
                lineout.Text = "0";
            }

            if (flag_neg)
            {
                if (flag_dot)
                {
                    dec_count++;
                    numnow -= n / Math.Pow(10, dec_count);
                }
                else
                {
                    numnow = numnow * 10 - n;
                }
            }
            else
            {
                if (flag_dot)
                {
                    dec_count++;
                    numnow += n / Math.Pow(10, dec_count);
                }
                else
                {
                    numnow = numnow * 10 + n;
                }
            }
            Display(Convert.ToString(n));
        }

        public void del()
        {
            if (lineout.Text.Length != 1)
            {
                numnow = Convert.ToDouble(lineout.Text.Remove(lineout.Text.Length - 1, 1));
                if (numnow == (int)numnow)
                {
                    flag_dot = false;
                    dec_count = 0;
                }
                else
                {
                    dec_count --;
                }
                    
            }
            else
                numnow = 0;
            if (flag_ans)
            {
                flag_ans = false;
                flag_opt = false;
                opt = null;
            }
            lineout.Text = Convert.ToString(numnow);
        }

        #endregion

        #region 运算
        public void _ADD()
        {
            numpre = numpre + numnow;
            opt = "+";
        }
        public void _MIN()
        {
            numpre = numpre - numnow;
            opt = "-";
        }
        public void _MULT()
        {
            numpre = numpre * numnow;
            opt = "*";
        }
        public void _DIV()
        {
            numpre = numpre / numnow;
            opt = "/";
        }
        #endregion

        #region 数字输入
        /// <summary>
        /// 按键“0”事件
        /// </summary>
        private void Click_0(object sender, RoutedEventArgs e){     inp(0);     }
        /// <summary>
        /// 按键“1”事件
        /// </summary>
        private void Click_1(object sender, RoutedEventArgs e){     inp(1);     }
        /// <summary>
        /// 按键“2”事件
        /// </summary>
        private void Click_2(object sender, RoutedEventArgs e){     inp(2);     }
        /// <summary>
        /// 按键“3”事件
        /// </summary>        
        private void Click_3(object sender, RoutedEventArgs e){     inp(3);     }
        /// <summary>
        /// 按键“4”事件
        /// </summary>
        private void Click_4(object sender, RoutedEventArgs e){     inp(4);     }
        /// <summary>
        /// 按键“5”事件
        /// </summary>
        private void Click_5(object sender, RoutedEventArgs e){     inp(5);     }
        /// <summary>
        /// 按键“6”事件
        /// </summary>
        private void Click_6(object sender, RoutedEventArgs e){     inp(6);     }
        /// <summary>
        /// 按键“7”事件
        /// </summary>
        private void Click_7(object sender, RoutedEventArgs e){     inp(7);     }
        /// <summary>
        /// 按键“8”事件
        /// </summary>
        private void Click_8(object sender, RoutedEventArgs e){     inp(8);     }
        /// <summary>
        /// 按键“9”事件
        /// </summary>
        private void Click_9(object sender, RoutedEventArgs e){     inp(9);     }
        #endregion

        #region 功能按键
        /// <summary>
        /// 按键"."事件
        /// </summary>
        private void Click_dot(object sender, RoutedEventArgs e)
        {
            if (flag_ans)
            {
                lineout.Text = "0";
                flag_ans = false;
                flag_opt = false;
                opt = null;
                result = 0;
                numnow = 0;
            }
            if (flag_dot == false)
            {
                lineout.Text += ".";
                dec_count = 0;
            }
            flag_dot = true;
        }
        /// <summary>
        /// 按键AC事件
        /// </summary>
        private void Click_AC(object sender, RoutedEventArgs e)
        {
            numnow = 0;
            numpre = 0;
            result = 0;
            flag_dot = false;
            flag_neg = false;
            dec_count = 0;
            opt = null;
            Display("=");
        }
        /// <summary>
        /// 按键+/-事件
        /// </summary>
        private void Click_neg(object sender, RoutedEventArgs e)
        {
            if (flag_ans)
            {
                flag_ans = false;
                numnow = numpre * -1;
                result = numnow;
            }
            else
            {
                numnow = numnow * -1;
            }
            flag_neg = !flag_neg;
            if(lineout.Text.StartsWith("-"))
            {
                lineout.Text = lineout.Text.Remove(0, 1);
            }
            else
            {
                lineout.Text = "-" + lineout.Text;
            }
        }
        /// <summary>
        /// 按键“=”事件
        /// </summary>
        private void Click_equ(object sender, RoutedEventArgs e)
        {
            switch (opt)
            {
                case null:
                    result = numnow;
                    numpre = numnow;
                    break;
                case "+":
                    _ADD();
                    result = numpre;
                    break;
                case "-":
                    _MIN();
                    result = numpre;
                    break;
                case "*":
                    _MULT();
                    result = numpre;
                    break;
                case "/":
                    _DIV();
                    result = numpre;
                    break;
                default:
                    break;
            }
            Display("=");
            opt = "=";
            flag_ans = true;
            flag_opt = true;
        }
        #endregion

        private void Click_del(object sender, RoutedEventArgs e)
        {
            del();
        }

        #region 运算输入
        private void Click_add(object sender, RoutedEventArgs e)
        {
            switch (opt)
            {
                case "=":
                    numpre = result;
                    flag_ans = false;
                    break;
                case null:
                    numpre = numnow;
                    break;
                case "+":
                    _ADD();
                    break;
                case "-":
                    _MIN();
                    break;
                case "*":
                    _MULT();
                    break;
                case "/":
                    _DIV();
                    break;
                default:
                    break;
            }
            opt = "+";
            numnow = 0;
            flag_neg = false;
            flag_opt = true;
            flag_dot = false;
            lineout.Text = Convert.ToString(numpre);
        }
        private void Click_min(object sender, RoutedEventArgs e)
        {
            switch (opt)
            {
                case "=":
                    numpre = result;
                    flag_ans = false;
                    break;
                case null:
                    numpre = numnow;
                    break;
                case "+":
                    _ADD();
                    break;
                case "-":
                    _MIN();
                    break;
                case "*":
                    _MULT();
                    break;
                case "/":
                    _DIV();
                    break;
                default:
                    break;
            }   
            opt = "-";
            numnow = 0;
            flag_neg = false;
            flag_opt = true;
            flag_dot = false;
            lineout.Text = Convert.ToString(numpre);
        }
        private void Click_mult(object sender, RoutedEventArgs e)
        {
            switch (opt)
            {
                case "=":
                    numpre = result;
                    flag_ans = false;
                    break;
                case null:
                    numpre = numnow;
                    break;
                case "+":
                    _ADD();
                    break;
                case "-":
                    _MIN();
                    break;
                case "*":
                    _MULT();
                    break;
                case "/":
                    _DIV();
                    break;
                default:
                    break;
            }
            opt = "*";
            numnow = 0;
            flag_neg = false;
            flag_opt = true;
            flag_dot = false;
            lineout.Text = Convert.ToString(numpre);
        }
        private void Click_div(object sender, RoutedEventArgs e)
        {
            switch (opt)
            {
                case "=":
                    numpre = result;
                    flag_ans = false;
                    break;
                case null:
                    numpre = numnow;
                    break;
                case "+":
                    _ADD();
                    break;
                case "-":
                    _MIN();
                    break;
                case "*":
                    _MULT();
                    break;
                case "/":
                    _DIV();
                    break;
                default:
                    break;
            }
            opt = "/";
            numnow = 0;
            flag_neg = false;
            flag_opt = true;
            flag_dot = false;
            lineout.Text = Convert.ToString(numpre);
        }
        #endregion

    }
}
