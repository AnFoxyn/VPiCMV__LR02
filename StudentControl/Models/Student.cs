namespace StudentControl.Models
{
    public class Student
    {
        private float avgEval = 0;
        private ushort[] Evals = { 0, 0, 0, 0, 0, 0, 0 };
        private string fio = " ";

        public string FIO
        {
            get => fio;
            set => fio = value;
        }

        public ushort EEiS
        {
            get => Evals[0];
            set => Evals[0] = value;
        }


        public ushort SEVMiT
        {
            get => Evals[1];
            set => Evals[1] = value;
        }

        public ushort AEVM
        {
            get => Evals[2];
            set => Evals[2] = value;
        }

        public ushort TViMS
        {
            get => Evals[3];
            set => Evals[3] = value;
        }

        public ushort SGMA
        {
            get => Evals[4];
            set => Evals[4] = value;
        }
        public ushort VM
        {
            get => Evals[5];
            set => Evals[5] = value;
        }
        public ushort VPiCMV
        {
            get => Evals[6];
            set => Evals[6] = value;
        }

        public float AverageEval
        {
            get
            {
                avgEval = 0;

                foreach (ushort num in Evals)
                {
                    avgEval += num;
                }

                return avgEval /= 7;
            }
        }
    }
}