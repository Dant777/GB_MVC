using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

/*
+ 1. Создайте форму WPF или WinForms, разместите на ней текстовое поле и в другом потоке последовательно добавляйте на него числа Фибоначчи. 
-2. В этой же форме добавьте регулятор, который будет отсчитывать, сколько секунд должно пройти, прежде чем появится следующее число.
+3. Изучите внимательно статичный класс Thread и не статичный класс. Найдите метод, который может прервать выполняющийся поток и зафиксируйте ту ошибку, которая формируется при отмене.
 */
namespace GB_MVC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int TIME_DILAY = 2000;
      
        public MainWindow()
        {
            InitializeComponent();

            Thread fiThread = new Thread(PrintFibanachi);
            fiThread.Start();
            Thread.Sleep(5000);
           // fiThread.Abort("Error");
           
        }

      

        private void PrintFibanachi()
        {

            for (int i = 0; i < 6; i++)
            {
                Thread.Sleep(TIME_DILAY);
                CreateFibanchiNumber(i);
            }
        }

        private void CreateFibanchiNumber(int number)
        {
            string txt;
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                txt = textBox.Text;
                int fiNumber = Fibonachi(number);
                txt += " " + fiNumber.ToString();
                textBox.Text = txt;
            }));
            
        }

        private int Fibonachi(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else
            {
                return Fibonachi(n - 1) + Fibonachi(n - 2);
            }
        }
    }
}
