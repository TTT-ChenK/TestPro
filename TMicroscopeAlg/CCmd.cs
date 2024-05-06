using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMicroscopeAlg
{
    internal class CCmd
    {
    }

    public enum ECameraCmd
    {
        OpenCamera=101,
        CloseCamera,
        StartGrap, 
        StopGrap,
        SetExporseTime, 
        SetGrain,
        SetModel,
        SetImageWH
    }

    public enum EAlgCmd
    {
        InitAlg = 201,
        TransImage,
        AlgDetect,
    }
}
