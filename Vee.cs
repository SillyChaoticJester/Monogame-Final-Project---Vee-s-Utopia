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
    public class Vee
    {
        private List<Texture2D> _textures;
        private Rectangle _location;
        private int _textureIndex;

        public Vee(List<Texture2D> textures, Rectangle location, int spriteSwitch)
        {
            _textures = textures;
            _location = location;
            _textureIndex = spriteSwitch;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_textures[_textureIndex], _location, Color.White);
        }

        public Rectangle Rect
        {
            get { return _location; }

        }
    }
}
