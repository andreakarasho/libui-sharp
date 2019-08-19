using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibUI;

namespace ConsoleApp1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application app = new Application();

            app.Run(new MyWindow("HELLO"));
        }


        class MyWindow : Window
        {
            public MyWindow(string title, int width = 500, int height = 200, bool hasMenubar = false) : base(title, width, height, hasMenubar)
            {
                VerticalBox box = new VerticalBox();

                Button buttonOk = new Button("OK");
                MultilineEntry textBox = new MultilineEntry();

                box.Children.Add(buttonOk);
                box.Children.Add(textBox);


                Child = box;
            }
        }

        public class MainWindow : Window
        {
            private Tab _tab;
            private BasicControlsPage _basicControlsPage;
            private NumbersPage _numbersPage;
            private DataChoosersPage _dataChoosersPage;

            public MainWindow(string title = "Window", int width = 500, int height = 200, bool hasMenubar = false) : base(title, width, height, hasMenubar)
            {
                InitializeComponent();
            }

            private void InitializeComponent()
            {
                this._tab = new Tab();
                this.Child = this._tab;

                this._basicControlsPage = new BasicControlsPage("Basic Controls") { AllowMargins = true };
                this._tab.Children.Add(this._basicControlsPage);

                this._numbersPage = new NumbersPage("Numbers and Lists") { AllowMargins = true };
                this._tab.Children.Add(this._numbersPage);

                this._dataChoosersPage = new DataChoosersPage("Data Choosers") { AllowMargins = true };
                this._tab.Children.Add(this._dataChoosersPage);
            }
        }

        public class BasicControlsPage : TabPage
        {
            private VerticalBox _verticalBox;
            private HorizontalBox _horizontalBox;
            private Group _group;
            private Form _form;

            private Button _button;
            private CheckBox _checkBox;
            private Label _label;

            private Separator _horizontalSeparator;

            private Entry _entry;
            private PasswordEntry _passwordEntry;
            private SearchEntry _searchEntry;
            private MultilineEntry _multilineEntry;
            private MultilineEntry _multilineNoWrappingEntry;

            public BasicControlsPage(string name) : base(name)
            {
                InitializeComponent();
            }

            private void InitializeComponent()
            {
                _verticalBox = new VerticalBox { AllowPadding = true };
                this.Child = _verticalBox;
                _horizontalBox = new HorizontalBox { AllowPadding = true };
                _verticalBox.Children.Add(_horizontalBox);
                _button = new Button("Button");
                _horizontalBox.Children.Add(_button);
                _checkBox = new CheckBox("CheckBox");
                _horizontalBox.Children.Add(_checkBox);
                _label = new Label("This is a label. Right now, labels can only span one line.");
                _verticalBox.Children.Add(_label);
                _horizontalSeparator = new Separator();
                _verticalBox.Children.Add(_horizontalSeparator);
                _group = new Group("Entries") { AllowMargins = true };
                _verticalBox.Children.Add(_group, true);
                _form = new Form { AllowPadding = true };
                _group.Child = _form;
                _entry = new Entry();
                _form.Children.Add("Entry", _entry);
                _passwordEntry = new PasswordEntry();
                _form.Children.Add("Password Entry", _passwordEntry);
                _searchEntry = new SearchEntry();
                _form.Children.Add("Search Entry", _searchEntry);
                _multilineEntry = new MultilineEntry();
                _form.Children.Add("Multiline Entry", _multilineEntry, true);
                _multilineNoWrappingEntry = new MultilineEntry(false);
                _form.Children.Add("Multiline Entry No Wrap", _multilineNoWrappingEntry, true);

            }
        }

        public class DataChoosersPage : TabPage
        {
            private HorizontalBox _hBox;
            private VerticalBox _vBox;
            private Grid _grid;
            private Button _button;
            private Entry _entry;
            private Grid _msgGrid;
            private Entry _entry2;

            public DataChoosersPage(string name) : base(name)
            {
                InitializeComponent();
            }

            private void InitializeComponent()
            {
                _hBox = new HorizontalBox() { AllowPadding = true };
                this.Child = _hBox;

                _vBox = new VerticalBox() { AllowPadding = true };
                _hBox.Children.Add(_vBox);

                _vBox.Children.Add(new DatePicker());
                _vBox.Children.Add(new TimePicker());
                _vBox.Children.Add(new DateTimePicker());
                _vBox.Children.Add(new FontPicker());
                _vBox.Children.Add(new ColorPicker());

                _hBox.Children.Add(new Separator(Orientation.Vertical));

                _vBox = new VerticalBox() { AllowPadding = true };
                _hBox.Children.Add(_vBox);

                _grid = new Grid() { AllowPadding = true };
                _vBox.Children.Add(_grid);

                _button = new Button("Open File");
                _entry = new Entry() { IsReadOnly = true };

                _button.Click += (sender, args) =>
                {
                    var dialog = new OpenFileDialog();
                    if (!dialog.Show())
                    {
                        _entry.Text = "(cancelled)";
                        return;
                    };
                    _entry.Text = dialog.Path;
                };

                _grid.Children.Add(_button, 0, 0, 1, 1, 0, HorizontalAlignment.Stretch, 0, VerticalAlignment.Stretch);
                _grid.Children.Add(_entry, 1, 0, 1, 1, 1, HorizontalAlignment.Stretch, 0, VerticalAlignment.Stretch);

                _button = new Button("Save File");
                _entry2 = new Entry() { IsReadOnly = true };

                _button.Click += (sender, args) =>
                {
                    var dialog = new SaveFileDialog();
                    if (!dialog.Show())
                    {
                        _entry2.Text = "(cancelled)";
                        return;
                    };
                    _entry2.Text = dialog.Path;
                };

                _grid.Children.Add(_button, 0, 1, 1, 1, 0, HorizontalAlignment.Stretch, 0, VerticalAlignment.Stretch);
                _grid.Children.Add(_entry2, 1, 1, 1, 1, 1, HorizontalAlignment.Stretch, 0, VerticalAlignment.Stretch);

                _msgGrid = new Grid() { AllowPadding = true };
                _grid.Children.Add(_msgGrid, 0, 2, 2, 1, 0, HorizontalAlignment.Center, 0, VerticalAlignment.Top);

                _button = new Button("Message Box");
                _button.Click += (sender, args) =>
                {
                    MessageBox.Show("This is a normal message box.", "More detailed information can be shown here.");
                };
                _msgGrid.Children.Add(_button, 0, 0, 1, 1, 0, HorizontalAlignment.Stretch, 0, VerticalAlignment.Stretch);

                _button = new Button("Error Box");
                _button.Click += (sender, args) =>
                {
                    MessageBox.Show("This message box describes an error.", "More detailed information can be shown here.", MessageBoxTypes.Error);
                };
                _msgGrid.Children.Add(_button, 1, 0, 1, 1, 0, HorizontalAlignment.Stretch, 0, VerticalAlignment.Stretch);
            }
        }

        public class NumbersPage : TabPage
        {
            private HorizontalBox _hBox;
            private Group _group;
            private VerticalBox _vBox;
            private ProgressBar _ip;
            private ComboBox _comboBox;
            private EditableComboBox _editableComboBox;
            private RadioButtonList _radioButtons;

            private SpinBox _spinBox;
            private Slider _slider;
            private ProgressBar _progressBar;

            public NumbersPage(string name) : base(name)
            {
                InitializeComponent();
            }

            private void InitializeComponent()
            {
                _hBox = new HorizontalBox() { AllowPadding = true };
                this.Child = _hBox;

                _group = new Group("Numbers") { AllowMargins = true };
                _hBox.Children.Add(_group, true);

                _vBox = new VerticalBox() { AllowPadding = true };
                _group.Child = _vBox;

                _spinBox = new SpinBox(0, 100);
                _slider = new Slider(0, 100);

                _progressBar = new ProgressBar();

                _spinBox.ValueChanged += (sender, args) =>
                {
                    var value = _spinBox.Value;
                    _slider.Value = value;
                    _progressBar.Value = value;
                };

                _slider.ValueChanged += (sender, args) =>
                {
                    var value = _slider.Value;
                    _spinBox.Value = value;
                    _progressBar.Value = value;
                };

                _vBox.Children.Add(_spinBox);
                _vBox.Children.Add(_slider);
                _vBox.Children.Add(_progressBar);

                _ip = new ProgressBar();
                _ip.Value = -1;
                _vBox.Children.Add(_ip);

                _group = new Group("Lists") { AllowMargins = true };
                _hBox.Children.Add(_group, true);

                _vBox = new VerticalBox() { AllowPadding = true };
                _group.Child = _vBox;

                _comboBox = new ComboBox();
                _comboBox.Add("Combobox Item 1", "Combobox Item 2", "Combobox Item 3");
                _vBox.Children.Add(_comboBox);

                _editableComboBox = new EditableComboBox();
                _editableComboBox.Add("Editable Item 1", "Editable Item 2", "Editable Item 3");
                _vBox.Children.Add(_editableComboBox);

                _radioButtons = new RadioButtonList();
                _radioButtons.Add("Radio Button 1", "Radio Button 2", "Radio Button 3");
                _vBox.Children.Add(_radioButtons);
            }
        }
    }
}
