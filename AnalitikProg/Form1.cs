using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using LiveCharts.Wpf;
using LiveCharts;

namespace AnalitikProg
{
    public partial class AnalitikProg : Form
    {
        List<Data> datas;
        public AnalitikProg()
        {
            InitializeComponent();
            datas = new List<Data>()
            {
                new Data(){ values=35000,date=new DateTime(2020,01,01) },
                new Data(){ values=30000,date=new DateTime(2020,01,02) },
                new Data(){ values=40000,date=new DateTime(2020,01,03) },
                new Data(){ values=55000,date=new DateTime(2020,01,04) },
                new Data(){ values=55000,date=new DateTime(2020,01,05) },
                new Data(){ values=30000,date=new DateTime(2020,01,06) },
                new Data(){ values=35000,date=new DateTime(2020,01,07) },
                new Data(){ values=42000,date=new DateTime(2020,01,08) },
                new Data(){ values=57000,date=new DateTime(2020,01,09) },
                new Data(){ values=88000,date=new DateTime(2020,01,10) },
                new Data(){ values=51000,date=new DateTime(2020,01,11) },
                new Data(){ values=65000,date=new DateTime(2020,01,12) },
                new Data(){ values=100000,date=new DateTime(2020,01,13) },
                new Data(){ values=75000,date=new DateTime(2020,01,14) },
                new Data(){ values=88000,date=new DateTime(2020,01,15) },
                new Data(){ values=92000,date=new DateTime(2020,01,16) },
                new Data(){ values=99000,date=new DateTime(2020,01,17) },
                new Data(){ values=87000,date=new DateTime(2020,01,18) },
                new Data(){ values=110000,date=new DateTime(2020,01,19) }
            };
        }

        private void toolStripButtonGenerate_Click(object sender, EventArgs e)
        {
            SeriesCollection series = new SeriesCollection(); //отображение данных на график. Линии и т.д.
            ChartValues<int> zp = new ChartValues<int>(); //Значения которые будут на линии, будет создания чуть позже.
            List<string> date = new List<string>(); //здесь будут храниться значения для оси X
            foreach (var item in datas) //Заполняем коллекции
            {
                zp.Add(item.values);
                date.Add(item.date.ToShortDateString());
            }

            cartesianChart1.AxisX.Clear(); //Очищаем ось X от значений по умолчанию
            cartesianChart1.AxisX.Add(new Axis //Добавляем на ось X значения, через блок инициализатора.
            {
                Title = "Дата",
                Labels = date
            });

            LineSeries line = new LineSeries(); //Создаем линию, задаем ей значения из коллекции
            line.Title = "График";
            line.Values = zp;

            series.Add(line); //Добавляем линию на график
            cartesianChart1.Series = series; //Отрисовываем график в интерфейсе
        }
        class Data
        {
            public int values { get; set; }
            public DateTime date { get; set; }
        }
    }
}
