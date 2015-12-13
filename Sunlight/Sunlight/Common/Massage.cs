using System;
using System.Collections;

namespace Sunlight.Common
{
    class Massage
    {
        // バージョン情報
        private string var, name;
        private ArrayList Info;
        // ヘルプメッセージ
        private ArrayList Help;
        // エラーメッセージ
        private Hashtable Error;

        // コンストラクタ
        // - クラス内メソッドで使うArrayListとかハッシュテーブルの初期化と中身の定義
        public Massage()
        {
            // ArrayList初期化
            Info = new ArrayList();
            Help = new ArrayList();
            Error = new Hashtable();

            // 製品情報の取得と設定
            var = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            name = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name.ToString();
            Info.Add("=================================");
            Info.Add("= " + name + " - v" + var + "\t=");
            Info.Add("=\tCreate by InariSoft.\t=");
            Info.Add("=================================");
            Info.Add("ちょっと！いきなり起動させないでよ！\n");

            // ヘルプメッセージを設定
            // - コマンドライン追加書式 → Help.Add("<コマンドライン>:<説明文>");
            // ※適宜\tなどでメッセージ表示位置を調整すること。
            //
            Help.Add("<使い方>\n Sunlight.exe [スイッチ] <パラメータ1>/<パラメータ2>...\n");
            Help.Add("<スイッチ/パラメータ一覧>");
            Help.Add("s [1] [2]\tスタミナが[1]から[2]まで回復する時間を算出するよ！" +
                "\n\t\t\tex1)sst s 1 62 ― 1から62まで回復する時間を表示" +
                "\n\t\t※[1]が[2]より大きいければ値を入れ替え算出するね！" +
                "\n\t\t\tex2)sst s 50 0 ― 0から50まで回復する時間を表示");

            // エラーメッセージを設定
            // - メッセージ書式 → "Error.Add("<コード>","<コード>:エラー文")
            Error.Add("E1001", "E1001:スイッチの値が正しくないよー\n\t全角文字や英数字になっていないか確認してね！");
            Error.Add("E2001", "E2001:パラメータの数が正しくないよ！");
            Error.Add("E2002", "E2002:パラメータの型が正しくないよ！\n\t全角文字や英数字になっていないか確認してね！");
        }

        // showInfoメソッド
        // - インスタンス化時に取得したアプリケーション情報を表示
        public void showInfo()
        {
            foreach (var message in Info)
            {
                Console.WriteLine(message);
            }
        }

        // showHelpメソッド
        // - インスタンス化時に定義したヘルプメッセージを表示
        public void showHelp()
        {
            foreach (var message in Help)
            {
                Console.WriteLine(message);
            }
            Console.Write("\n");
        }

        // showErrorメソッド
        // - 引数をキーとしてハッシュテーブルからメッセージを検索、表示
        // - 見つからなければ不明エラーを表示(あってはならないけどね！)
        public void showError(string code)
        {
            string message = (string)Error[code];
            if (string.IsNullOrEmpty(message))
            {
                // 本来あってはならない。
                Console.WriteLine("E0000:定義されていないエラーコードを検出しちゃった・・・・");
            }
            else
            {
                Console.WriteLine("ふえぇ・・・エラーだよぉ >_<");
                Console.WriteLine(message);
            }

            Console.Write("\n");
        }
    }
}
