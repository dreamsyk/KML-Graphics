using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using EARTHLib;
using HookAPI;

namespace Maye
{
    public partial class KMLGraphicsControl : Component
    {

        #region Perproties

        /// <summary>The Panel to the GE will load to
        /// The Panel to the GE will load to
        /// </summary>
        private Panel pnlGoogleEarth;

        /// <summary>The Dialog to open a kml file
        /// The Dialog to open a kml file
        /// </summary>
        private OpenFileDialog ofdOpenKML;

        /// <summary>GoogleEarth's application
        /// GoogleEarth's application.
        /// </summary>
        private ApplicationGEClass _geApp;

        /// <summary>A new Handler of GE Application
        /// A new Handler of GE Application
        /// </summary>
        private IntPtr _gEHandler = (IntPtr)5;

        /// <summary>Get the Handler of the view of GE Application
        /// Get the Handler of the view of GE Application
        /// </summary>
        private IntPtr GEHandler
        {
            get { return _gEHandler; }
        }

        /// <summary>A new Handler of GE Control
        /// A new Handler of GE Control
        /// </summary>
        private SetGEHandler myGEHandler;

        /// <summary>鼠标钩子
        /// 鼠标钩子
        /// </summary>
        private MouseHook mouseHook;

        /// <summary>The number of the mouseWheel to get bigger
        /// The number of the mouseWheel to get bigger
        /// </summary>
        private const int ZoomIn = 78000;

        /// <summary>The number of the mouseWheel to get smaller
        /// The number of the mouseWheel to get smaller
        /// </summary>
        private const int ZoomOut = -78000;

        #endregion




        #region Constructor

        /// <summary>The Constructor to set the param_pnl to Perproties_pnlGoogleEarth
        /// The Constructor to set the param_pnl to Perproties_pnlGoogleEarth
        /// </summary>
        /// <param name="pnl"></param>
        public KMLGraphicsControl(Panel pnl)
        {
            this.pnlGoogleEarth = pnl;
 
        }

        #endregion


        #region Public Function

        /// <summary>The mouseHook of MouseWheel
        /// The mouseHook of MouseWheel
        /// </summary>
        /// <param name="e">The event of mouse</param>
        private void mouseHook_MouseWheel(object sender, MouseEventArgs e)
        {
            IntPtr hWnd = GetGEControl.WindowFromPoint(e.Location);
            if (hWnd == this.GEHandler)
            {
                Point point = this.pnlGoogleEarth.PointToClient(e.Location);
                // 如果鼠标击点位置在控件内部，则说明鼠标点击了GoogleEarth视图 
                if (this.pnlGoogleEarth.ClientRectangle.Contains(point))
                {
                    NativeMethods.PostMessage(this.GEHandler.ToInt32(), (int)WM_MOUSE.WM_MOUSEWHEEL, e.Delta == 120 ? ZoomIn : ZoomOut, 0);
                }
            }
        }

        /// <summary>Set and start mouseHook
        /// Set and start mouseHook
        /// </summary>
        private void StartMouseHook()
        {
            //Set the mouseHook
            mouseHook = new MouseHook();
            mouseHook.MouseWheel += new MouseEventHandler(mouseHook_MouseWheel);
            //Start the mouseHook
            mouseHook.StartHook(HookType.WH_MOUSE_LL, 0);
        }

        #endregion



        #region Public Function

        /// <summary>Load GoogleEarth to a new Panel
        /// Load GoogleEarth to a new Panel
        /// </summary>
        public void LoadGoogleEarth()
        {
            //将GoogleEarth加载到窗口上
            myGEHandler = new SetGEHandler();
            _geApp = new ApplicationGEClass();
            myGEHandler.SetGEHandlerToControl(this.pnlGoogleEarth, _geApp);
            _gEHandler = (IntPtr)_geApp.GetRenderHwnd();

            this.StartMouseHook();
        }

        /// <summary>Open KML File by show a Dialog to open a file
        /// Open KML File by show a Dialog to open a file
        /// </summary>
        public void OpenKMLFile()
        {
            ofdOpenKML = new OpenFileDialog();
            ofdOpenKML.Filter = "*.kml文件|*.kml";
            ofdOpenKML.FileName = "";
            if (ofdOpenKML.ShowDialog() == DialogResult.OK)
            {
                String kmlFile = ofdOpenKML.FileName.ToString();
                _geApp.OpenKmlFile(kmlFile, 1);
            }
        }

        /// <summary>Open KML File by a filename
        /// Open KML File by a filename
        /// </summary>
        /// <param name="filename"></param>
        public void OpenKMLFile(string filename)
        {
            _geApp.OpenKmlFile(filename, 1);
        }

        /// <summary>Reset the size of GEControl
        /// Reset the size of GEControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ReSizeGEControl()
        {
            myGEHandler.ResizeGEControl();
        }

        /// <summary>Close the control of GE and the Application of GE
        /// Close the control of GE and the Application of GE
        /// </summary>
        public void CloseGEControl()
        {
            myGEHandler.RealseGEHandler();
        }

        #endregion
    }
}
