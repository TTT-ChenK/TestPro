using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTMicroscope
{
    /// <summary>
    /// 状态枚举
    /// </summary>
    public enum TTStatue
    {
        //默认状态
        Defaut,
        //正确
        OK,
        //错误
        Error,
        //警告
        Warn
    }

    /// <summary>
    /// 状态枚举
    /// </summary>
    public enum TTStatueImageStyle
    {
        //图片
        Image,
        //圆
        Cycle,
        //矩形
        Rectangle,
        //圆角矩形
        Rectangle2

    }

    /// <summary>
    /// 位置信息
    /// </summary>
    public enum TTPosition
    {
        Left,
        Top,
        Right,
        Bottom
    }

    /// <summary>
    /// 文本方向
    /// </summary>
    public enum TTTextDirect
    {
        Horizontal,
        Vertical

    }

    /// <summary>
    /// 文本方向
    /// </summary>
    public enum TSensorStatue
    {
        High,
        Low,
        Default
    }

    /// <summary>
    /// 运动卡类型
    /// </summary>
    public enum TMotionType
    {
        GaoChuang,
        ACS,
        AiMou,
        Other
    }


    /// <summary>
    /// 相机类型
    /// </summary>
    public enum TCameraType
    {
        HaiKang,
        Balser,
        Opt,
        Dalsa,
        Null
    }

    /// <summary>
    /// 相机类型
    /// </summary>
    public enum TObjectiveType
    {
        X1,
        X5,
        X10,
        X20,
        X40,
        X60,
        Null
    }

    /// <summary>
    /// 样品的形状
    /// </summary>
    public enum TWaferType
    {
        Rectangle,
        Cycle,
        Other,
    }

    /// <summary>
    /// XY定位方式
    /// </summary>
    public enum TXYLocationType
    {
        ForePoint,
        ForeEdge,
        CameraPic,
        Mark,
    }

    /// <summary>
    /// XY定位方式
    /// </summary>
    public enum TZFouceType
    {
        Center,
        ForeConner,
        NinePosition,
        FreePoint,
    }

    /// <summary>
    /// XY定位方式
    /// </summary>
    public enum TExposureType
    {
        /// <summary>
        /// 阵列
        /// </summary>
        Array,
        /// <summary>
        /// 图纸
        /// </summary>
        GDS,
        /// <summary>
        /// 套刻
        /// </summary>
        Alignment,
        /// <summary>
        /// 其他
        /// </summary>
        other,
    }

    /// <summary>
    /// XY定位方式
    /// </summary>
    public enum TAreaPositionType
    {
        One,
        Two,
        Four,
        XY,
    }

    /// <summary>
    /// XY定位方式
    /// </summary>
    public enum TExporsureQualityType
    {
        High,
        Low
    }
    /// <summary>
    /// XY定位方式
    /// </summary>
    public enum TResolution
    {
        S10um,
        S20um,
        S30um,
        S50um,
        S60um,
        S80um,
    }    /// <summary>
         /// XY定位方式
         /// </summary>
    public enum TExporsureMode
    {
        Normal,
        Overlap,
        Scroll
    }

    public enum EStepsStatue
    {
        Default,
        WaitRuning,
        Runinng,
        OK,
        NG
    }
}
