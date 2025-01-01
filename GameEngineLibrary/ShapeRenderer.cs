using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GameEngineLibrary
{
    public class ShapeRenderer
    {
        private GraphicsDevice _graphicsDevice;

        public ShapeRenderer(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        public Texture2D CreateRectangle(int width, int height, Color color)
        {
            var texture = new Texture2D(_graphicsDevice, width, height);
            Color[] data = new Color[width * height];
            for (int i = 0; i < data.Length; i++) data[i] = color;
            texture.SetData(data);
            return texture;
        }

        public Texture2D CreateCircle(int radius, Color color)
        {
            int diameter = radius * 2;
            var texture = new Texture2D(_graphicsDevice, diameter, diameter);
            Color[] data = new Color[diameter * diameter];
            
            Vector2 center = new Vector2(radius, radius);
            for (int y = 0; y < diameter; y++)
            {
                for (int x = 0; x < diameter; x++)
                {
                    Vector2 position = new Vector2(x, y);
                    if (Vector2.Distance(position, center) <= radius)
                    {
                        data[y * diameter + x] = color;
                    }
                }
            }
            
            texture.SetData(data);
            return texture;
        }

    public Texture2D CreateTriangle(int width, int height, Color color)
    {
        var texture = new Texture2D(_graphicsDevice, width, height);
        Color[] data = new Color[width * height];
        
        float halfWidth = width / 2f;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float xPos = x - halfWidth;
                float yPos = y;
                if (Math.Abs(xPos) <= yPos)
                {
                    data[y * width + x] = color;
                }
            }
        }
        
        texture.SetData(data);
        return texture;
    }

    public Texture2D CreateEllipse(int width, int height, Color color)
    {
        var texture = new Texture2D(_graphicsDevice, width, height);
        Color[] data = new Color[width * height];
        
        Vector2 center = new Vector2(width / 2f, height / 2f);
        float radiusX = width / 2f;
        float radiusY = height / 2f;
        
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float dx = (x - center.X) / radiusX;
                float dy = (y - center.Y) / radiusY;
                if (dx * dx + dy * dy <= 1)
                {
                    data[y * width + x] = color;
                }
            }
        }
        
        texture.SetData(data);
        return texture;
    }

    public Texture2D CreateStar(int width, int height, Color color, int points = 5, float innerRadiusRatio = 0.5f)
    {
        var texture = new Texture2D(_graphicsDevice, width, height);
        Color[] data = new Color[width * height];
        
        Vector2 center = new Vector2(width / 2f, height / 2f);
        float outerRadius = Math.Min(width, height) / 2f;
        float innerRadius = outerRadius * innerRadiusRatio;
        
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Vector2 point = new Vector2(x, y);
                Vector2 direction = point - center;
                float angle = (float)Math.Atan2(direction.Y, direction.X);
                float radius = GetStarRadius(angle, points, outerRadius, innerRadius);
                
                if (direction.Length() <= radius)
                {
                    data[y * width + x] = color;
                }
            }
        }
        
        texture.SetData(data);
        return texture;
    }

    private float GetStarRadius(float angle, int points, float outerRadius, float innerRadius)
    {
        float pointAngle = MathHelper.TwoPi / points;
        float modAngle = angle % pointAngle;
        float halfPointAngle = pointAngle / 2f;
        
        if (modAngle > halfPointAngle)
        {
            modAngle = pointAngle - modAngle;
        }
        
        return outerRadius - (outerRadius - innerRadius) * (modAngle / halfPointAngle);
    }

    public Texture2D CreatePolygon(int width, int height, Color color, Vector2[] vertices)
    {
        var texture = new Texture2D(_graphicsDevice, width, height);
        Color[] data = new Color[width * height];
        
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (IsPointInPolygon(new Vector2(x, y), vertices))
                {
                    data[y * width + x] = color;
                }
            }
        }
        
        texture.SetData(data);
        return texture;
    }

    private bool IsPointInPolygon(Vector2 point, Vector2[] polygon)
    {
        bool inside = false;
        for (int i = 0, j = polygon.Length - 1; i < polygon.Length; j = i++)
        {
            if (((polygon[i].Y > point.Y) != (polygon[j].Y > point.Y)) &&
                (point.X < (polygon[j].X - polygon[i].X) * (point.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) + polygon[i].X))
            {
                inside = !inside;
            }
        }
        return inside;
    }
    }
}
