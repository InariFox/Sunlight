using System;

namespace Sunlight.Common
{
    class Timer
    {
        private int time;
        private DateTime dt;

        // 加算時間をセット(分)
        public void setTime(int time)
        {
            this.time = time;
        }

        // 時間計算
        public void calcTime()
        {
            dt = DateTime.Now;
            TimeSpan addtime = TimeSpan.FromMinutes(time);
            dt += addtime;
        }

        // 計算結果を返す
        public DateTime getTime()
        {
            return dt;
        }
    }
}
