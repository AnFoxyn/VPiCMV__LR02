using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.VisualTree;

namespace UITestsForStudentControl
{
    public class StudentControlTests
    {
        [Fact]
        public async void colors_tests_red()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var listBoxItems = mainWindow.GetVisualDescendants().OfType<ListBox>().First().GetVisualDescendants().OfType<ListBoxItem>();

            var listBoxItem = listBoxItems.ToArray()[0];
            var visualProgrammBorder = listBoxItem.GetVisualDescendants().OfType<Border>().First(x => (x.Name != null) && x.Name.Equals("VisualProgrammBorder"));
            var textBlockVisualProgramm = listBoxItem.GetVisualDescendants().OfType<TextBlock>().First(x => (x.Name != null) && x.Name.Equals("VisualProgrammText"));
            var text = textBlockVisualProgramm.Text;
            Color c = text switch
            {
                "0" => Colors.Red,
                "1" => Colors.Yellow,
                "2" => Colors.Green,
            };
            var color = (visualProgrammBorder.Background as SolidColorBrush).Color;
            Assert.True(color.Equals(c), "Not true");
        }

        [Fact]
        public async void color_tests_green()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var listBoxItems = mainWindow.GetVisualDescendants().OfType<ListBox>().First().GetVisualDescendants().OfType<ListBoxItem>();

            var listBoxItem = listBoxItems.ToArray()[1];
            var visualProgrammBorder = listBoxItem.GetVisualDescendants().OfType<Border>().First(x => (x.Name != null) && x.Name.Equals("VisualProgrammBorder"));
            var textBlockVisualProgramm = listBoxItem.GetVisualDescendants().OfType<TextBlock>().First(x => (x.Name != null) && x.Name.Equals("VisualProgrammText"));
            var text = textBlockVisualProgramm.Text;
            Color c = text switch
            {
                "0" => Colors.Red,
                "1" => Colors.Yellow,
                "2" => Colors.Green,
            };
            var color = (visualProgrammBorder.Background as SolidColorBrush).Color;
            Assert.True(color.Equals(c), "Not true");
        }

        [Fact]
        public async void color_tests_yellow()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var grid = mainWindow.GetVisualDescendants().OfType<Grid>().First(x => (x.Name != null) && x.Name.Equals("SrGrid"));

            var visualProgrammBorder = grid.GetVisualDescendants().OfType<Border>().First(x => (x.Name != null) && x.Name.Equals("VisualSrBorder"));
            var textBlockVisualProgramm = grid.GetVisualDescendants().OfType<TextBlock>().First(x => (x.Name != null) && x.Name.Equals("VisualSrText"));
            var text = textBlockVisualProgramm.Text;
            Color c = text switch
            {
                "0" => Colors.Red,
                "1" => Colors.Yellow,
                "2" => Colors.Green,
            };
            var color = (visualProgrammBorder.Background as SolidColorBrush).Color;
            Assert.True(color.Equals(c), "Not true");
        }


        [Fact]
        public async void add_student_and_save_test()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var listBoxItems = mainWindow.GetVisualDescendants().OfType<ListBox>().First().GetVisualDescendants().OfType<ListBoxItem>();

            var buttonAdd = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "AddStudentCommand");
            var buttonSave = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "SaveToFileCommand");
            var buttonLoad = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "UploadFromFileCommand");

            var textbox = mainWindow.GetVisualDescendants().OfType<TextBox>().First(t => t.Name == "TextBoxName");

            buttonSave.Command.Execute(buttonSave.CommandParameter);
            textbox.Text = "Иванов Иван Иванович";
            buttonAdd.Command.Execute(buttonAdd.CommandParameter);


            Assert.True(listBoxItems.Count() == 3);

            buttonLoad.Command.Execute(buttonLoad.CommandParameter);
        }

        [Fact]
        public async void student_save_test()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var listBoxItems = mainWindow.GetVisualDescendants().OfType<ListBox>().First().GetVisualDescendants().OfType<ListBoxItem>();

            var buttonAdd = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "AddStudentCommand");
            var buttonSave = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "SaveToFileCommand");
            var buttonLoad = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "UploadFromFileCommand");

            var textbox = mainWindow.GetVisualDescendants().OfType<TextBox>().First(t => t.Name == "TextBoxName");

            buttonSave.Command.Execute(buttonSave.CommandParameter);
            textbox.Text = "Василий Василий Васильевич";
            buttonAdd.Command.Execute(buttonAdd.CommandParameter);



            buttonLoad.Command.Execute(buttonLoad.CommandParameter);
            Assert.True(listBoxItems.Count() == 2);
        }

        [Fact]
        public async void remove_student_test()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var listBox = mainWindow.GetVisualDescendants().OfType<ListBox>().First();

            var listBoxItems = listBox.GetVisualDescendants().OfType<ListBoxItem>();

            var buttonRemove = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "DeleteStudentCommand");
            var buttonSave = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "SaveToFileCommand");
            var buttonLoad = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "UploadFromFileCommand");

            buttonSave.Command.Execute(buttonSave.CommandParameter);
            listBox.SelectedIndex = 0;
            buttonRemove.Command.Execute(buttonRemove.CommandParameter);

            Assert.True(listBoxItems.Count() == 1);

            buttonLoad.Command.Execute(buttonLoad.CommandParameter);
        }

        [Fact]
        public async void sr_color_test()
        {
            var app = AvaloniaApp.GetApp();
            var mainWindow = AvaloniaApp.GetMainWindow();

            await Task.Delay(100);

            var grid = mainWindow.GetVisualDescendants().OfType<Grid>().First(x => (x.Name != null) && x.Name.Equals("SrGrid"));

            var visualProgrammBorder = grid.GetVisualDescendants().OfType<Border>().First(x => (x.Name != null) && x.Name.Equals("AverageSrBorder"));
            var textBlockVisualProgramm = grid.GetVisualDescendants().OfType<TextBlock>().First(x => (x.Name != null) && x.Name.Equals("AverageSrText"));

            var buttonAdd = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "AddStudentCommand");
            var buttonSave = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "SaveToFileCommand");
            var buttonLoad = mainWindow.GetVisualDescendants().OfType<Button>().First(b => b.Name == "UploadFromFileCommand");

            var textbox = mainWindow.GetVisualDescendants().OfType<TextBox>().First(t => t.Name == "TextBoxName");

            buttonSave.Command.Execute(buttonSave.CommandParameter);
            textbox.Text = "Петров Петр Петрович";
            buttonAdd.Command.Execute(buttonAdd.CommandParameter);

            var text = textBlockVisualProgramm.Text;
            float asd = (float)Convert.ToDouble(text);
            Color c;
            if (asd < 1) c = Colors.Red;
            else if (asd < 1.5) c = Colors.Yellow;
            else c = Colors.Green;
            var color = (visualProgrammBorder.Background as SolidColorBrush).Color;
            Assert.True(color.Equals(c), "Not true");

            buttonLoad.Command.Execute(buttonLoad.CommandParameter);
        }
    }
}