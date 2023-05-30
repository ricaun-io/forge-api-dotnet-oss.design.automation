namespace Autodesk.Forge.Oss.DesignAutomation.Services
{
    /// <summary>
    /// DefineDesignAutomation
    /// </summary>
    public static class DefineDesignAutomation
    {
        /// <summary>
        /// Revit
        /// </summary>
        public static class Revit
        {
            /// <summary>
            /// revitcoreconsole.exe
            /// </summary>
            public static string Core { get; } = "revitcoreconsole.exe";
            /// <summary>
            /// Autodesk.Revit
            /// </summary>
            public static string Engine { get; } = "Autodesk.Revit";
        }

        /// <summary>
        /// Max
        /// </summary>
        public static class Max
        {
            /// <summary>
            /// 3dsmaxbatch.exe
            /// </summary>
            public static string Core { get; } = "3dsmaxbatch.exe";
            /// <summary>
            /// Autodesk.3dsMax
            /// </summary>
            public static string Engine { get; } = "Autodesk.3dsMax";
        }

        /// <summary>
        /// AutoCAD
        /// </summary>
        public static class AutoCAD
        {
            /// <summary>
            /// accoreconsole.exe
            /// </summary>
            public static string Core { get; } = "accoreconsole.exe";
            /// <summary>
            /// Autodesk.AutoCAD
            /// </summary>
            public static string Engine { get; } = "Autodesk.AutoCAD";
        }

        /// <summary>
        /// Inventor
        /// </summary>
        public static class Inventor
        {
            /// <summary>
            /// InventorCoreConsole.exe
            /// </summary>
            public static string Core { get; } = "InventorCoreConsole.exe";
            /// <summary>
            /// Autodesk.Inventor
            /// </summary>
            public static string Engine { get; } = "Autodesk.Inventor";
        }
    }
}