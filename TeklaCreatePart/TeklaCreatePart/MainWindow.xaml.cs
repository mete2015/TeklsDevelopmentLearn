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
using Tekla.Structures.Model;
using Tekla.Structures.Geometry3d;
using TSG = Tekla.Structures.Geometry3d;
using Tekla.Structures.Model.UI;



namespace TeklaCreatePart
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Model model = new Model();
            if (model.GetConnectionStatus())
            {
            }
            else
            {
                MessageBox.Show("请打开Tekle21.0");
            }

        }


        /// <summary>
        /// 2点创建一个钢梁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model model = new Model();
                Picker picker = new Picker();
                TSG.Point p1 = picker.PickPoint();
                TSG.Point p2 = picker.PickPoint();
                Beam beam = new Beam(p1, p2);
                beam.Profile.ProfileString = "HI800-26-26*350";
                beam.Material.MaterialString = "Q235";
                beam.Insert();
                model.CommitChanges();


            }
            catch { }

        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Model model = new Model();
            //构建4个多边形点
            ContourPoint p1 = new ContourPoint(new TSG.Point(0, 0, 0), null);
            ContourPoint p2 = new ContourPoint(new TSG.Point(5000, 2500, 0), null);
            ContourPoint p3 = new ContourPoint(new TSG.Point(10000, 5000, 0), null);
            ContourPoint p4 = new ContourPoint(new TSG.Point(15000, 0, 0), null);

            PolyBeam polyBeam = new PolyBeam();
            polyBeam.AddContourPoint(p1);
            polyBeam.AddContourPoint(p2);
            polyBeam.AddContourPoint(p3);
            polyBeam.AddContourPoint(p4);
            polyBeam.Profile.ProfileString = "HI800-26-26*350";
            polyBeam.Material.MaterialString = "Q235";
            polyBeam.Insert();
            model.CommitChanges();
        }

     
    }
}
