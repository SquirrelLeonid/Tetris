using System.Media;

namespace LittleTetris
{
    public class SoundMaster
    {
        public SoundPlayer player;

        public SoundMaster()
        {
            player = new SoundPlayer(@"C:\Users\Марсель\Desktop\Tetris\LittleTetris\Source\MainTheme.wav");
            player.Load();
            player.PlayLooping();
        }

        public void MakePause()
        {
        }

        public void ContinuePlaying()
        {
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
