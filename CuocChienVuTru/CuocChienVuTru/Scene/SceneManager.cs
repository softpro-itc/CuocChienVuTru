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


namespace CuocChienVuTru.Scene
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class SceneManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public GameScene active;
        public List<GameScene> listScene;
        public StartScene start;
        public PauseScene pause;
        public HelpScene help;
        public Level1Scene level1Scene;

        public SceneManager(CuocChienVuTru game)
            : base(game)
        {
            start = new StartScene(game, game.Content.Load<Texture2D>(@"Images\Background\Menu"));
            help = new HelpScene(game, game.Content.Load<Texture2D>(@"Images\Background\Help"));
            level1Scene = new Level1Scene(game, game.Content.Load<Texture2D>(@"Images\Background\1"));
            pause = new PauseScene(game, game.Content.Load<Texture2D>(@"Images\Background\Pause"));
            active = start;
            listScene = new List<GameScene>();
            listScene.Add(start);
            listScene.Add(pause);
            listScene.Add(help);
            listScene.Add(level1Scene);
        }


        public override void Initialize()
        {
            foreach (GameScene scene in listScene)
                scene.Initialize();
            base.Initialize();
        }

        public void ShowScene(GameScene scene)
        {
            active.Hide();
            active = scene;
            active.Initialize();
            active.Show();
        }

        public override void Update(GameTime gameTime)
        {
            active.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            active.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
