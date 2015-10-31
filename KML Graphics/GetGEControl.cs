using System;
using System.Drawing;
using System.Runtime.InteropServices;
 
 
namespace Maye
{
    /// <summary>Get the widget of GoogleEarth
    /// Get the widget of GoogleEarth
    /// </summary>
    class GetGEControl
    {
        #region Perproties

        /// <summary>GetGEWidget.SetWindowPos(): A handle to the window to precede the positioned window in the Z order.
        /// GetGEWidget.SetWindowPos(): A handle to the window to precede the positioned window in the Z order.
        /// </summary>
        public static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

        /// <summary>GetGEWidget.SetWindowPos(): A handle to the window to precede the positioned window in the Z order.
        /// GetGEWidget.SetWindowPos(): A handle to the window to precede the positioned window in the Z order.
        /// </summary>        
        public static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);

        /// <summary>GetGEWidget.SetWindowPos(): A handle to the window to precede the positioned window in the Z order.
        /// GetGEWidget.SetWindowPos(): A handle to the window to precede the positioned window in the Z order.
        /// </summary>
        public static readonly IntPtr HWND_TOP = new IntPtr(0);

        /// <summary>GetGEWidget.SetWindowPos(): A handle to the window to precede the positioned window in the Z order.
        /// GetGEWidget.SetWindowPos(): A handle to the window to precede the positioned window in the Z order.
        /// </summary>
        public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

        /// <summary>GetGEWidget.SetWindowPos():The window sizing and positioning flags.
        /// GetGEWidget.SetWindowPos():The window sizing and positioning flags.
        /// </summary>
        public static readonly UInt32 SWP_NOSIZE = 1;

        /// <summary>GetGEWidget.SetWindowPos():The window sizing and positioning flags.
        /// GetGEWidget.SetWindowPos():The window sizing and positioning flags.
        /// </summary>
        public static readonly UInt32 SWP_HIDEWINDOW = 128;

        /// <summary>GetGEWidget.PostMessage(): The message to be posted.Indicates a request to terminate an application.
        /// GetGEWidget.PostMessage(): The message to be posted.Indicates a request to terminate an application.
        /// </summary>
        public static readonly Int32 WM_QUIT = 0x0012;

        /// <summary>GetGEWidget.PostMessage(): The message to be posted.Indicates a request to hide an application.
        /// GetGEWidget.PostMessage(): The message to be posted.Indicates a request to hide an application.
        /// </summary>
        public static readonly Int32 WM_HIDE = 0x0;

        public static readonly int WM_COMMAND = 0x0112;
        public static readonly int WM_PAINT = 0x000F;
        public static readonly int WM_QT_PAINT = 0xC2DC;
        public static readonly UInt32 SWP_FRAMECHANGED = 32;
        public static readonly int WM_SIZE = 0x0005;

        #endregion




        #region Constructor

        #endregion
        




        #region Public Function

        /// <summary>Changes the size, position, and Z order of a child, pop-up, or top-level window.
        /// Changes the size, position, and Z order of a child, pop-up, or top-level window.
        /// </summary>
        /// <param name="hWnd">A handle to the window</param>
        /// <param name="hWndInsertAfter">A handle to the window to precede the positioned window in the Z order.</param>
        /// <param name="X">The new position of the left side of the window, in client coordinates.</param>
        /// <param name="Y">The new position of the top of the window, in client coordinates.</param>
        /// <param name="cx">The new width of the window, in pixels.</param>
        /// <param name="cy">The new height of the window, in pixels.</param>
        /// <param name="uFlags">The window sizing and positioning flags.</param>
        /// <returns>If the function succeeds, the return value is nonzero.If the function fails, the return value is zero. </returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        /// <summary>Find the Handler of Window
        /// Find the Handler of Window
        /// </summary>
        /// <param name="className">The classname of Window</param>
        /// <param name="windowTitle">The title of Window</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string className, string windowTitle);

        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(int hWnd, int nCmdShow);

        /// <summary>Get the Handler of DeskTop
        /// Get the Handler of DeskTop
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();

        /// <summary>Get the Window HDC by Handler
        /// Get the Window HDC by Handler
        /// </summary>
        /// <param name="hwnd">the handler to get the window HDC</param>
        /// <returns></returns>
        [DllImport("user32")]
        public static extern IntPtr GetWindowDC(IntPtr hwnd);

        /// <summary>Get DC by Handler
        /// Get DC by Handler
        /// </summary>
        /// <param name="hwnd">The Handler to get DC</param>
        /// <returns></returns>
        [DllImport("user32")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        /// <summary>Release HDC
        /// Release HDC
        /// </summary>
        /// <param name="handle">The Handler of HDC</param>
        /// <param name="hdc">HDC</param>
        /// <returns></returns>
        [DllImport("user32")]
        public static extern long ReleaseDC(IntPtr handle, IntPtr hdc);

        /// <summary>Post a message in the message queue associated with the thread that created the specified window and returns without waiting for the thread to process the message.
        /// Post a message in the message queue associated with the thread that created the specified window and returns without waiting for the thread to process the message.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose window procedure is to receive the message</param>
        /// <param name="msg">The message to be posted.</param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">Additional message-specific information.</param>
        /// <returns>If the function succeeds, the return value is nonzero.If the function fails, the return value is zero.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(int hWnd, int msg, int wParam, int lParam);

        /// <summary>Post Message
        /// Post Message
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        internal static void PostMessage(IntPtr hWnd, int msg, int wParam, int lParam)
        {
            throw new NotImplementedException();
        }

        /// <summary>Get a handle to the specified window's parent or owner.
        /// Get a handle to the specified window's parent or owner.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose parent window handle is to be retrieved.</param>
        /// <returns>If the function succeeds, the return value is a handle to the parent window. If the function fails, the value is NULL </returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        public extern static IntPtr GetParent(IntPtr hWnd);

        /// <summary>Changes the position and dimensions of the specified window.
        /// Changes the position and dimensions of the specified window. 
        /// </summary>
        /// <param name="hWnd">A handle to the window.</param>
        /// <param name="X">The new position of the left side of the window.</param>
        /// <param name="Y">The new position of the top of the window.</param>
        /// <param name="nWidth">The new width of the window.</param>
        /// <param name="nHeight">The new height of the window.</param>
        /// <param name="bRepaint">Indicates whether the window is to be repainted. </param>
        /// <returns>If the function succeeds, the return value is nonzero.If the function fails, the return value is zero.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        public extern static bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        /// <summary>Changes the parent window of the specified child window.
        /// Changes the parent window of the specified child window.
        /// </summary>
        /// <param name="hWndChild">A handle to the child window.</param>
        /// <param name="hWndNewParent">A handle to the new parent window.</param>
        /// <returns>If the function succeeds, the return value is a handle to the previous parent window. If the function fails, the return value is NULL.</returns>
        [DllImport("user32", CharSet = CharSet.Auto)]
        public extern static IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        /// <summary>Retrieves a handle to the window that contains the specified point.
        /// Retrieves a handle to the window that contains the specified point.
        /// </summary>
        /// <param name="point">The point to be checked.</param>
        /// <returns>The return value is a handle to the window that contains the point. If no window exists at the given point, the return value is NULL. If the point is over a static text control, the return value is a handle to the window under the static text control.</returns>
        [DllImport("user32")]
        public static extern IntPtr WindowFromPoint(Point point);

        #endregion





        #region Private Function
        #endregion


       
    }
}
