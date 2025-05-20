
using System.Windows.Input;
using System.Windows.Ink;
using System.Windows.Media;

namespace AMDEstimator.ViewModels
{
    public class TakeoffViewModel : ViewModelBase
    {
        private DrawingAttributes _drawingAttributes;
        private StrokeCollection _strokes;
        private StrokeCollection _undoStrokes;

        public TakeoffViewModel()
        {
            _drawingAttributes = new DrawingAttributes
            {
                Color = Colors.Black,
                Height = 2,
                Width = 2,
                FitToCurve = true
            };

            _strokes = new StrokeCollection();
            _undoStrokes = new StrokeCollection();

            StartAreaTakeoffCommand = new RelayCommand(StartAreaTakeoff);
            StartLinearTakeoffCommand = new RelayCommand(StartLinearTakeoff);
            UndoCommand = new RelayCommand(Undo);
            ClearCommand = new RelayCommand(Clear);
        }

        public DrawingAttributes DrawingAttributes
        {
            get { return _drawingAttributes; }
            set
            {
                _drawingAttributes = value;
                OnPropertyChanged();
            }
        }

        public StrokeCollection Strokes
        {
            get { return _strokes; }
            set
            {
                _strokes = value;
                OnPropertyChanged();
            }
        }

        public ICommand StartAreaTakeoffCommand { get; }
        public ICommand StartLinearTakeoffCommand { get; }
        public ICommand UndoCommand { get; }
        public ICommand ClearCommand { get; }

        private void StartAreaTakeoff(object parameter)
        {
            DrawingAttributes.Color = Colors.Red;
            DrawingAttributes.Height = 5;
            DrawingAttributes.Width = 5;
        }

        private void StartLinearTakeoff(object parameter)
        {
            DrawingAttributes.Color = Colors.Blue;
            DrawingAttributes.Height = 2;
            DrawingAttributes.Width = 2;
        }

        private void Undo(object parameter)
        {
            if (Strokes.Count > 0)
            {
                var lastStroke = Strokes[Strokes.Count - 1];
                _undoStrokes.Add(lastStroke);
                Strokes.Remove(lastStroke);
            }
        }

        private void Clear(object parameter)
        {
            Strokes.Clear();
            _undoStrokes.Clear();
        }
    }
}
