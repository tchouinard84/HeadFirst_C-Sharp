namespace BaseBall
{
    public class Bat
    {
        private BatCallback hitBallCallback;

        public Bat(BatCallback callbackDelegate)
        {
            this.hitBallCallback = callbackDelegate;
        }

        public void HitTheBall(BallEventArgs e)
        {
            if (hitBallCallback == null) { return; }
            hitBallCallback(e);
        }
    }
}
