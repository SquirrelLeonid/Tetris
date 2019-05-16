using System.Media;
namespace LittleTetris
{
    public class SoundMaster
    {
        public SoundPlayer player;

        public SoundMaster()
        {
            player = new SoundPlayer(@"C:\Users\Марсель\Desktop\Tetris\LittleTetris\Source\Sound\MainTheme.wav");
            player.Load();
            player.PlayLooping();
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
