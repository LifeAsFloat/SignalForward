using System.Collections.Generic;
using System.Windows.Forms;

namespace SignalForward
{
    /// <summary>
    /// 界面中英文切换
    /// </summary>
    public static class LanguageHelper
    {
        /// <summary>
        /// 当前界面语言是否为英文（默认中文）
        /// </summary>
        public static bool IsEnglish { get; set; } = false;

        /// <summary>
        /// 按当前语言返回文本
        /// </summary>
        /// <param name="zh">中文</param>
        /// <param name="en">英文</param>
        /// <returns></returns>
        public static string T(string zh, string en) => IsEnglish ? en : zh;

        /// <summary>
        /// 请选择通讯模式提示
        /// </summary>
        public static string MsgSelectMode => T("请选择通讯模式！", "Please select a communication mode!");

        /// <summary>
        /// 密码错误提示
        /// </summary>
        public static string MsgWrongPassword => T("密码错误", "Incorrect password.");

        /// <summary>
        /// 主界面文本映射（控件名 -> 中文/英文）
        /// </summary>
        private static readonly Dictionary<string, (string Zh, string En)> UdpMap = new()
        {
            ["groupBox1"] = ("与PLC连接", "PLC Connection"),
            ["groupBox2"] = ("与AOI_1连接", "AOI_1 Connection"),
            ["groupBox3"] = ("与AOI_2连接", "AOI_2 Connection"),
            ["groupBox4"] = ("模式", "Mode"),
            ["RemoteBnt"] = ("连接", "Connect"),
            ["button1"] = ("连接", "Connect"),
            ["button2"] = ("连接", "Connect"),
            ["button3"] = ("关闭", "Close"),
            ["button4"] = ("关闭", "Close"),
            ["button5"] = ("关闭", "Close"),
            ["button6"] = ("修改", "Modify"),
            ["label9"] = ("本软件", "Local"),
            ["label10"] = ("本软件", "Local"),
            ["label16"] = ("本软件", "Local"),
            ["label1"] = ("IP：", "IP:"),
            ["label4"] = ("IP：", "IP:"),
            ["label6"] = ("IP：", "IP:"),
            ["label8"] = ("IP：", "IP:"),
            ["label12"] = ("IP：", "IP:"),
            ["label15"] = ("IP：", "IP:"),
            ["label2"] = ("Port：", "Port:"),
            ["label3"] = ("Port：", "Port:"),
            ["label5"] = ("Port：", "Port:"),
            ["label7"] = ("Port：", "Port:"),
            ["label11"] = ("Port：", "Port:"),
            ["label14"] = ("Port：", "Port:"),
            ["label18"] = ("触发回复间隔时间(毫秒)：", "Trigger reply interval (ms):"),
            ["label20"] = ("自动清除缓存(秒)：", "Auto-clear cache (s):"),
            ["label21"] = ("拍照最长等待(毫秒)：", "Max photo wait (ms):"),
            ["label22"] = ("停机信号下标：", "Stop signal index:"),
            ["label23"] = ("停机信号值：", "Stop signal value:"),
            ["label24"] = ("停机PLC下标：", "Stop PLC index:"),
            ["CB"] = ("出版", "CB"),
            ["CP"] = ("成品", "CP"),
            ["languageLabel"] = ("语言：", "Language:"),
        };

        /// <summary>
        /// 登录框文本映射（控件名 -> 中文/英文）
        /// </summary>
        private static readonly Dictionary<string, (string Zh, string En)> LoginMap = new()
        {
            ["LoginScreen"] = ("登录", "Login"),
            ["PA"] = ("密码：", "Password:"),
            ["UserName"] = ("登录", "Login"),
            ["button1"] = ("退出", "Exit"),
        };

        /// <summary>
        /// 应用主界面语言
        /// </summary>
        /// <param name="root"></param>
        public static void ApplyUdp(Control root) => Apply(root, UdpMap);

        /// <summary>
        /// 应用登录框语言
        /// </summary>
        /// <param name="root"></param>
        public static void ApplyLogin(Control root) => Apply(root, LoginMap);

        /// <summary>
        /// 按映射递归设置控件文本
        /// </summary>
        /// <param name="root"></param>
        /// <param name="map"></param>
        private static void Apply(Control root, Dictionary<string, (string Zh, string En)> map)
        {
            if (map.TryGetValue(root.Name, out var pair))
            {
                root.Text = IsEnglish ? pair.En : pair.Zh;
            }
            foreach (Control child in root.Controls)
            {
                Apply(child, map);
            }
        }
    }
}
