using System.Media;
using System;
namespace LittleTetris
{
    public class SoundMaster
    {
        public SoundPlayer player;

        public SoundMaster()
        {
            var a = Environment.CurrentDirectory;
            player = new SoundPlayer(@"C:\Users\Марсель\Desktop\Tetris\LittleTetris\Source\Sound\MainTheme.wav");
            player.Load();
            //player.PlayLooping();
        }

        public void MakePause()
        {
            player.Stop();
        }

        public void ContinuePlaying()
        {
            player.Play();
        }

        public void LineDestroyed()
        {

        }

        public void FigurePlaced()
        {

        }

        public void GameOver()
        {

        }
    }
}
