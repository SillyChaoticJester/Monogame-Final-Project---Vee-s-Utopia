using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_Final_Project___Vees_Utopia
{
    public class Rodger
    {
        private List<Texture2D> _textures;
        private Rectangle _location;
        private int _textureIndex;

        public Rodger(List<Texture2D> textures, Rectangle location)
        {
            _textures = textures;
            _location = location;
            _textureIndex = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_textures[0], _location, Color.White);
        }

        public Rectangle Rect
        {
            get { return _location; }

        }
    }

    
}
