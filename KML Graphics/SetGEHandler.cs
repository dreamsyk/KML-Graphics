using System;
using EARTHLib;


namespace Maye 
{
    class SetGEHandler
    {
        #region Member

        /// <summary>The Handler of GoogleEarth.
        /// The Handler of GoogleEarth.
        /// </summary>
        private IntPtr _GEHandler;

        /// <summary>The Handler of parentForm of GoogleEarth.
        /// The Handler of parentForm of GoogleEarth.
        /// </summary>
        private IntPtr _GEParentHandler;

        /// <summary>The Handler of parentMainForm of GoogleEarth.
        /// The Handler of parentMainForm of GoogleEarth.
        /// </summary>
        private IntPtr _GEMainHandler;

        /// <summary>The application of GoogleEarth.
        /// The application of GoogleEarth.
        /// </summary>
        private IApplicationGE _googleEarth;

        /// <summary>A Control of Windows.Forms.Control
        /// A Control of Windows.Forms.Control
        /// </summary>
        private System.Windows.Forms.Control _parentControl;

        #endregion






        #region Constructor

        #endregion





        #region Public Function
 
        /// <summary>Move the GoogleEarth's map control to the specified control
        /// Move the GoogleEarth's map control to the specified control
        /// </summary>
        /// <param name="parentControl">The specified control that GoogleEarth's map control will be moved to.</param>
        /// <param name="geApplication">The application which will be moved to the specified control. </param>
        public void SetGEHandlerToControl(System.Windows.Forms.Control parentControl, IApplicationGE geApplication)
        {
            this._parentControl = parentControl;
            this._googleEarth = geApplication;

            //Get the Handler of the application's MainForm to SetGEHandler._GEMainHandler.
            this._GEMainHandler = (IntPtr)this._googleEarth.GetMainHwnd();
            
            //Set the Hight of GoogleEarth's MainForm to 0, and hide the Height of GoogleEarth's MainForm.
            GetGEControl.SetWindowPos(this._GEMainHandler, GetGEControl.HWND_BOTTOM, 0, 0, 0, 0, GetGEControl.SWP_NOSIZE + GetGEControl.SWP_HIDEWINDOW);

            // Get the Handler of the application's map control.
            this._GEHandler = (IntPtr)_googleEarth.GetRenderHwnd();

            //Get the Handler of GoogleEarth's parentForm from GoogleEarth's map control.
            this._GEParentHandler = GetGEControl.GetParent(this._GEHandler);

            //将GE地图控件的父窗体设置为不可见
            //Hide the parentForm of GoogleEarth.
            GetGEControl.PostMessage((int)this._GEParentHandler, GetGEControl.WM_HIDE, 0, 0);

            //Set the Handler of GoogleEarth's parentForm to winform's control.
            GetGEControl.SetParent(this._GEHandler, parentControl.Handle);

            // 
            ResizeGEControl();
        }

        /// <summary>Set GooleEarth's control's size to parentMainControl's size
        /// Set GooleEarth's control's size to parentMainControl's size.
        /// </summary>
        public void ResizeGEControl()
        {
            //If the parentControl exist.
            if (this._parentControl != null)
            {
                //Set GooleEarth's control's size to parentMainControl's size.
                GetGEControl.MoveWindow(this._GEHandler, 0, 0, this._parentControl.Width, this._parentControl.Height, true);
            }
        }

        /// <summary>Terminate GoogleEarth
        /// Terminate GoogleEarth
        /// </summary>
        public void RealseGEHandler()
        {
            try
            {
                if (this._parentControl != null)
                {
                    //Restore GooleEarth's Handler to the original Form.
                    GetGEControl.SetParent(this._GEHandler, this._GEParentHandler);
                    
                    //Terminate GoogleEarth's main application.
                    GetGEControl.PostMessage(this._googleEarth.GetMainHwnd(), GetGEControl.WM_QUIT, 0, 0);
                }
            }
            finally
            {
                //Get current process and kill it.
                System.Diagnostics.Process geProcess = System.Diagnostics.Process.GetCurrentProcess();
                geProcess.Kill();
            }
        }

        #endregion





        #region Private Function

        #endregion

 

     


    
    }
}
