using System;

namespace Unvurn.Unity
{
    /// <summary>
    ///   Unix時間に基づく時間情報の取得を行うメソッドを集めた静的クラス。
    /// </summary>
    /// <remarks>
    ///   本来ならばUnix時間は「秒」なので、ミリ秒(=ms)として扱っている当クラス・メソッドは注意が必要。
    /// </remarks>
    public class MillisecondUnixTime
    {
        /// <summary>
        ///   アプリケーション起動からの経過時間(ms)。
        /// </summary>
        public static long FromApplicationLaunched => Current - ApplicationLaunchedAt;

        /// <summary>
        ///   現在時刻のUnix時間(ms)。
        /// </summary>
        public static long Current => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        /// <summary>
        ///   アプリケーション起動時刻のUnix時間(ms)。
        /// </summary>
        private static readonly long ApplicationLaunchedAt;

        /// <summary>
        ///   静的コンストラクター。
        /// </summary>
        /// <remarks>
        ///   アプリケーション起動時刻を自動で初期化する。
        ///   利用者がこのコンストラクターの呼び出しを考慮する必要はない。
        /// </remarks>
        static MillisecondUnixTime()
        {
            ApplicationLaunchedAt = Current;
        }
    }
}
