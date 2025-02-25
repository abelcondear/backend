using System.Windows;
using System.Windows.Input;

namespace bin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public dynamic ob;

        public MainWindow()
        {
            InitializeComponent();
            CleanCmdContent();

            ob = new PlayControl();
        }
        
        private void CleanCmdContent()
        {
            CmdX1Y1.Content = "";
            CmdX1Y2.Content = "";
            CmdX1Y3.Content = "";            

            CmdX2Y1.Content = "";
            CmdX2Y2.Content = "";
            CmdX2Y3.Content = "";

            CmdX3Y1.Content = "";
            CmdX3Y2.Content = "";
            CmdX3Y3.Content = "";
        }

        private void CmdX1Y1_Click(object sender, RoutedEventArgs e)
        {
            //0, 0            
            CmdX1Y1.Content = (CmdX1Y1.Content.ToString() == "X") ? "" : "X";
            if (ob.Play(0, 0, (CmdX1Y1.Content.ToString() == "X"))) { CleanCmdContent(); }
        }

        private void CmdX1Y2_Click(object sender, RoutedEventArgs e)
        {
            //0, 1            
            CmdX1Y2.Content = (CmdX1Y2.Content.ToString() == "X") ? "" : "X";            
            if (ob.Play(0, 1, (CmdX1Y2.Content.ToString() == "X"))) { CleanCmdContent(); }
        }

        private void CmdX1Y3_Click(object sender, RoutedEventArgs e)
        {
            //0, 2            
            CmdX1Y3.Content = (CmdX1Y3.Content.ToString() == "X") ? "" : "X";            
            if (ob.Play(0, 2, (CmdX1Y3.Content.ToString() == "X"))) { CleanCmdContent(); }
        }

        private void CmdX2Y1_Click(object sender, RoutedEventArgs e)
        {
            //1, 0
            CmdX2Y1.Content = (CmdX2Y1.Content.ToString() == "X") ? "" : "X";           
            if (ob.Play(1, 0, (CmdX2Y1.Content.ToString() == "X"))) { CleanCmdContent(); }
        }

        private void CmdX2Y2_Click(object sender, RoutedEventArgs e)
        {
            //1, 1
            CmdX2Y2.Content = (CmdX2Y2.Content.ToString() == "X") ? "" : "X";           
            if (ob.Play(1, 1, (CmdX2Y2.Content.ToString() == "X"))) { CleanCmdContent(); }
        }

        private void CmdX2Y3_Click(object sender, RoutedEventArgs e)
        {
            //1, 2
            CmdX2Y3.Content = (CmdX2Y3.Content.ToString() == "X") ? "" : "X";
            if (ob.Play(1, 2, (CmdX2Y3.Content.ToString() == "X"))) { CleanCmdContent(); }
        }

        private void CmdX3Y1_Click(object sender, RoutedEventArgs e)
        {
            //2, 0
            CmdX3Y1.Content = (CmdX3Y1.Content.ToString() == "X") ? "" : "X";
            if (ob.Play(2, 0, (CmdX3Y1.Content.ToString() == "X"))) { CleanCmdContent(); }
        }

        private void CmdX3Y2_Click(object sender, RoutedEventArgs e)
        {
            //2, 1
            CmdX3Y2.Content = (CmdX3Y2.Content.ToString() == "X") ? "" : "X";
            if (ob.Play(2, 1, (CmdX3Y2.Content.ToString() == "X"))) { CleanCmdContent(); }
        }

        private void CmdX3Y3_Click(object sender, RoutedEventArgs e)
        {
            //2, 2
            CmdX3Y3.Content = (CmdX3Y3.Content.ToString() == "X") ? "" : "X";
            if (ob.Play(2, 2, (CmdX3Y3.Content.ToString() == "X"))) { CleanCmdContent(); }
        }
    }
}
