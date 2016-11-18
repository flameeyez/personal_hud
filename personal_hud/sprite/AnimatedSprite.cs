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
    class AnimatedSprite : Sprite {
        private double _frameThreshold;
        private double _elapsedFrameTime;
        private int _currentFrame;
        public List<Rect> Frames = new List<Rect>();

        public AnimatedSprite(CanvasBitmap canvasBitmap, Vector2 position, double width, double height, int frameResolution, double frameThreshold = 200.0) : base(canvasBitmap, position, width, height) {
            _frameThreshold = frameThreshold;

            int frameCountX = (int)canvasBitmap.Bounds.Width / frameResolution;
            int frameCountY = (int)canvasBitmap.Bounds.Height / frameResolution;
            for (int y = 0; y < frameCountY; y++) {
                for (int x = 0; x < frameCountX; x++) {
                    Frames.Add(new Rect(x * frameResolution, y * frameResolution, frameResolution, frameResolution));
                }
            }
        }

        public override void Draw(CanvasAnimatedDrawEventArgs args) {
            args.DrawingSession.DrawImage(_canvasBitmap, new Rect(Position.X, Position.Y, Width, Height), Frames[_currentFrame], 1.0f, CanvasImageInterpolation.NearestNeighbor);
        }

        public override void Update(CanvasAnimatedUpdateEventArgs args) {
            _elapsedFrameTime += args.Timing.ElapsedTime.TotalMilliseconds;
            if (_elapsedFrameTime >= _frameThreshold) {
                _elapsedFrameTime = 0.0;
                if (++_currentFrame >= Frames.Count) { _currentFrame = 0; }
            }
        }
    }
}
