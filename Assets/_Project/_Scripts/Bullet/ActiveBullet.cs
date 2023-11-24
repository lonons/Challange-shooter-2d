using System;

namespace _Project._Scripts.Bullet
{
    public class ActiveBullet
    {
        public Projectile Bullet { get; private set; }
        public float TimerActive { get; private set; }
        public float LiveTimeBullet { get; private set; }
        public Action<ActiveBullet> TimeLeft;

        public ActiveBullet(Projectile projectile, float liveTimeBullet)
        {
            Bullet = projectile;
            LiveTimeBullet = liveTimeBullet;
            TimerActive = 0f;
        }

        public void TimerTick(float time)
        {
            TimerActive += time;
            if (TimerActive>= LiveTimeBullet) TimeLeft?.Invoke(this);
        }
    }
}