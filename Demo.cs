using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _02_Animace
{
    public class Demo : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _textura, HL, HR;
        private int x, y, w, h;
        private int HLx, HLy, HLw, HLh;
        private int HRx, HRy, HRw, HRh;

        private bool XsmerR, YsmerD;

        public Demo()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.Title = "Animace textury";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 600;
            _graphics.PreferredBackBufferHeight = 400;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            w = h = 10;
            x = 0;
            y = 0;
            XsmerR = true;
            YsmerD = true;
            _textura = new Texture2D(GraphicsDevice, 1, 1);
            _textura.SetData<Color>(new Color[] { Color.Black });

            HLw = 10; HLh = 50;
            HLx = 0;
            HLy = _graphics.PreferredBackBufferHeight / 2;
            HL = new Texture2D(GraphicsDevice, 1, 1);
            HL.SetData<Color>(new Color[] { Color.Green });

            HRw = 10; HRh = 50; // Hrac_Pravy sirka 10 bodu vyska 50 bodu
            HRx = _graphics.PreferredBackBufferWidth - HRw;
            HRy = _graphics.PreferredBackBufferHeight / 2;
            HR = new Texture2D(GraphicsDevice, 1, 1);
            HR.SetData<Color>(new Color[] { Color.Red });

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (x < (_graphics.PreferredBackBufferWidth - w) && XsmerR) x = x + 1;
            if (x > 0 && !XsmerR) x = x - 1;

            if (x >= (_graphics.PreferredBackBufferWidth - w)) XsmerR = false;
            if (x <= 0 && !XsmerR) XsmerR = true;

            KeyboardState newState = Keyboard.GetState();
            if (newState.IsKeyDown(Keys.S) && HLy < (_graphics.PreferredBackBufferHeight - HLh)) HLy += 1;
            if (newState.IsKeyDown(Keys.W) && HLy > 0) HLy -= 1;
            if (newState.IsKeyDown(Keys.Down) && HRy < (_graphics.PreferredBackBufferHeight - HRh)) HRy += 1;
            if (newState.IsKeyDown(Keys.Up) && HRy > 0) HRy -= 1;


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_textura, new Rectangle(x, y, w, h), Color.White);
            _spriteBatch.Draw(HL, new Rectangle(HLx, HLy, HLw, HLh), Color.White);
            _spriteBatch.Draw(HR, new Rectangle(HRx, HRy, HRw, HRh), Color.White);
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
