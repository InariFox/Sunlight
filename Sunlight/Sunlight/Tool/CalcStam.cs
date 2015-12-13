using System;

namespace Sunlight.Tool
{
    class CalcStam
    {
        // スタミナ値保持
        private int nowstam;    // 現在のスタミナ値
        private int fullstam;   // フル回復時のスタミナ値

        // コンストラクタ setStamせずにgetHTされた時用に0で初期化しておく
        public CalcStam()
        {
            nowstam = 0;
            fullstam = 0;
        }

        // スタミナ値のセット
        public bool setStam(string ns, string fs)
        {
            // 整数値に変換できれば変換したスタミナ値をセットしてtrueを返す
            // 整数値に変換できなければfalseを返す
            if ((Int32.TryParse(ns, out nowstam) && (Int32.TryParse(fs, out fullstam))))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // 回復時間を計算して返す(分)
        public int getHT()
        {
            if (fullstam < nowstam)
                return (nowstam - fullstam) * 5;
            else
                return (fullstam - nowstam) * 5;
        }
    }
}
