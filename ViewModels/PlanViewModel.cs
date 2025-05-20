using Microsoft.Win32;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AMDEstimator.ViewModels
{
    public class PlanViewModel : INotifyPropertyChanged
    {
        private ImageSource _planImage;
        public ImageSource PlanImage
        {
            get => _planImage;
            set { _planImage = value; OnPropertyChanged(); }
        }

        private string _planFilePath;
        public string PlanFilePath
        {
            get => _planFilePath;
            set { _planFilePath = value; OnPropertyChanged(); }
        }

        public void ImportPlan()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Plan Files|*.pdf;*.png;*.jpg;*.jpeg;*.bmp|All Files|*.*";
            if (dialog.ShowDialog() == true)
            {
                PlanFilePath = dialog.FileName;
                if (IsImageFile(PlanFilePath))
                {
                    PlanImage = new BitmapImage(new System.Uri(PlanFilePath));
                }
                else if (PlanFilePath.EndsWith(".pdf", System.StringComparison.OrdinalIgnoreCase))
                {
                    // TODO: Load PDF page as image using a PDF library (e.g. PdfiumViewer or PdfSharp)
                    PlanImage = null; // placeholder for now
                }
            }
        }

        private bool IsImageFile(string path)
        {
            string ext = System.IO.Path.GetExtension(path).ToLower();
            return ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
