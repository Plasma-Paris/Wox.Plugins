using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Windows.Controls;
using System.Collections.Generic;
using Wox.Plugin.Common.Settings;

namespace Wox.Plugin.Translator.Settings
{
    /// <summary>
    /// Interaction logic for SettingsForm.xaml
    /// </summary>
    public partial class SettingsForm : UserControl
    {
        private readonly PluginInitContext _context;
        private readonly SettingElements _settings;
        private readonly SettingService _service;

        public SettingsForm(PluginInitContext context, SettingElements settings, SettingService service)
        {
            if (service == null)
                throw new ArgumentNullException("service", "service is null.");
            if (context == null)
                throw new ArgumentNullException("context", "context is null.");
            if (settings == null)
                throw new ArgumentNullException("settings", "settings is null.");

            _settings = settings;
            _service = service;
            _context = context;

            InitializeComponent();

            _settings.PropertyChanged += (sender, e) => _service.SaveSettings(context, settings);
            _settings.DefaultLanguages.CollectionChanged += (sender, e) => _service.SaveSettings(context, settings);

            DataContext = _settings;
        }
        
        private void ButtonAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _settings.DefaultLanguages.Add(new DefaultLanguage() { Source = _textSource.Text, Destination = _textDestination.Text });
        }

        private void ButtonRemove_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _settings.DefaultLanguages.Remove(_listBox.SelectedItem as DefaultLanguage);
        }
    }
}
