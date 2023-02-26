using Avalonia.Media;
using ReactiveUI;
using StudentControl.Models;
using StudentControl.Converters;
using System;
using System.Reactive;

namespace StudentControl.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Student[] students;

        private SolidColorBrush checkColor(float num)
        {
            if (num < 1) return new SolidColorBrush(Colors.Red);
            if (num < 1.5) return new SolidColorBrush(Colors.Yellow);
            else return new SolidColorBrush(Colors.Green);
        }

        private void CheckAverage(Student[] students)
        {
            for (int i = 0; i < 8; i++)
            {
                avg_evals[i] = 0;
            }
            for (int i = 0; i < students.Length; i++)
            {
                AvgEvalEEiS += students[i].EEiS;
                AvgEvalSEVMiT += students[i].SEVMiT;
                AvgEvalAEVM += students[i].AEVM;
                AvgEvalTViMS += students[i].TViMS;
                AvgEvalSGMA += students[i].SGMA;
                AvgEvalVM += students[i].VM;
                AvgEvalVPiCMV += students[i].VPiCMV;
                AvgAverageEval += students[i].AverageEval;
            }
            AvgEvalEEiS /= students.Length;
            ColorEEiS = checkColor(AvgEvalEEiS);
            AvgEvalSEVMiT /= students.Length;
            ColorSEVMiT = checkColor(AvgEvalSEVMiT);
            AvgEvalAEVM /= students.Length;
            ColorAEVM = checkColor(AvgEvalAEVM);
            AvgEvalTViMS /= students.Length;
            ColorTViMS = checkColor(AvgEvalTViMS);
            AvgEvalSGMA /= students.Length;
            ColorSGMA = checkColor(AvgEvalSGMA);
            AvgEvalVM /= students.Length;
            ColorVM = checkColor(AvgEvalVM);
            AvgEvalVPiCMV /= students.Length;
            ColorVPiCMV = checkColor(AvgEvalVPiCMV);
            AvgAverageEval /= students.Length;
            ColorAverageEval = checkColor(AvgAverageEval);
        }

        public MainWindowViewModel()
        {
            AddStudentCommand = ReactiveCommand.Create(() =>
            {
                if (NewFIO != "")
                {
                    Student[] temp = students;
                    Array.Resize(ref temp, temp.Length + 1);
                    temp[temp.Length - 1] = new Student { FIO = NewFIO, EEiS = evals[0], SEVMiT = evals[1], AEVM = evals[2], TViMS = evals[3], SGMA = evals[4], VM = evals[5], VPiCMV = evals[6] };
                    Students = temp;
                    NewFIO = "";
                    EvalEEiS = 0;
                    EvalSEVMiT = 0;
                    EvalAEVM = 0;
                    EvalTViMS = 0;
                    EvalSGMA = 0;
                    EvalVM = 0;
                    EvalVPiCMV = 0;
                    CheckAverage(students);
                }
            });

            DeleteStudentCommand = ReactiveCommand.Create(() =>
            {
                if (index < students.Length)
                {
                    Student[] temp = students;
                    for (int i = index; i < temp.Length - 1; i++)
                    {
                        temp[i] = temp[i + 1];
                    }
                    Array.Resize(ref temp, temp.Length - 1);
                    Students = temp;
                    Index = 5000;
                    CheckAverage(students);
                }
            });

            SaveToFileCommand = ReactiveCommand.Create(() =>
            {
                Serializer<Student[]>.Save("Students.dat", students);
            });

            UploadFromFileCommand = ReactiveCommand.Create(() =>
            {
                Students = Serializer<Student[]>.Load("Students.dat");
                CheckAverage(students);
            });
            Students = new Student[]
            {
                new Student{FIO="Иванов Иван Иванович", EEiS=2, SEVMiT=2, AEVM=2, TViMS=2, SGMA=2, VM=2, VPiCMV=2},
                new Student{FIO="Василий Василий Васильевич", EEiS=1, SEVMiT=1, AEVM=1, TViMS=1, SGMA=1, VM=1, VPiCMV=1},
                new Student{FIO="Петров Петр Петрович", EEiS=0, SEVMiT=0, AEVM=0, TViMS=0, SGMA=0, VM=0, VPiCMV=0},
            };
            CheckAverage(students);

        }

        public Student[] Students
        {
            get => students;
            set => this.RaiseAndSetIfChanged(ref students, value);
        }

        public ReactiveCommand<Unit, Unit> AddStudentCommand { get; }
        public ReactiveCommand<Unit, Unit> DeleteStudentCommand { get; }
        public ReactiveCommand<Unit, Unit> SaveToFileCommand { get; }
        public ReactiveCommand<Unit, Unit> UploadFromFileCommand { get; }

        private ushort[] evals = { 0, 0, 0, 0, 0, 0, 0 };
        private string new_fio = "";
        private ushort index = 5000;
        private float[] avg_evals = { 0, 0, 0, 0, 0, 0, 0, 0 };
        private SolidColorBrush[] colorBrush = new SolidColorBrush[8];

        public ushort Index { get => index; set => this.RaiseAndSetIfChanged(ref index, value); }
        public string NewFIO { get => new_fio; set => this.RaiseAndSetIfChanged(ref new_fio, value); }
        public ushort EvalEEiS { get => evals[0]; set => this.RaiseAndSetIfChanged(ref evals[0], value); }
        public ushort EvalSEVMiT { get => evals[1]; set => this.RaiseAndSetIfChanged(ref evals[1], value); }
        public ushort EvalAEVM { get => evals[2]; set => this.RaiseAndSetIfChanged(ref evals[2], value); }
        public ushort EvalTViMS { get => evals[3]; set => this.RaiseAndSetIfChanged(ref evals[3], value); }
        public ushort EvalSGMA { get => evals[4]; set => this.RaiseAndSetIfChanged(ref evals[4], value); }
        public ushort EvalVM { get => evals[5]; set => this.RaiseAndSetIfChanged(ref evals[5], value); }
        public ushort EvalVPiCMV { get => evals[6]; set => this.RaiseAndSetIfChanged(ref evals[6], value); }

        public float AvgEvalEEiS { get => avg_evals[0]; set => this.RaiseAndSetIfChanged(ref avg_evals[0], value); }
        public float AvgEvalSEVMiT { get => avg_evals[1]; set => this.RaiseAndSetIfChanged(ref avg_evals[1], value); }
        public float AvgEvalAEVM { get => avg_evals[2]; set => this.RaiseAndSetIfChanged(ref avg_evals[2], value); }
        public float AvgEvalTViMS { get => avg_evals[3]; set => this.RaiseAndSetIfChanged(ref avg_evals[3], value); }
        public float AvgEvalSGMA { get => avg_evals[4]; set => this.RaiseAndSetIfChanged(ref avg_evals[4], value); }
        public float AvgEvalVM { get => avg_evals[5]; set => this.RaiseAndSetIfChanged(ref avg_evals[5], value); }
        public float AvgEvalVPiCMV { get => avg_evals[6]; set => this.RaiseAndSetIfChanged(ref avg_evals[6], value); }
        public float AvgAverageEval { get => avg_evals[7]; set => this.RaiseAndSetIfChanged(ref avg_evals[7], value); }

        public SolidColorBrush ColorEEiS { get => colorBrush[0]; set => this.RaiseAndSetIfChanged(ref colorBrush[0], value); }
        public SolidColorBrush ColorSEVMiT { get => colorBrush[1]; set => this.RaiseAndSetIfChanged(ref colorBrush[1], value); }
        public SolidColorBrush ColorAEVM { get => colorBrush[2]; set => this.RaiseAndSetIfChanged(ref colorBrush[2], value); }
        public SolidColorBrush ColorTViMS { get => colorBrush[3]; set => this.RaiseAndSetIfChanged(ref colorBrush[3], value); }
        public SolidColorBrush ColorSGMA { get => colorBrush[4]; set => this.RaiseAndSetIfChanged(ref colorBrush[4], value); }
        public SolidColorBrush ColorVM { get => colorBrush[5]; set => this.RaiseAndSetIfChanged(ref colorBrush[5], value); }
        public SolidColorBrush ColorVPiCMV { get => colorBrush[6]; set => this.RaiseAndSetIfChanged(ref colorBrush[6], value); }
        public SolidColorBrush ColorAverageEval { get => colorBrush[7]; set => this.RaiseAndSetIfChanged(ref colorBrush[7], value); }
    }
}