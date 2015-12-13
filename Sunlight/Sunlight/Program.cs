//
// Sunlight @ MainProgram
// メインになるところ。どっちかと言えばフロントエンド的な。
//
using Sunlight.Common;
using Sunlight.Tool;
using System;

namespace Sunlight
{
    class Program
    {
        static void Main(string[] args)
        {
            // メッセージテキスト読み込み
            Massage mes = new Massage();
            // ツール読み込み
            CalcStam cs = new CalcStam();
            Timer tm = new Timer();
            // 処理結果フラグ保管用
            bool fgresult;

            // 起動ロゴ的なものを表示
            mes.showInfo();

            // 条件判定
            // - パラメータが1 or 2の場合はエラーとヘルプを表示して終了
            // - パラメータが0の場合はヘルプを表示して終了
            if (args.Length <= 2)
            {
                if (args.Length > 0)
                    mes.showError("E2001");
                mes.showHelp();
                return;
            }

            // 条件判定 パラメータによって処理する内容を振り分け。
            // - sならスタミナ計算モード
            if (args[0].Equals("s"))
            {
                Console.WriteLine("--- スタミナ計算機モード♪ ------------");

                // スタミナ値をセット
                Console.WriteLine(" > スタミナ値をセット！");
                Console.WriteLine("  arg[1]:" + args[1] + "\n  arg[2]:" + args[2]);
                fgresult = cs.setStam(args[1], args[2]);

                Console.Write("\n");

                // スタミナ値が整数に出来なければエラー返して終了
                if (!fgresult)
                {
                    mes.showError("E2002");
                    return;
                }

                // スタミナ回復時間を計算
                Console.WriteLine(" > 回復時間を計算中だよ！");
                tm.setTime(cs.getHT());
                tm.calcTime();

                // スタミナ回復時間計算結果を出力
                Console.WriteLine(" > 計算完了！\n");
                Console.WriteLine("スタミナ回復 [" + args[1] + "→" + args[2] + "]");
                Console.WriteLine("現在時刻は" + DateTime.Now + "だよ！");
                Console.WriteLine("スタミナ最大予定時刻は大体 " + tm.getTime() + " 前後だよ！");
                Console.WriteLine("回復まで " + cs.getHT() + " 分かかるみたい！");
            }
        }
    }
}
