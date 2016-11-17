using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace personal_hud {
    class AnimatedSprite {
        private CanvasBitmap _canvasBitmap;
        private double _frameThreshold;
        private double _elapsedFrameTime;
        private int _currentFrame;

        public Vector2 Position { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public List<Rect> Frames = new List<Rect>();

        public AnimatedSprite(CanvasBitmap canvasBitmap, Vector2 position, double width, double height, int frameResolution, double frameThreshold = 200.0) {
            _canvasBitmap = canvasBitmap;
            Position = position;
            Width = width;
            Height = height;
            _frameThreshold = frameThreshold;

            int frameCountX = (int)canvasBitmap.Bounds.Width / frameResolution;
            int frameCountY = (int)canvasBitmap.Bounds.Height / frameResolution;
            for (int x = 0; x < frameCountX; x++) {
                for (int y = 0; y < frameCountY; y++) {
                    Frames.Add(new Rect(x * frameResolution, y * frameResolution, frameResolution, frameResolution));
                }
            }
        }

        public void Draw(CanvasAnimatedDrawEventArgs args) {
            args.DrawingSession.DrawImage(_canvasBitmap, new Rect(Position.X, Position.Y, Width, Height), Frames[_currentFrame], 1.0f, CanvasImageInterpolation.NearestNeighbor);
        }

        public void Update(CanvasAnimatedUpdateEventArgs args) {
            _elapsedFrameTime += args.Timing.ElapsedTime.TotalMilliseconds;
            if (_elapsedFrameTime >= _frameThreshold) {
                _elapsedFrameTime = 0.0;
                if (++_currentFrame >= Frames.Count) { _currentFrame = 0; }
            }
        }
    }
}
