using Sajat.Alkalmazas.API;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Xml;

namespace Sajat.Alkalmazas.WPF
{
    public partial class App : Application
    {

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            StilusBetoltese(@"M_Alkalmazas_WPF_EgyeniStilus.xaml");
        }

        private void StilusBetoltese(string utvonal)
        {
            XmlReader XmlRead;
            try
            {
                XmlRead = XmlReader.Create(utvonal);
                Application.Current.Resources.MergedDictionaries.Add((ResourceDictionary)XamlReader.Load(XmlRead));
                XmlRead.Close();
            }
            catch (Exception) { }
        }
    }
}
