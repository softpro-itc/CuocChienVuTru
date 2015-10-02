using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using CuocChienVuTru.Object;

namespace CuocChienVuTru.Scene
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Level1Scene : GameScene
    {

        Player player;
        List<Enemy> listEnemy;

        Texture2D textureTmp;

        public Level1Scene(CuocChienVuTru game, Texture2D background)
            : base(game, background)
        {
            textureTmp = game.Content.Load<Texture2D>(@"Images\Player\player");
            player = new Player(game, textureTmp, new Rectangle(350, 450, textureTmp.Width, textureTmp.Height), new Vector2(350, 450), 3);
            components.Add(player);
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }
    }
}
